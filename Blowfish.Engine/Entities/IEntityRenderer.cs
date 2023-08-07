using Blowfish.Framework;
using System;

namespace Blowfish.Engine.Entities;

/// <summary>
///   Рендерер сущностей.
/// </summary>
public interface IEntityRenderer
{
    /// <summary>
    ///   Выполняет отрисовку сущности.
    /// </summary>
    ///
    /// <param name="context">Контекст отрисовки.</param>
    /// <param name="snapshot">Снимок сущности.</param>
    ///
    /// <exception cref="ArgumentNullException">
    ///   1. Указанный контекст отрисовки <paramref name="context" /> равен <see langword="null" />.
    ///   2. Указанный снимок сущности <paramref name="snapshot" /> равен <see langword="null" />.
    /// </exception>
    ///
    /// <exception cref="NotSupportedException">
    ///   Указанный снимок сущности не поддерживается.
    /// </exception>
    void Render(RenderContext context, EntitySnapshot snapshot);
}
