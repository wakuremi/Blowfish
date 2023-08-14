using Blowfish.Common;
using Blowfish.Engine.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Blowfish.Engine.Extensions;

/// <summary>
///   Содержит методы-расширения для <see cref="IEnumerable{T}" />, состоящего из элементов типа <see cref="Entity" />.
/// </summary>
public static class ExtensionsForIEnumerableOfEntity
{
    /// <summary>
    ///   Возвращает из указанного перечня сущности, у которых есть модуль указанного типа, удовлетворяющий предикату.
    /// </summary>
    ///
    /// <typeparam name="T">Тип модуля.</typeparam>
    ///
    /// <param name="entities">Перечень сущностей.</param>
    /// <param name="predicate">Предикат.</param>
    ///
    /// <returns>
    ///   Перечень сущностей.
    /// </returns>
    ///
    /// <exception cref="ArgumentNullException">
    ///   Указанный перечень сущностей <paramref name="entities" /> равен <see langword="null" />.
    /// </exception>
    public static IEnumerable<Entity> With<T>(
        this IEnumerable<Entity> entities,
        Func<T, bool>? predicate = null
        )
        where T : IModule
    {
        return entities
            .WithModules(predicate)
            .Select(x => x.Entity);
    }

    /// <summary>
    ///   Возвращает из указанного перечня сущности, у которых есть модули указанного типа, удовлетворяющие предикату.
    /// </summary>
    ///
    /// <typeparam name="T1">Тип модуля 1.</typeparam>
    /// <typeparam name="T2">Тип модуля 2.</typeparam>
    ///
    /// <param name="entities">Перечень сущностей.</param>
    /// <param name="predicate">Предикат.</param>
    ///
    /// <returns>
    ///   Перечень сущностей.
    /// </returns>
    ///
    /// <exception cref="ArgumentNullException">
    ///   Указанный перечень сущностей <paramref name="entities" /> равен <see langword="null" />.
    /// </exception>
    public static IEnumerable<Entity> With<T1, T2>(
        this IEnumerable<Entity> entities,
        Func<T1, T2, bool>? predicate = null
        )
        where T1 : IModule
        where T2 : IModule
    {
        return entities
            .WithModules(predicate)
            .Select(x => x.Entity);
    }

    /// <summary>
    ///   Возвращает из указанного перечня сущности, у которых есть модули указанного типа, удовлетворяющие предикату.
    /// </summary>
    ///
    /// <typeparam name="T1">Тип модуля 1.</typeparam>
    /// <typeparam name="T2">Тип модуля 2.</typeparam>
    /// <typeparam name="T2">Тип модуля 3.</typeparam>
    ///
    /// <param name="entities">Перечень сущностей.</param>
    /// <param name="predicate">Предикат.</param>
    ///
    /// <returns>
    ///   Перечень сущностей.
    /// </returns>
    ///
    /// <exception cref="ArgumentNullException">
    ///   Указанный перечень сущностей <paramref name="entities" /> равен <see langword="null" />.
    /// </exception>
    public static IEnumerable<Entity> With<T1, T2, T3>(
        this IEnumerable<Entity> entities,
        Func<T1, T2, T3, bool>? predicate = null
        )
        where T1 : IModule
        where T2 : IModule
        where T3 : IModule
    {
        return entities
            .WithModules(predicate)
            .Select(x => x.Entity);
    }

    /// <summary>
    ///   Возвращает из указанного перечня сущности, у которых есть модуль указанного типа, удовлетворяющий предикату.
    /// </summary>
    ///
    /// <typeparam name="T">Тип модуля.</typeparam>
    ///
    /// <param name="entities">Перечень сущностей.</param>
    /// <param name="predicate">Предикат.</param>
    ///
    /// <returns>
    ///   Перечень сущностей и их модулей.
    /// </returns>
    ///
    /// <exception cref="ArgumentNullException">
    ///   Указанный перечень сущностей <paramref name="entities" /> равен <see langword="null" />.
    /// </exception>
    public static IEnumerable<EntityTuple<T>> WithModules<T>(
        this IEnumerable<Entity?> entities,
        Func<T, bool>? predicate = null
        )
        where T : IModule
    {
        #region Проверка аргументов ...

        Throw.IfNull(entities);

        #endregion Проверка аргументов ...

        foreach (var entity in entities)
        {
            if (entity != null)
            {
                var module = entity.GetModulesIfHas<T>();

                if (module != null
                    && (predicate == null || predicate.Invoke(module)))
                {
                    var result = new EntityTuple<T>(entity, module);

                    yield return result;
                }
            }
        }
    }

