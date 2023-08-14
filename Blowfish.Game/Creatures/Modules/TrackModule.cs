using Blowfish.Engine.Entities;

namespace Blowfish.Game.Creatures.Modules;

/// <inheritdoc cref="IModule" />
public sealed class TrackModule : IModule
{
    /// <summary>
    ///   Возвращает или устанавливает след по оси X или <see langword="null" />, если отсутствует.
    /// </summary>
    public float? X
    {
        get;
        set;
    }

    /// <summary>
    ///   Возвращает или устанавливает след по оси Y или <see langword="null" />, если отсутствует.
    /// </summary>
    public float? Y
    {
        get;
        set;
    }

    /// <summary>
    ///   Создает модуль.
    /// </summary>
    public TrackModule()
    {
    }
}
