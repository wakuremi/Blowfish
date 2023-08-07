using System;

namespace Blowfish.Engine.Entities;

/// <summary>
///   Фабрика снимков компонентов.
/// </summary>
public interface IComponentSnapshotFactory
{
    /// <summary>
    ///   Определяет, поддерживает фабрика указанный компонент.
    /// </summary>
    ///
    /// <param name="component">Компонент.</param>
    ///
    /// <returns>
    ///   <see langword="true" />, если поддерживает; иначе <see langword="false" .
    /// </returns>
    ///
    /// <exception cref="ArgumentNullException">
    ///   Указанный компонент <paramref name="component" /> равен <see langword="null" />.
    /// </exception>
    bool IsSupported(IComponent component);

    /// <summary>
    ///   Создает снимок указанного компонента.
    /// </summary>
    ///
    /// <param name="component">Компонент.</param>
    ///
    /// <returns>
    ///   Снимок компонента.
    /// </returns>
    ///
    /// <exception cref="ArgumentNullException">
    ///   Указанный компонент <paramref name="component" /> равен <see langword="null" />.
    /// </exception>
    ///
    /// <exception cref="NotSupportedException">
    ///   Указанный компонент не поддерживается.
    /// </exception>
    IComponentSnapshot Create(IComponent component);
}
