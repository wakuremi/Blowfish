using NativeButton = Blowfish.Framework.Input.ButtonEnum;
using NativeKey = Blowfish.Framework.Input.KeyEnum;
using SfmlButton = SFML.Window.Mouse.Button;
using SfmlKey = SFML.Window.Keyboard.Key;

namespace Blowfish.Framework.Sfml.Helpers;

/// <summary>
///   Содержит вспомогательные методы для работы с вводом.
/// </summary>
internal static class InputHelper
{
    /// <summary>
    ///   Преобразует указанную SFML-клавишу в нативную клавишу.
    /// </summary>
    ///
    /// <param name="sfml">SFML-клавиша.</param>
    ///
    /// <returns>
    ///   Нативная клавиша или <see langword="null" />, если нет подходящего преобразования.
    /// </returns>
    public static NativeKey? ToNative(SfmlKey sfml)
    {
        switch (sfml)
        {
            case SfmlKey.W:
                return NativeKey.W;

            case SfmlKey.A:
                return NativeKey.A;

            case SfmlKey.S:
                return NativeKey.S;

            case SfmlKey.D:
                return NativeKey.D;

            default:
                return null;
        }
    }

    /// <summary>
    ///   Преобразует указанную SFML-кнопку в нативную кнопку.
    /// </summary>
    ///
    /// <param name="sfml">SFML-кнопка.</param>
    ///
    /// <returns>
    ///   Нативная кнопка или <see langword="null" />, если нет подходящего преобразования.
    /// </returns>
    public static NativeButton? ToNative(SfmlButton sfml)
    {
        switch (sfml)
        {
            case SfmlButton.Left:
                return NativeButton.Left;

            case SfmlButton.Right:
                return NativeButton.Right;

            case SfmlButton.Middle:
                return NativeButton.Middle;

            default:
                return null;
        }
    }
}
