using log4net;
using System;

namespace Blowfish.Program;

/// <summary>
///   Приложение.
/// </summary>
public sealed class Application
{
    private readonly Game _game;
    private readonly ILog _log;

    /// <summary>
    ///   Создает новый экземпляр.
    /// </summary>
    ///
    /// <param name="game">Игра.</param>
    /// <param name="logProvider">Провайдер журналов.</param>
    ///
    /// <exception cref="ArgumentNullException">
    ///   1. Указанная игра <paramref name="game" /> равна <see langword="null" />.
    ///   2. Указанный провайдер журналов <paramref name="logProvider" /> равен <see langword="null" />.
    /// </exception>
    public Application(
        Game game,
        LogProvider logProvider
        )
    {
        #region Проверка аргументов ...

        if (game == null)
        {
            throw new ArgumentNullException(nameof(game), "Указанная игра равна 'null'.");
        }

        if (logProvider == null)
        {
            throw new ArgumentNullException(nameof(logProvider), "Указанный провайдер журналов равен 'null'.");
        }

        #endregion Проверка аргументов ...

        _game = game;
        _log = logProvider.Get();
    }

    /// <summary>
    ///   Запускает приложение.
    /// </summary>
    public void Start()
    {
        _log.Info("Приложение запущено.");

        _game.Run();

        _log.Info("Приложение остановлено.");
    }
}
