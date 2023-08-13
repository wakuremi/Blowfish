﻿using Blowfish.Common;
using Blowfish.Common.Attributes;
using Blowfish.Engine.Entities;
using Blowfish.Game.Entities.Components;
using System;

namespace Blowfish.Game.Entities.Snapshots;

/// <inheritdoc cref="IComponentSnapshot" />
[TargetType(typeof(PreviousLocationComponent))]
public sealed class PreviousLocationComponentSnapshotFactory : IComponentSnapshotFactory
{
    /// <summary>
    ///   Создает фабрику снимков компонентов.
    /// </summary>
    public PreviousLocationComponentSnapshotFactory()
    {
    }

    /// <inheritdoc />
    public bool IsSupported(IComponent component)
    {
        #region Проверка аргументов ...

        Throw.IfNull(component);

        #endregion Проверка аргументов ...

        var isSupported = component is PreviousLocationComponent;

        return isSupported;
    }

    /// <inheritdoc />
    public IComponentSnapshot Create(IComponent component)
    {
        #region Проверка аргументов ...

        Throw.IfNull(component);

        #endregion Проверка аргументов ...

        if (component is not PreviousLocationComponent previousLocationComponent)
        {
            throw new NotSupportedException("Указанный компонент не поддерживается: неверный тип.");
        }

        var componentSnapshot = new PreviousLocationComponentSnapshot(previousLocationComponent.X, previousLocationComponent.Y);

        return componentSnapshot;
    }
}
