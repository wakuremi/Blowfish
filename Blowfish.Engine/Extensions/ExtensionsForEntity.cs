using Blowfish.Common;
using Blowfish.Engine.Entities;
using System;

namespace Blowfish.Engine.Extensions;

/// <summary>
///   Содержит методы-расширения для <see cref="Entity" />.
/// </summary>
public static class ExtensionsForEntity
{
    /// <summary>
    ///   Возвращает компонент указанного типа.
    /// </summary>
    ///
    /// <typeparam name="T">Тип компонента.</typeparam>
    ///
    /// <param name="entity">Сущность.</param>
    ///
    /// <returns>
    ///   Компонент.
    /// </returns>
    ///
    /// <exception cref="ArgumentNullException">
    ///   Указанная сущность <paramref name="entity" /> равна <see langword="null" />.
    /// </exception>
    ///
    /// <exception cref="InvalidOperationException">
    ///   Компонент указанного типа отсутствует.
    /// </exception>
    public static T GetComponent<T>(
        this Entity entity
        )
        where T : IComponent
    {
        #region Проверка аргументов ...

        Throw.IfNull(entity);

        #endregion Проверка аргументов ...

        var type = typeof(T);

        if (!entity.Components.TryGetValue(type, out var component))
        {
            throw new InvalidOperationException("Компонент указанного типа отсутствует.");
        }

        return (T) component;
    }

    /// <summary>
    ///   Возвращает компонент указанного типа.
    /// </summary>
    ///
    /// <typeparam name="T">Тип компонента.</typeparam>
    ///
    /// <param name="entity">Сущность.</param>
    ///
    /// <returns>
    ///   Компонент или <see langword="null" />, если таковой отсутствует.
    /// </returns>
    ///
    /// <exception cref="ArgumentNullException">
    ///   Указанная сущность <paramref name="entity" /> равна <see langword="null" />.
    /// </exception>
    public static T? GetComponentIfHas<T>(
        this Entity entity
        )
        where T : IComponent
    {
        #region Проверка аргументов ...

        Throw.IfNull(entity);

        #endregion Проверка аргументов ...

        var type = typeof(T);

        if (!entity.Components.TryGetValue(type, out var component))
        {
            return default;
        }

        return (T) component;
    }

    /// <summary>
    ///   Определяет, есть ли компонент указанного типа.
    /// </summary>
    ///
    /// <typeparam name="T">Тип компонента.</typeparam>
    ///
    /// <param name="entity">Сущность.</param>
    ///
    /// <returns>
    ///   <see langword="true" />, если есть; иначе <see langword="false" />.
    /// </returns>
    ///
    /// <exception cref="ArgumentNullException">
    ///   Указанная сущность <paramref name="entity" /> равна <see langword="null" />.
    /// </exception>
    public static bool HasComponent<T>(
        this Entity entity
        )
        where T : IComponent
    {
        #region Проверка аргументов ...

        Throw.IfNull(entity);

        #endregion Проверка аргументов ...

        var type = typeof(T);

        var hasComponent = entity.Components.ContainsKey(type);

        return hasComponent;
    }
}
