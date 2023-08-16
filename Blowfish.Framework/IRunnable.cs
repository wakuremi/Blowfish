using System;

namespace Blowfish.Framework;

/// <summary>
///   Объект для выполнения.
/// </summary>
public interface IRunnable
{
    /// <summary>
    ///   Выполняет обновление.
    /// </summary>
    ///
    /// <param name="context">Контекст обновления.</param>
    void Update(UpdateContext context);

    /// <summary>
    ///   Выполняет отрисовку.
    /// </summary>
    ///
    /// <param name="context">Контекст отрисовки.</param>
    void Render(RenderContext context);
}
