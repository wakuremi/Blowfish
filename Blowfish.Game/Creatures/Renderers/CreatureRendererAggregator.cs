using Blowfish.Common;
using Blowfish.Common.Attributes;
using Blowfish.Engine.Entities;
using Blowfish.Engine.Extensions;
using Blowfish.Framework;
using Blowfish.Game.Creatures.Modules;
using System;
using System.Collections.Immutable;

namespace Blowfish.Game.Creatures.Renderers;

/// <summary>
///   Агрегатор рендереров существ.
/// </summary>
public sealed class CreatureRendererAggregator : ICreatureRenderer
{
    private readonly ImmutableDictionary<CreatureTypeEnum, ICreatureRenderer> _renderers;

    /// <summary>
    ///   Создает агрегатор рендереров существ.
    /// </summary>
    ///
    /// <param name="renderers">Массив рендереров.</param>
    ///
    /// <exception cref="ArgumentNullException">
    ///   Указанный массив рендереров <paramref name="renderers" /> равен <see langword="null" />.
    /// </exception>
    ///
    /// <exception cref="ArgumentException">
    ///   Указанный массив рендереров <paramref name="renderers" /> содержит <see langword="null" />.
    /// </exception>
    public CreatureRendererAggregator(
        ICreatureRenderer[] renderers
        )
    {
        #region Проверка аргументов ...

        Throw.IfNull(renderers);
        Throw.IfHasNull(renderers);

        #endregion Проверка аргументов ...

        _renderers = TargetAttributeHelper.Separate<CreatureTypeEnum, ICreatureRenderer>(renderers);
    }

    /// <inheritdoc />
    public void Render(RenderContext context, Entity entity, float x, float y, float width, float height)
    {
        #region Проверка аргументов ...

        Throw.IfNull(entity);

        #endregion Проверка аргументов ...

        var creatureType = entity.GetModule<CreatureTypeModule>();

        if (!_renderers.TryGetValue(creatureType.Type, out var renderer))
        {
            throw new InvalidOperationException("Отсутствует соответствующий рендерер.");
        }

        renderer.Render(context, entity, x, y, width, height);
    }
}
