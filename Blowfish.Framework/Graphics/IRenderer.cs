using Blowfish.Framework.Graphics.Renderables;
using System;

namespace Blowfish.Framework.Graphics;

/// <summary>
///   Рендерер.
/// </summary>
public interface IRenderer
{
    /// <summary>
    ///   Рисует указанный объект.
    /// </summary>
    ///
    /// <param name="renderable">Объект для отрисовки.</param>
    ///
    /// <exception cref="ArgumentNullException">
    ///   Указанный объект для отрисовки <paramref name="renderable" /> равен <see langword="null" />.
    /// </exception>
    ///
    /// <exception cref="InvalidOperationException">
    ///   Ошибка отрисовки.
    /// </exception>
    void Render(IRenderable renderable);
}
