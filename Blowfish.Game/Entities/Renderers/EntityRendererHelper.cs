using Blowfish.Engine.Entities;
using Blowfish.Game.Entities.Snapshots;
using System;

namespace Blowfish.Game.Entities.Renderers;

public sealed class EntityRendererHelper
{
    public static float GetX(EntitySnapshot entitySnapshot, float delta)
    {
        #region Проверка аргументов ...

        if (entitySnapshot == null)
        {
            throw new ArgumentNullException(nameof(entitySnapshot), "Указанный снимок сущности равен 'null'.");
        }

        #endregion Проверка аргументов ...

        var locationComponentSnapshot = entitySnapshot.GetComponentSnapshot<LocationComponentSnapshot>();

        if (locationComponentSnapshot == null)
        {
            throw new NotSupportedException("Указанный снимок сущности не поддерживается: отсутствует снимок компонента позиции.");
        }

        var previousLocationComponentSnapshot = entitySnapshot.GetComponentSnapshot<PreviousLocationComponentSnapshot>();

        if (previousLocationComponentSnapshot == null)
        {
            return locationComponentSnapshot.X;
        }

        return previousLocationComponentSnapshot.X
            + (locationComponentSnapshot.X - previousLocationComponentSnapshot.X) * delta;
    }

    public static float GetY(EntitySnapshot entitySnapshot, float delta)
    {
        #region Проверка аргументов ...

        if (entitySnapshot == null)
        {
            throw new ArgumentNullException(nameof(entitySnapshot), "Указанный снимок сущности равен 'null'.");
        }

        #endregion Проверка аргументов ...

        var locationComponentSnapshot = entitySnapshot.GetComponentSnapshot<LocationComponentSnapshot>();

        if (locationComponentSnapshot == null)
        {
            throw new NotSupportedException("Указанный снимок сущности не поддерживается: отсутствует снимок компонента позиции.");
        }

        var previousLocationComponentSnapshot = entitySnapshot.GetComponentSnapshot<PreviousLocationComponentSnapshot>();

        if (previousLocationComponentSnapshot == null)
        {
            return locationComponentSnapshot.Y;
        }

        return previousLocationComponentSnapshot.Y
            + (locationComponentSnapshot.Y - previousLocationComponentSnapshot.Y) * delta;
    }
}
