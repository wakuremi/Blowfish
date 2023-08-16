using Blowfish.Common;
using Blowfish.Engine.Entities;
using Blowfish.Engine.Extensions;
using Blowfish.Framework;
using Blowfish.Game.Creatures.Modules;

namespace Blowfish.Game.Creatures.Updaters;

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
    public void Update(UpdateContext context, IEntityController controller)
    {
        #region Проверка аргументов ...

        Throw.IfNull(controller);

        #endregion Проверка аргументов ...

        var updatables = controller.Entities
            .WithModules<BoundsModule, VelocityModule>();

        foreach (var (_, bounds, velocity) in updatables)
        {
            bounds.X += velocity.X;
            bounds.Y += velocity.Y;
        }
    }
}
