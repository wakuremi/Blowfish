using Blowfish.Common;
using Blowfish.Engine.Entities;
using Blowfish.Framework;
using System;
using System.Collections.Immutable;

namespace Blowfish.Game.Entities.Updaters;

/// <inheritdoc cref="IEntityUpdater" />
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
    ///
    /// <remarks>
    ///   Апдейтеры будут выполняться в том порядке, в котором они были указаны.
    /// </remarks>
    public EntityUpdaterAggregator(
        IEntityUpdater[] updaters
        )
    {
        #region Проверка аргументов ...

        Throw.IfNull(updaters);
        Throw.IfContainsNull(updaters);

        #endregion Проверка аргументов ...

        _updaters = updaters.ToImmutableList();
    }

    /// <inheritdoc />
    public void Update(UpdateContext context, IEntityController controller, ImmutableList<Entity> entities)
    {
        #region Проверка аргументов ...

        Throw.IfNull(context);
        Throw.IfNull(controller);
        Throw.IfNull(entities);
        Throw.IfContainsNull(entities);

        #endregion Проверка аргументов ...

        // Запускаем апдейтеры в том порядке, в котором они были указаны.
        foreach (var updater in _updaters)
        {
            updater.Update(context, controller, entities);
        }
    }
}
