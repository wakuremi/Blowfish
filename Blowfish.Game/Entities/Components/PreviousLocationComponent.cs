using Blowfish.Engine.Entities;

namespace Blowfish.Game.Entities.Components;

/// <summary>
///   Компонент предыдущей позиции.
/// </summary>
public sealed class PreviousLocationComponent : IComponent
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
    public PreviousLocationComponent()
    {
    }
}
