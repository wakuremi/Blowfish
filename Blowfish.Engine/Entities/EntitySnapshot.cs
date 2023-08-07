using Blowfish.Common;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace Blowfish.Engine.Entities;

/// <summary>
///   Снимок сущности.
/// </summary>
public sealed class EntitySnapshot
{
    /// <summary>
    ///   Возвращает словарь снимков компонентов.
    /// </summary>
    public ImmutableDictionary<Type, IComponentSnapshot> ComponentSnapshots
    {
        get;
    }

    /// <summary>
    ///   Создает снимок сущности.
    /// </summary>
    ///
    /// <param name="componentSnapshots">Список снимков компонентов.</param>
    ///
    /// <exception cref="ArgumentNullException">
    ///   Указанный список снимков компонентов <paramref name="componentSnapshots" /> равен <see langword="null" />.
    /// </exception>
    ///
    /// <exception cref="ArgumentException">
    ///   Указанный список снимков компонентов <paramref name="componentSnapshots" /> содержит <see langword="null" />.
    /// </exception>
    public EntitySnapshot(
        IReadOnlyList<IComponentSnapshot> componentSnapshots
        )
    {
        #region Проверка аргументов ...

        if (componentSnapshots == null)
        {
            throw new ArgumentNullException(nameof(componentSnapshots), "Указанный список снимков компонентов равен 'null'.");
        }

        if (componentSnapshots.HasNull())
        {
            throw new ArgumentException("Указанный список снимков компонентов содержит 'null'.", nameof(componentSnapshots));
        }

        #endregion Проверка аргументов ...

        ComponentSnapshots = TypeHelper.Separate(componentSnapshots);
    }
}
