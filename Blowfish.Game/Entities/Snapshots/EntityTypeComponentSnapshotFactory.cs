using Blowfish.Common.Attributes;
using Blowfish.Engine.Entities;
using Blowfish.Game.Entities.Components;
using System;

namespace Blowfish.Game.Entities.Snapshots;

/// <inheritdoc cref="IComponentSnapshotFactory" />
[TargetType(typeof(EntityTypeComponent))]
public sealed class EntityTypeComponentSnapshotFactory : IComponentSnapshotFactory
{
    /// <summary>
    ///   Создает фабрику снимков компонентов.
    /// </summary>
    public EntityTypeComponentSnapshotFactory()
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

        var isSupported = component is EntityTypeComponent;

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

        if (component is not EntityTypeComponent entityTypeComponent)
        {
            throw new NotSupportedException("Указанный компонент не поддерживается: неверный тип.");
        }

        // Т.к. этот компонент иммутабельный, то его и используем в качестве снимка.
        var componentSnapshot = entityTypeComponent;

        return componentSnapshot;
    }
}
