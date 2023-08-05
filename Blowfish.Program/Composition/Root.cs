using Blowfish.Program.Composition.Modules;
using Ninject;
using System;

namespace Blowfish.Program.Composition;

public sealed class Root : IDisposable
{
    private readonly StandardKernel _kernel;

    public Root()
    {
        _kernel = new StandardKernel();
        _kernel.Load<LoggerModule>();
        _kernel.Load<MiscModule>();
    }

    public T GetInstance<T>()
    {
        var instance = _kernel.Get<T>();

        return instance;
    }

    public void Dispose()
    {
        _kernel.Dispose();
    }
}
