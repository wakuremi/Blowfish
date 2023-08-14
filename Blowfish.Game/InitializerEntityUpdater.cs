using Blowfish.Common;
using Blowfish.Engine.Entities;
using Blowfish.Framework;
using Blowfish.Game.Creatures;
using Blowfish.Game.Creatures.Modules;

namespace Blowfish.Game;

/// <inheritdoc cref="IEntityUpdater" />
public sealed class InitializerEntityUpdater : IEntityUpdater
{
    private bool _isInitialized;

    /// <summary>
    ///   Создает апдейтер сущностей.
    /// </summary>
    public InitializerEntityUpdater()
    {
    }

    /// <inheritdoc />
    public void Update(UpdateContext context, IEntityController controller)
    {
        #region Проверка аргументов ...

        Throw.IfNull(context);
        Throw.IfNull(controller);

        #endregion Проверка аргументов ...

        if (_isInitialized)
        {
            return;
        }

        _isInitialized = true;

        controller.Insert(
            new Entity(
                new IModule[]
                {
                    new EntityTypeModule(EntityTypeEnum.Creature),
                    new CreatureTypeModule(CreatureTypeEnum.Player),
                    new TrackModule(),
                    new BoundsModule(32.0F, 32.0F) { X = 128.0F, Y = 128.0F },
                    new VelocityModule()
                }
                )
            );

        controller.Insert(
            new Entity(
                new IModule[]
                {
                    new EntityTypeModule(EntityTypeEnum.Creature),
                    new CreatureTypeModule(CreatureTypeEnum.Crate),
                    new BoundsModule(64.0F, 64.0F) { X = 300.0F, Y = 300.0F }
                }
                )
            );
    }
}
