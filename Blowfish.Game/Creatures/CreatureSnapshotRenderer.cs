using Blowfish.Common;
using Blowfish.Common.Attributes;
using Blowfish.Engine.Entities;
using Blowfish.Framework;
using Blowfish.Game.Creatures.Renderers;
using System;
using System.Collections.Immutable;

namespace Blowfish.Game.Creatures;

/// <inheritdoc cref="ISnapshotRenderer" />
[Target<Type>(typeof(CreatureSnapshot))]
public sealed class CreatureSnapshotRenderer : ISnapshotRenderer
{
    private readonly ImmutableDictionary<CreatureTypeEnum, ICreatureRenderer> _creatureRenderers;

    /// <summary>
    ///   Создает рендерер снимков.
    /// </summary>
    ///
    /// <param name="creatureRenderers">Массив рендереров существ.</param>
    ///
    /// <exception cref="ArgumentNullException">
    ///   Указанный массив рендереров существ <paramref name="creatureRenderers" /> равен <see langword="null" />.
    /// </exception>
    ///
    /// <exception cref="ArgumentException">
    ///   Указанный массив рендереров существ <paramref name="creatureRenderers" /> содержит <see langword="null" />.
    /// </exception>
    public CreatureSnapshotRenderer(
        ICreatureRenderer[] creatureRenderers
        )
    {
        #region Проверка аргументов ...

        Throw.IfNull(creatureRenderers);
        Throw.IfHasNull(creatureRenderers);

        #endregion Проверка аргументов ...

        _creatureRenderers = TargetAttributeHelper.Separate<CreatureTypeEnum, ICreatureRenderer>(creatureRenderers);
    }

    /// <inheritdoc />
    public void Render(RenderContext context, ISnapshot snapshot)
    {
        #region Проверка аргументов ...

        Throw.IfNull(snapshot);

        #endregion Проверка аргументов ...

        var creature = (CreatureSnapshot) snapshot;

        if (!_creatureRenderers.TryGetValue(creature.Type, out var creatureRenderer))
        {
            throw new InvalidOperationException("Отсутствует соответствующий рендерер существ.");
        }

        var delta = context.Delta;

        float x;
        
        if (creature.TrackX.HasValue)
        {
            x = creature.TrackX.Value + (creature.X - creature.TrackX.Value) * delta;
        }
        else
        {
            x = creature.X;
        }

        float y;

        if (creature.TrackY.HasValue)
        {
            y = creature.TrackY.Value + (creature.Y - creature.TrackY.Value) * delta;
        }
        else
        {
            y = creature.Y;
        }

        creatureRenderer.Render(context.Renderer, creature.Type, x, y, creature.Width, creature.Height);
    }
}
