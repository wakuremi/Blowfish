namespace Blowfish.Framework;

/// <summary>
///   Фабрика раннеров.
/// </summary>
public interface IRunnerFactory
{
    /// <summary>
    ///   Создает раннер.
    /// </summary>
    ///
    /// <returns>
    ///   Раннер.
    /// </returns>
    IRunner Create();
}
