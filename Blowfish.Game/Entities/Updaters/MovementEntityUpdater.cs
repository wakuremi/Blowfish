using Blowfish.Common;
using Blowfish.Engine.Entities;
using Blowfish.Framework;
using Blowfish.Framework.Input;
using Blowfish.Game.Entities.Components;
using System;
using System.Collections.Immutable;

namespace Blowfish.Game.Entities.Updaters;

/// <inheritdoc cref="IEntityUpdater" />
public sealed class MovementEntityUpdater : IEntityUpdater
{
    /// <summary>
    ///   Создает апдейтер сущностей.
    /// </summary>
    public MovementEntityUpdater()
    {
    }

    /// <inheritdoc />
    public void Update(UpdateContext context, ImmutableList<Entity> entities)
    {
        #region Проверка аргументов ...

        if (context == null)
        {
            throw new ArgumentNullException(nameof(context), "Указанный контекст обновления равен 'null'.");
        }

        if (entities == null)
        {
            throw new ArgumentNullException(nameof(entities), "Указанный список сущностей равен 'null'.");
        }

        if (entities.HasNull())
        {
            throw new ArgumentException("Указанный список сущностей содержит 'null'.", nameof(entities));
        }

        #endregion Проверка аргументов ...

        var dx = 0;
        var dy = 0;

        var keyboard = context.Keyboard;

        if (keyboard.IsKeyPressed(KeyEnum.A))
        {
            dx -= 8;
        }

        if (keyboard.IsKeyPressed(KeyEnum.D))
        {
            dx += 8;
        }

        if (keyboard.IsKeyPressed(KeyEnum.W))
        {
            dy -= 8;
        }

        if (keyboard.IsKeyPressed(KeyEnum.S))
        {
            dy += 8;
        }

        foreach (var entity in entities.With<LocationComponent>())
        {
            var location = entity.GetComponentOrThrow<LocationComponent>();

            location.X += dx;
            location.Y += dy;
        }
    }
}
