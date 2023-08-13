using Blowfish.Common;
using Blowfish.Framework.Graphics;
using System;

namespace Blowfish.Framework;

/// <summary>
///   Контекст отрисовки.
/// </summary>
public sealed class RenderContext
{
    /// <summary>
    ///   Возвращает рендерер.
    /// </summary>
    public IRenderer Renderer
    {
        get;
    }

    /// <summary>
    ///   Возвращает дельту времени.
    /// </summary>
    public float Delta
    {
        get;
    }

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
