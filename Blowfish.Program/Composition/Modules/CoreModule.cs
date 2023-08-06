using Ninject.Modules;

namespace Blowfish.Program.Composition.Modules;

public sealed class CoreModule : NinjectModule
{
    public CoreModule()
    {
    }

    public override void Load()
    {
        _ = Bind<Application>()
            .ToSelf()
            .InSingletonScope();

        _ = Bind<Game>()
            .ToSelf()
            .InSingletonScope();

        _ = Bind<Scene>()
            .ToSelf()
            .InSingletonScope();
    }
}
