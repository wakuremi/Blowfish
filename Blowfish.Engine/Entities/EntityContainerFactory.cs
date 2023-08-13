using Blowfish.Common;
using System;

namespace Blowfish.Engine.Entities;

/// <summary>
///   Фабрика контейнеров сущностей.
/// </summary>
public sealed class EntityContainerFactory
{
    private readonly EntitySnapshotFactory _snapshotFactory;

    /// <summary>
    ///   Создает фабрику контейнеров сущностей.
    /// </summary>
    ///
    /// <param name="snapshotFactory">Фабрика снимков сущностей.</param>
    ///
    /// <exception cref="ArgumentNullException">
    ///   Указанная фабрика снимков сущностей <paramref name="snapshotFactory" /> равна <see langword="null" />.
    /// </exception>
    public EntityContainerFactory(
        EntitySnapshotFactory snapshotFactory
        )
    {
        #region Проверка аргументов ...

        Throw.IfNull(snapshotFactory);

        #endregion Проверка аргументов ...

        _snapshotFactory = snapshotFactory;
    }

    /// <summary>
    ///   Создает контейнер сущностей.
    /// </summary>
    ///
    /// <returns>
    ///   Контейнер сущностей.
    /// </returns>
    public EntityContainer Create()
    {
        var container = new EntityContainer(_snapshotFactory);

        return container;
    }
}
