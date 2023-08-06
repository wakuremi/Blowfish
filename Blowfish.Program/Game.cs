using log4net;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Immutable;

namespace Blowfish.Program;

/// <summary>
///   Игра.
/// </summary>
public sealed class Game : IUserInput, IDisposable
{
    private readonly Scene _scene;
    private readonly ILog _log;

    private ImmutableHashSet<Keyboard.Key> _keys;
    private ImmutableHashSet<Mouse.Button> _buttons;
    private Vector2f _pointer;

    private readonly RenderWindow _window;

    /// <summary>
    ///   Создает новый экземпляр.
    /// </summary>
    /// 
    /// <param name="scene">Сцена.</param>
    /// <param name="logProvider">Провайдер журналов.</param>
    /// 
    /// <exception cref="ArgumentNullException">
    ///   1. Указанная сцена <paramref name="scene" /> равна <see langword="null" />.
    ///   2. Указанный провайдер журналов <paramref name="logProvider" /> равен <see langword="null" />.
    /// </exception>
    public Game(
        Scene scene,
        LogProvider logProvider
        )
    {
        #region Проверка аргументов ...

        if (scene == null)
        {
            throw new ArgumentNullException(nameof(scene), "Указанная сцена равна 'null'.");
        }

        if (logProvider == null)
        {
            throw new ArgumentNullException(nameof(logProvider), "Указанный провайдер журналов равен 'null'.");
        }

        #endregion Проверка аргументов ...

        _scene = scene;
        _log = logProvider.Get();

        _keys = ImmutableHashSet<Keyboard.Key>.Empty;
        _buttons = ImmutableHashSet<Mouse.Button>.Empty;

        var mode = new VideoMode(640, 480);

        _window = new RenderWindow(mode, "Blowfish");

        _window.Closed += HandleClosed;
        _window.KeyPressed += HandleKeyPressed;
        _window.KeyReleased += HandleKeyReleased;
        _window.MouseButtonPressed += HandleButtonPressed;
        _window.MouseButtonReleased += HandleMouseButtonReleased;
        _window.MouseMoved += HandlePointerMoved;
    }

    #region Обработка событий ...

    /// <summary>
    ///   Обрабатывает нажатие на кнопку закрыть.
    /// </summary>
    ///
    /// <param name="sender">Отправитель.</param>
    /// <param name="args">Аргументы события.</param>
    private void HandleClosed(object? sender, EventArgs args)
    {
        if (sender is Window window)
        {
            window.Close();
        }
    }

    /// <summary>
    ///   Обрабатывает нажатие клавиши.
    /// </summary>
    ///
    /// <param name="sender">Отправитель.</param>
    /// <param name="args">Аргументы события.</param>
    private void HandleKeyPressed(object? sender, KeyEventArgs args)
    {
        if (args != null)
        {
            _keys = _keys.Add(args.Code);
        }
    }

    /// <summary>
    ///   Обрабатывает отпускание клавиши.
    /// </summary>
    ///
    /// <param name="sender">Отправитель.</param>
    /// <param name="args">Аргументы события.</param>
    private void HandleKeyReleased(object? sender, KeyEventArgs args)
    {
        if (args != null)
        {
            _keys = _keys.Remove(args.Code);
        }
    }

    /// <summary>
    ///   Обрабатывает нажатие кнопки.
    /// </summary>
    ///
    /// <param name="sender">Отправитель.</param>
    /// <param name="args">Аргументы события.</param>
    private void HandleButtonPressed(object? sender, MouseButtonEventArgs args)
    {
        if (args != null)
        {
            _buttons = _buttons.Add(args.Button);
        }
    }

    /// <summary>
    ///   Обрабатывает отпускание кнопки.
    /// </summary>
    ///
    /// <param name="sender">Отправитель.</param>
    /// <param name="args">Аргументы события.</param>
    private void HandleMouseButtonReleased(object? sender, MouseButtonEventArgs args)
    {
        if (args != null)
        {
            _buttons = _buttons.Remove(args.Button);
        }
    }

    /// <summary>
    ///   Обрабатывает перемещение указателя.
    /// </summary>
    ///
    /// <param name="sender">Отправитель.</param>
    /// <param name="args">Аргументы события.</param>
    private void HandlePointerMoved(object? sender, MouseMoveEventArgs args)
    {
        if (sender is RenderWindow window
            && args != null)
        {
            var pixel = new Vector2i(args.X, args.Y);

            _pointer = window.MapPixelToCoords(pixel);
        }
    }

    #endregion Обработка событий ...

    /// <summary>
    ///   Запускает игровой цикл.
    /// </summary>
    public void Run()
    {
        // 20.0 - среднее количество обновлений в секунду.
        const float Micros = 1_000_000.0F / 20.0F;

        var clock = new Clock();
        var lag = 0.0F;

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
        _scene.Update(this);
    }

    private void Render(float delta)
    {
        _window.Clear(Color.White);

        _scene.Render(_window, delta);

        _window.Display();
    }

    /// <inheritdoc />
    public bool IsKeyPressed(Keyboard.Key key)
    {
        return _keys.Contains(key);
    }

    /// <inheritdoc />
    public bool IsButtonPressed(Mouse.Button button)
    {
        return _buttons.Contains(button);
    }

    /// <inheritdoc />
    public Vector2f GetPointer()
    {
        return _pointer;
    }

    /// <inheritdoc />
    public void Dispose()
    {
        _window.Closed -= HandleClosed;
        _window.KeyPressed -= HandleKeyPressed;
        _window.KeyReleased -= HandleKeyReleased;
        _window.MouseButtonPressed -= HandleButtonPressed;
        _window.MouseButtonReleased -= HandleMouseButtonReleased;
        _window.MouseMoved -= HandlePointerMoved;

        _window.Close();
        _window.Dispose();

        _log.Info("Окно было уничтожено!");
    }
}
