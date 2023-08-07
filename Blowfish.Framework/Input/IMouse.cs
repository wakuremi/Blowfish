namespace Blowfish.Framework.Input;

/// <summary>
///   Мышь.
/// </summary>
public interface IMouse
{
    /// <summary>
    ///   Определяет, нажата ли указанная кнопка.
    /// </summary>
    ///
    /// <param name="button">Кнопка.</param>
    ///
    /// <returns>
    ///   <see langword="true" />, если нажата; иначе <see langword="false" />.
    /// </returns>
    bool IsButtonPressed(ButtonEnum button);

    /// <summary>
    ///   Возвращает позицию указателя по оси X.
    /// </summary>
    ///
    /// <returns>
    ///   Позиция указателя по оси X.
    /// </returns>
    float GetPointerX();

    /// <summary>
    ///   Возвращает позицию указателя по оси Y.
    /// </summary>
    ///
    /// <returns>
    ///   Позиция указателя по оси Y.
    /// </returns>
    float GetPointerY();
}
