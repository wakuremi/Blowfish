using SFML.System;
using System;

namespace Blowfish.Program;

/// <inheritdoc cref="IEntitySnapshot" />
public sealed class PlayerEntitySnapshot : IEntitySnapshot
{
    /// <inheritdoc />
    public Guid EntityGuid
    {
        get;
    }

    /// <inheritdoc />
    public Vector2f Position
    {
        get;
    }

    /// <summary>
    ///   Создает новый экземпляр.
    /// </summary>
    ///
    /// <param name="entityGuid">Идентификатор сущности.</param>
    /// <param name="position">Позиция.</param>
    public PlayerEntitySnapshot(
        Guid entityGuid,
        Vector2f position
        )
    {
        EntityGuid = entityGuid;
        Position = position;
    }
}
