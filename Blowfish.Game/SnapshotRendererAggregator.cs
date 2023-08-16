using Blowfish.Common;
using Blowfish.Common.Attributes;
using Blowfish.Engine.Entities;
using Blowfish.Framework;
using System;
using System.Collections.Immutable;

namespace Blowfish.Game;

/// <summary>
///   Агрегатор рендереров снимков.
/// </summary>
public sealed class SnapshotRendererAggregator : ISnapshotRenderer
{
    private readonly ImmutableDictionary<Type, ISnapshotRenderer> _renderers;

    /// <summary>
    ///   Создает агрегатор рендереров снимков.
    /// </summary>
    ///
    /// <param name="renderers">Массив рендереров.</param>
    ///
    /// <exception cref="ArgumentNullException">
    ///   Указанный массив рендереров снимков <paramref name="renderers" /> равен <see langword="null" />.
    /// </exception>
    ///
    /// <exception cref="ArgumentException">
    ///   Указанный массив рендереров снимков <paramref name="renderers" /> содержит <see langword="null" />.
    /// </exception>
    public SnapshotRendererAggregator(
        ISnapshotRenderer[] renderers
        )
    {
        #region Проверка аргументов ...

        Throw.IfNull(renderers);
        Throw.IfHasNull(renderers);

        #endregion Проверка аргументов ...

        _renderers = TargetAttributeHelper.Separate<Type, ISnapshotRenderer>(renderers);
    }

    /// <inheritdoc />
    public void Render(RenderContext context, ISnapshot snapshot)
    {
        #region Проверка аргументов ...

        Throw.IfNull(snapshot);

        #endregion Проверка аргументов ...

        var type = snapshot.GetType();

        if (!_renderers.TryGetValue(type, out var renderer))
        {
            throw new InvalidOperationException("Отсутствует соответствующий рендерер снимков.");
        }

        renderer.Render(context, snapshot);
    }
}
