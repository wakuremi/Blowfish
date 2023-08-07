using System;

namespace Blowfish.Framework.Graphics.Renderables;

/// <summary>
///   Фабрика объектов для отрисовки.
/// </summary>
public interface IRenderableFactory
{
    /// <summary>
    ///   Создает объект для отрисовки.
    /// </summary>
    ///
    /// <param name="type">Тип объекта для отрисовки.</param>
    /// <param name="args">Аргументы.</param>
    ///
    /// <returns>
    ///   Объект для отрисовки.
    /// </returns>
    ///
    /// <exception cref="ArgumentNullException">
    ///   1. Указанный тип объекта для отрисовки <paramref name="type" /> равен <see langword="null" />.
    ///   2. Указанные аргументы <paramref name="args" /> равны <see langword="null" />.
    /// </exception>
    ///
    /// <exception cref="NotSupportedException">
    ///   1. Указанный тип объекта для отрисовки не поддерживается.
    ///   2. Указанные аргументы не соответствуют типу создаваемого объекта.
    /// </exception>
    ///
    /// <exception cref="InvalidOperationException">
    ///   Ошибка создания объекта.
    /// </exception>
    IRenderable Create(Type type, IRenderableFactoryArgs args);
}
