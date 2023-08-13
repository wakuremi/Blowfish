using Blowfish.Common;
using Blowfish.Engine.Entities;
using Blowfish.Framework;
using Blowfish.Framework.Input;
using Blowfish.Game.Entities.Components;
using System;
using System.Collections.Immutable;

namespace Blowfish.Game.Entities.Updaters;

/// <inheritdoc cref="IEntityUpdater" />
public sealed class FireEntityUpdater : IEntityUpdater
{
    /// <summary>
    ///   Создает апдейтер сущностей.
    /// </summary>
    public FireEntityUpdater()
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

        var isSpacePressed = context.Keyboard.IsKeyPressed(KeyEnum.Space);

        if (!isSpacePressed)
        {
            return;
        }

        var players = entities.With<EntityTypeComponent>(x => x.Type == EntityTypeEnum.Player);

        foreach (var player in players.With<FireComponent, LocationComponent>())
        {
            var fireComponent = player.GetComponentOrThrow<FireComponent>();

            if (fireComponent.Cooldown > 0)
            {
                fireComponent.Cooldown--;

                continue;
            }

            var locationComponent = player.GetComponentOrThrow<LocationComponent>();

            var bullet = new Entity(
                new IComponent[]
                {
                    new EntityTypeComponent(EntityTypeEnum.Bullet),
                    new PreviousLocationComponent(),
                    new LocationComponent() { X = locationComponent.X + 8.0F, Y = locationComponent.Y + 8.0F },
                    new VelocityComponent() { X = 16.0F, Y = 0.0F }
                }
                );

            controller.Insert(bullet);

            fireComponent.Cooldown = 20;
        }
    }
}
