using Blowfish.Common;
using System;
using System.Collections.Generic;

namespace Blowfish.Engine.Entities;

/// <summary>
///   Фабрика снимков сущностей.
/// </summary>
public sealed class EntitySnapshotFactory
{
    private readonly IComponentSnapshotFactory _factory;

    /// <summary>
    ///   Создает фабрику снимков сущностей.
    /// </summary>
    ///
    /// <param name="factory">Фабрика снимков компонентов.</param>
    ///
    /// <exception cref="ArgumentNullException">
    ///   Указанная фабрика снимков компонентов <paramref name="factory" /> равна <see langword="null" />.
    /// </exception>
    public EntitySnapshotFactory(
        IComponentSnapshotFactory factory
        )
    {
        #region Проверка аргументов ...

        Throw.IfNull(factory);

        #endregion Проверка аргументов ...

        _factory = factory;
    }

    /// <summary>
    ///   Создает снимок указанной сущности.
    /// </summary>
    ///
    /// <param name="entity">Сущность.</param>
    ///
    /// <returns>
    ///   Снимок сущности.
    /// </returns>
    ///
    /// <exception cref="ArgumentNullException">
    ///   Указанная сущность <paramref name="entity" /> равна <see langword="null" />.
    /// </exception>
    public EntitySnapshot Create(Entity entity)
    {
        #region Проверка аргументов ...

        Throw.IfNull(entity);

        #endregion Проверка аргументов ...

        var componentSnapshots = new List<IComponentSnapshot>();

        foreach (var (_, component) in entity.Components)
        {
            if (_factory.IsSupported(component))
            {
                var componentSnapshot = _factory.Create(component);

                componentSnapshots.Add(componentSnapshot);
            }
        }

        var entitySnapshot = new EntitySnapshot(componentSnapshots);

        return entitySnapshot;
    }
}
