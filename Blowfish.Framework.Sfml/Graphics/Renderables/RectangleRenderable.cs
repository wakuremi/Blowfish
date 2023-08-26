using Blowfish.Framework.Graphics.Renderables;
using SFML.Graphics;
using SFML.System;
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
        // Если объект уничтожен, то ничего не делаем.
        if (IsDisposed())
        {
            return;
        }

        var position = new Vector2f(x, y);

        _rectangle.Position = position;
    }

    /// <inheritdoc />
    public void SetSize(float width, float height)
    {
        // Если объект уничтожен, то ничего не делаем.
        if (IsDisposed())
        {
            return;
        }

        var size = new Vector2f(width, height);

        _rectangle.Size = size;
    }

    /// <inheritdoc />
    public void SetColor(byte r, byte g, byte b)
    {
        // Если объект уничтожен, то ничего не делаем.
        if (IsDisposed())
        {
            return;
        }

        var color = new Color(r, g, b);

        _rectangle.FillColor = color;
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

    private bool IsDisposed()
    {
        return Interlocked.Read(ref _isDisposed) == 1L;
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
        _rectangle.Draw(target, states);
    }
}
