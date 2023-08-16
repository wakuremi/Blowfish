using Blowfish.Engine.Entities;
using Blowfish.Framework;
using System;

namespace Blowfish.Game.Creatures.Renderers;

/// <summary>
///   Рендерер существ.
/// </summary>
public interface ICreatureRenderer
{
    /// <summary>
    ///   Выполняет отрисовку.
    /// </summary>
    ///
    /// <param name="context">Контекст отрисовки.</param>
    /// <param name="entity">Сущность.</param>
    /// <param name="x">Позиция по оси X.</param>
    /// <param name="y">Позиция по оси Y.</param>
    /// <param name="width">Ширина.</param>
    /// <param name="height">Высота.</param>
    ///
    /// <exception cref="ArgumentNullException">
    ///   Указанная сущность <paramref name="entity" /> равна <see langword="null" />.
    /// </exception>
    void Render(RenderContext context, Entity entity, float x, float y, float width, float height);
}
