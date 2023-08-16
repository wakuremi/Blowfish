using Blowfish.Common;
using Blowfish.Common.Attributes;
using Blowfish.Engine.Entities;
using Blowfish.Engine.Graphics;
using Blowfish.Framework;
using System;

namespace Blowfish.Game.Creatures.Renderers;

/// <inheritdoc cref="ICreatureRenderer" />
[Target<CreatureTypeEnum>(CreatureTypeEnum.Player)]
public sealed class PlayerCreatureRenderer : ICreatureRenderer
{
    private readonly SpriteSheet _spriteSheet;

    /// <summary>
    ///   Создает рендерер существ.
    /// </summary>
    ///
    /// <param name="spriteSheet">Набор спрайтов.</param>
    ///
    /// <exception cref="ArgumentNullException">
    ///   Указанный набор спрайтов <paramref name="spriteSheet" /> равен <see langword="null" />.
    /// </exception>
    public PlayerCreatureRenderer(SpriteSheet spriteSheet)
    {
        #region Проверка аргументов ...

        Throw.IfNull(spriteSheet);

        #endregion Проверка аргументов ...

        _spriteSheet = spriteSheet;
    }

    /// <inheritdoc />
    public void Render(RenderContext context, Entity entity, float x, float y, float width, float height)
    {
        #region Проверка аргументов ...

        Throw.IfNull(entity);

        #endregion Проверка аргументов ...

        _spriteSheet.Render(context.Renderer, 0, x, y, width, height);
    }
}
