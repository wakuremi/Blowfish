using Blowfish.Engine.Entities;

namespace Blowfish.Game.Entities.Components;

/// <summary>
///   Компонент скорости.
/// </summary>
public sealed class VelocityComponent : IComponent
{
    /// <summary>
    ///   Возвращает или устанавливает скорость по оси X.
    /// </summary>
    public float X
    {
        get;
        set;
    }

    /// <summary>
    ///   Возвращает или устанавливает скорость по оси Y.
    /// </summary>
    public float Y
    {
        get;
        set;
    }

    /// <summary>
    ///   Создает новый экземпляр.
    /// </summary>
    public VelocityComponent()
    {
    }
}
