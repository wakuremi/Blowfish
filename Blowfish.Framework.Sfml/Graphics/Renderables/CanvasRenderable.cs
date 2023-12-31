﻿using Blowfish.Common;
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

        Throw.IfLess(height, 1);
        Throw.IfLess(width, 1);

        #endregion Проверка аргументов ...

        _texture = new RenderTexture((uint) width, (uint) height);
        _sprite = new Sprite(_texture.Texture);

        _renderer = rendererFactory.Create(_texture, _texture.DefaultView);
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
    public void Render(IRenderable renderable)
    {
        #region Проверка аргументов ...

        Throw.IfNull(renderable);

        #endregion Проверка аргументов ...

        _renderer.Render(renderable);
    }

    /// <inheritdoc />
    public void Translate(float x, float y)
    {
        _renderer.Translate(x, y);
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
