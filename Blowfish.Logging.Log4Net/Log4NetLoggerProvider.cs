using System.Diagnostics;

namespace Blowfish.Logging.Log4Net;

/// <inheritdoc cref="ILoggerProvider" />
public sealed class Log4NetLoggerProvider : ILoggerProvider
{
    /// <summary>
    ///   Создает новый провайдер логгеров.
    /// </summary>
    public Log4NetLoggerProvider()
    {
    }

    /// <inheritdoc />
    public ILogger Get()
    {
        var type = new StackFrame(1).GetMethod()?.ReflectedType;

        var logger = new Log4NetLogger(type);

        return logger;
    }
}
