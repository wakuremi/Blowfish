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

        Throw.IfNull(context);
        Throw.IfNull(controller);

        #endregion Проверка аргументов ...

        var updatables = controller.Entities
            .WithModules<TrackModule, BoundsModule>();

        foreach (var (_, track, bounds) in updatables)
        {
            track.X = bounds.X;
            track.Y = bounds.Y;
        }
    }
}
