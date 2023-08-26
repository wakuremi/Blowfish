using Blowfish.Common;
using Blowfish.Common.Structures;
using Blowfish.Framework.Extensions;
using Blowfish.Framework.Graphics;
using Blowfish.Framework.Graphics.Renderables;
using System;

namespace Blowfish.Engine.Graphics;

/// <summary>
///   Карта тайлов.
/// </summary>
public sealed class TileMap : IDisposable
{
    private readonly ICanvasRenderable _renderable;

    /// <summary>
    ///   Создает карту тайлов.
    /// </summary>
    ///
    /// <param name="renderableFactory">Фабрика объектов для отрисовки.</param>
    /// <param name="spriteSheet">Набор спрайтов.</param>
    /// <param name="map">Карта.</param>
    /// <param name="tileWidth">Ширина тайла.</param>
    /// <param name="tileHeight">Высота тайла.</param>
    ///
    /// <exception cref="ArgumentNullException">
    ///   1. Указанная фабрика объектов для отрисовки <paramref name="renderableFactory" /> равна <see langword="null" />.
    ///   2. Указанный набор спрайтов <paramref name="spriteSheet" /> равен <see langword="null" />.
    ///   3. Указанная карта <paramref name="map" /> равна <see langword="null" />.
    /// </exception>
    public TileMap(
        IRenderableFactory renderableFactory,
        SpriteSheet spriteSheet,
        IReadOnlyMap<int> map,
        int tileWidth,
        int tileHeight
        )
    {
        #region Проверка аргументов ...

        Throw.IfNull(spriteSheet);
        Throw.IfNull(renderableFactory);
        Throw.IfNull(map);

        #endregion Проверка аргументов ...

        var width = tileWidth * map.Width;
        var height = tileHeight * map.Height;

        var renderable = renderableFactory.Create<ICanvasRenderable>(new CanvasRenderableFactoryArgs(width, height));

        for (var i = 0; i < map.Height; i++)
        {
            for (var j = 0; j < map.Height; j++)
            {
                var index = map[i, j];

                var x = i * tileWidth;
                var y = j * tileHeight;

                spriteSheet.Render(renderable, index, x, y, tileWidth, tileHeight);
            }
        }

        _renderable = renderable;
    }

    /// <summary>
    ///   Выполняет отрисовку.
    /// </summary>
    ///
    /// <param name="renderer">Рендерер.</param>
    /// <param name="x">Позиция по оси X.</param>
    /// <param name="y">Позиция по оси Y.</param>
    ///
    /// <exception cref="ArgumentNullException">
    ///   Указанный рендерер <paramref name="renderer" /> равен <see langword="null" />.
    /// </exception>
    public void Render(IRenderer renderer, float x, float y)
    {
        #region Проверка аргументов ...

        Throw.IfNull(renderer);

        #endregion Проверка аргументов ...

        _renderable.SetLocation(x, y);

        renderer.Render(_renderable);
    }

    /// <inheritdoc cref="IDisposable" />
    public void Dispose()
    {
        _renderable.Dispose();
    }
}
