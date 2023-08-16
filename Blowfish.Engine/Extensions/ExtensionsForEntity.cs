using Blowfish.Common;
using Blowfish.Engine.Entities;
using System;
using System.Collections.Immutable;

namespace Blowfish.Engine.Extensions;

/// <summary>
///   Содержит методы-расширения для <see cref="Entity" />.
/// </summary>
public static class ExtensionsForEntity
{
    /// <summary>
    ///   Возвращает модуль указанного типа.
    /// </summary>
    ///
    /// <typeparam name="T">Тип модуля.</typeparam>
    ///
    /// <param name="entity">Сущность.</param>
    ///
    /// <returns>
    ///   Модуль.
    /// </returns>
    ///
    /// <exception cref="ArgumentNullException">
    ///   Указанная сущность <paramref name="entity" /> равна <see langword="null" />.
    /// </exception>
    ///
    /// <exception cref="InvalidOperationException">
    ///   Модуль указанного типа отсутствует.
    /// </exception>
    public static T GetModule<T>(
        this Entity entity
        )
        where T : IModule
    {
        #region Проверка аргументов ...

        Throw.IfNull(entity);

        #endregion Проверка аргументов ...

        var type = typeof(T);

        if (!entity.Modules.TryGetValue(type, out var module))
        {
            throw new InvalidOperationException("Модуль указанного типа отсутствует.");
        }

        return (T) module;
    }

    /// <summary>
    ///   Возвращает модуль указанного типа.
    /// </summary>
    ///
    /// <typeparam name="T">Тип модуля.</typeparam>
    ///
    /// <param name="entity">Сущность.</param>
    ///
    /// <returns>
    ///   Модуль или <see langword="null" />, если таковой отсутствует.
    /// </returns>
    ///
    /// <exception cref="ArgumentNullException">
    ///   Указанная сущность <paramref name="entity" /> равна <see langword="null" />.
    /// </exception>
    public static T? GetModuleIfHas<T>(
        this Entity entity
        )
        where T : IModule
    {
        #region Проверка аргументов ...

        Throw.IfNull(entity);

        #endregion Проверка аргументов ...

        var type = typeof(T);

        if (!entity.Modules.TryGetValue(type, out var module))
        {
            return default;
        }

        return (T) module;
    }

    /// <summary>
    ///   Определяет, есть ли модуль указанного типа.
    /// </summary>
    ///
    /// <typeparam name="T">Тип модуля.</typeparam>
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
    public static bool HasModule<T>(
        this Entity entity
        )
        where T : IModule
    {
        #region Проверка аргументов ...

        Throw.IfNull(entity);

        #endregion Проверка аргументов ...

        var type = typeof(T);

        var hasModule = entity.Modules.ContainsKey(type);

        return hasModule;
    }
}
