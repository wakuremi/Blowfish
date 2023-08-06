using System;
using System.Reflection;

namespace Blowfish.Program.Helpers;

/// <summary>
///   Вспомогательный класс для работы с атрибутами.
/// </summary>
public static class AttributeHelper
{
    /// <summary>
    ///   Возвращает атрибут указанного типа <typeparamref name="T" />, которым помечен указанный тип <paramref name="type" />.
    /// </summary>
    ///
    /// <typeparam name="T">Тип атрибута.</typeparam>
    ///
    /// <param name="type">Тип.</param>
    ///
    /// <returns>
    ///   Атрибут.
    /// </returns>
    ///
    /// <exception cref="ArgumentNullException">
    ///   Указанный тип <paramref name="type" /> равен <see langword="null" />.
    /// </exception>
    ///
    /// <exception cref="InvalidOperationException">
    ///   Не удалось получить атрибут.
    /// </exception>
    public static T GetAttribute<T>(Type type) where T : Attribute
    {
        #region Проверка аргументов ...

        if (type == null)
        {
            throw new ArgumentNullException(nameof(type), "Указанный тип равен 'null'.");
        }

        #endregion Проверка аргументов ...

        T? attribute;

        try
        {
            attribute = type.GetCustomAttribute<T>();
        }
        catch (Exception exception)
        {
            // Вероятно, внутри конструктора атрибута было брошено исключение или атрибутов указанного типа несколько.
            throw new InvalidOperationException("Не удалось получить атрибут.", exception);
        }

        if (attribute == null)
        {
            // Вероятно, указанный тип не помечен атрибутом указанного типа.
            throw new InvalidOperationException("Не удалось получить атрибут.");
        }

        return attribute;
    }
}
