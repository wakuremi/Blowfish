﻿using Blowfish.Common;
using Blowfish.Engine.Entities;
using Blowfish.Framework;
using Blowfish.Game.Entities.Components;
using System;
using System.Collections.Immutable;

namespace Blowfish.Game.Entities.Renderers;

/// <inheritdoc cref="IEntityRenderer" />
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
    ///
    /// <exception cref="InvalidOperationException">
    ///   1. Ошибка формирования списка атрибутов.
    ///   2. Целевой тип сущности не указан.
    ///   3. Целевой тип сущности фигурирует более одного раза.
    /// </exception>
    public EntityRendererAggregator(
        IEntityRenderer[] renderers
        )
    {
        #region Проверка аргументов ...

        if (renderers == null)
        {
            throw new ArgumentNullException(nameof(renderers), "Указанный массив рендереров равен 'null'.");
        }

        if (renderers.HasNull())
        {
            throw new ArgumentException("Указанный массив рендереров содержит 'null'.", nameof(renderers));
        }

        #endregion Проверка аргументов ...

        _renderers = TargetEntityTypeAttributeHelper.CreateDictionary(renderers);
    }

    /// <inheritdoc />
    public void Render(RenderContext context, EntitySnapshot snapshot)
    {
        #region Проверка аргументов ...

        if (context == null)
        {
            throw new ArgumentNullException(nameof(context), "Указанный контекст отрисовки равен 'null'.");
        }

        if (snapshot == null)
        {
            throw new ArgumentNullException(nameof(snapshot), "Указанный снимок сущности равен 'null'.");
        }

        #endregion Проверка аргументов ...

        var entityTypeComponent = snapshot.GetComponentSnapshot<EntityTypeComponent>();

        if (entityTypeComponent == null)
        {
            throw new NotSupportedException("Указанный снимок сущности не поддерживается: отсутствует компонент типа сущности.");
        }

        var type = entityTypeComponent.Type;

        if (!_renderers.TryGetValue(type, out var renderer))
        {
            throw new NotSupportedException("Указанный снимок сущности не поддерживается: отсутствует соответствующий рендерер.");
        }

        renderer.Render(context, snapshot);
    }
}
