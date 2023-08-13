﻿using Blowfish.Common;
using Blowfish.Engine.Entities;
using Blowfish.Framework;
using Blowfish.Game.Entities.Components;
using System;
using System.Collections.Immutable;

namespace Blowfish.Game.Entities.Updaters;

/// <inheritdoc cref="IEntityUpdater" />
public sealed class PreviousLocationEntityUpdater : IEntityUpdater
{
    /// <summary>
    ///   Создает апдейтер сущностей.
    /// </summary>
    public PreviousLocationEntityUpdater()
    {
    }

    /// <inheritdoc />
    public void Update(UpdateContext context, IEntityController controller, ImmutableList<Entity> entities)
    {
        #region Проверка аргументов ...

        if (context == null)
        {
            throw new ArgumentNullException(nameof(context), "Указанный контекст обновления равен 'null'.");
        }

        if (controller == null)
        {
            throw new ArgumentNullException(nameof(controller), "Указанный контроллер сущностей равен 'null'.");
        }

        if (entities == null)
        {
            throw new ArgumentNullException(nameof(entities), "Указанный список сущностей равен 'null'.");
        }

        if (entities.HasNull())
        {
            throw new ArgumentException("Указанный список сущностей содержит 'null'.", nameof(entities));
        }

        #endregion Проверка аргументов ...

        foreach (var entity in entities.With<LocationComponent, PreviousLocationComponent>())
        {
            var locationComponent = entity.GetComponentOrThrow<LocationComponent>();
            var previousLocationComponent = entity.GetComponentOrThrow<PreviousLocationComponent>();

            previousLocationComponent.X = locationComponent.X;
            previousLocationComponent.Y = locationComponent.Y;
        }
    }
}
