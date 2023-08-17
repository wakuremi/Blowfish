using System;

namespace Blowfish.Framework;

/// <summary>
///   Объект для выполнения.
/// </summary>
///
/// <remarks>
///   Не является потокобезопасным, поэтому требует последовательного выполнение обновления и отрисовки.
/// </remarks>
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
