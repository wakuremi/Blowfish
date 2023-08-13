using Blowfish.Common;
using Blowfish.Framework;
using System;
using System.Collections.Immutable;

namespace Blowfish.Engine.Entities;

/// <summary>
///   Стейдж сущностей.
/// </summary>
public sealed class EntityStage
{
    private readonly IEntityUpdater _updater;
    private readonly IEntityRenderer _renderer;
    private readonly EntityContainer _container;

    private ImmutableArray<EntitySnapshot> _snapshots;

    /// <summary>
    ///   Создает стейдж сущностей.
    /// </summary>
    ///
    /// <param name="updater">Апдейтер сущностей.</param>
    /// <param name="renderer">Рендерер сущностей.</param>
    /// <param name="containerFactory">Фабрика контейнеров сущностей.</param>
    /// <param name="entities">Массив сущностей.</param>
    ///
    /// <exception cref="ArgumentNullException">
    ///   1. Указанный апдейтер сущностей <paramref name="updater" /> равен <see langword="null" />.
    ///   2. Указанный рендерер сущностей <paramref name="renderer" /> равен <see langword="null" />.
    ///   3. Указанная фабрика контейнеров сущностей <paramref name="containerFactory" /> равна <see langword="null" />.
    ///   4. Указанный массив сущностей <paramref name="entities" /> равен <see langword="null" />.
    /// </exception>
    ///
    /// <exception cref="ArgumentException">
    ///   Указанный массив сущностей <paramref name="entities" /> содержит <see langword="null" />.
    /// </exception>
    public EntityStage(
        IEntityUpdater updater,
        IEntityRenderer renderer,
        EntityContainerFactory containerFactory,
        Entity[] entities
        )
    {
        #region Проверка аргументов ...

        if (updater == null)
        {
            throw new ArgumentNullException(nameof(updater), "Указанный апдейтер сущностей равен 'null'.");
        }

        if (renderer == null)
        {
            throw new ArgumentNullException(nameof(renderer), "Указанныйы рендерер сущностей равен 'null'.");
        }

        if (containerFactory == null)
        {
            throw new ArgumentNullException(nameof(containerFactory), "Указанная фабрика контейнеров сущностей равна 'null'.");
        }

        if (entities == null)
        {
            throw new ArgumentNullException(nameof(entities), "Указанный массив сущностей равен 'null'.");
        }

        if (entities.HasNull())
        {
            throw new ArgumentException("Указанный массив сущностей содержит 'null'.", nameof(entities));
        }

        #endregion Проверка аргументов ...

        _updater = updater;
        _renderer = renderer;
        _container = containerFactory.Create();

        foreach (var entity in entities)
        {
            _container.Insert(entity);
        }

        _ = _container.Commit();

        _snapshots = ImmutableArray<EntitySnapshot>.Empty;
    }

    /// <summary>
    ///   Выполняет обновление.
    /// </summary>
    ///
    /// <param name="context">Контекст обновления.</param>
    ///
    /// <exception cref="ArgumentNullException">
    ///   Указанный контекст обновления <paramref name="context" /> равен <see langword="null" />.
    /// </exception>
    public void Update(UpdateContext context)
    {
        #region Проверка аргументов ...

        if (context == null)
        {
            throw new ArgumentNullException(nameof(context), "Указанный контекст обновления 'null'.");
        }

        #endregion Проверка аргументов ...

        _updater.Update(context, _container, _container.Entities);

        var snapshots = _container.Commit();

        _ = ImmutableInterlocked.InterlockedExchange(ref _snapshots, snapshots);
    }

    /// <summary>
    ///   Выполняет отрисовку.
    /// </summary>
    ///
    /// <param name="context">Контекст отрисовки.</param>
    ///
    /// <exception cref="ArgumentNullException">
    ///   Указанный контекст отрисовки <paramref name="context" /> равен <see langword="null" />.
    /// </exception>
    ///
    /// <exception cref="NotSupportedException">
    ///   Рендерер не поддерживает отрисовку сущности.
    /// </exception>
    public void Render(RenderContext context)
    {
        #region Проверка аргументов ...

        if (context == null)
        {
            throw new ArgumentNullException(nameof(context), "Указанный контекст отрисовки 'null'.");
        }

        #endregion Проверка аргументов ...

        foreach (var snapshot in _snapshots)
        {
            _renderer.Render(context, snapshot);
        }
    }
}
