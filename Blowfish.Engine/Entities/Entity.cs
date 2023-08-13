using Blowfish.Common;
using System;
using System.Collections.Immutable;

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
    /// <param name="components">Массив компонентов.</param>
    ///
    /// <exception cref="ArgumentNullException">
    ///   Указанный массив компонентов <paramref name="components" /> равен <see langword="null" />.
    /// </exception>
    ///
    /// <exception cref="ArgumentException">
    ///   Указанный массив компонентов <paramref name="components" /> содержит <see langword="null" />.
    /// </exception>
    ///
    /// <exception cref="InvalidOperationException">
    ///   Указано несколько компонентов одного типа.
    /// </exception>
    public Entity(
        IComponent[] components
        )
    {
        #region Проверка аргументов ...

        Throw.IfNull(components);
        Throw.IfContainsNull(components);

        #endregion Проверка аргументов ...

        Components = TypeHelper.Separate(components);
    }
}
