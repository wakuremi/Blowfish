using System;

namespace Blowfish.Program.Helpers;

/// <summary>
///   Атрибут для указания целевого типа.
/// </summary>
[AttributeUsage(AttributeTargets.Class)]
public sealed class TargetTypeAttribute : Attribute
{
    /// <summary>
    ///   Возвращает целевой тип.
    /// </summary>
    public Type TargetType
    {
        get;
    }

    /// <summary>
    ///   Создает новый экземпляр.
    /// </summary>
    ///
    /// <param name="targetType">Целевой тип.</param>
    ///
    /// <exception cref="ArgumentNullException">
    ///   Указанный целевой тип <paramref name="targetType" /> равен <see langword="null" />.
    /// </exception>
    public TargetTypeAttribute(Type targetType)
    {
        #region Проверка аргументов ...

        if (targetType == null)
        {
            throw new ArgumentNullException(nameof(targetType), "Указанный целевой тип равен 'null'.");
        }

        #endregion Проверка аргументов ...

        TargetType = targetType;
    }
}
