using System;

namespace Blowfish.Framework.Graphics.Renderables;

/// <summary>
///   Аргументы фабрики для создания картинки.
/// </summary>
public sealed class PictureRenderableFactoryArgs : IRenderableFactoryArgs
{
    /// <summary>
    ///   Возвращает путь к файлу изображения.
    /// </summary>
    public string FilePath
    {
        get;
    }

    /// <summary>
    ///   Создает аргументы фабрики для создания картинки.
    /// </summary>
    ///
    /// <param name="filePath">Путь к файлу изображения.</param>
    ///
    /// <exception cref="ArgumentNullException">
    ///   Указанный путь к файлу изображения <paramref name="filePath" /> равен <see langword="null" />.
    /// </exception>
    public PictureRenderableFactoryArgs(string filePath)
    {
        #region Проверка аргументов ...

        if (filePath == null)
        {
            throw new ArgumentNullException(nameof(filePath), "Указанный путь к файлу изображения равен 'null'.");
        }

        #endregion Проверка аргументов ...

        FilePath = filePath;
    }
}
