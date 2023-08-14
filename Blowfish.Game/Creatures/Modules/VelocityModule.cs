using Blowfish.Engine.Entities;

namespace Blowfish.Game.Creatures.Modules;

/// <summary>
///   Модуль скорости.
/// </summary>
public sealed class VelocityModule : IModule
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
    ///   Создает модуль.
    /// </summary>
    public VelocityModule()
    {
    }
}
