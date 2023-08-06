using Ninject.Modules;

namespace Blowfish.Program.Composition.Modules;

public sealed class MiscModule : NinjectModule
{
    public MiscModule()
    {
    }

    public override void Load()
    {
        _ = Bind<Game>()
            .ToSelf()
            .InSingletonScope()
            .WithConstructorArgument("width", 640U)
            .WithConstructorArgument("height", 480U)
            .WithConstructorArgument("title", "Game");
    }
}
