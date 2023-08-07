using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Reflection;

namespace Blowfish.Common.Attributes;

/// <summary>
///   Вспомогательный класс для работы с <see cref="TargetTypeAttribute" />.
/// </summary>
public static class TargetTypeAttributeHelper
{
    /// <summary>
    ///   Возвращает список целевых типов указанного объекта.
    /// </summary>
    ///
    /// <param name="item">Объект.</param>
    ///
    /// <returns>
    ///   Список целевых типов.
    /// </returns>
    ///
    /// <exception cref="ArgumentNullException">
    ///   Указанный объект <paramref name="item" /> равен <see langword="null" />.
    /// </exception>
    ///
    /// <exception cref="InvalidOperationException">
    ///   Ошибка получения списка целевых типов.
    /// </exception>
    public static ImmutableList<Type> GetTargetTypes(object item)
    {
        #region Проверка аргументов ...

        if (item == null)
        {
            throw new ArgumentNullException(nameof(item), "Указанный объект равен 'null'.");
        }

        #endregion Проверка аргументов ...

        ImmutableList<Type> types;

        try
        {
            types = item.GetType().GetCustomAttributes<TargetTypeAttribute>()
                .Select(x => x.TargetType)
                .ToImmutableList();
        }
        catch (Exception exception)
        {
            throw new InvalidOperationException("Ошибка получения списка целевых типов.", exception);
        }

        return types;
    }

    /// <summary>
    ///   Создает словарь, где значением является объект из списка, а ключом - соответствующий ему целевой тип.
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
    ///   1. Ошибка формирования списка атрибутов.
    ///   2. Целевой тип не указан.
    ///   3. Целевой тип фигурирует более одного раза.
    /// </exception>
    public static ImmutableDictionary<Type, T> Separate<T>(IReadOnlyList<T> items) where T : notnull
    {
        #region Проверка аргументов ...

        if (items == null)
        {
            throw new ArgumentNullException(nameof(items), "Указанный список объектов равен 'null'.");
        }

        if (items.HasNull())
        {
            throw new ArgumentException("Указанный список объектов содержит 'null'.", nameof(items));
        }

        #endregion Проверка аргументов ...

        var builder = ImmutableDictionary.CreateBuilder<Type, T>();

        foreach (var item in items)
        {
            var types = GetTargetTypes(item);

            if (types.Count <= 0)
            {
                throw new InvalidOperationException("Целевой тип не указан.");
            }

            foreach (var type in types)
            {
                if (builder.ContainsKey(type))
                {
                    throw new InvalidOperationException("Целевой тип фигурирует более одного раза.");
                }

                builder.Add(type, item);
            }
        }

        var dictionary = builder.ToImmutable();

        return dictionary;
    }
}
