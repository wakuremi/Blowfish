using Blowfish.Engine;
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
        _ = Bind<Application>()
            .ToSelf()
            .InSingletonScope();

        _ = Bind<GameFactory>()
            .ToSelf()
            .InSingletonScope();

        _ = Bind<SpriteSheetFactory>()
            .ToSelf()
            .InSingletonScope();

        _ = Bind<Stage>()
            .ToSelf()
            .InSingletonScope();
    }
}
