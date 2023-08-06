using System;

namespace Blowfish.Program;

/// <summary>
///   Провайдер ассетов.
/// </summary>
public interface IAssetProvider
{
    /// <summary>
    ///   Возвращает набор тайлов с указанным именем.
    /// </summary>
    ///
    /// <param name="name">Имя.</param>
    ///
    /// <returns>
    ///   Набор тайлов.
    /// </returns>
    ///
    /// <exception cref="ArgumentNullException">
    ///   Указанное имя <paramref name="name" /> равно <see langword="null" />.
    /// </exception>
    ///
    /// <exception cref="InvalidOperationException">
    ///   Набор тайлов с указанным именем не существует.
    /// </exception>
    TileSet GetTileSet(string name);
}
