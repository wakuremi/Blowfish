using Blowfish.Common;
using Blowfish.Engine.Entities;
using Blowfish.Engine.Graphics;
using Blowfish.Framework;
using Blowfish.Game.Entities.Components;
using System;

namespace Blowfish.Game.Entities.Renderers;

/// <inheritdoc cref="IEntityRenderer" />
[TargetEntityType(EntityTypeEnum.Bullet)]
public sealed class BulletEntityRenderer : IEntityRenderer
{
    private readonly TileSet _tileSet;

    /// <summary>
    ///   Создает рендерер сущностей.
    /// </summary>
    ///
    /// <param name="tileSetFactory">Фабрика наборов тайлов.</param>
    ///
    /// <exception cref="ArgumentNullException">
    ///   Указанная фабрика наборов тайлов <paramref name="tileSetFactory" /> равна <see langword="null" />.
    /// </exception>
    public BulletEntityRenderer(
        TileSetFactory tileSetFactory
        )
    {
        #region Проверка аргументов ...

        Throw.IfNull(tileSetFactory);

        #endregion Проверка аргументов ...

        _tileSet = tileSetFactory.Create("Assets/Sprites.png", 16, 16);
    }

    /// <inheritdoc />
    public void Render(RenderContext context, EntitySnapshot snapshot)
    {
        #region Проверка аргументов ...

        Throw.IfNull(context);
        Throw.IfNull(snapshot);

        #endregion Проверка аргументов ...

        var x = EntityRendererHelper.GetLocationX(snapshot, context.Delta);
        var y = EntityRendererHelper.GetLocationY(snapshot, context.Delta);

        _tileSet.Render(context.Renderer, 5, x, y, 16.0F, 16.0F);
    }
}
