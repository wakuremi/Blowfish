using System;
using System.Collections.Generic;

namespace Blowfish.Common;

/// <summary>
///   Вспомогательный класс для работы с коллекциями.
/// </summary>
public static class CollectionHelper
{
    /// <summary>
    ///   Определяет, есть ли в указанном списке <see langword="null" />.
    /// </summary>
    ///
    /// <typeparam name="T">Тип элементов в списке.</typeparam>
    ///
    /// <param name="list">Список.</param>
    ///
    /// <returns>
    ///   <see langword="true" />, если есть; иначе <see langword="null" />.
    /// </returns>
    ///
    /// <exception cref="ArgumentNullException">
    ///   Указанный список <paramref name="list" /> равен <see langword="null" />.
    /// </exception>
    public static bool HasNull<T>(this IReadOnlyList<T> list)
    {
        #region Проверка аргументов ...

        if (list == null)
        {
            throw new ArgumentNullException(nameof(list), "Указанный список равен 'null'.");
        }

        #endregion Проверка аргументов ...

        for (var i = 0; i < list.Count; i++)
        {
            if (list[i] == null)
            {
                return true;
            }
        }

        return false;
    }
}
