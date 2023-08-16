using Blowfish.Common;
using Blowfish.Common.Attributes;
using Blowfish.Engine.Entities;
using Blowfish.Engine.Extensions;
using Blowfish.Framework;
using Blowfish.Game.Creatures.Modules;
using Blowfish.Game.Creatures.Renderers;
using System;

namespace Blowfish.Game.Creatures;

/// <inheritdoc cref="IEntityRenderer" />
[Target<EntityTypeEnum>(EntityTypeEnum.Creature)]
public sealed class CreatureEntityRenderer : IEntityRenderer
{
    private readonly ICreatureRenderer _renderer;

    /// <summary>
    ///   Создает рендерер сущностей.
    /// </summary>
    ///
    /// <param name="renderer">Рендерер существ.</param>
    ///
    /// <exception cref="ArgumentNullException">
    ///   Указанный рендерер существ <paramref name="renderer" /> равен <see langword="null" />.
    /// </exception>
    public CreatureEntityRenderer(
        ICreatureRenderer renderer
        )
    {
        #region Проверка аргументов ...

        Throw.IfNull(renderer);

        #endregion Проверка аргументов ...

        _renderer = renderer;
    }

    /// <inheritdoc />
    public void Render(RenderContext context, Entity entity)
    {
        #region Проверка аргументов ...

        Throw.IfNull(entity);

        #endregion Проверка аргументов ...

        var delta = context.Delta;

        var bounds = entity.GetModule<BoundsModule>();

        var bx = bounds.X;
        var by = bounds.Y;

        var track = entity.GetModuleIfHas<TrackModule>();

        float x;

        if (track != null
            && track.X.HasValue)
        {
            var tx = track.X.Value;

            x = tx + (bx - tx) * delta;
        }
        else
        {
            x = bx;
        }

        float y;

        if (track != null
            && track.Y.HasValue)
        {
            var ty = track.Y.Value;

            y = ty + (by - ty) * delta;
        }
        else
        {
            y = by;
        }

        _renderer.Render(context, entity, x, y, bounds.Width, bounds.Height);
    }
}
