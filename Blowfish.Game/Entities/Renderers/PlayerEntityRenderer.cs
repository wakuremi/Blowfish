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
        ITileSetFactory tileSetFactory
        )
    {
        #region Проверка аргументов ...

        if (tileSetFactory == null)
        {
            throw new ArgumentNullException(nameof(tileSetFactory), "Указанная фабрика наборов тайлов равна 'null'.");
        }

        #endregion Проверка аргументов ...

        _tileSet = tileSetFactory.Create("Assets/Sprites.png", 16, 16);
    }

    /// <inheritdoc />
    public void Render(RenderContext context, EntitySnapshot snapshot)
    {
        #region Проверка аргументов ...

        if (context == null)
        {
            throw new ArgumentNullException(nameof(context), "Указанный контекст отрисовки равен 'null'.");
        }

        if (snapshot == null)
        {
            throw new ArgumentNullException(nameof(snapshot), "Указанный снимок сущности равен 'null'.");
        }

        #endregion Проверка аргументов ...

        var x = EntityRendererHelper.GetX(snapshot, context.Delta);
        var y = EntityRendererHelper.GetY(snapshot, context.Delta);

        _tileSet.Render(context.Renderer, 0, x, y, 32.0F, 32.0F);
    }

    /// <inheritdoc />
    public void Dispose()
    {
        _tileSet.Dispose();
    }
}
