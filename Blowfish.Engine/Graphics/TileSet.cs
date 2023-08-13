using Blowfish.Common;
using Blowfish.Framework.Graphics;
using Blowfish.Framework.Graphics.Renderables;
using System;

namespace Blowfish.Engine.Graphics;

/// <summary>
///   Набор тайлов.
/// </summary>
public sealed class TileSet : IDisposable
{
    private readonly IPictureRenderable _renderable;
    private readonly int _tileWidth;
    private readonly int _tileHeight;
    private readonly int _rows;

    /// <summary>
    ///   Создает набор тайлов.
    /// </summary>
    ///
    /// <param name="renderableFactory">Фабрика объектов для отрисовки.</param>
    /// <param name="filePath">Путь к файлу изображения.</param>
    /// <param name="tileWidth">Ширина тайла.</param>
    /// <param name="tileHeight">Высота тайла.</param>
    ///
    /// <exception cref="ArgumentNullException">
    ///   1. Указанная фабрика объектов для отрисовки <paramref name="renderableFactory" /> равна <see langword="null" />.
    ///   2. Указанный путь к файлу изображения <paramref name="filePath" /> равен <see langword="null" />.
    /// </exception>
    ///
    /// <exception cref="ArgumentException">
    ///   1. Указанная ширина тайла меньше 1.
    ///   2. Указанная высота тайла меньше 1.
    /// </exception>
    ///
    /// <exception cref="InvalidOperationException">
    ///   Размер тайла больше размера картинки.
    /// </exception>
    public TileSet(
        IRenderableFactory renderableFactory,
        string filePath,
        int tileWidth,
        int tileHeight
        )
    {
        #region Проверка аргументов ...

        Throw.IfNull(renderableFactory);
        Throw.IfNull(filePath);
        Throw.IfLess(tileWidth, 1);
        Throw.IfLess(tileHeight, 1);

        #endregion Проверка аргументов ...

        _renderable = renderableFactory.Create<IPictureRenderable>(new PictureRenderableFactoryArgs(filePath));
        _tileWidth = tileWidth;
        _tileHeight = tileHeight;

        if (tileWidth > _renderable.Width
            || tileHeight > _renderable.Height)
        {
            _renderable.Dispose();

            throw new InvalidOperationException("Размер тайла больше размера картинки.");
        }

        _rows = _renderable.Width / tileWidth;
    }

    /// <summary>
    ///   Рисует указанный тайл.
    /// </summary>
    ///
    /// <param name="renderer">Рендерер.</param>
    /// <param name="index">Порядковый номер тайла.</param>
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

        // Никаких проверок на порядковый номер тайла не делаем.
        // Если передали ерунду, то ерунду и рисуем :)
        var row = index / _rows;
        var col = index % _rows;

        _renderable.SetViewport(
            row * _tileWidth,
            col * _tileHeight,
            _tileWidth,
            _tileHeight
            );

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
