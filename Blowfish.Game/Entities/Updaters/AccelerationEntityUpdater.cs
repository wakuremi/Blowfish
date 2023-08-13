using Blowfish.Common;
using Blowfish.Engine.Entities;
using Blowfish.Framework;
using Blowfish.Game.Entities.Components;
using System.Collections.Immutable;

namespace Blowfish.Game.Entities.Updaters;

/// <inheritdoc cref="IEntityUpdater" />
public sealed class AccelerationEntityUpdater : IEntityUpdater
{
    private const float MaxVelocityX = 16.0F;
    private const float MaxVelocityY = 16.0F;

    /// <summary>
    ///   Создает апдейтер сущностей.
    /// </summary>
    public AccelerationEntityUpdater()
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

        var updatables = entities
            .WithComponent<VelocityComponent, AccelerationComponent>();

        foreach (var (_, velocity, acceleration) in updatables)
        {
            velocity.X += acceleration.X;
            velocity.Y += acceleration.Y;

            if (velocity.X > MaxVelocityX)
            {
                velocity.X = MaxVelocityX;
            }

            if (velocity.Y > MaxVelocityY)
            {
                velocity.Y = MaxVelocityY;
            }
        }
    }
}
