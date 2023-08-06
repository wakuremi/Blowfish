using log4net;
using System;

namespace Blowfish.Program;

/// <summary>
///   Приложение.
/// </summary>
public sealed class Application
{
    private readonly GameWindow _window;
    private readonly ILog _log;

    /// <summary>
    ///   Создает новый экземпляр.
    /// </summary>
    ///
    /// <param name="window">Игровое окно.</param>
    /// <param name="logProvider">Провайдер журналов.</param>
    ///
    /// <exception cref="ArgumentNullException">
    ///   1. Указанное игровое окно <paramref name="window" /> равно <see langword="null" />.
    ///   2. Указанный провайдер журналов <paramref name="logProvider" /> равен <see langword="null" />.
    /// </exception>
    public Application(
        GameWindow window,
        LogProvider logProvider
        )
    {
        #region Проверка аргументов ...

        if (window == null)
        {
            throw new ArgumentNullException(nameof(window), "Указанное игровое окно равно 'null'.");
        }

        if (logProvider == null)
        {
            throw new ArgumentNullException(nameof(logProvider), "Указанный провайдер журналов равен 'null'.");
        }

        #endregion Проверка аргументов ...

        _window = window;
        _log = logProvider.Get();
    }

    /// <summary>
    ///   Запускает приложение.
    /// </summary>
    public void Start()
    {
        _log.Info("Приложение запущено.");

        _window.Wait();

        _log.Info("Приложение остановлено.");
    }
}
