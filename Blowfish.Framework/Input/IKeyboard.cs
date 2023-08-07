namespace Blowfish.Framework.Input;

/// <summary>
///   Клавиатура.
/// </summary>
public interface IKeyboard
{
    /// <summary>
    ///   Определяет, нажата ли указанная клавиша.
    /// </summary>
    ///
    /// <param name="key">Клавиша.</param>
    ///
    /// <returns>
    ///   <see langword="true" />, если нажата; иначе <see langword="false" />.
    /// </returns>
    bool IsKeyPressed(KeyEnum key);
}
