using log4net;
using System;
using System.Collections.Generic;

namespace Blowfish.Program;

/// <inheritdoc cref="IAssetProvider" />
public sealed class AssetProvider : IAssetProvider
{
    private readonly ILog _log;

    private readonly Dictionary<string, TileSet> _tileSets;

    /// <summary>
    ///   Создает новый экземпляр.
    /// </summary>
    ///
    /// <param name="logProvider">Провайдер журналов.</param>
    ///
    /// <exception cref="ArgumentNullException">
    ///   Указанный провайдер журналов <paramref name="logProvider" /> равен <see langword="null" />.
    /// </exception>
    public AssetProvider(
        LogProvider logProvider
        )
    {
        #region Проверка аргументов ...

        if (logProvider == null)
        {
            throw new ArgumentNullException(nameof(logProvider), "Указанный провайдер журналов равен 'null'.");
        }

        #endregion Проверка аргументов ...

        _log = logProvider.Get();

        _tileSets = new();

        try
        {
            _tileSets.Add("sprites", new TileSet(16, 16, "Assets/Sprites.png"));
        }
        catch (Exception exception)
        {
            _log.Error("Ошибка создания набора тайлов.", exception);
        }
    }

    /// <inheritdoc />
    public TileSet GetTileSet(string name)
    {
        #region Проверка аргументов ...

        if (name == null)
        {
            throw new ArgumentNullException(nameof(name), "Указанное имя равно 'null'.");
        }

        #endregion Проверка аргументов ...

        if (!_tileSets.TryGetValue(name, out var tileSet))
        {
            throw new InvalidOperationException("Набор тайлов с указанным именем не существует.");
        }

        return tileSet;
    }
}
