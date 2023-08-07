using Blowfish.Engine.Entities;

namespace Blowfish.Game.Entities.Components;

/// <summary>
///   Компонент типа сущности.
/// </summary>
public sealed class EntityTypeComponent : IComponent, IComponentSnapshot
{
    /// <summary>
    ///   Возвращает тип сущности.
    /// </summary>
    public EntityTypeEnum Type
    {
        get;
    }

    /// <summary>
    ///   Создает компонент.
    /// </summary>
    ///
    /// <param name="type">Тип сущности.</param>
    public EntityTypeComponent(EntityTypeEnum type)
    {
        Type = type;
    }
}
