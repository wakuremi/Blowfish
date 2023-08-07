namespace Blowfish.Logging;

/// <summary>
///   Провайдер логгеров.
/// </summary>
public interface ILoggerProvider
{
    /// <summary>
    ///   Возвращает логгер для класса, в котором данный метод был вызван или анонимный, если класс определить не
    ///   удалось.
    /// </summary>
    ///
    /// <returns>Логгер.</returns>
    ILogger Get();
}
