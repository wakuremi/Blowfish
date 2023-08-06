using SFML.System;
using System;

namespace Blowfish.Program;

/// <summary>
///   Рендерер сущностей.
/// </summary>
public interface IEntityRenderer
{
    /// <summary>
    ///   Рисует сущность.
    /// </summary>
    ///
    /// <param name="context">Контекст отрисовки.</param>
    /// <param name="snapshot">Снимок состояния сущности.</param>
    /// <param name="position">Позиция отрисовки.</param>
    ///
    /// <exception cref="ArgumentNullException">
    ///   1. Указанный контекст отрисовки <paramref name="context" /> равен <see langword="null" />.
    ///   2. Указанный снимок состояния сущности <paramref name="snapshot" /> равен <see langword="null" />.
    /// </exception>
    void Render(RenderContext context, IEntitySnapshot snapshot, Vector2f position);
}
