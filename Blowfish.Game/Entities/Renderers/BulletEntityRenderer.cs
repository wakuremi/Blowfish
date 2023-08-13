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
        ITileSetFactory tileSetFactory
        )
    {
        #region Проверка аргументов ...

        if (tileSetFactory == null)
        {
            throw new ArgumentException(nameof(tileSetFactory), "Указанная фабрика наборов тайлов равна 'null'.");
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

        var x = EntityRendererHelper.GetLocationX(snapshot, context.Delta);
        var y = EntityRendererHelper.GetLocationY(snapshot, context.Delta);

        _tileSet.Render(context.Renderer, 5, x, y, 16.0F, 16.0F);
    }
}
