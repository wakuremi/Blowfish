using SFML.System;
using SFML.Window;

namespace Blowfish.Program;

/// <summary>
///   Пользовательский ввод.
/// </summary>
public interface IUserInput
{
    /// <summary>
    ///   Определяет, нажата ли указанная клавиша <paramref name="key" />.
    /// </summary>
    ///
    /// <param name="key">Клавиша.</param>
    ///
    /// <returns>
    ///   <see langword="true" />, если нажата; иначе <see langword="false" />.
    /// </returns>
    bool IsKeyPressed(Keyboard.Key key);

    /// <summary>
    ///   Определяет, нажата ли указанная кнопка <paramref name="button" />.
    /// </summary>
    ///
    /// <param name="button">Кнопка.</param>
    ///
    /// <returns>
    ///   <see langword="true" />, если нажата; иначе <see langword="false" />.
    /// </returns>
    bool IsButtonPressed(Mouse.Button button);

    /// <summary>
    ///   Возвращает позицию указателя.
    /// </summary>
    ///
    /// <returns>
    ///   Позиция указателя.
    /// </returns>
    Vector2f GetPointer();
}
