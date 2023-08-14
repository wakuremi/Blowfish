using System;

namespace Blowfish.Engine.Entities;

/// <summary>
///   Фабрика снимков.
/// </summary>
public interface ISnapshotFactory
{
    /// <summary>
    ///   Определяет, поддерживается ли указанная сущность.
    /// </summary>
    ///
    /// <param name="entity">Сущность.</param>
    ///
    /// <returns>
    ///   <see langword="true" />, если поддерживается; иначе <see langword="false" />.
    /// </returns>
    ///
    /// <exception cref="ArgumentNullException">
    ///   Указанная сущность <paramref name="entity" /> равна <see langword="null" />.
    /// </exception>
    bool IsSupported(Entity entity);

    /// <summary>
    ///   Создает снимок указанной сущности.
    /// </summary>
    ///
    /// <param name="entity">Сущность.</param>
    ///
    /// <returns>
    ///   Снимок.
    /// </returns>
    ///
    /// <exception cref="ArgumentNullException">
    ///   Указанная сущность <paramref name="entity" /> равна <see langword="null" />.
    /// </exception>
    ///
    /// <exception cref="InvalidOperationException">
    ///   Указанная сущность не поддерживается.
    /// </exception>
    ISnapshot Create(Entity entity);
}
