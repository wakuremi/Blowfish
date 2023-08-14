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
    #region "GetModules" ...

    /// <summary>
    ///   Возвращает модули указанных типов.
    /// </summary>
    ///
    /// <param name="entity">Сущность.</param>
    /// <param name="types">Массив типов модулей.</param>
    ///
    /// <returns>
    ///   Словарь модулей.
    /// </returns>
    ///
    /// <exception cref="ArgumentNullException">
    ///   1. Указанная сущность <paramref name="entity" /> равна <see langword="null" />.
    ///   2. Указанный массив типов модулей <paramref name="types" /> равен <see langword="null" />.
    /// </exception>
    ///
    /// <exception cref="ArgumentException">
    ///   Указанный массив типов модулей <paramref name="types" /> содержит <see langword="null" />.
    /// </exception>
    ///
    /// <exception cref="InvalidOperationException">
    ///   Модуль указанного типа отсутствует.
    /// </exception>
    public static ImmutableDictionary<Type, IModule> GetModules(
        this Entity entity,
        params Type[] types
        )
    {
        #region Проверка аргументов ...

        Throw.IfNull(entity);
        Throw.IfNull(types);
        Throw.IfHasNull(types);

        #endregion Проверка аргументов ...

        var builder = ImmutableDictionary.CreateBuilder<Type, IModule>();

        foreach (var type in types)
        {
            if (!entity.Modules.TryGetValue(type, out var module))
            {
                throw new InvalidOperationException($"Модуль указанного типа '{type}' отсутствует.");
            }

            builder.Add(type, module);
        }

        var modules = builder.ToImmutable();

        return modules;
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
    public static T GetModules<T>(
        this Entity entity
        )
        where T : IModule
    {
        var t = typeof(T);

        var modules = entity.GetModules(t);

        var module = (T) modules[t];

        return module;
    }

    /// <summary>
    ///   Возвращает модули указанных типов.
    /// </summary>
    ///
    /// <typeparam name="T1">Тип модуля 1.</typeparam>
    /// <typeparam name="T2">Тип модуля 2.</typeparam>
    ///
    /// <param name="entity">Сущность.</param>
    ///
    /// <returns>
    ///   Модули.
    /// </returns>
    ///
    /// <exception cref="ArgumentNullException">
    ///   Указанная сущность <paramref name="entity" /> равна <see langword="null" />.
    /// </exception>
    ///
    /// <exception cref="InvalidOperationException">
    ///   Модуль указанного типа отсутствует.
    /// </exception>
    public static (T1, T2) GetModules<T1, T2>(
        this Entity entity
        )
        where T1 : IModule
        where T2 : IModule
    {
        var t1 = typeof(T1);
        var t2 = typeof(T2);

        var modules = entity.GetModules(t1, t2);

        var module1 = (T1) modules[t1];
        var module2 = (T2) modules[t2];

        return (module1, module2);
    }

    /// <summary>
    ///   Возвращает модули указанных типов.
    /// </summary>
    ///
    /// <typeparam name="T1">Тип модуля 1.</typeparam>
    /// <typeparam name="T2">Тип модуля 2.</typeparam>
    /// <typeparam name="T3">Тип модуля 3.</typeparam>
    ///
    /// <param name="entity">Сущность.</param>
    ///
    /// <returns>
    ///   Модули.
    /// </returns>
    ///
    /// <exception cref="ArgumentNullException">
    ///   Указанная сущность <paramref name="entity" /> равна <see langword="null" />.
    /// </exception>
    ///
    /// <exception cref="InvalidOperationException">
    ///   Модуль указанного типа отсутствует.
    /// </exception>
    public static (T1, T2, T3) GetModules<T1, T2, T3>(
        this Entity entity
        )
        where T1 : IModule
        where T2 : IModule
        where T3 : IModule
    {
        var t1 = typeof(T1);
        var t2 = typeof(T2);
        var t3 = typeof(T3);

        var modules = entity.GetModules(t1, t2, t3);

        var module1 = (T1) modules[t1];
        var module2 = (T2) modules[t2];
        var module3 = (T3) modules[t3];

        return (module1, module2, module3);
    }

    #endregion "GetModule" ...

    #region "GetModulesIfHas" ...

    /// <summary>
    ///   Возвращает модули указанных типов, если таковые есть.
    /// </summary>
    ///
    /// <param name="entity">Сущность.</param>
    /// <param name="types">Массив типов модулей.</param>
    ///
    /// <returns>
    ///   Словарь модулей.
    /// </returns>
    ///
    /// <exception cref="ArgumentNullException">
    ///   1. Указанная сущность <paramref name="entity" /> равна <see langword="null" />.
    ///   2. Указанный массив типов модулей <paramref name="types" /> равен <see langword="null" />.
    /// </exception>
    ///
    /// <exception cref="ArgumentException">
    ///   Указанный массив типов модулей <paramref name="types" /> содержит <see langword="null" />.
    /// </exception>
    public static ImmutableDictionary<Type, IModule?> GetModulesIfHas(
        this Entity entity,
        params Type[] types
        )
    {
        #region Проверка аргументов ...

        Throw.IfNull(entity);
        Throw.IfNull(types);
        Throw.IfHasNull(types);

        #endregion Проверка аргументов ...

        var builder = ImmutableDictionary.CreateBuilder<Type, IModule?>();

        foreach (var type in types)
        {
            if (!entity.Modules.TryGetValue(type, out var module))
            {
                continue;
            }

            builder.Add(type, module);
        }

        var modules = builder.ToImmutable();

        return modules;
    }

    /// <summary>
    ///   Возвращает модуль указанного типа, если таковой есть.
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
    public static T? GetModulesIfHas<T>(
        this Entity entity
        )
        where T : IModule
    {
        var t = typeof(T);

        var modules = entity.GetModulesIfHas(t);

        var module = modules.TryGetValue(t, out var m) ? (T?) m : default;

        return module;
    }

    /// <summary>
    ///   Возвращает модули указанных типов, если таковые есть.
    /// </summary>
    ///
    /// <typeparam name="T1">Тип модуля 1.</typeparam>
    /// <typeparam name="T2">Тип модуля 2.</typeparam>
    ///
    /// <param name="entity">Сущность.</param>
    ///
    /// <returns>
    ///   Модули.
    /// </returns>
    ///
    /// <exception cref="ArgumentNullException">
    ///   Указанная сущность <paramref name="entity" /> равна <see langword="null" />.
    /// </exception>
    public static (T1?, T2?) GetModulesIfHas<T1, T2>(
        this Entity entity
        )
        where T1 : IModule
        where T2 : IModule
    {
        var t1 = typeof(T1);
        var t2 = typeof(T2);

        var modules = entity.GetModulesIfHas(t1, t2);

        var module1 = modules.TryGetValue(t1, out var m1) ? (T1?) m1 : default;
        var module2 = modules.TryGetValue(t2, out var m2) ? (T2?) m2 : default;

        return (module1, module2);
    }

    /// <summary>
    ///   Возвращает модули указанных типов, если таковые есть.
    /// </summary>
    ///
    /// <typeparam name="T1">Тип модуля 1.</typeparam>
    /// <typeparam name="T2">Тип модуля 2.</typeparam>
    /// <typeparam name="T3">Тип модуля 3.</typeparam>
    ///
    /// <param name="entity">Сущность.</param>
    ///
    /// <returns>
    ///   Модули.
    /// </returns>
    ///
    /// <exception cref="ArgumentNullException">
    ///   Указанная сущность <paramref name="entity" /> равна <see langword="null" />.
    /// </exception>
    public static (T1?, T2?, T3?) GetModulesIfHas<T1, T2, T3>(
        this Entity entity
        )
        where T1 : IModule
        where T2 : IModule
        where T3 : IModule
    {
        var t1 = typeof(T1);
        var t2 = typeof(T2);
        var t3 = typeof(T3);

        var modules = entity.GetModulesIfHas(t1, t2, t3);

        var module1 = modules.TryGetValue(t1, out var m1) ? (T1?) m1 : default;
        var module2 = modules.TryGetValue(t2, out var m2) ? (T2?) m2 : default;
        var module3 = modules.TryGetValue(t3, out var m3) ? (T3?) m3 : default;

        return (module1, module2, module3);
    }

    #endregion "GetModulesIfHas" ...

    #region "HasModules" ...

    /// <summary>
    ///   Определяет, содержит ли указанная сущность модули указанных типов.
    /// </summary>
    ///
    /// <param name="entity">Сущность.</param>
    /// <param name="types">Массив типов модулей.</param>
    ///
    /// <returns>
    ///   <see langword="true" />, если содержит; иначе <see langword="false" />.
    /// </returns>
    ///
    /// <exception cref="ArgumentNullException">
    ///   1. Указанная сущность <paramref name="entity" /> равна <see langword="null" />.
    ///   2. Указанный массив типов модулей <paramref name="types" /> равен <see langword="null" />.
    /// </exception>
    ///
    /// <exception cref="ArgumentException">
    ///   Указанный массив типов модулей <paramref name="types" /> содержит <see langword="null" />.
    /// </exception>
    public static bool HasModules(
        this Entity entity,
        params Type[] types
        )
    {
        #region Проверка аргументов ...

        Throw.IfNull(entity);
        Throw.IfNull(types);
        Throw.IfHasNull(types);

        #endregion Проверка аргументов ...

        foreach (var type in types)
        {
            if (!entity.Modules.ContainsKey(type))
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    ///   Определяет, содержит ли указанная сущность модуль указанного типа.
    /// </summary>
    ///
    /// <typeparam name="T">Тип модуля.</typeparam>
    ///
    /// <param name="entity">Сущность.</param>
    ///
    /// <returns>
    ///   <see langword="true" />, если содержит; иначе <see langword="false" />.
    /// </returns>
    ///
    /// <exception cref="ArgumentNullException">
    ///   Указанная сущность <paramref name="entity" /> равна <see langword="null" />.
    /// </exception>
    public static bool HasModules<T>(
        this Entity entity
        )
        where T : IModule
    {
        var t = typeof(T);

        var hasModules = entity.HasModules(t);

        return hasModules;
    }

    /// <summary>
    ///   Определяет, содержит ли указанная сущность модули указанных типов.
    /// </summary>
    ///
    /// <typeparam name="T1">Тип модуля 1.</typeparam>
    /// <typeparam name="T2">Тип модуля 2.</typeparam>
    ///
    /// <param name="entity">Сущность.</param>
    ///
    /// <returns>
    ///   <see langword="true" />, если содержит; иначе <see langword="false" />.
    /// </returns>
    ///
    /// <exception cref="ArgumentNullException">
    ///   Указанная сущность <paramref name="entity" /> равна <see langword="null" />.
    /// </exception>
    public static bool HasModules<T1, T2>(
        this Entity entity
        )
        where T1 : IModule
        where T2 : IModule
    {
        var t1 = typeof(T1);
        var t2 = typeof(T2);

        var hasModules = entity.HasModules(t1, t2);

        return hasModules;
    }

    /// <summary>
    ///   Определяет, содержит ли указанная сущность модули указанных типов.
    /// </summary>
    ///
    /// <typeparam name="T1">Тип модуля 1.</typeparam>
    /// <typeparam name="T2">Тип модуля 2.</typeparam>
    /// <typeparam name="T3">Тип модуля 3.</typeparam>
    ///
    /// <param name="entity">Сущность.</param>
    ///
    /// <returns>
    ///   <see langword="true" />, если содержит; иначе <see langword="false" />.
    /// </returns>
    ///
    /// <exception cref="ArgumentNullException">
    ///   Указанная сущность <paramref name="entity" /> равна <see langword="null" />.
    /// </exception>
    public static bool HasModules<T1, T2, T3>(
        this Entity entity
        )
        where T1 : IModule
        where T2 : IModule
        where T3 : IModule
    {
        var t1 = typeof(T1);
        var t2 = typeof(T2);
        var t3 = typeof(T3);

        var hasModules = entity.HasModules(t1, t2, t3);

        return hasModules;
    }

    #endregion "HasModules" ...
}
