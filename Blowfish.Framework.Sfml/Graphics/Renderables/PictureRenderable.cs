using Blowfish.Common;
using Blowfish.Framework.Graphics.Renderables;
using SFML.Graphics;
using SFML.System;
using System;
using System.IO;
using System.Threading;

namespace Blowfish.Framework.Sfml.Graphics.Renderables;

/// <inheritdoc cref="IPictureRenderable" />
public sealed class PictureRenderable : IPictureRenderable, Drawable
{
    private readonly Texture _texture;
    private readonly Sprite _sprite;

    private long _isDisposed;

    /// <inheritdoc />
    public int Width
    {
        get;
    }

    /// <inheritdoc />
    public int Height
    {
        get;
    }

    /// <summary>
    ///   Создает картинку.
    /// </summary>
    ///
    /// <param name="filePath">Путь к файлу изображения.</param>
    ///
    /// <exception cref="ArgumentNullException">
    ///   Указанный путь к файлу изображения <paramref name="filePath" /> равен <see langword="null" />.
    /// </exception>
    ///
    /// <exception cref="IOException">
    ///   Ошибка загрузки.
    /// </exception>
    public PictureRenderable(string filePath)
    {
        #region Проверка аргументов ...

        Throw.IfNull(filePath);

        #endregion Проверка аргументов ...

        try
        {
            _texture = new Texture(filePath);
        }
        catch (SFML.LoadingFailedException exception)
        {
            throw new IOException("Ошибка загрузки.", exception);
        }

        // Костыль, чтобы избавиться от "uint" в размерах.
        if (_texture.Size.X > int.MaxValue
            || _texture.Size.Y > int.MaxValue)
        {
            _texture.Dispose();

            throw new IOException("Ошибка загрузки: недопустимый размер текстуры.");
        }

        _sprite = new Sprite(_texture);

        Width = (int) _texture.Size.X;
        Height = (int) _texture.Size.Y;
    }

    /// <inheritdoc />
    public void SetLocation(float x, float y)
    {
        // Если объект уничтожен, то ничего не делаем.
        if (IsDisposed())
        {
            return;
        }

        var position = new Vector2f(x, y);

        _sprite.Position = position;
    }

    /// <inheritdoc />
    public void SetSize(float width, float height)
    {
        // Если объект уничтожен, то ничего не делаем.
        if (IsDisposed())
        {
            return;
        }

        var scale = new Vector2f(width / _sprite.TextureRect.Width, height / _sprite.TextureRect.Height);

        _sprite.Scale = scale;
    }

    /// <inheritdoc />
    public void SetViewport(int x, int y, int width, int height)
    {
        // Если объект уничтожен, то ничего не делаем.
        if (IsDisposed())
        {
            return;
        }

        var viewport = new IntRect(x, y, width, height);

        _sprite.TextureRect = viewport;
    }

    /// <inheritdoc />
    public void Dispose()
    {
        if (Interlocked.CompareExchange(ref _isDisposed, 1L, 0L) != 0L)
        {
            return;
        }

        _sprite.Dispose();
        _texture.Dispose();
    }

    private bool IsDisposed()
    {
        var isDisposed = Interlocked.Read(ref _isDisposed) == 1L;

        return isDisposed;
    }

    /// <inheritdoc />
    public void Draw(RenderTarget target, RenderStates states)
    {
        // Если объект уничтожен, то ничего не делаем.
        if (IsDisposed())
        {
            return;
        }

        // Никаких проверок аргументов не делаем - передаем как есть.
        _sprite.Draw(target, states);
    }
}
