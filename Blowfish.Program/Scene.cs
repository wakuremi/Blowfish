using log4net;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;

namespace Blowfish.Program;

public sealed class Scene : IDisposable
{
    private readonly ILog _log;

    private readonly TileSet? _tileSet;

    private Vector2f _pos0;
    private Vector2f _pos;

    public Scene(
        LogProvider logProvider
        )
    {
        #region Проверка аргументов ...

        if (logProvider == null)
        {
            throw new ArgumentNullException(nameof(logProvider));
        }

        #endregion Проверка аргументов ...

        _log = logProvider.Get();

        try
        {
            _tileSet = new TileSet(16, 16, "Resources/Sprites.png");
        }
        catch (Exception exception)
        {
            _log.Error("Ошибка создания набора тайлов.", exception);
        }
    }

    public void Update(IUserInput input)
    {
        #region Проверка аргументов ...

        if (input == null)
        {
            throw new ArgumentNullException(nameof(input), "Указанный пользовательский ввод равен 'null'.");
        }

        #endregion Проверка аргументов ...

        _pos0 = _pos;

        if (input.IsButtonPressed(Mouse.Button.Left))
        {
            _pos = input.GetPointer();
        }
    }

    public void Render(RenderTarget target, float delta)
    {
        #region Проверка аргументов ...

        if (target == null)
        {
            throw new ArgumentNullException(nameof(target), "Указанное место отрисовки равно 'null'.");
        }

        #endregion Проверка аргументов ...

        var ix = _pos0.X + (_pos.X - _pos0.X) * delta;
        var iy = _pos0.Y + (_pos.Y - _pos0.Y) * delta;

        if (_tileSet != null)
        {
            _tileSet.Draw(target, 5, ix, iy, 100.0F, 100.0F);
        }
    }

    public void Dispose()
    {
        if (_tileSet != null)
        {
            _tileSet.Dispose();
        }
    }
}
