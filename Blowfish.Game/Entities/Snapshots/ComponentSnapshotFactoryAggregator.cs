using Blowfish.Common;
using Blowfish.Common.Attributes;
using Blowfish.Engine.Entities;
using System;
using System.Collections.Immutable;

namespace Blowfish.Game.Entities.Snapshots;

/// <inheritdoc cref="IComponentSnapshotFactory" />
public sealed class ComponentSnapshotFactoryAggregator : IComponentSnapshotFactory
{
    private readonly ImmutableDictionary<Type, IComponentSnapshotFactory> _factories;

    /// <summary>
    ///   Создает агрегатор фабрик снимков компонентов.
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
    ///
    /// <exception cref="InvalidOperationException">
    ///   1. Ошибка формирования списка атрибутов.
    ///   2. Целевой тип не указан.
    ///   3. Целевой тип фигурирует более одного раза.
    /// </exception>
    public ComponentSnapshotFactoryAggregator(
        IComponentSnapshotFactory[] factories
        )
    {
        #region Проверка аргументов ...

        Throw.IfNull(factories);
        Throw.IfContainsNull(factories);

        #endregion Проверка аргументов ...

        _factories = TargetTypeAttributeHelper.Separate(factories);
    }

    /// <inheritdoc />
    public bool IsSupported(IComponent component)
    {
        #region Проверка аргументов ...

        Throw.IfNull(component);

        #endregion Проверка аргументов ...

        var type = component.GetType();

        var isSupported = _factories.ContainsKey(type);

        return isSupported;
    }

    /// <inheritdoc />
    public IComponentSnapshot Create(IComponent component)
    {
        #region Проверка аргументов ...

        Throw.IfNull(component);

        #endregion Проверка аргументов ...

        var type = component.GetType();

        if (!_factories.TryGetValue(type, out var factory))
        {
            throw new NotSupportedException("Указанный компонент не поддерживается: отсутствует соответствующая фабрика.");
        }

        var componentSnapshot = factory.Create(component);

        return componentSnapshot;
    }
}
