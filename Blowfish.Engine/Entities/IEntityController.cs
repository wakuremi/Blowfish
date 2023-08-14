using System;
using System.Collections.Immutable;

namespace Blowfish.Engine.Entities;

/// <summary>
///   Контроллер сущностей.
/// </summary>
public interface IEntityController
{
    /// <summary>
    ///   Возвращает список сущностей.
    /// </summary>
    ImmutableList<Entity> Entities
    {
        get;
    }

    /// <summary>
    ///   Вставляет указанную сущность.
    /// </summary>
    ///
    /// <param name="entity">Сущность.</param>
    ///
    /// <exception cref="ArgumentNullException">
    ///   Указанная сущность <paramref name="entity" /> равна <see langword="null" />.
    /// </exception>
    void Insert(Entity entity);

    /// <summary>
    ///   Удаляет указанную сущность.
    /// </summary>
    ///
    /// <param name="entity">Сущность.</param>
    ///
    /// <exception cref="ArgumentNullException">
    ///   Указанная сущность <paramref name="entity" /> равна <see langword="null" />.
    /// </exception>
    void Delete(Entity entity);
}
