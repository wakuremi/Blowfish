using Blowfish.Engine.Entities;

namespace Blowfish.Game.Entities.Components;

/// <summary>
///   Компонент позиции.
/// </summary>
public sealed class LocationComponent : IComponent
{
    /// <summary>
    ///   Возвращает или устанавливает позицию по оси X.
    /// </summary>
    public float X
    {
        get;
        set;
    }

    /// <summary>
    ///   Возвращает или устанавливает позицию по оси Y.
    /// </summary>
    public float Y
    {
        get;
        set;
    }

    /// <summary>
    ///   Создает компонент.
    /// </summary>
    public LocationComponent()
    {
    }
}
