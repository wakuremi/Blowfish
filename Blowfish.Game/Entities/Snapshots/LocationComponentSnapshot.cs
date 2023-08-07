using Blowfish.Engine.Entities;

namespace Blowfish.Game.Entities.Snapshots;

/// <summary>
///   Снимок компонента позиции.
/// </summary>
public sealed class LocationComponentSnapshot : IComponentSnapshot
{
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
    ///   Создает снимок компонента.
    /// </summary>
    ///
    /// <param name="x">Позиция по оси X.</param>
    /// <param name="y">Позиция по оси Y.</param>
    public LocationComponentSnapshot(float x, float y)
    {
        X = x;
        Y = y;
    }
}
