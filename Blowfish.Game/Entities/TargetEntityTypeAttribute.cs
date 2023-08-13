using System;

namespace Blowfish.Game.Entities;

/// <summary>
///   Атрибут для указания целевого типа сущности.
/// </summary>
[AttributeUsage(AttributeTargets.Class)]
public sealed class TargetEntityTypeAttribute : Attribute
{
    /// <summary>
    ///   Возвращает целевой тип сущности.
    /// </summary>
    public EntityTypeEnum TargetType
    {
        get;
    }

    /// <summary>
    ///   Создает атрибут для указания целевого типа сущности.
    /// </summary>
    ///
    /// <param name="targetType">Целевой тип сущности.</param>
    public TargetEntityTypeAttribute(EntityTypeEnum targetType)
    {
        TargetType = targetType;
    }
}
