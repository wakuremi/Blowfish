using Blowfish.Common;
using Blowfish.Engine.Entities;
using Blowfish.Framework;
using System;
using System.Collections.Immutable;

namespace Blowfish.Game;

/// <summary>
///   Агрегатор апдейтеров сущностей.
/// </summary>
public sealed class EntityUpdaterAggregator : IEntityUpdater
{
    private readonly ImmutableList<IEntityUpdater> _updaters;

    /// <summary>
    ///   Создает агрегатор апдейтеров сущностей.
    /// </summary>
    ///
    /// <param name="updaters">Массив апдейтеров.</param>
    ///
    /// <exception cref="ArgumentNullException">
    ///   Указанный массив апдейтеров <paramref name="updaters" /> равен <see langword="null" />.
    /// </exception>
    ///
    /// <exception cref="ArgumentException">
    ///   Указанный массив апдейтеров <paramref name="updaters" /> содержит <see langword="null" />.
    /// </exception>
    public EntityUpdaterAggregator(
        IEntityUpdater[] updaters
        )
    {
        #region Проверка аргументов ...

        Throw.IfNull(updaters);
        Throw.IfHasNull(updaters);

        #endregion Проверка аргументов ...

        _updaters = updaters.ToImmutableList();
    }

    /// <inheritdoc />
    public void Update(UpdateContext context, IEntityController controller)
    {
        #region Проверка аргументов ...

        Throw.IfNull(controller);

        #endregion Проверка аргументов ...

        foreach (var updater in _updaters)
        {
            updater.Update(context, controller);
        }
    }
}
