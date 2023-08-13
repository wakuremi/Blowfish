using Blowfish.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Blowfish.Engine.Entities;

/// <summary>
///   Содержит методы-расширения для <see cref="IEnumerable{T}" />, состоящего из элементов типа <see cref="Entity" />.
/// </summary>
public static class EntityIEnumerableExtension
{
    /// <summary>
    ///   Возвращает из указанного перечня сущности, у которых есть компоненты указанного типа, которые удовлетворяют
    ///   указанному предикату (если он указан).
    /// </summary>
    ///
    /// <typeparam name="T">Тип компонента.</typeparam>
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
        this IEnumerable<Entity?> entities,
        Func<T, bool>? predicate = null
        )
        where T : IComponent
    {
        return entities
            .WithComponent(predicate)
            .Select(x => x.Entity);
    }

    /// <summary>
    ///   Возвращает из указанного перечня сущности, у которых есть компоненты указанных типов, которые удовлетворяют
    ///   указанному предикату (если он указан).
    /// </summary>
    ///
    /// <typeparam name="T1">Тип компонента 1.</typeparam>
    /// <typeparam name="T2">Тип компонента 2.</typeparam>
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
        this IEnumerable<Entity?> entities,
        Func<T1, T2, bool>? predicate = null
        )
        where T1 : IComponent
        where T2 : IComponent
    {
        return entities
            .WithComponent(predicate)
            .Select(x => x.Entity);
    }

    /// <summary>
    ///   Возвращает из указанного перечня сущности, у которых есть компоненты указанного типа, которые удовлетворяют
    ///   указанному предикату (если он указан).
    /// </summary>
    ///
    /// <typeparam name="T">Тип компонента.</typeparam>
    ///
    /// <param name="entities">Перечень сущностей.</param>
    /// <param name="predicate">Предикат.</param>
    ///
    /// <returns>
    ///   Перечень сущностей и компонентов указанного типа.
    /// </returns>
    ///
    /// <exception cref="ArgumentNullException">
    ///   Указанный перечень сущностей <paramref name="entities" /> равен <see langword="null" />.
    /// </exception>
    public static IEnumerable<(Entity Entity, T Component)> WithComponent<T>(
        this IEnumerable<Entity?> entities,
        Func<T, bool>? predicate = null
        )
        where T : IComponent
    {
        #region Проверка аргументов ...

        Throw.IfNull(entities);

        #endregion Проверка аргументов ...

        foreach (var entity in entities)
        {
            if (entity != null)
            {
                var component = entity.GetComponent<T>();

                if (component != null
                    && (predicate == null || predicate.Invoke(component)))
                {
                    yield return (entity, component);
                }
            }
        }
    }

    /// <summary>
    ///   Возвращает из указанного перечня сущности, у которых есть компоненты указанных типов, которые удовлетворяют
    ///   указанному предикату (если он указан).
    /// </summary>
    ///
    /// <typeparam name="T1">Тип компонента 1.</typeparam>
    /// <typeparam name="T2">Тип компонента 2.</typeparam>
    ///
    /// <param name="entities">Перечень сущностей.</param>
    /// <param name="predicate">Предикат.</param>
    ///
    /// <returns>
    ///   Перечень сущностей и компонентов указанных типов.
    /// </returns>
    ///
    /// <exception cref="ArgumentNullException">
    ///   Указанный перечень сущностей <paramref name="entities" /> равен <see langword="null" />.
    /// </exception>
    public static IEnumerable<(Entity Entity, T1 Component1, T2 Component2)> WithComponent<T1, T2>(
        this IEnumerable<Entity?> entities,
        Func<T1, T2, bool>? predicate = null
        )
        where T1 : IComponent
        where T2 : IComponent
    {
        #region Проверка аргументов ...

        Throw.IfNull(entities);

        #endregion Проверка аргументов ...

        foreach (var entity in entities)
        {
            if (entity != null)
            {
                var component1 = entity.GetComponent<T1>();
                var component2 = entity.GetComponent<T2>();

                if (component1 != null && component2 != null
                    && (predicate == null || predicate.Invoke(component1, component2)))
                {
                    yield return (entity, component1, component2);
                }
            }
        }
    }
}
