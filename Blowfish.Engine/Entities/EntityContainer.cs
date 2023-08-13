using Blowfish.Common;
using System;
using System.Collections.Immutable;

namespace Blowfish.Engine.Entities;

/// <summary>
///   Контейнер сущностей.
/// </summary>
public sealed class EntityContainer : IEntityController
{
    private readonly EntitySnapshotFactory _snapshotFactory;

    private ImmutableList<Entity> _modified;

    /// <summary>
    ///   Возвращает список сущностей.
    /// </summary>
    public ImmutableList<Entity> Entities
    {
        get;
        private set;
    }

    /// <summary>
    ///   Создает контейнер сущностей.
    /// </summary>
    ///
    /// <param name="snapshotFactory">Фабрика снимков сущностей.</param>
    ///
    /// <exception cref="ArgumentNullException">
    ///   Указанная фабрика снимков сущностей <paramref name="snapshotFactory" /> равна <see langword="null" />.
    /// </exception>
    public EntityContainer(
        EntitySnapshotFactory snapshotFactory
        )
    {
        #region Проверка аргументов ...

        Throw.IfNull(snapshotFactory);

        #endregion Проверка аргументов ...

        _snapshotFactory = snapshotFactory;

        _modified = ImmutableList<Entity>.Empty;

        Entities = ImmutableList<Entity>.Empty;
    }

    /// <inheritdoc />
    public void Insert(Entity entity)
    {
        #region Проверка аргументов ...

        Throw.IfNull(entity);

        #endregion Проверка аргументов ...

        _modified = _modified.Add(entity);
    }

    /// <inheritdoc />
    public void Delete(Entity entity)
    {
        #region Проверка аргументов ...

        Throw.IfNull(entity);

        #endregion Проверка аргументов ...

        _modified = _modified.Remove(entity);
    }

    /// <summary>
    ///   Фиксирует сделанные изменения.
    /// </summary>
    ///
    /// <returns>
    ///   Массив снимков сущностей.
    /// </returns>
    public ImmutableArray<EntitySnapshot> Commit()
    {
        Entities = _modified;

        var builder = ImmutableArray.CreateBuilder<EntitySnapshot>();

        foreach (var entity in _modified)
        {
            var snapshot = _snapshotFactory.Create(entity);

            builder.Add(snapshot);
        }

        var snapshots = builder.ToImmutable();

        return snapshots;
    }
}
