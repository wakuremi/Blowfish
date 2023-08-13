using Blowfish.Engine.Entities;

namespace Blowfish.Game.Entities.Components;

/// <summary>
///   Компонент ускорения.
/// </summary>
public sealed class AccelerationComponent : IComponent
{
    /// <summary>
    ///   Возвращает или устанавливает ускорение по оси X.
    /// </summary>
    public float X
    {
        get;
        set;
    }

    /// <summary>
    ///   Возвращает или устанавливает ускорение по оси Y.
    /// </summary>
    public float Y
    {
        get;
        set;
    }

    /// <summary>
    ///   Создает компонент.
    /// </summary>
    public AccelerationComponent()
    {
    }
}
