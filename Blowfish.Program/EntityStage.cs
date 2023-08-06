using System;
using System.Collections.Immutable;
using System.Linq;

namespace Blowfish.Program;

public sealed class EntityStage
{
    private readonly ImmutableList<IEntity> _entities;

    public EntityStage(
        IEntity[] entities
        )
    {
        #region Проверка аргументов ...

        if (entities == null)
        {
            throw new ArgumentNullException(nameof(entities), "Указанный массив сущностей равен 'null'.");
        }

        if (entities.Any(x => x == null))
        {
            throw new ArgumentException("Указанный массив сущностей содержит 'null'.", nameof(entities));
        }

        #endregion Проверка аргументов ...

        _entities = entities.ToImmutableList();
    }

    public ImmutableList<IEntitySnapshot> Update(UpdateContext context)
    {
        #region Проверка аргументов ...

        if (context == null)
        {
            throw new ArgumentNullException(nameof(context), "Указанный контекст обновления равен 'null'.");
        }

        #endregion Проверка аргументов ...

        var builder = ImmutableList.CreateBuilder<IEntitySnapshot>();

        foreach (var entity in _entities)
        {
            var snapshot = entity.Update(context);

            builder.Add(snapshot);
        }

        var snapshots = builder.ToImmutable();

        return snapshots;
    }
}
