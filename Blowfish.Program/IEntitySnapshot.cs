using SFML.System;
using System;

namespace Blowfish.Program;

/// <summary>
///   Снимок сущности.
/// </summary>
public interface IEntitySnapshot
{
    /// <summary>
    ///   Возвращает идентификатор сущности.
    /// </summary>
    Guid EntityGuid
    {
        get;
    }

    /// <summary>
    ///   Возвращает позицию.
    /// </summary>
    Vector2f Position
    {
        get;
    }
}
