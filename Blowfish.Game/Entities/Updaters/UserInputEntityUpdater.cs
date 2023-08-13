using Blowfish.Common;
using Blowfish.Engine.Entities;
using Blowfish.Framework;
using Blowfish.Framework.Input;
using Blowfish.Game.Entities.Components;
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

        Throw.IfNull(context);
        Throw.IfNull(controller);
        Throw.IfNull(entities);
        Throw.IfContainsNull(entities);

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

        foreach (var (_, velocity) in players.WithComponent<VelocityComponent>())
        {
            velocity.X = x;
            velocity.Y = y;
        }
    }
}
