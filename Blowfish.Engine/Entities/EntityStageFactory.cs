using Blowfish.Common;
using System;

namespace Blowfish.Engine.Entities;

/// <summary>
///   Фабрика стейджей сущностей.
/// </summary>
public sealed class EntityStageFactory
{
    private readonly IEntityUpdater _updater;
    private readonly IEntityRenderer _renderer;
    private readonly EntityContainerFactory _containerFactory;

    /// <summary>
    ///   Создает фабрику стейджей сущностей.
    /// </summary>
    ///
    /// <param name="updater">Апдейтер сущностей.</param>
    /// <param name="renderer">Рендерер сущностей.</param>
    /// <param name="containerFactory">Фабрика контейнеров сущностей.</param>
    ///
    /// <exception cref="ArgumentNullException">
    ///   1. Указанный апдейтер сущностей <paramref name="updater" /> равен <see langword="null" />.
    ///   2. Указанный рендерер сущностей <paramref name="renderer" /> равен <see langword="null" />.
    ///   3. Указанная фабрика контейнеров сущностей <paramref name="containerFactory" /> равна <see langword="null" />.
    /// </exception>
    public EntityStageFactory(
        IEntityUpdater updater,
        IEntityRenderer renderer,
        EntityContainerFactory containerFactory
        )
    {
        #region Проверка аргументов ...

        Throw.IfNull(updater);
        Throw.IfNull(renderer);
        Throw.IfNull(containerFactory);

        #endregion Проверка аргументов ...

        _updater = updater;
        _renderer = renderer;
        _containerFactory = containerFactory;
    }

    /// <summary>
    ///   Создает стейдж сущностей.
    /// </summary>
    ///
    /// <param name="entities">Массив сущностей.</param>
    ///
    /// <returns>
    ///   Стейдж сущностей.
    /// </returns>
    ///
    /// <exception cref="ArgumentNullException">
    ///   Указанный массив сущностей <paramref name="entities" /> равен <see langword="null" />.
    /// </exception>
    ///
    /// <exception cref="ArgumentException">
    ///   Указанный массив сущностей <paramref name="entities" /> содержит <see langword="null" />.
    /// </exception>
    public EntityStage Create(Entity[] entities)
    {
        var stage = new EntityStage(
            _updater,
            _renderer,
            _containerFactory,
            entities
            );

        return stage;
    }
}
