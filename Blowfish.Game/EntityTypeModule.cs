using Blowfish.Engine.Entities;

namespace Blowfish.Game;

/// <summary>
///   Модуль типа сущности.
/// </summary>
public sealed class EntityTypeModule : IModule
{
    /// <summary>
    ///   Возвращает тип сущности.
    /// </summary>
    public EntityTypeEnum Type
    {
        get;
    }

    /// <summary>
    ///   Создает модуль.
    /// </summary>
    ///
    /// <param name="type">Тип сущности.</param>
    public EntityTypeModule(EntityTypeEnum type)
    {
        Type = type;
    }
}
