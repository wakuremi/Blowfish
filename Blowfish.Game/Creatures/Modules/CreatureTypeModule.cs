using Blowfish.Engine.Entities;

namespace Blowfish.Game.Creatures.Modules;

/// <summary>
///   Модуль типа существа.
/// </summary>
public sealed class CreatureTypeModule : IModule
{
    /// <summary>
    ///   Возвращает тип существа.
    /// </summary>
    public CreatureTypeEnum Type
    {
        get;
    }

    /// <summary>
    ///   Создает модуль.
    /// </summary>
    ///
    /// <param name="type">Тип существа.</param>
    public CreatureTypeModule(CreatureTypeEnum type)
    {
        Type = type;
    }
}
