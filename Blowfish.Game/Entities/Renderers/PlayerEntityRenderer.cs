using Blowfish.Common;
using Blowfish.Engine.Entities;
using Blowfish.Engine.Graphics;
using Blowfish.Framework;
using Blowfish.Game.Entities.Components;
using System;

namespace Blowfish.Game.Entities.Renderers;

/// <inheritdoc cref="IEntityRenderer" />
[TargetEntityType(EntityTypeEnum.Player)]
public sealed class PlayerEntityRenderer : IEntityRenderer, IDisposable
{
    private readonly TileSet _tileSet;

    /// <summary>
    ///   Создает рендерер сущностей.
    /// </summary>
    ///
    /// <param name="tileSetFactory">Фабрика наборов тайлов.</param>
    public PlayerEntityRenderer(
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

        _tileSet.Render(context.Renderer, 0, x, y, 32.0F, 32.0F);
    }

    /// <inheritdoc />
    public void Dispose()
    {
        _tileSet.Dispose();
    }
}
