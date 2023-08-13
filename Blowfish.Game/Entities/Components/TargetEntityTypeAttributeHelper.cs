using Blowfish.Common;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Reflection;

namespace Blowfish.Game.Entities.Components;

/// <summary>
///   Вспомогательный класс для работы с <see cref="TargetEntityTypeAttribute" />.
/// </summary>
public static class TargetEntityTypeAttributeHelper
{
    /// <summary>
    ///   Возвращает список целевых типов сущностей указанного объекта.
    /// </summary>
    ///
    /// <param name="item">Объект.</param>
    ///
    /// <returns>
    ///   Список целевых типов сущностей.
    /// </returns>
    ///
    /// <exception cref="ArgumentNullException">
    ///   Указанный объект <paramref name="item" /> равен <see langword="null" />.
    /// </exception>
    ///
    /// <exception cref="InvalidOperationException">
    ///   Ошибка получения списка целевых типов сущностей.
    /// </exception>
    public static ImmutableList<EntityTypeEnum> GetTargetTypes(object item)
    {
        #region Проверка аргументов ...

        Throw.IfNull(item);

        #endregion Проверка аргументов ...

        ImmutableList<EntityTypeEnum> types;

        try
        {
            types = item.GetType().GetCustomAttributes<TargetEntityTypeAttribute>()
                .Select(x => x.TargetType)
                .ToImmutableList();
        }
        catch (Exception exception)
        {
            throw new InvalidOperationException("Ошибка получения целевого типа сущности.", exception);
        }

        return types;
    }

    /// <summary>
    ///   Создает словарь, где значением является объект из списка, а ключом - соответствующий ему целевой тип сущности.
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
    ///   2. Целевой тип сущности не указан.
    ///   3. Целевой тип сущности фигурирует более одного раза.
    /// </exception>
    public static ImmutableDictionary<EntityTypeEnum, T> Separate<T>(IReadOnlyList<T> items) where T : notnull
    {
        #region Проверка аргументов ...

        Throw.IfNull(items);
        Throw.IfContainsNull(items);

        #endregion Проверка аргументов ...

        var builder = ImmutableDictionary.CreateBuilder<EntityTypeEnum, T>();

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
