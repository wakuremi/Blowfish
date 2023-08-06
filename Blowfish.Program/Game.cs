using log4net;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;

namespace Blowfish.Program;

/// <summary>
///   Игра.
/// </summary>
public sealed class Game : IDisposable
{
    private readonly ILog _log = LogManager.GetLogger(typeof(Game));

    private readonly RenderWindow _window;

    private readonly Texture _texture;

    /// <summary>
    ///   Создает новый экземпляр.
    /// </summary>
    /// 
    /// <param name="width">Ширина окна.</param>
    /// <param name="height">Высота окна.</param>
    /// <param name="title">Заголовок окна.</param>
    ///
    /// <exception cref="ArgumentNullException">
    ///   Указанный заголовок окна <paramref name="title" /> равен <see langword="null" />.
    /// </exception>
    public Game(uint width, uint height, string title)
    {
        #region Проверка аргументов ...

        if (title == null)
        {
            throw new ArgumentNullException(nameof(title), "Указанный заголовок окна равен 'null'.");
        }

        #endregion Проверка аргументов ...

        var mode = new VideoMode(width, height);

        _window = new RenderWindow(mode, title);
        //_window.SetVerticalSyncEnabled(true);
        _window.Closed += WindowClosed;

        _texture = new Texture("Resources/Sprites.png");
    }

    private void WindowClosed(object? sender, EventArgs args)
    {
        if (sender is Window window)
        {
            window.Close();
        }
    }

    /// <summary>
    ///   Запускает игровой цикл.
    /// </summary>
    public void Run()
    {
        // 20.0 - среднее количество обновлений в секунду.
        const double Micros = 1_000_000.0 / 20.0;

        var clock = new Clock();
        var lag = 0.0;

        var updates = 0;
        var renders = 0;

        var timer = new Clock();

        while (_window.IsOpen)
        {
            _window.DispatchEvents();

            lag += clock.Restart().AsMicroseconds();

            while (lag >= Micros)
            {
                Update();
                updates++;

                lag -= Micros;
            }

            var delta = lag / Micros;

            Render(delta);
            renders++;

            var time = timer.ElapsedTime;
            if (time > Time.FromSeconds(1))
            {
                _ = timer.Restart();

                _log.Debug($"{updates}, {renders}");

                updates = 0;
                renders = 0;
            }
        }

        _log.Info("Игровой цикл завершен.");
    }

    private void Update()
    {

    }

    private void Render(double delta)
    {
        _window.Clear(Color.White);

        var sprite = new Sprite(_texture, new IntRect(0, 0, 16, 16));
        sprite.Position = new Vector2f(100.0F, 100.0F);
        sprite.Scale = new Vector2f(2.0F, 2.0F);

        _window.Draw(sprite);

        _window.Display();
    }

    /// <summary>
    ///   Закрывает и уничтожает окно.
    /// </summary>
    public void Dispose()
    {
        _window.Closed -= WindowClosed;

        _window.Close();
        _window.Dispose();

        _log.Info("Окно было уничтожено!");
    }
}
