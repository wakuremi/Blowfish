using System;

namespace Blowfish.Engine.Graphics;

/// <summary>
///   Фабрика наборов тайлов.
/// </summary>
public interface ITileSetFactory
{
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
    TileSet Create(
        string filePath,
        int tileWidth,
        int tileHeight
        );
}
