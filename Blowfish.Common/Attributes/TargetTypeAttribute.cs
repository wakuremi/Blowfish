using System;

namespace Blowfish.Common.Attributes;

/// <summary>
///   Атрибут для указания целевого типа.
/// </summary>
[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
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
    ///   Создает атрибут для указания целевого типа.
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

        Throw.IfNull(targetType);

        #endregion Проверка аргументов ...

        TargetType = targetType;
    }
}
