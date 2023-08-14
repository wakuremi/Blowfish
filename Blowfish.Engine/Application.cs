using Blowfish.Common;
using Blowfish.Framework;
using System;

namespace Blowfish.Engine;

/// <summary>
///   Приложение.
/// </summary>
public sealed class Application
{
    private readonly IRunnerFactory _runnerFactory;
    private readonly GameFactory _gameFactory;

    /// <summary>
    ///   Создает приложение.
    /// </summary>
    ///
    /// <param name="runnerFactory">Фабрика раннеров.</param>
    /// <param name="gameFactory">Фабрика игр.</param>
    ///
    /// <exception cref="ArgumentNullException">
    ///   1. Указанная фабрика раннеров <paramref name="runnerFactory" /> равна <see langword="null" />.
    ///   2. Указанная фабрика игр <paramref name="gameFactory" /> равна <see langword="null" />.
    /// </exception>
    public Application(
        IRunnerFactory runnerFactory,
        GameFactory gameFactory
        )
    {
        #region Проверка аргументов ...

        Throw.IfNull(runnerFactory);
        Throw.IfNull(gameFactory);

        #endregion Проверка аргументов ...

        _runnerFactory = runnerFactory;
        _gameFactory = gameFactory;
    }

    /// <summary>
    ///   Запускает приложение и ожидает окончания его выполнения.
    /// </summary>
    public void Run()
    {
        using (var runner = _runnerFactory.Create())
        {
            var game = _gameFactory.Create();

            runner.Run(game);
        }
    }
}
