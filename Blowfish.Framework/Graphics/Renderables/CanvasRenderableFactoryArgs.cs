using Blowfish.Common;
using System;

namespace Blowfish.Framework.Graphics.Renderables;

/// <summary>
///   Аргументы фабрики для создания холста.
/// </summary>
public sealed class CanvasRenderableFactoryArgs : IRenderableFactoryArgs
{
    /// <summary>
    ///   Возвращает ширину.
    /// </summary>
    public int Width
    {
        get;
    }

    /// <summary>
    ///   Возвращает высоту.
    /// </summary>
    public int Height
    {
        get;
    }

    /// <summary>
    ///   Создает аргументы фабрики для создания холста.
    /// </summary>
    ///
    /// <param name="width">Ширина.</param>
    /// <param name="height">Высота.</param>
    ///
    /// <exception cref="ArgumentException">
    ///   1. Указанная ширина <paramref name="width" /> меньше 1.
    ///   2. Указанная высота <paramref name="height" /> меньше 1.
    /// </exception>
    public CanvasRenderableFactoryArgs(int width, int height)
    {
        #region Проверка аргументов ...

        Throw.IfLess(width, 1);
        Throw.IfLess(height, 1);

        #endregion Проверка аргументов ...

        Width = width;
        Height = height;
    }
}
