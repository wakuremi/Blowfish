using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace Blowfish.Common;

/// <summary>
///   Вспомогательный класс для работы с типами.
/// </summary>
public static class TypeHelper
{
    /// <summary>
    ///   Создает словарь, где значением является объект из списка, а ключом - соответствующий ему конкретный тип.
    /// </summary>
    ///
    /// <typeparam name="T">Тип объектов.</typeparam>
    ///
    /// <param name="items">Список объектов.</param>
    ///
    /// <returns>
    ///   Словарь.
    /// </returns>
    ///
    /// <exception cref="ArgumentNullException">
    ///   Указанный список объектов <paramref name="items" /> равен <see langword="null" />.
    /// </exception>
    ///
    /// <exception cref="ArgumentException">
    ///   Указанный список объектов <paramref name="items" /> содержит <see langword="null" />.
    /// </exception>
    ///
    /// <exception cref="InvalidOperationException">
    ///   Конкретный тип фигурирует более одного раза.
    /// </exception>
    public static ImmutableDictionary<Type, T> Separate<T>(IReadOnlyList<T> items) where T : notnull
    {
        #region Проверка аргументов ...

        Throw.IfNull(items);
        Throw.IfHasNull(items);

        #endregion Проверка аргументов ...

        var builder = ImmutableDictionary.CreateBuilder<Type, T>();

        foreach (var item in items)
        {
            var type = item.GetType();

            if (builder.ContainsKey(type))
            {
                throw new InvalidOperationException("Конкретный тип фигурирует более одного раза.");
            }

            builder.Add(type, item);
        }

        var dictionary = builder.ToImmutable();

        return dictionary;
    }
}
