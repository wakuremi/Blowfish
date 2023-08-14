using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Reflection;

namespace Blowfish.Common.Attributes;

/// <summary>
///   Содержит вспомогательные методы для работы с <see cref="TargetAttribute{T}" />.
/// </summary>
public static class TargetAttributeHelper
{
    /// <summary>
    ///   Возвращает список целей указанного объекта.
    /// </summary>
    ///
    /// <typeparam name="TTarget">Тип цели.</typeparam>
    /// <typeparam name="TSource">Тип объекта.</typeparam>
    ///
    /// <param name="source">Объект.</param>
    ///
    /// <returns>
    ///   Список целей.
    /// </returns>
    ///
    /// <exception cref="InvalidOperationException">
    ///   Ошибка получения списка целей.
    /// </exception>
    public static ImmutableList<TTarget> GetTargets<TTarget, TSource>(
        TSource source
        )
        where TTarget : notnull
        where TSource : notnull
    {
        #region Проверка аргументов ...

        Throw.IfNull(source);

        #endregion Проверка аргументов ...

        ImmutableList<TTarget> targets;

        try
        {
            targets = source.GetType().GetCustomAttributes<TargetAttribute<TTarget>>()
                .Select(x => x.Target)
                .ToImmutableList();
        }
        catch (Exception exception)
        {
            throw new InvalidOperationException("Ошибка получения списка целей.", exception);
        }

        return targets;
    }

    /// <summary>
    ///   Разделяет указанные объекты по соответствующим им целям.
    /// </summary>
    ///
    /// <typeparam name="TTarget">Тип цели.</typeparam>
    /// <typeparam name="TSource">Тип объекта.</typeparam>
    ///
    /// <param name="sources">Список объектов.</param>
    ///
    /// <returns>
    ///   Словарь, где ключом является цель, а значением - соответствующий ей объект.
    /// </returns>
    ///
    /// <exception cref="InvalidOperationException">
    ///   Цель фигурирует более одного раза.
    /// </exception>
    public static ImmutableDictionary<TTarget, TSource> Separate<TTarget, TSource>(
        IReadOnlyList<TSource> sources
        )
        where TTarget : notnull
        where TSource : notnull
    {
        #region Проверка аргументов ...

        Throw.IfNull(sources);
        Throw.IfHasNull(sources);

        #endregion Проверка аргументов ...

        var dictionary = sources
            .SelectMany(
                x => GetTargets<TTarget, TSource>(x)
                    .Select(y => (Target: y, Source: x))
                )
            .GroupBy(x => x.Target)
            .ToImmutableDictionary(
                x => x.Key,
                x => x.Select(x => x.Source).Single()
                );

        return dictionary;
    }
}
