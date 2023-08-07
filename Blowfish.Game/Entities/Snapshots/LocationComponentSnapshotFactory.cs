using Blowfish.Common.Attributes;
using Blowfish.Engine.Entities;
using Blowfish.Game.Entities.Components;
using System;

namespace Blowfish.Game.Entities.Snapshots;

/// <inheritdoc cref="IComponentSnapshotFactory" />
[TargetType(typeof(LocationComponent))]
public sealed class LocationComponentSnapshotFactory : IComponentSnapshotFactory
{
    /// <summary>
    ///   Создает фабрику снимков компонентов.
    /// </summary>
    public LocationComponentSnapshotFactory()
    {
    }

    /// <inheritdoc />
    public bool IsSupported(IComponent component)
    {
        #region Проверка аргументов ...

        if (component == null)
        {
            throw new ArgumentNullException(nameof(component), "Указанный компонент равен 'null'.");
        }

        #endregion Проверка аргументов ...

        var isSupported = component is LocationComponent;

        return isSupported;
    }

    /// <inheritdoc />
    public IComponentSnapshot Create(IComponent component)
    {
        #region Проверка аргументов ...

        if (component == null)
        {
            throw new ArgumentNullException(nameof(component), "Указанный компонент равен 'null'.");
        }

        #endregion Проверка аргументов ...

        if (component is not LocationComponent locationComponent)
        {
            throw new NotSupportedException("Указанный компонент не поддерживается: неверный тип.");
        }

        var componentSnapshot = new LocationComponentSnapshot(locationComponent.X, locationComponent.Y);

        return componentSnapshot;
    }
}
