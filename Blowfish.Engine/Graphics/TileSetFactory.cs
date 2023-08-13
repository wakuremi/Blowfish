using Blowfish.Common;
using Blowfish.Framework.Graphics.Renderables;
using System;

namespace Blowfish.Engine.Graphics;

/// <summary>
///   Фабрика наборов тайлов.
/// </summary>
public sealed class TileSetFactory
{
    private readonly IRenderableFactory _renderableFactory;

    /// <summary>
    ///   Создает фабрику наборов тайлов.
    /// </summary>
    ///
    /// <param name="renderableFactory">Фабрика объектов для отрисовки.</param>
    ///
    /// <exception cref="ArgumentNullException">
    ///   Указанная фабрика объектов для отрисовки <paramref name="renderableFactory" /> равна <see langword="null" />.
    /// </exception>
    public TileSetFactory(
        IRenderableFactory renderableFactory
        )
    {
        #region Проверка аргументов ...

        Throw.IfNull(renderableFactory);

        #endregion Проверка аргументов ...

        _renderableFactory = renderableFactory;
    }

    /// <summary>
    ///   Создает набор тайлов.
    /// </summary>
    ///
    /// <param name="filePath">Путь к файлу изображения.</param>
    /// <param name="tileWidth">Ширина тайла.</param>
    /// <param name="tileHeight">Высота тайла.</param>
    ///
    /// <returns>
    ///   Набор тайлов.
    /// </returns>
    ///
    /// <exception cref="ArgumentNullException">
    ///   Указанный путь к файлу изображения <paramref name="filePath" /> равен <see langword="null" />.
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
    public TileSet Create(
        string filePath,
        int tileWidth,
        int tileHeight
        )
    {
        var tileSet = new TileSet(_renderableFactory, filePath, tileWidth, tileHeight);

        return tileSet;
    }
}
