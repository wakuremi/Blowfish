using System;

namespace Blowfish.Engine.Entities;

/// <summary>
///   Содержит методы-расширения для <see cref="Entity" />.
/// </summary>
public static class ExtensionsForEntity
{
    /// <summary>
    ///   Возвращает компонент указанного типа.
    /// </summary>
    ///
    /// <typeparam name="T">Тип.</typeparam>
    ///
    /// <returns>
    ///   Компонент или <see langword="null" />, если таковой отсутствует.
    /// </returns>
    ///
    /// <exception cref="ArgumentNullException">
    ///   Указанная сущность <paramref name="entity" /> равна <see langword="null" />.
    /// </exception>
    public static T? GetComponent<T>(this Entity entity) where T : IComponent
    {
        #region Проверка аргументов ...

        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity), "Указанная сущность равна 'null'.");
        }

        #endregion Проверка аргументов ...

        var type = typeof(T);

        if (!entity.Components.TryGetValue(type, out var component))
        {
            return default;
        }

        return (T) component;
    }

    /// <summary>
    ///   Возвращает компонент указанного типа.
    /// </summary>
    ///
    /// <typeparam name="T">Тип.</typeparam>
    ///
    /// <returns>
    ///   Компонент.
    /// </returns>
    ///
    /// <exception cref="ArgumentNullException">
    ///   Указанная сущность <paramref name="entity" /> равна <see langword="null" />.
    /// </exception>
    ///
    /// <exception cref="ArgumentNullException">
    ///   Отсутствует компонент указанного типа.
    /// </exception>
    public static T GetComponentOrThrow<T>(this Entity entity) where T : IComponent
    {
        #region Проверка аргументов ...

        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity), "Указанная сущность равна 'null'.");
        }

        #endregion Проверка аргументов ...

        var component = entity.GetComponent<T>();

        if (component == null)
        {
            throw new InvalidOperationException("Отсутствует компонент указанного типа.");
        }

        return component;
    }
}
