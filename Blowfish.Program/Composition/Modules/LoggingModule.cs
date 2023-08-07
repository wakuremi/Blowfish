using Blowfish.Logging;
using Blowfish.Logging.Log4Net;
using Ninject.Modules;

namespace Blowfish.Program.Composition.Modules;

public sealed class LoggingModule : NinjectModule
{
    public LoggingModule()
    {
    }

    public override void Load()
    {
        _ = Bind<ILoggerProvider>()
            .To<Log4NetLoggerProvider>()
            .InSingletonScope();
    }
}
