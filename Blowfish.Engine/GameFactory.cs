using Blowfish.Common;
using Blowfish.Engine.Entities;
using System;

namespace Blowfish.Engine;

/// <summary>
///   Фабрика игр.
/// </summary>
public sealed class GameFactory
{
    private readonly Stage _stage;

    /// <summary>
    ///   Создает фабрику игр.
    /// </summary>
    ///
    /// <param name="stage">Стейдж.</param>
    ///
    /// <exception cref="ArgumentNullException">
    ///   Указанный стейдж <paramref name="stage" /> равен <see langword="null" />.
    /// </exception>
    public GameFactory(
        Stage stage
        )
    {
        #region Проверка аргументов ...

        Throw.IfNull(stage);

        #endregion Проверка аргументов ...

        _stage = stage;
    }

    /// <summary>
    ///   Создает игру.
    /// </summary>
    ///
    /// <returns>
    ///   Игра.
    /// </returns>
    public Game Create()
    {
        var game = new Game(_stage);

        return game;
    }
}
