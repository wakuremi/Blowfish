using Blowfish.Framework;
using System;

namespace Blowfish.Engine.Entities;

/// <summary>
///   Рендерер снимков.
/// </summary>
public interface ISnapshotRenderer
{
    /// <summary>
    ///   Выполняет отрисовку.
    /// </summary>
    ///
    /// <param name="context">Контекст отрисовки.</param>
    /// <param name="snapshot">Снимок.</param>
    ///
    /// <exception cref="ArgumentNullException">
    ///   Указанный снимок <paramref name="snapshot" /> равен <see langword="null" />.
    /// </exception>
    void Render(RenderContext context, ISnapshot snapshot);
}
