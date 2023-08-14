using Blowfish.Engine.Entities;

namespace Blowfish.Game.Creatures;

/// <summary>
///   Снимок существа.
/// </summary>
public sealed class CreatureSnapshot : ISnapshot
{
    /// <summary>
    ///   Возвращает тип существа.
    /// </summary>
    public CreatureTypeEnum Type
    {
        get;
    }

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
    ///   Возвращает позицию по оси X.
    /// </summary>
    public float X
    {
        get;
    }

    /// <summary>
    ///   Возвращает позицию по оси Y.
    /// </summary>
    public float Y
    {
        get;
    }

    /// <summary>
    ///   Возвращает след по оси X или <see langword="null" />, если отсутствует.
    /// </summary>
    public float? TrackX
    {
        get;
    }

    /// <summary>
    ///   Возвращает след по оси Y или <see langword="null" />, если отсутствует.
    /// </summary>
    public float? TrackY
    {
        get;
    }

    /// <summary>
    ///   Создает снимок.
    /// </summary>
    ///
    /// <param name="type">Тип существа.</param>
    /// <param name="width">Ширина.</param>
    /// <param name="height">Высота.</param>
    /// <param name="x">Позиция по оси X.</param>
    /// <param name="y">Позиция по оси Y.</param>
    /// <param name="trackX">След по оси Y или <see langword="null" />, если отсутствует.</param>
    /// <param name="trackY">След по оси Y или <see langword="null" />, если отсутствует..</param>
    public CreatureSnapshot(
        CreatureTypeEnum type,
        float width,
        float height,
        float x,
        float y,
        float? trackX,
        float? trackY
        )
    {
        Type = type;
        Width = width;
        Height = height;
        X = x;
        Y = y;
        TrackX = trackX;
        TrackY = trackY;
    }
}
