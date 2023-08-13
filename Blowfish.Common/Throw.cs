using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Blowfish.Common;

/// <summary>
///   Вспомогательный класс для проверки аргументов.
/// </summary>
public static class Throw
{
    /// <summary>
    ///   Бросает исключение, если указанное значение равно <see langword="null" />.
    /// </summary>
    ///
    /// <param name="value">Значение.</param>
    /// <param name="name">Имя.</param>
    ///
    /// <exception cref="ArgumentNullException">
    ///   Указанное значение <paramref name="name" /> равно <see langword="null" />.
    /// </exception>
    public static void IfNull(
        object value,
        [CallerArgumentExpression(nameof(value))] string? name = null
        )
    {
        if (value is null)
        {
            throw new ArgumentNullException(name, "Указанное значение равно 'null'.");
        }
    }

    /// <summary>
    ///   Бросает исключение, если указанный список содержит <see langword="null" />.
    /// </summary>
    ///
    /// <typeparam name="T">Тип элементов списка.</typeparam>
    ///
    /// <param name="list">Список.</param>
    /// <param name="name">Имя.</param>
    ///
    /// <exception cref="NullReferenceException">
    ///   Указанный список <paramref name="list" /> равен <see langword="null" />.
    /// </exception>
    ///
    /// <exception cref="ArgumentException">
    ///   Указанный список <paramref name="list" /> содержит <see langword="null" />.
    /// </exception>
    public static void IfContainsNull<T>(
        IReadOnlyList<T> list,
        [CallerArgumentExpression(nameof(list))] string? name = null
        )
    {
        for (var i = 0; i < list.Count; i++)
        {
            if (list[i] is null)
            {
                throw new ArgumentException("Указанный список содержит 'null'.", name);
            }
        }
    }

    /// <summary>
    ///   Бросает исключение, если одно значение меньше другого.
    /// </summary>
    ///
    /// <typeparam name="T">Тип значений.</typeparam>
    ///
    /// <param name="value">Значение.</param>
    /// <param name="other">Другое значение.</param>
    /// <param name="name">Имя.</param>
    ///
    /// <exception cref="NullReferenceException">
    ///   Указанное значение <paramref name="value" /> равно <see langword="null" />.
    /// </exception>
    ///
    /// <exception cref="ArgumentException">
    ///   Указанное значение <paramref name="value" /> меньше другого <paramref name="other" />.
    /// </exception>
    public static void IfLess<T>(
        IComparable<T> value,
        T? other,
        [CallerArgumentExpression(nameof(value))] string? name = null
        )
    {
        if (value.CompareTo(other) < 0)
        {
            throw new ArgumentException($"Указанное значение {value} меньше {other}.", name);
        }
    }

    /// <summary>
    ///   Бросает исключение, если одно значение меньше другого или равно ему.
    /// </summary>
    ///
    /// <typeparam name="T">Тип значений.</typeparam>
    ///
    /// <param name="value">Значение.</param>
    /// <param name="other">Другое значение.</param>
    /// <param name="name">Имя.</param>
    ///
    /// <exception cref="NullReferenceException">
    ///   Указанное значение <paramref name="value" /> равно <see langword="null" />.
    /// </exception>
    ///
    /// <exception cref="ArgumentException">
    ///   Указанное значение <paramref name="value" /> меньше другого <paramref name="other" />.
    /// </exception>
    public static void IfLessOrEqual<T>(
        IComparable<T> value,
        T? other,
        [CallerArgumentExpression(nameof(value))] string? name = null
        )
    {
        if (value.CompareTo(other) <= 0)
        {
            throw new ArgumentException($"Указанное значение {value} меньше {other} или равно ему.", name);
        }
    }

    /// <summary>
    ///   Бросает исключение, если одно значение больше другого.
    /// </summary>
    ///
    /// <typeparam name="T">Тип значений.</typeparam>
    ///
    /// <param name="value">Значение.</param>
    /// <param name="other">Другое значение.</param>
    /// <param name="name">Имя.</param>
    ///
    /// <exception cref="NullReferenceException">
    ///   Указанное значение <paramref name="value" /> равно <see langword="null" />.
    /// </exception>
    ///
    /// <exception cref="ArgumentException">
    ///   Указанное значение <paramref name="value" /> больше другого <paramref name="other" />.
    /// </exception>
    public static void IfGreater<T>(
        IComparable<T> value,
        T? other,
        [CallerArgumentExpression(nameof(value))] string? name = null
        )
    {
        if (value.CompareTo(other) > 0)
        {
            throw new ArgumentException($"Указанное значение {value} больше {other}.", name);
        }
    }

