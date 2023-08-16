using Blowfish.Framework.Graphics;
using SFML.Graphics;
using System;

namespace Blowfish.Framework.Sfml.Graphics;

/// <summary>
///   Фабрика рендереров.
/// </summary>
public interface IRendererFactory
{
    /// <summary>
    ///   Создает рендерер.
    /// </summary>
    ///
    /// <param name="target">Место отрисовки.</param>
    /// <param name="target">Представление.</param>
    ///
    /// <exception cref="ArgumentNullException">
    ///   1. Указанное место отрисовки <paramref name="target" /> равно <see langword="null" />.
    ///   2. Указанное представление <paramref name="view" /> равно <see langword="null" />.
    /// </exception>
    IRenderer Create(RenderTarget target, View view);
}