    /// <summary>
    ///   Возвращает из указанного перечня сущности, у которых есть модули указанного типа, удовлетворяющие предикату.
    /// </summary>
    ///
    /// <typeparam name="T1">Тип модуля 1.</typeparam>
    /// <typeparam name="T2">Тип модуля 2.</typeparam>
    ///
    /// <param name="entities">Перечень сущностей.</param>
    /// <param name="predicate">Предикат.</param>
    ///
    /// <returns>
    ///   Перечень сущностей и их модулей.
    /// </returns>
    ///
    /// <exception cref="ArgumentNullException">
    ///   Указанный перечень сущностей <paramref name="entities" /> равен <see langword="null" />.
    /// </exception>
    public static IEnumerable<EntityTuple<T1, T2>> WithModules<T1, T2>(
        this IEnumerable<Entity?> entities,
        Func<T1, T2, bool>? predicate = null
        )
        where T1 : IModule
        where T2 : IModule
    {
        #region Проверка аргументов ...

        Throw.IfNull(entities);

        #endregion Проверка аргументов ...

        foreach (var entity in entities)
        {
            if (entity != null)
            {
                var (module1, module2) = entity.GetModulesIfHas<T1, T2>();

                if (module1 != null && module2 != null
                    && (predicate == null || predicate.Invoke(module1, module2)))
                {
                    var result = new EntityTuple<T1, T2>(entity, module1, module2);

                    yield return result;
                }
            }
        }
    }

    /// <summary>
    ///   Возвращает из указанного перечня сущности, у которых есть модули указанного типа, удовлетворяющие предикату.
    /// </summary>
    ///
    /// <typeparam name="T1">Тип модуля 1.</typeparam>
    /// <typeparam name="T2">Тип модуля 2.</typeparam>
    /// <typeparam name="T2">Тип модуля 3.</typeparam>
    ///
    /// <param name="entities">Перечень сущностей.</param>
    /// <param name="predicate">Предикат.</param>
    ///
    /// <returns>
    ///   Перечень сущностей и их модулей.
    /// </returns>
    ///
    /// <exception cref="ArgumentNullException">
    ///   Указанный перечень сущностей <paramref name="entities" /> равен <see langword="null" />.
    /// </exception>
    public static IEnumerable<EntityTuple<T1, T2, T3>> WithModules<T1, T2, T3>(
        this IEnumerable<Entity?> entities,
        Func<T1, T2, T3, bool>? predicate = null
        )
        where T1 : IModule
        where T2 : IModule
        where T3 : IModule
    {
        #region Проверка аргументов ...

        Throw.IfNull(entities);

        #endregion Проверка аргументов ...

        foreach (var entity in entities)
        {
            if (entity != null)
            {
                var (module1, module2, module3) = entity.GetModulesIfHas<T1, T2, T3>();

                if (module1 != null && module2 != null && module3 != null
                    && (predicate == null || predicate.Invoke(module1, module2, module3)))
                {
                    var tuple = new EntityTuple<T1, T2, T3>(entity, module1, module2, module3);

                    yield return tuple;
                }
            }
        }
    }

    /// <summary>
    ///   Возвращает перечень всех пар указанных сущностей.
    /// </summary>
    ///
    /// <param name="entities">Перечень сущностей.</param>
    ///
    /// <returns>
    ///   Перечень пар.
    /// </returns>
    ///
    /// <exception cref="ArgumentNullException">
    ///   Указанный перечень сущностей <paramref name="entities" /> равен <see langword="null" />.
    /// </exception>
    public static IEnumerable<(Entity Entity1, Entity Entity2)> Match(
        this IEnumerable<Entity?> entities
        )
    {
        #region Проверка аргументов ...

        Throw.IfNull(entities);

        #endregion Проверка аргументов ...

        var set = new HashSet<Entity>();

        foreach (var entity1 in entities)
        {
            if (entity1 != null)
            {
                _ = set.Add(entity1);

                foreach (var entity2 in entities)
                {
                    if (entity2 != null
                        && !set.Contains(entity2))
                    {
                        yield return (entity1, entity2);
                    }
                }
            }
        }
    }
}
