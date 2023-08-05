using Ninject.Modules;

namespace Blowfish.Program.Composition.Modules;

public sealed class MiscModule : NinjectModule
{
    public MiscModule()
    {
    }

    public override void Load()
    {
        _ = Bind<Form1>()
            .ToSelf()
            .InSingletonScope()
            ;
    }
}
