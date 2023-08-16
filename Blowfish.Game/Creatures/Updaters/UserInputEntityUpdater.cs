using Blowfish.Common;
using Blowfish.Engine.Entities;
using Blowfish.Engine.Extensions;
using Blowfish.Framework;
using Blowfish.Framework.Input;
using Blowfish.Game.Creatures.Modules;

namespace Blowfish.Game.Creatures.Updaters;

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
    public void Update(UpdateContext context, IEntityController controller)
    {
        #region Проверка аргументов ...

        Throw.IfNull(controller);

        #endregion Проверка аргументов ...

        const float Velocity = 8.0F;

        var x = 0.0F;
        var y = 0.0F;

        var keyboard = context.Keyboard;

        if (keyboard.IsKeyPressed(KeyEnum.A))
        {
            x -= Velocity;
        }

        if (keyboard.IsKeyPressed(KeyEnum.D))
        {
            x += Velocity;
        }

        if (keyboard.IsKeyPressed(KeyEnum.W))
        {
            y -= Velocity;
        }

        if (keyboard.IsKeyPressed(KeyEnum.S))
        {
            y += Velocity;
        }

        var updatables = controller.Entities
            .With<CreatureTypeModule>(x => x.Type == CreatureTypeEnum.Player)
            .WithModules<VelocityModule>();

        foreach (var (_, velocity) in updatables)
        {
            velocity.X = x;
            velocity.Y = y;
        }
    }
}
