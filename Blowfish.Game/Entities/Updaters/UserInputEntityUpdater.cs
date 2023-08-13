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
    private const float AccelerationX = 1.25F;
    private const float AccelerationY = 1.25F;

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

        var x = 0.0F;
        var y = 0.0F;

        var keyboard = context.Keyboard;

        if (keyboard.IsKeyPressed(KeyEnum.A))
        {
            x -= AccelerationX;
        }

        if (keyboard.IsKeyPressed(KeyEnum.D))
        {
            x += AccelerationX;
        }

        if (keyboard.IsKeyPressed(KeyEnum.W))
        {
            y -= AccelerationY;
        }

        if (keyboard.IsKeyPressed(KeyEnum.S))
        {
            y += AccelerationY;
        }

        var updatables = entities
            .With<EntityTypeComponent>(x => x.Type == EntityTypeEnum.Player)
            .WithComponent<AccelerationComponent>();

        foreach (var (_, acceleration) in updatables)
        {
            acceleration.X = x;
            acceleration.Y = y;
        }
    }
}
