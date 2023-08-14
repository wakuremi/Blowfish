using Blowfish.Common;
using System.Collections.Immutable;

namespace Blowfish.Engine.Entities;

/// <inheritdoc cref="IEntityController" />
public sealed class EntityController : IEntityController
{
    private ImmutableList<Entity> _modified;

    /// <inheritdoc />
    public ImmutableList<Entity> Entities
    {
        get;
        private set;
    }

    public EntityController()
    {
        _modified = ImmutableList<Entity>.Empty;

        Entities = ImmutableList<Entity>.Empty;
    }

    /// <inheritdoc />
    public void Insert(Entity entity)
    {
        #region Проверка аргументов ...

        Throw.IfNull(entity);

        #endregion Проверка аргументов ...

        _modified = _modified.Add(entity);
    }

    /// <inheritdoc />
    public void Delete(Entity entity)
    {
        #region Проверка аргументов ...

        Throw.IfNull(entity);

        #endregion Проверка аргументов ...

        _modified = _modified.Remove(entity);
    }

    /// <summary>
    ///   Фиксирует изменения.
    /// </summary>
    public void Commit()
    {
        Entities = _modified;
    }
}
