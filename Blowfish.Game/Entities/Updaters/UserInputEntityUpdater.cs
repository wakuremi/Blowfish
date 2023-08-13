using Blowfish.Common;
using Blowfish.Engine.Entities;
using Blowfish.Framework;
using Blowfish.Framework.Input;
using Blowfish.Game.Entities.Components;
using System;
using System.Collections.Immutable;

namespace Blowfish.Game.Entities.Updaters;

/// <inheritdoc cref="IEntityUpdater" />
public sealed class UserInputEntityUpdater : IEntityUpdater
{
    /// <summary>
    ///   Создает апдейтер сущностей.
    /// </summary>
    public UserInputEntityUpdater()
    {
    }

    /// <inheritdoc />
    public void Update(UpdateContext context, IEntityController controller, ImmutableList<Entity> entities)
    {
        #region Проверка аргументов ...

        if (context == null)
        {
            throw new ArgumentNullException(nameof(context), "Указанный контекст обновления равен 'null'.");
        }

        if (controller == null)
        {
            throw new ArgumentNullException(nameof(controller), "Указанный контроллер сущностей равен 'null'.");
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

        var x = 0;
        var y = 0;

        var keyboard = context.Keyboard;

        if (keyboard.IsKeyPressed(KeyEnum.A))
        {
            x -= 8;
        }

        if (keyboard.IsKeyPressed(KeyEnum.D))
        {
            x += 8;
        }

        if (keyboard.IsKeyPressed(KeyEnum.W))
        {
            y -= 8;
        }

        if (keyboard.IsKeyPressed(KeyEnum.S))
        {
            y += 8;
        }

        var players = entities.With<EntityTypeComponent>(x => x.Type == EntityTypeEnum.Player);

        foreach (var player in players.With<VelocityComponent>())
        {
            var velocityComponent = player.GetComponentOrThrow<VelocityComponent>();

            velocityComponent.X = x;
            velocityComponent.Y = y;
        }
    }
}
