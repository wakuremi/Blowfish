using Blowfish.Common;
using Blowfish.Engine.Entities;
using Blowfish.Framework;
using Blowfish.Framework.Input;
using Blowfish.Game.Entities.Components;
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

        Throw.IfNull(context);
        Throw.IfNull(controller);
        Throw.IfNull(entities);
        Throw.IfContainsNull(entities);

        #endregion Проверка аргументов ...

        var isSpacePressed = context.Keyboard.IsKeyPressed(KeyEnum.Space);

        if (!isSpacePressed)
        {
            return;
        }

        var players = entities.With<EntityTypeComponent>(x => x.Type == EntityTypeEnum.Player);

        foreach (var (_, fire, location) in players.WithComponent<FireComponent, LocationComponent>())
        {
            if (fire.Cooldown > 0)
            {
                fire.Cooldown--;
            }
            else
            {
                fire.Cooldown = 20;

                var bullet = new Entity(
                    new IComponent[]
                    {
                    new EntityTypeComponent(EntityTypeEnum.Bullet),
                    new PreviousLocationComponent(),
                    new LocationComponent() { X = location.X + 8.0F, Y = location.Y + 8.0F },
                    new VelocityComponent() { X = 16.0F, Y = 0.0F }
                    }
                    );

                controller.Insert(bullet);
            }
        }
    }
}
