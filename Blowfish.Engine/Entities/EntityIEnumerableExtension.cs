using Blowfish.Common;
using System;
using System.Collections.Generic;

namespace Blowfish.Engine.Entities;

/// <summary>
///   Содержит методы-расширения для <see cref="IEnumerable{T}" />, состоящего из элементов типа <see cref="Entity" />.
/// </summary>
public static class EntityIEnumerableExtension
{
    /// <summary>
    ///   Возвращает из указанного перечня сущности, которые имеют компоненты указанных типов.
    /// </summary>
    ///
    /// <param name="entities">Перечень сущностей.</param>
    /// <param name="types">Массив типов.</param>
    ///
    /// <returns>
    ///   Перечень сущностей.
    /// </returns>
    ///
    /// <exception cref="ArgumentNullException">
    ///   1. Указанный перечень сущностей <paramref name="entities" /> равен <see langword="null" />.
    ///   2. Указанный массив типов <paramref name="types" /> равен <see langword="null" />.
    /// </exception>
    ///
    /// <exception cref="ArgumentException">
    ///   Указанный массив типов <paramref name="types" /> содержит <see langword="null" />.
    /// </exception>
    public static IEnumerable<Entity> With(this IEnumerable<Entity?> entities, params Type[] types)
    {
        #region Проверка аргументов ...

        if (entities == null)
        {
            throw new ArgumentNullException(nameof(entities), "Указанный перечень сущностей равен 'null'.");
        }

        if (types == null)
        {
            throw new ArgumentNullException(nameof(types), "Указанный массив типов равен 'null'.");
        }

        if (types.HasNull())
        {
            throw new ArgumentException("Указанный массив типов содержит 'null'.", nameof(types));
        }

        #endregion Проверка аргументов ...

        if (types.Length <= 0)
        {
            yield break;
        }

        foreach (var entity in entities)
        {
            if (entity == null)
            {
                continue;
            }

            var isSuitable = true;

            foreach (var type in types)
            {
                isSuitable &= entity.Components.ContainsKey(type);
            }

            if (isSuitable)
            {
                yield return entity;
            }
        }
    }

    /// <summary>
    ///   Возвращает из указанного перечня сущности, которые имеют компонент указанного типа.
    /// </summary>
    ///
    /// <typeparam name="T">Тип компонента.</typeparam>
    ///
    /// <param name="entities">Перечень сущностей.</param>
    ///
    /// <returns>
    ///   Перечень сущностей.
    /// </returns>
    ///
    /// <exception cref="ArgumentNullException">
    ///   Указанный перечень сущностей <paramref name="entities" /> равен <see langword="null" />.
    /// </exception>
    public static IEnumerable<Entity> With<T>(this IEnumerable<Entity?> entities)
        where T : IComponent
    {
        var t = typeof(T);

        var enumerable = With(entities, t);

        return enumerable;
    }

    /// <summary>
    ///   Возвращает из указанного перечня сущности, которые имеют компоненты указанных типов.
    /// </summary>
    ///
    /// <typeparam name="T1">Тип компонента 1.</typeparam>
    /// <typeparam name="T2">Тип компонента 2.</typeparam>
    ///
    /// <param name="entities">Перечень сущностей.</param>
    ///
    /// <returns>
    ///   Перечень сущностей.
    /// </returns>
    ///
    /// <exception cref="ArgumentNullException">
    ///   Указанный перечень сущностей <paramref name="entities" /> равен <see langword="null" />.
    /// </exception>
    ///
    /// <exception cref="ArgumentException">
    ///   Указанный массив типов <paramref name="types" /> содержит <see langword="null" />.
    /// </exception>
    public static IEnumerable<Entity> With<T1, T2>(this IEnumerable<Entity?> entities)
        where T1 : IComponent
        where T2 : IComponent
    {
        var t1 = typeof(T1);
        var t2 = typeof(T2);

        var enumerable = With(entities, t1, t2);

        return enumerable;
    }

    /// <summary>
    ///   Возвращает из указанного перечня сущности, которые имеют компонент указанного типа, удовлетворяющий указанному предикату.
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
    ///   1. Указанный перечень сущностей <paramref name="entities" /> равен <see langword="null" />.
    ///   2. Указанный предикат <paramref name="predicate" /> равен <see langword="null" />.
    /// </exception>
    public static IEnumerable<Entity> With<T>(
        this IEnumerable<Entity?> entities,
        Func<T, bool> predicate
        )
        where T : IComponent
    {
        #region Проверка аргументов ...

        if (entities == null)
        {
            throw new ArgumentNullException(nameof(entities), "Указанный перечень сущностей равен 'null'.");
        }

        if (predicate == null)
        {
            throw new ArgumentNullException(nameof(predicate), "Указанный предикат равен 'null'.");
        }

        #endregion Проверка аргументов ...

        foreach (var entity in entities)
        {
            if (entity == null)
            {
                continue;
            }

            var component = entity.GetComponent<T>();

            if (component == null
                || !predicate.Invoke(component))
            {
                continue;
            }

            yield return entity;
        }
    }
}
