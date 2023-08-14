using Blowfish.Framework.Graphics;
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
    /// <param name="renderer">Рендерер.</param>
    /// <param name="type">Тип существа.</param>
    /// <param name="x">Позиция по оси X.</param>
    /// <param name="y">Позиция по оси Y.</param>
    /// <param name="width">Ширина.</param>
    /// <param name="height">Высота.</param>
    ///
    /// <exception cref="ArgumentNullException">
    ///   Указанный рендерер <paramref name="renderer" /> равен <see langword="null" />.
    /// </exception>
    void Render(IRenderer renderer, CreatureTypeEnum type, float x, float y, float width, float height);
}
