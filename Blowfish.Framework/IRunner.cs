using System;

namespace Blowfish.Framework;

/// <summary>
///   Раннер.
/// </summary>
public interface IRunner : IDisposable
{
    /// <summary>
    ///   Запускает выполнение указанного объекта и ожидает его окончания.
    /// </summary>
    ///
    /// <param name="runnable">Объект для выполнения.</param>
    ///
    /// <exception cref="ArgumentNullException">
    ///   Указанный объект для выполнения <paramref name="runnable" /> равен <see langword="null" />.
    /// </exception>
    void Run(IRunnable runnable);
}
