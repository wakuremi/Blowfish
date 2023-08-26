using Blowfish.Common;
using Blowfish.Framework.Graphics;
using System;

namespace Blowfish.Framework;

/// <summary>
///   Контекст отрисовки.
/// </summary>
public readonly ref struct RenderContext
{
    // Это структура! Убедитесь, что параметрический конструктор будет вызван!

    /// <summary>
    ///   Рендерер.
    /// </summary>
    public readonly IRenderer Renderer;

    /// <summary>
    ///   Дельта времени.
    /// </summary>
    public readonly float Delta;

    /// <summary>
    ///   Создает контекст отрисовки.
    /// </summary>
    ///
    /// <param name="renderer">Рендерер.</param>
    /// <param name="delta">Дельта времени.</param>
    ///
    /// <exception cref="ArgumentNullException">
    ///   Указанный рендерер <paramref name="renderer" /> равен <see langword="null" />.
    /// </exception>
    public RenderContext(
        IRenderer renderer,
        float delta
        )
    {
        #region Проверка аргументов ...

        Throw.IfNull(renderer);

        #endregion Проверка аргументов ...

        Renderer = renderer;
        Delta = delta;
    }
}
