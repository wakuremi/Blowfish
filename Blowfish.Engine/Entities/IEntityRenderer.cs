using Blowfish.Framework;
using System;

namespace Blowfish.Engine.Entities;

/// <summary>
///   Рендерер сущностей.
/// </summary>
public interface IEntityRenderer
{
    /// <summary>
    ///   Выполняет отрисовку.
    /// </summary>
    ///
    /// <param name="context">Контекст отрисовки.</param>
    /// <param name="entity">Сущность.</param>
    ///
    /// <exception cref="ArgumentNullException">
    ///   Указанная сущность <paramref name="entity" /> равна <see langword="null" />.
    /// </exception>
    void Render(RenderContext context, Entity entity);
}
