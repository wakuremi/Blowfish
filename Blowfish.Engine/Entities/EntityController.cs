using Blowfish.Common;
using System.Collections.Generic;

namespace Blowfish.Engine.Entities;

/// <inheritdoc cref="IEntityController" />
public sealed class EntityController : IEntityController
{
    private readonly List<Entity> _entities;
    private readonly List<Entity> _modified;

    /// <inheritdoc />
    public IReadOnlyList<Entity> Entities => _entities;

    /// <summary>
    ///   Создает контроллер сущностей.
    /// </summary>
    public EntityController()
    {
        // Очевидно, что список сущностей будет наполняться.
        // Зададим некоторую емкость "по умолчанию".
        const int Capacity = 16;

        _entities = new List<Entity>(Capacity);
        _modified = new List<Entity>(Capacity);
    }

    /// <inheritdoc />
    public void Insert(Entity entity)
    {
        #region Проверка аргументов ...

        Throw.IfNull(entity);

        #endregion Проверка аргументов ...

        _modified.Add(entity);
    }

    /// <inheritdoc />
    public void Delete(Entity entity)
    {
        #region Проверка аргументов ...

        Throw.IfNull(entity);

        #endregion Проверка аргументов ...

        _ = _modified.Remove(entity);
    }

    /// <summary>
    ///   Фиксирует изменения.
    /// </summary>
    public void Commit()
    {
        _entities.Clear();

        for (var i = 0; i < _modified.Count; i++)
        {
            var entity = _modified[i];

            _entities.Add(entity);
        }
    }
}
