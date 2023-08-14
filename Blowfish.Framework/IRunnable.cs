﻿using System;

namespace Blowfish.Framework;

/// <summary>
///   Объект для выполнения.
/// </summary>
public interface IRunnable
{
    /// <summary>
    ///   Выполняет обновление.
    /// </summary>
    ///
    /// <param name="context">Контекст обновления.</param>
    ///
    /// <exception cref="ArgumentNullException">
    ///   Указанный контекст обновления <paramref name="context" /> равен <see langword="null" />.
    /// </exception>
    void Update(UpdateContext context);

    /// <summary>
    ///   Выполняет отрисовку.
    /// </summary>
    ///
    /// <param name="context">Контекст отрисовки.</param>
    ///
    /// <exception cref="ArgumentNullException">
    ///   Указанный контекст отрисовки <paramref name="context" /> равен <see langword="null" />.
    /// </exception>
    void Render(RenderContext context);
}