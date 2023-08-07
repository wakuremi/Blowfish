using Blowfish.Framework.Graphics.Renderables;
using SFML.Graphics;
using SFML.System;
using System;
using System.Threading;

namespace Blowfish.Framework.Sfml.Graphics.Renderables;

/// <inheritdoc cref="IRectangleRenderable" />
public sealed class RectangleRenderable : IRectangleRenderable, Drawable
{
    private readonly RectangleShape _rectangle;

    private long _isDisposed;

    /// <summary>
    ///   Создает прямоугольник.
    /// </summary>
    public RectangleRenderable()
    {
        _rectangle = new RectangleShape();
    }

    /// <inheritdoc />
    public void SetLocation(float x, float y)
    {
        ThrowIfDisposed();

        var position = new Vector2f(x, y);

        try
        {
            _rectangle.Position = position;
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

        var size = new Vector2f(width, height);

        try
        {
            _rectangle.Size = size;
        }
        catch (Exception exception)
        {
            throw new InvalidOperationException("Не удалось установить размер.", exception);
        }
    }

    /// <inheritdoc />
    public void SetColor(byte r, byte g, byte b)
    {
        ThrowIfDisposed();

        var color = new Color(r, g, b);

        try
        {
            _rectangle.FillColor = color;
        }
        catch (Exception exception)
        {
            throw new InvalidOperationException("Не удалось установить цвет.", exception);
        }
    }

    /// <inheritdoc />
    public void Dispose()
    {
        if (Interlocked.CompareExchange(ref _isDisposed, 1L, 0L) != 0L)
        {
            return;
        }

        _rectangle.Dispose();
    }

    private void ThrowIfDisposed()
    {
        if (Interlocked.Read(ref _isDisposed) != 0L)
        {
            throw new ObjectDisposedException(nameof(RectangleRenderable));
        }
    }

    /// <inheritdoc />
    public void Draw(RenderTarget target, RenderStates states)
    {
        // Никаких проверок не делаем - передаем как есть.
        _rectangle.Draw(target, states);
    }
}
