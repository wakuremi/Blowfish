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

        if (updaters == null)
        {
            throw new ArgumentNullException(nameof(updaters), "Укзанный массив апдейтеров равен 'null'.");
        }

        if (updaters.HasNull())
        {
            throw new ArgumentException("Указанный массив апдейтеров содержит 'null'.", nameof(updaters));
        }

        #endregion Проверка аргументов ...

        _updaters = updaters.ToImmutableList();
    }

    /// <inheritdoc />
    public void Update(UpdateContext context, IEntityController controller, ImmutableList<Entity> entities)
    {
        #region Проверка аргументов ...

        if (context == null)
        {
            throw new ArgumentNullException(nameof(context), "Указанный контекст обновления равен 'null'.");
        }

        if (controller == null)
        {
            throw new ArgumentNullException(nameof(controller), "Указанный контроллер сущностей равен 'null'.");
        }

        if (entities == null)
        {
            throw new ArgumentNullException(nameof(entities), "Указанный список сущностей равен 'null'.");
        }

        if (entities.HasNull())
        {
            throw new ArgumentException("Указанный список сущностей содержит 'null'.", nameof(entities));
        }

        #endregion Проверка аргументов ...

        // Запускаем апдейтеры в том порядке, в котором они были указаны.
        foreach (var updater in _updaters)
        {
            updater.Update(context, controller, entities);
        }
    }
}
