using Blowfish.Common;
using Blowfish.Framework;
using System;
using System.Collections.Immutable;

namespace Blowfish.Engine.Entities;

/// <summary>
///   Стейдж.
/// </summary>
public sealed class Stage
{
    private readonly IEntityUpdater _updater;
    private readonly ISnapshotFactory _snapshotFactory;

    private readonly EntityController _controller;

    /// <summary>
    ///   Создает стейдж.
    /// </summary>
    ///
    /// <param name="updater">Апдейтер сущностей.</param>
    /// <param name="snapshotFactory">Фабрика снимков.</param>
    ///
    /// <exception cref="ArgumentNullException">
    ///   1. Указанный апдейтер сущностей <paramref name="updater" /> равен <see langword="null" />.
    ///   2. Указанная фабрика снимков <paramref name="snapshotFactory" /> равна <see langword="null" />.
    /// </exception>
    public Stage(
        IEntityUpdater updater,
        ISnapshotFactory snapshotFactory
        )
    {
        #region Проверка аргументов ...

        Throw.IfNull(updater);
        Throw.IfNull(snapshotFactory);

        #endregion Проверка аргументов ...

        _updater = updater;
        _snapshotFactory = snapshotFactory;

        _controller = new EntityController();
    }

    /// <summary>
    ///   Выполняет обновление.
    /// </summary>
    ///
    /// <param name="context">Контекст обновления.</param>
    ///
    /// <returns>
    ///   Массив снимков.
    /// </returns>
    ///
    /// <exception cref="ArgumentNullException">
    ///   Указанный контекст обновления <paramref name="context" /> равен <see langword="null" />.
    /// </exception>
    public ImmutableArray<ISnapshot> Update(UpdateContext context)
    {
        #region Проверка аргументов ...

        Throw.IfNull(context);

        #endregion Проверка аргументов ...

        _updater.Update(context, _controller);

        _controller.Commit();

        var builder = ImmutableArray.CreateBuilder<ISnapshot>();

        foreach (var entity in _controller.Entities)
        {
            var snapshot = _snapshotFactory.Create(entity);

            builder.Add(snapshot);
        }

        var snapshots = builder.ToImmutable();

        return snapshots;
    }
}
