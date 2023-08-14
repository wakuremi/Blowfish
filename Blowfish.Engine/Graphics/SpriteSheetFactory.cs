using Blowfish.Common;
using Blowfish.Framework.Graphics.Renderables;
using System;

namespace Blowfish.Engine.Graphics;

/// <summary>
///   Фабрика наборов спрайтов.
/// </summary>
public sealed class SpriteSheetFactory
{
    private readonly IRenderableFactory _renderableFactory;

    /// <summary>
    ///   Создает фабрику наборов спрайтов.
    /// </summary>
    ///
    /// <param name="renderableFactory">Фабрика объектов для отрисовки.</param>
    ///
    /// <exception cref="ArgumentNullException">
    ///   Указанная фабрика объектов для отрисовки <paramref name="renderableFactory" /> равна <see langword="null" />.
    /// </exception>
    public SpriteSheetFactory(
        IRenderableFactory renderableFactory
        )
    {
        #region Проверка аргументов ...

        Throw.IfNull(renderableFactory);

        #endregion Проверка аргументов ...

        _renderableFactory = renderableFactory;
    }

    /// <summary>
    ///   Создает набор спрайтов.
    /// </summary>
    ///
    /// <param name="filePath">Путь к файлу изображения.</param>
    /// <param name="tileWidth">Ширина спрайта.</param>
    /// <param name="tileHeight">Высота спрайта.</param>
    ///
    /// <returns>
    ///   Набор спрайтов.
    /// </returns>
    ///
    /// <exception cref="ArgumentNullException">
    ///   Указанный путь к файлу изображения <paramref name="filePath" /> равен <see langword="null" />.
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
    public SpriteSheet Create(
        string filePath,
        int tileWidth,
        int tileHeight
        )
    {
        var tileSet = new SpriteSheet(_renderableFactory, filePath, tileWidth, tileHeight);

        return tileSet;
    }
}
