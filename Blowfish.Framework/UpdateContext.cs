﻿using Blowfish.Framework.Input;
using System;

namespace Blowfish.Framework;

/// <summary>
///   Контекст обновления.
/// </summary>
public sealed class UpdateContext
{
    /// <summary>
    ///   Возвращает клавиатуру.
    /// </summary>
    public IKeyboard Keyboard
    {
        get;
    }

    /// <summary>
    ///   Возвращает мышь.
    /// </summary>
    public IMouse Mouse
    {
        get;
    }

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

        if (keyboard == null)
        {
            throw new ArgumentNullException(nameof(keyboard), "Указанная клавиатура равна 'null'.");
        }

        if (mouse == null)
        {
            throw new ArgumentNullException(nameof(mouse), "Указанная мышь равна 'null'.");
        }

        #endregion Проверка аргументов ...

        Keyboard = keyboard;
        Mouse = mouse;
    }
}
