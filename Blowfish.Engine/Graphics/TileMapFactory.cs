using Blowfish.Common;
using Blowfish.Common.Structures;
using Blowfish.Framework.Graphics.Renderables;
using System;

namespace Blowfish.Engine.Graphics;

/// <summary>
///   Фабрика карт тайлов.
/// </summary>
public sealed class TileMapFactory
{
    private readonly IRenderableFactory _renderableFactory;

    /// <summary>
    ///   Создает фабрику карт тайлов.
    /// </summary>
    ///
    /// <param name="renderableFactory">Фабрика объектов для отрисовки.</param>
    public TileMapFactory(
        IRenderableFactory renderableFactory
        )
    {
        #region Проверка аргументов ...

        Throw.IfNull(renderableFactory);

        #endregion Проверка аргументов ...

        _renderableFactory = renderableFactory;
    }

    /// <summary>
    ///   Создает карту тайлов.
    /// </summary>
    ///
    /// <param name="map">Карта.</param>
    /// <param name="tileWidth">Ширина тайла.</param>
    /// <param name="tileHeight">Высота тайла.</param>
    /// <param name="spriteSheet">Набор спрайтов.</param>
    ///
    /// <returns>
    ///   Карта тайлов.
    /// </returns>
    ///
    /// <exception cref="ArgumentNullException">
    ///   1. Указанный набор спрайтов <paramref name="spriteSheet" /> равен <see langword="null" />.
    ///   2. Указанная карта <paramref name="map" /> равна <see langword="null" />.
    /// </exception>
    public TileMap Create(
        IReadOnlyMap<int> map,
        SpriteSheet spriteSheet,
        int tileWidth,
        int tileHeight
        )
    {
        var tileMap = new TileMap(
            _renderableFactory,
            spriteSheet,
            map,
            tileWidth,
            tileHeight
            );

        return tileMap;
    }
}
