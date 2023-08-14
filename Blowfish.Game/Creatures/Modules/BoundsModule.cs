using Blowfish.Engine.Entities;

namespace Blowfish.Game.Creatures.Modules;

/// <summary>
///   Модуль границ.
/// </summary>
public sealed class BoundsModule : IModule
{
    /// <summary>
    ///   Возвращает ширину.
    /// </summary>
    public float Width
    {
        get;
    }

    /// <summary>
    ///   Возвращает высоту.
    /// </summary>
    public float Height
    {
        get;
    }

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
    ///   Создает модуль.
    /// </summary>
    ///
    /// <param name="width">Ширина.</param>
    /// <param name="height">Высота.</param>
    public BoundsModule(
        float width,
        float height
        )
    {
        Width = width;
        Height = height;
    }
}
