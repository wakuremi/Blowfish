using Blowfish.Common;
using Blowfish.Engine.Entities;
using Blowfish.Game.Entities.Snapshots;
using System;

namespace Blowfish.Game.Entities.Renderers;

/// <summary>
///   Содержит вспомогательные мтеоды для работы с <see cref="IEntityRenderer" />.
/// </summary>
public sealed class EntityRendererHelper
{
    /// <summary>
    ///   Возвращает интерполированную позицию по оси X для указанного снимка сущности.
    /// </summary>
    ///
    /// <param name="entitySnapshot">Снимок сущности.</param>
    /// <param name="delta">Дельта времени.</param>
    ///
    /// <returns>
    ///   Позиция по оси X.
    /// </returns>
    ///
    /// <exception cref="ArgumentNullException">
    ///   Указанный снимок сущности <paramref name="entitySnapshot" /> равен <see langword="null" />.
    /// </exception>
    ///
    /// <exception cref="NotSupportedException">
    ///   Отсутствует снимок компонента позиции.
    /// </exception>
    ///
    /// <remarks>
    ///   Если в указанном снимке сущности нет компонента предыдущей позиции, то будет возвращена неинтерполированная позиция.
    /// </remarks>
    public static float GetLocationX(EntitySnapshot entitySnapshot, float delta)
    {
        #region Проверка аргументов ...

        Throw.IfNull(entitySnapshot);

        #endregion Проверка аргументов ...

        var locationComponentSnapshot = entitySnapshot.GetComponentSnapshot<LocationComponentSnapshot>();

        if (locationComponentSnapshot == null)
        {
            throw new NotSupportedException("Отсутствует снимок компонента позиции.");
        }

        var previousLocationComponentSnapshot = entitySnapshot.GetComponentSnapshot<PreviousLocationComponentSnapshot>();

        if (previousLocationComponentSnapshot == null
            || !previousLocationComponentSnapshot.X.HasValue)
        {
            return locationComponentSnapshot.X;
        }

        return previousLocationComponentSnapshot.X.Value
            + (locationComponentSnapshot.X - previousLocationComponentSnapshot.X.Value) * delta;
    }

    /// <summary>
    ///   Возвращает интерполированную позицию по оси Y для указанного снимка сущности.
    /// </summary>
    ///
    /// <param name="entitySnapshot">Снимок сущности.</param>
    /// <param name="delta">Дельта времени.</param>
    ///
    /// <returns>
    ///   Позиция по оси Y.
    /// </returns>
    ///
    /// <exception cref="ArgumentNullException">
    ///   Указанный снимок сущности <paramref name="entitySnapshot" /> равен <see langword="null" />.
    /// </exception>
    ///
    /// <exception cref="NotSupportedException">
    ///   Отсутствует снимок компонента позиции.
    /// </exception>
    ///
    /// <remarks>
    ///   Если в указанном снимке сущности нет компонента предыдущей позиции, то будет возвращена неинтерполированная позиция.
    /// </remarks>
    public static float GetLocationY(EntitySnapshot entitySnapshot, float delta)
    {
        #region Проверка аргументов ...

        Throw.IfNull(entitySnapshot);

        #endregion Проверка аргументов ...

        var locationComponentSnapshot = entitySnapshot.GetComponentSnapshot<LocationComponentSnapshot>();

        if (locationComponentSnapshot == null)
        {
            throw new NotSupportedException("Отсутствует снимок компонента позиции.");
        }

        var previousLocationComponentSnapshot = entitySnapshot.GetComponentSnapshot<PreviousLocationComponentSnapshot>();

        if (previousLocationComponentSnapshot == null
            || !previousLocationComponentSnapshot.Y.HasValue)
        {
            return locationComponentSnapshot.Y;
        }

        return previousLocationComponentSnapshot.Y.Value
            + (locationComponentSnapshot.Y - previousLocationComponentSnapshot.Y.Value) * delta;
    }
}
