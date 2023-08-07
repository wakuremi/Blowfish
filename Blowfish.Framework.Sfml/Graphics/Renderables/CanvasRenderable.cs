using Blowfish.Framework.Graphics;
using Blowfish.Framework.Graphics.Renderables;
using SFML.Graphics;
using SFML.System;
using System;
using System.Threading;

namespace Blowfish.Framework.Sfml.Graphics.Renderables;

/// <inheritdoc cref="ICanvasRenderable" />
public sealed class CanvasRenderable : ICanvasRenderable, Drawable
{
    private readonly IRenderer _renderer;
    private readonly RenderTexture _texture;
    private readonly Sprite _sprite;

    private long _isDisposed;

    /// <summary>
    ///   Создает холст.
    /// </summary>
    ///
    /// <param name="rendererFactory">Фабрика рендереров.</param>
    /// <param name="width">Ширина.</param>
    /// <param name="height">Высота.</param>
    ///
    /// <exception cref="ArgumentNullException">
    ///   Указанная фабрика рендереров <paramref name="rendererFactory" /> равна <see langword="null" />.
    /// </exception>
    ///
    /// <exception cref="ArgumentException">
    ///   1. Указанная ширина <paramref name="width" /> меньше 1.
    ///   2. Указанная высота <paramref name="height" /> меньше 1.
    /// </exception>
    ///
    /// <exception cref="InvalidOperationException">
    ///   Ошибка вызова коллбека.
    /// </exception>
    public CanvasRenderable(
        IRendererFactory rendererFactory,
        int width,
        int height
        )
    {
        #region Проверка аргументов ...

        if (width < 1)
        {
            throw new ArgumentException("Указанная ширина меньше 1.");
        }

        if (height < 1)
        {
            throw new ArgumentException("Указанная высота меньше 1.");
        }

        #endregion Проверка аргументов ...

        _texture = new RenderTexture((uint) width, (uint) height);
        _sprite = new Sprite(_texture.Texture);

        _renderer = rendererFactory.Create(_texture);
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
    public void Render(IRenderable renderable)
    {
        #region Проверка аргументов ...

        if (renderable == null)
        {
            throw new ArgumentNullException(nameof(renderable), "Указанный объект для отрисовки равен 'null'.");
        }

        #endregion Проверка аргументов ...

        _renderer.Render(renderable);
    }

    /// <inheritdoc />
    public void Draw(RenderTarget target, RenderStates states)
    {
        // Никаких проверок не делаем - передаем как есть.
        _sprite.Draw(target, states);
    }
}
