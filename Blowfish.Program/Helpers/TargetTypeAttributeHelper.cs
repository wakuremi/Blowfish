using System;

namespace Blowfish.Program.Helpers;

/// <summary>
///   Вспомогательный класс для работы с <see cref="TargetTypeAttribute" />.
/// </summary>
public static class TargetTypeAttributeHelper
{
    /// <summary>
    ///   Возвращает целевой тип из атрибута, которым помечен класс указанного объекта.
    /// </summary>
    ///
    /// <param name="obj">Объект.</param>
    ///
    /// <returns>
    ///   Целевой тип.
    /// </returns>
    ///
    /// <exception cref="ArgumentNullException">
    ///   Указанный объект <paramref name="obj" /> равен <see langword="null" />.
    /// </exception>
    public static Type? GetTargetType(object obj)
    {
        #region Проверка аргументов ...

        if (obj == null)
        {
            throw new ArgumentNullException(nameof(obj), "Указанный объект равен 'null'.");
        }

        #endregion Проверка аргументов ...

        var type = obj.GetType();

        TargetTypeAttribute attribute;

        try
        {
            attribute = AttributeHelper.GetAttribute<TargetTypeAttribute>(type);
        }
        catch (InvalidOperationException)
        {
            return null;
        }

        var targetType = attribute.TargetType;

        return targetType;
    }
}
