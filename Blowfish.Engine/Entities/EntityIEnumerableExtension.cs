using Blowfish.Common;
using System;
using System.Collections.Generic;

namespace Blowfish.Engine.Entities;

/// <summary>
///   Вспомогательный класс для <see cref="IEnumerable{T}" />.
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
    ///
    /// <exception cref="InvalidOperationException">
    ///  Указанный перечень сущностей содержит <see langword="null" />.
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

    public static IEnumerable<Entity> With<T>(this IEnumerable<Entity?> entities)
    {
        var t = typeof(T);

        var enumerable = With(entities, t);

        return enumerable;
    }

    public static IEnumerable<Entity> With<T1, T2>(this IEnumerable<Entity?> entities)
    {
        var t1 = typeof(T1);
        var t2 = typeof(T2);

        var enumerable = With(entities, t1, t2);

        return enumerable;
    }
}
