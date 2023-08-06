using SFML.System;
using SFML.Window;
using System;

namespace Blowfish.Program;

/// <inheritdoc cref="IEntity" />
public sealed class PlayerEntity : IEntity
{
    private readonly Guid _entityGuid = Guid.NewGuid();

    private Vector2f _position;

    /// <summary>
    ///   Создает новый экземпляр.
    /// </summary>
    ///
    /// <param name="position">Позиция.</param>
    public PlayerEntity(
        Vector2f position
        )
    {
        _position = position;
    }

    /// <inheritdoc />
    public IEntitySnapshot Update(UpdateContext context)
    {
        #region Проверка аргументов ...

        if (context == null)
        {
            throw new ArgumentNullException(nameof(context), "Указанный контекст обновления равен 'null'.");
        }

        #endregion Проверка аргументов ...

        var dx = 0;
        var dy = 0;

        var input = context.UserInput;

        if (input.IsKeyPressed(Keyboard.Key.A))
        {
            dx -= 8;
        }

        if (input.IsKeyPressed(Keyboard.Key.D))
        {
            dx += 8;
        }

        if (input.IsKeyPressed(Keyboard.Key.W))
        {
            dy -= 8;
        }

        if (input.IsKeyPressed(Keyboard.Key.S))
        {
            dy += 8;
        }

        _position.X += dx;
        _position.Y += dy;

        var snapshot = new PlayerEntitySnapshot(_entityGuid, _position);

        return snapshot;
    }
}
