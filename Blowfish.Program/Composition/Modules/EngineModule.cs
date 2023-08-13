using Blowfish.Engine.Entities;
using Blowfish.Engine.Graphics;
using Ninject.Modules;

namespace Blowfish.Program.Composition.Modules;

public sealed class EngineModule : NinjectModule
{
    public EngineModule()
    {
    }

    public override void Load()
    {
        _ = Bind<EntityStageFactory>()
            .ToSelf()
            .InSingletonScope();

        _ = Bind<EntitySnapshotFactory>()
            .ToSelf()
            .InSingletonScope();

        _ = Bind<TileSet>()
            .ToSelf()
            .InTransientScope();

        _ = Bind<TileSetFactory>()
            .ToSelf()
            .InSingletonScope();
    }
}
