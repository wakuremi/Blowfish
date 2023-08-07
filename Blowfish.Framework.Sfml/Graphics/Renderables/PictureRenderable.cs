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
    ///   1. Ошибка загрузки.
    ///   2. Недопустимый размер текстуры.
    /// </exception>
    public PictureRenderable(string filePath)
    {
        #region Проверка аргументов ...

        if (filePath == null)
        {
            throw new ArgumentNullException(nameof(filePath), "Указанный путь к файлу равен 'null'.");
        }

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

            throw new IOException("Недопустимый размер текстуры.");
        }

        _sprite = new Sprite(_texture);

        Width = (int) _texture.Size.X;
        Height = (int) _texture.Size.Y;
    }

    /// <inheritdoc />
    public void SetLocation(float x, float y)
    {
        ThrowIfDisposed();

        var position = new Vector2f(x, y);

        try
        {
            _sprite.Position = position;
        }
        catch (Exception exception)
        {
            throw new InvalidOperationException("Не удалось установить позицию.", exception);
        }
    }

    /// <inheritdoc />
    public void SetSize(float width, float height)
    {
        ThrowIfDisposed();

        var scale = new Vector2f(width / _sprite.TextureRect.Width, height / _sprite.TextureRect.Height);

        try
        {
            _sprite.Scale = scale;
        }
        catch (Exception exception)
        {
            throw new InvalidOperationException("Не удалось установить размер.", exception);
        }
    }

    /// <inheritdoc />
    public void SetViewport(int x, int y, int width, int height)
    {
        ThrowIfDisposed();

        var viewport = new IntRect(x, y, width, height);

        try
        {
            _sprite.TextureRect = viewport;
        }
        catch (Exception exception)
        {
            throw new InvalidOperationException("Не удалось установить область просмотра.", exception);
        }
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

    private void ThrowIfDisposed()
    {
        if (Interlocked.Read(ref _isDisposed) != 0L)
        {
            throw new ObjectDisposedException(nameof(PictureRenderable));
        }
    }

    /// <inheritdoc />
    public void Draw(RenderTarget target, RenderStates states)
    {
        // Никаких проверок не делаем - передаем как есть.
        _sprite.Draw(target, states);
    }
}
