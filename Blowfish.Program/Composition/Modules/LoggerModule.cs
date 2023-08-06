using Ninject.Modules;

namespace Blowfish.Program.Composition.Modules;

public sealed class LoggerModule : NinjectModule
{
    public LoggerModule()
    {
    }

    public override void Load()
    {
        _ = Bind<LogProvider>()
            .ToSelf()
            .InSingletonScope();
    }
}
