using System;

namespace Blowfish.Logging;

/// <summary>
///   Логгер.
/// </summary>
public interface ILogger
{
    /// <summary>
    ///   Записывает в лог указанное сообщение с уровнем "Debug".
    /// </summary>
    ///
    /// <param name="message">Сообщение.</param>
    void Debug(string? message);

    /// <summary>
    ///   Записывает в лог указанное сообщение с уровнем "Info".
    /// </summary>
    ///
    /// <param name="message">Сообщение.</param>
    void Info(string? message);

    /// <summary>
    ///   Записывает в лог указанное сообщение с уровнем "Warn".
    /// </summary>
    ///
    /// <param name="message">Сообщение.</param>
    void Warn(string? message);

    /// <summary>
    ///   Записывает в лог указанное сообщение с уровнем "Error".
    /// </summary>
    ///
    /// <param name="message">Сообщение.</param>
    /// <param name="exception">Сопутствующее исключение, если есть.</param>
    void Error(string? message, Exception? exception = null);

    /// <summary>
    ///   Записывает в лог указанное сообщение с уровнем "Fatal".
    /// </summary>
    ///
    /// <param name="message">Сообщение.</param>
    /// <param name="exception">Сопутствующее исключение, если есть.</param>
    void Fatal(string? message, Exception? exception = null);
}