    /// <summary>
    ///   Бросает исключение, если одно значение больше другого или равно ему.
    /// </summary>
    ///
    /// <typeparam name="T">Тип значений.</typeparam>
    ///
    /// <param name="value">Значение.</param>
    /// <param name="other">Другое значение.</param>
    /// <param name="name">Имя.</param>
    ///
    /// <exception cref="NullReferenceException">
    ///   Указанное значение <paramref name="value" /> равно <see langword="null" />.
    /// </exception>
    ///
    /// <exception cref="ArgumentException">
    ///   Указанное значение <paramref name="value" /> больше другого <paramref name="other" />.
    /// </exception>
    public static void IfGreaterOrEqual<T>(
        IComparable<T> value,
        T? other,
        [CallerArgumentExpression(nameof(value))] string? name = null
        )
    {
        if (value.CompareTo(other) >= 0)
        {
            throw new ArgumentException($"Указанное значение {value} больше {other} или равно ему.", name);
        }
    }

    /// <summary>
    ///   Бросает исключение, если одно значение равно другому.
    /// </summary>
    ///
    /// <typeparam name="T">Тип значений.</typeparam>
    ///
    /// <param name="value">Значение.</param>
    /// <param name="other">Другое значение.</param>
    /// <param name="name">Имя.</param>
    ///
    /// <exception cref="NullReferenceException">
    ///   Указанное значение <paramref name="value" /> равно <see langword="null" />.
    /// </exception>
    ///
    /// <exception cref="ArgumentException">
    ///   Указанное значение <paramref name="value" /> равно другому <paramref name="other" />.
    /// </exception>
    public static void IfEqual<T>(
        IComparable<T> value,
        T? other,
        [CallerArgumentExpression(nameof(value))] string? name = null
        )
    {
        if (value.CompareTo(other) != 0)
        {
            throw new ArgumentException($"Указанное значение {value} равно {other}.", name);
        }
    }

    /// <summary>
    ///   Бросает исключение, если одно значение не равно другому.
    /// </summary>
    ///
    /// <typeparam name="T">Тип значений.</typeparam>
    ///
    /// <param name="value">Значение.</param>
    /// <param name="other">Другое значение.</param>
    /// <param name="name">Имя.</param>
    ///
    /// <exception cref="NullReferenceException">
    ///   Указанное значение <paramref name="value" /> равно <see langword="null" />.
    /// </exception>
    ///
    /// <exception cref="ArgumentException">
    ///   Указанное значение <paramref name="value" /> не равно другому <paramref name="other" />.
    /// </exception>
    public static void IfNotEqual<T>(
        IComparable<T> value,
        T? other,
        [CallerArgumentExpression(nameof(value))] string? name = null
        )
    {
        if (value.CompareTo(other) == 0)
        {
            throw new ArgumentException($"Указанное значение {value} не равно {other}.", name);
        }
    }

    /// <summary>
    ///   Бросает исключение, если указанное значение находится вне указанного диапазона.
    /// </summary>
    ///
    /// <typeparam name="T">Тип значений.</typeparam>
    ///
    /// <param name="value">Значение.</param>
    /// <param name="a">Начало диапазона.</param>
    /// <param name="b">Конец диапазона (не включается).</param>
    /// <param name="name">Имя.</param>
    ///
    /// <exception cref="NullReferenceException">
    ///   Указанное значение <paramref name="value" /> равно <see langword="null" />.
    /// </exception>
    ///
    /// <exception cref="ArgumentOutOfRangeException">
    ///   Указанное значение <paramref name="value" /> меньше <paramref name="a" /> или больше или равно <paramref name="b" />.
    /// </exception>
    public static void IfNotWithin<T>(
        IComparable<T> value,
        T? a,
        T? b,
        [CallerArgumentExpression(nameof(value))] string? name = null
        )
    {
        if (value.CompareTo(a) < 0
            || value.CompareTo(b) >= 0)
        {
            throw new ArgumentOutOfRangeException(name, $"Указанное значение {value} меньше {a} или больше или равно {b}.");
        }
    }
}
