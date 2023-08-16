using Blowfish.Common;
using Blowfish.Framework;
using System.Collections.Immutable;
using System;
using Blowfish.Engine.Entities;

namespace Blowfish.Engine;

/// <summary>
///   Игра.
/// </summary>
public sealed class Game : IRunnable
{
    private readonly Stage _stage;
    private readonly ISnapshotRenderer _renderer;

    private ImmutableArray<ISnapshot> _snapshots;

    /// <summary>
    ///   Создает игру.
    /// </summary>
    ///
    /// <param name="stage">Стейдж.</param>
    /// <param name="renderer">Рендерер снимков.</param>
    ///
    /// <exception cref="ArgumentNullException">
    ///   1. Указанный стейдж <paramref name="stage" /> равен <see langword="null" />.
    ///   2. Указанный рендерер снимков <paramref name="renderer" /> равен <see langword="null" />.
    /// </exception>
    public Game(
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

        _snapshots = ImmutableArray<ISnapshot>.Empty;
    }

    /// <inheritdoc />
    public void Update(UpdateContext context)
    {
        var snapshots = _stage.Update(context);

        _ = ImmutableInterlocked.InterlockedExchange(ref _snapshots, snapshots);
    }

    /// <inheritdoc />
    public void Render(RenderContext context)
    {
        foreach (var snapshot in _snapshots)
        {
            _renderer.Render(context, snapshot);
        }
    }
}
