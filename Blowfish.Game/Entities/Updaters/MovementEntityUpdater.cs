using Blowfish.Common;
using Blowfish.Engine.Entities;
using Blowfish.Framework;
using Blowfish.Game.Entities.Components;
using System.Collections.Immutable;

namespace Blowfish.Game.Entities.Updaters;

/// <inheritdoc cref="IEntityUpdater" />
public sealed class MovementEntityUpdater : IEntityUpdater
{
    /// <summary>
    ///   Создает апдейтер сущностей.
    /// </summary>
    public MovementEntityUpdater()
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
            .WithComponent<LocationComponent, VelocityComponent>();

        foreach (var (_, location, velocity) in updatables)
        {
            location.X += velocity.X;
            location.Y += velocity.Y;
        }
    }
}
