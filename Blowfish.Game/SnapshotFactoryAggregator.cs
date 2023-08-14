using Blowfish.Common;
using Blowfish.Common.Attributes;
using Blowfish.Engine.Entities;
using Blowfish.Engine.Extensions;
using System;
using System.Collections.Immutable;

namespace Blowfish.Game;

/// <summary>
///   Агрегатор снимков фабрик.
/// </summary>
public sealed class SnapshotFactoryAggregator : ISnapshotFactory
{
    private readonly ImmutableDictionary<EntityTypeEnum, ISnapshotFactory> _factories;

    /// <summary>
    ///   Создает агрегатор снимков фабрик.
    /// </summary>
    ///
    /// <param name="factories">Массив фабрик.</param>
    ///
    /// <exception cref="ArgumentNullException">
    ///   Указанный массив фабрик <paramref name="factories" /> равен <see langword="null" />.
    /// </exception>
    ///
    /// <exception cref="ArgumentException">
    ///   Указанный массив фабрик <paramref name="factories" /> содержит <see langword="null" />.
    /// </exception>
    public SnapshotFactoryAggregator(
        ISnapshotFactory[] factories
        )
    {
        #region Проверка аргументов ...

        Throw.IfNull(factories);
        Throw.IfHasNull(factories);

        #endregion Проверка аргументов ...

        _factories = TargetAttributeHelper.Separate<EntityTypeEnum, ISnapshotFactory>(factories);
    }

    /// <inheritdoc />
    public bool IsSupported(Entity entity)
    {
        #region Проверка аргументов ...

        Throw.IfNull(entity);

        #endregion Проверка аргументов ...

        var entityType = entity.GetModulesIfHas<EntityTypeModule>();

        var isSupported = entityType != null
            && _factories.ContainsKey(entityType.Type);

        return isSupported;
    }

    /// <inheritdoc />
    public ISnapshot Create(Entity entity)
    {
        #region Проверка аргументов ...

        Throw.IfNull(entity);

        #endregion Проверка аргументов ...

        var entityType = entity.GetModules<EntityTypeModule>();

        if (!_factories.TryGetValue(entityType.Type, out var factory))
        {
            throw new InvalidOperationException("Отсутствует соответствующая фабрика снимков.");
        }

        var snapshot = factory.Create(entity);

        return snapshot;
    }
}
