using Blowfish.Common;
using Blowfish.Engine.Entities;
using Blowfish.Framework;
using Blowfish.Game.Entities.Components;
using System;
using System.Collections.Immutable;

namespace Blowfish.Game.Entities.Updaters;

/// <inheritdoc cref="IEntityUpdater" />
public sealed class DecelerationEntityUpdater : IEntityUpdater
{
    private const float AbsDecelerationX = 0.15F;
    private const float AbsDecelerationY = 0.15F;

    /// <summary>
    ///   Создает апдейтер сущностей.
    /// </summary>
    public DecelerationEntityUpdater()
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
            .WithComponent<VelocityComponent>();

        foreach (var (_, velocity) in updatables)
        {
            if (velocity.X > AbsDecelerationX)
            {
                velocity.X -= AbsDecelerationX;
            }
            else if (velocity.X < -AbsDecelerationX)
            {
                velocity.X += AbsDecelerationX;
            }
            else
            {
                velocity.X = 0;
            }

            if (velocity.Y > AbsDecelerationY)
            {
                velocity.Y -= AbsDecelerationY;
            }
            else if (velocity.Y < -AbsDecelerationY)
            {
                velocity.Y += AbsDecelerationY;
            }
            else
            {
                velocity.Y = 0;
            }
        }
    }
}
