using Blowfish.Common;
using Blowfish.Common.Attributes;
using Blowfish.Engine.Entities;
using Blowfish.Engine.Extensions;
using Blowfish.Framework;
using System;
using System.Collections.Immutable;

namespace Blowfish.Game;

/// <summary>
///   Агрегатор рендереров сущностей.
/// </summary>
public sealed class EntityRendererAggregator : IEntityRenderer
{
    private readonly ImmutableDictionary<EntityTypeEnum, IEntityRenderer> _renderers;

    /// <summary>
    ///   Создает агрегатор рендереров сущностей.
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
    public EntityRendererAggregator(
        IEntityRenderer[] renderers
        )
    {
        #region Проверка аргументов ...

        Throw.IfNull(renderers);
        Throw.IfHasNull(renderers);

        #endregion Проверка аргументов ...

        _renderers = TargetAttributeHelper.Separate<EntityTypeEnum, IEntityRenderer>(renderers);
    }

    /// <inheritdoc />
    public void Render(RenderContext context, Entity entity)
    {
        #region Проверка аргументов ...

        Throw.IfNull(entity);

        #endregion Проверка аргументов ...

        var entityType = entity.GetModule<EntityTypeModule>();

        if (!_renderers.TryGetValue(entityType.Type, out var renderer))
        {
            throw new InvalidOperationException("Отсутствует соответствующий рендерер.");
        }

        renderer.Render(context, entity);
    }
}
