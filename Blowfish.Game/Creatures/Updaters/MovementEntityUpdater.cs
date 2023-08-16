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

        var entities = controller.Entities;

        for (var i = 0; i < entities.Count; i++)
        {
            var entity = entities[i];

            var bounds = entity.GetModuleIfHas<BoundsModule>();
            var velocity = entity.GetModuleIfHas<VelocityModule>();

            if (bounds == null
                || velocity == null)
            {
                continue;
            }

            bounds.X += velocity.X;
            bounds.Y += velocity.Y;
        }
    }
}
