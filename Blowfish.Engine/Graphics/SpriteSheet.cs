using Blowfish.Common;
using Blowfish.Framework.Extensions;
using Blowfish.Framework.Graphics;
using Blowfish.Framework.Graphics.Renderables;
using System;

namespace Blowfish.Engine.Graphics;

/// <summary>
///   Набор спрайтов.
/// </summary>
public sealed class SpriteSheet : IDisposable
{
    private readonly IPictureRenderable _renderable;
    private readonly int _spriteWidth;
    private readonly int _spriteHeight;
    private readonly int _rows;

    /// <summary>
    ///   Создает набор спрайтов.
    /// </summary>
    ///
    /// <param name="renderableFactory">Фабрика объектов для отрисовки.</param>
    /// <param name="filePath">Путь к файлу изображения.</param>
    /// <param name="spriteWidth">Ширина спрайта.</param>
    /// <param name="spriteHeight">Высота спрайта.</param>
    ///
    /// <exception cref="ArgumentNullException">
    ///   1. Указанная фабрика объектов для отрисовки <paramref name="renderableFactory" /> равна <see langword="null" />.
    ///   2. Указанный путь к файлу изображения <paramref name="filePath" /> равен <see langword="null" />.
    /// </exception>
    ///
    /// <exception cref="ArgumentException">
    ///   1. Указанная ширина спрайта меньше 1.
    ///   2. Указанная высота спрайта меньше 1.
    /// </exception>
    ///
    /// <exception cref="InvalidOperationException">
    ///   Размер спрайта больше размера картинки.
    /// </exception>
    public SpriteSheet(
        IRenderableFactory renderableFactory,
        string filePath,
        int spriteWidth,
        int spriteHeight
        )
    {
        #region Проверка аргументов ...

        Throw.IfNull(renderableFactory);
        Throw.IfNull(filePath);
        Throw.IfLess(spriteWidth, 1);
        Throw.IfLess(spriteHeight, 1);

        #endregion Проверка аргументов ...

        _renderable = renderableFactory.Create<IPictureRenderable>(new PictureRenderableFactoryArgs(filePath));
        _spriteWidth = spriteWidth;
        _spriteHeight = spriteHeight;

        if (spriteWidth > _renderable.Width
            || spriteHeight > _renderable.Height)
        {
            _renderable.Dispose();

            throw new InvalidOperationException("Размер спрайта больше размера картинки.");
        }

        _rows = _renderable.Width / spriteWidth;
    }

    /// <summary>
    ///   Рисует указанный спрайт.
    /// </summary>
    ///
    /// <param name="renderer">Рендерер.</param>
    /// <param name="index">Порядковый номер спрайта.</param>
    /// <param name="x">Позиция по оси X.</param>
    /// <param name="y">Позиция по оси Y.</param>
    /// <param name="width">Ширина.</param>
    /// <param name="height">Высота.</param>
    ///
    /// <exception cref="ArgumentNullException">
    ///   Указанный рендерер <paramref name="renderer" /> равен <see langword="null" />.
    /// </exception>
    ///
    /// <exception cref="InvalidOperationException">
    ///   Ошибка отрисовки.
    /// </exception>
    public void Render(IRenderer renderer, int index, float x, float y, float width, float height)
    {
        #region Проверка аргументов ...

        Throw.IfNull(renderer);

        #endregion Проверка аргументов ...

        // Никаких проверок на порядковый номер спрайта не делаем.
        // Если передали ерунду, то ерунду и рисуем :)
        var row = index / _rows;
        var col = index % _rows;

        _renderable.SetViewport(
            row * _spriteWidth,
            col * _spriteHeight,
            _spriteWidth,
            _spriteHeight
            );

        // С высотой и шириной поступаем аналогично.

        _renderable.SetLocation(x, y);
        _renderable.SetSize(width, height);

        renderer.Render(_renderable);
    }

    /// <inheritdoc />
    public void Dispose()
    {
        _renderable.Dispose();
    }
}
