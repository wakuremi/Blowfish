using log4net.Core;
using System;
using System.Reflection;

namespace Blowfish.Logging.Log4Net;

/// <inheritdoc cref="ILogger" />
public sealed class Log4NetLogger : ILogger
{
    private static readonly Type _self = typeof(Log4NetLogger);

    private readonly log4net.Core.ILogger _logger;

    /// <summary>
    ///   Создает логгер для указанного типа или анонимный, если тип не указан.
    /// </summary>
    ///
    /// <param name="type">Тип.</param>
    public Log4NetLogger(Type? type)
    {
        var asm = Assembly.GetCallingAssembly();

        _logger = type == null
            ? LoggerManager.GetLogger(asm, "ANONYMOUS")
            : LoggerManager.GetLogger(asm, type);
    }

    /// <inheritdoc />
    public void Debug(string? message)
    {
        _logger.Log(_self, Level.Debug, message, null);
    }

    /// <inheritdoc />
    public void Info(string? message)
    {
        _logger.Log(_self, Level.Info, message, null);
    }

    /// <inheritdoc />
    public void Warn(string? message)
    {
        _logger.Log(_self, Level.Warn, message, null);
    }

    /// <inheritdoc />
    public void Error(string? message, Exception? exception = null)
    {
        _logger.Log(_self, Level.Error, message, exception);
    }

    /// <inheritdoc />
    public void Fatal(string? message, Exception? exception = null)
    {
        _logger.Log(_self, Level.Fatal, message, exception);
    }
}
