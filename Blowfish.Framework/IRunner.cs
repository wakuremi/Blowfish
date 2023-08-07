using System;

namespace Blowfish.Framework;

/// <summary>
///   Раннер.
/// </summary>
public interface IRunner : IDisposable
{
    /// <summary>
    ///   Выполняет указанную игру до тех пор, пока не будет остановлен.
    /// </summary>
    ///
    /// <param name="game">Игра.</param>
    ///
    /// <exception cref="ArgumentNullException">
    ///   Указанная игра <paramref name="game" /> равна <see langword="null" />.
    /// </exception>
    void Run(IGame game);
}
