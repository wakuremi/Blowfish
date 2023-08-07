using System;

namespace Blowfish.Framework;

/// <summary>
///   Приложение.
/// </summary>
public sealed class Application
{
    private readonly IRunnerFactory _runnerFactory;
    private readonly IGameFactory _gameFactory;

    /// <summary>
    ///   Создает приложение.
    /// </summary>
    ///
    /// <param name="runnerFactory">Фабрика раннеров.</param>
    /// <param name="gameFactory">Фабрика игр.</param>
    ///
    /// <exception cref="ArgumentNullException">
    ///   1. Указанная фабрика раннеров <paramref name="gameFactory" /> равна <see langword="null" />.
    ///   2. Указанная фабрика игр <paramref name="runnerFactory" /> равна <see langword="null" />.
    /// </exception>
    public Application(
        IRunnerFactory runnerFactory,
        IGameFactory gameFactory
        )
    {
        #region Проверка аргументов ...

        if (runnerFactory == null)
        {
            throw new ArgumentNullException(nameof(runnerFactory), "Указанная фабрика раннеров равна 'null'.");
        }

        if (gameFactory == null)
        {
            throw new ArgumentNullException(nameof(gameFactory), "Указанная фабрика игр равна 'null'.");
        }

        #endregion Проверка аргументов ...

        _runnerFactory = runnerFactory;
        _gameFactory = gameFactory;
    }

    /// <summary>
    ///   Запускает приложение и ожидает конца его выполнения.
    /// </summary>
    public void Run()
    {
        using (var runner = _runnerFactory.Create())
        using (var game = _gameFactory.Create())
        {
            runner.Run(game);
        }
    }
}
