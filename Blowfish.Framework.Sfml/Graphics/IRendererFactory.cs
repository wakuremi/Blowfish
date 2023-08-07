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
    ///
    /// <exception cref="ArgumentNullException">
    ///   Указанное место отрисовки <paramref name="target" /> равно <see langword="null" />.
    /// </exception>
    IRenderer Create(RenderTarget target);
}
