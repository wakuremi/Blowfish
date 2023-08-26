using Blowfish.Common;
using System.Collections.Immutable;
using System;

namespace Blowfish.Engine.Entities;

/// <summary>
///   Сущность.
/// </summary>
public sealed class Entity
{
    /// <summary>
    ///   Возвращает словарь компонентов.
    /// </summary>
    public ImmutableDictionary<Type, IComponent> Components
    {
        get;
    }

    /// <summary>
    ///   Создает сущность.
    /// </summary>
    ///
    /// <param name="components">Список компонентов.</param>
    ///
    /// <exception cref="ArgumentNullException">
    ///   Указанный список компонентов <paramref name="components" /> равен <see langword="null" />.
    /// </exception>
    ///
    /// <exception cref="ArgumentException">
    ///   Указанный список компонентов <paramref name="components" /> содержит <see langword="null" />.
    /// </exception>
    ///
    /// <exception cref="InvalidOperationException">
    ///   Указано несколько компонентов одного и того же типа.
    /// </exception>
    public Entity(
        ImmutableList<IComponent> components
        )
    {
        #region Проверка аргументов ...

        Throw.IfNull(components);
        Throw.IfHasNull(components);

        #endregion Проверка аргументов ...

        Components = TypeHelper.Separate(components);
    }
}
