namespace Blowfish.Framework;

/// <summary>
///   Фабрика игр.
/// </summary>
public interface IGameFactory
{
    /// <summary>
    ///   Создает игру.
    /// </summary>
    ///
    /// <returns>
    ///   Игра.
    /// </returns>
    IGame Create();
}
