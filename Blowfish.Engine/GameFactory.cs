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
    private readonly ISnapshotRenderer _renderer;

    /// <summary>
    ///   Создает фабрику игр.
    /// </summary>
    ///
    /// <param name="stage">Стейдж.</param>
    /// <param name="renderer">Рендерер снимков.</param>
    ///
    /// <exception cref="ArgumentNullException">
    ///   1. Указанный стейдж <paramref name="stage" /> равен <see langword="null" />.
    ///   2. Указанный рендерер снимков <paramref name="renderer" /> равен <see langword="null" />.
    /// </exception>
    public GameFactory(
        Stage stage,
        ISnapshotRenderer renderer
        )
    {
        #region Проверка аргументов ...

        Throw.IfNull(stage);
        Throw.IfNull(renderer);

        #endregion Проверка аргументов ...

        _stage = stage;
        _renderer = renderer;
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
        var game = new Game(_stage, _renderer);

        return game;
    }
}
