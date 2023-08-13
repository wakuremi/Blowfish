using Blowfish.Engine.Entities;

namespace Blowfish.Game.Entities.Components;

/// <summary>
///   Компонент стрельбы.
/// </summary>
public sealed class FireComponent : IComponent
{
    /// <summary>
    ///   Возвращает или устанавливает кулдаун.
    /// </summary>
    public int Cooldown
    {
        get;
        set;
    }

    /// <summary>
    ///   Создает новый экземпляр.
    /// </summary>
    public FireComponent()
    {
    }
}
