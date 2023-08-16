using Blowfish.Common;
using Blowfish.Framework.Input;
using System;

namespace Blowfish.Framework;

/// <summary>
///   Контекст обновления.
/// </summary>
public readonly struct UpdateContext
{
    // Это структура! Убедитесь, что параметрический конструктор будет вызван!

    /// <summary>
    ///   Клавиатура.
    /// </summary>
    public readonly IKeyboard Keyboard;

    /// <summary>
    ///   Мышь.
    /// </summary>
    public readonly IMouse Mouse;

    /// <summary>
    ///   Создает контекст обновления.
    /// </summary>
    ///
    /// <param name="keyboard">Клавиатура.</param>
    /// <param name="mouse">Мышь.</param>
    ///
    /// <exception cref="ArgumentNullException">
    ///   1. Указанная клавиатура <paramref name="keyboard" /> равна <see langword="null" />.
    ///   2. Указанная мышь <paramref name="mouse" /> равна <see langword="null" />.
    /// </exception>
    public UpdateContext(
        IKeyboard keyboard,
        IMouse mouse
        )
    {
        #region Проверка аргументов ...

        Throw.IfNull(keyboard);
        Throw.IfNull(mouse);

        #endregion Проверка аргументов ...

        Keyboard = keyboard;
        Mouse = mouse;
    }
}
