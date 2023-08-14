using Blowfish.Common;
using Blowfish.Common.Attributes;
using Blowfish.Engine.Entities;
using Blowfish.Engine.Extensions;
using Blowfish.Game.Creatures.Modules;

namespace Blowfish.Game.Creatures;

/// <inheritdoc />
[Target<EntityTypeEnum>(EntityTypeEnum.Creature)]
public sealed class CreatureSnapshotFactory : ISnapshotFactory
{
    /// <summary>
    ///   Создает фабрику снимков.
    /// </summary>
    public CreatureSnapshotFactory()
    {
    }

    /// <inheritdoc />
    public bool IsSupported(Entity entity)
    {
        #region Проверка аргументов ...

        Throw.IfNull(entity);

        #endregion Проверка аргументов ...

        var entityType = entity.GetModulesIfHas<EntityTypeModule>();

        var isSupported = entityType != null
            && entityType.Type == EntityTypeEnum.Creature;

        return isSupported;
    }

    /// <inheritdoc />
    public ISnapshot Create(Entity entity)
    {
        #region Проверка аргументов ...

        Throw.IfNull(entity);

        #endregion Проверка аргументов ...

        var bounds = entity.GetModules<BoundsModule>();
        var creatureType = entity.GetModules<CreatureTypeModule>();

        var track = entity.GetModulesIfHas<TrackModule>();

        var snapshot = new CreatureSnapshot(
            creatureType.Type,
            bounds.Width,
            bounds.Height,
            bounds.X,
            bounds.Y,
            track?.X,
            track?.Y
            );

        return snapshot;
    }
}
