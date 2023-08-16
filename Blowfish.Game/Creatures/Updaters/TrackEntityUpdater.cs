using Blowfish.Common;
using Blowfish.Engine.Entities;
using Blowfish.Engine.Extensions;
using Blowfish.Framework;
using Blowfish.Game.Creatures.Modules;

namespace Blowfish.Game.Creatures.Updaters;

/// <inheritdoc cref="IEntityUpdater" />
public sealed class TrackEntityUpdater : IEntityUpdater
{
    /// <summary>
    ///   Создает апдейтер сущностей.
    /// </summary>
    public TrackEntityUpdater()
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

            var track = entity.GetModuleIfHas<TrackModule>();
            var bounds = entity.GetModuleIfHas<BoundsModule>();

            if (track == null
                || bounds == null)
            {
                continue;
            }

            track.X = bounds.X;
            track.Y = bounds.Y;
        }
    }
}
