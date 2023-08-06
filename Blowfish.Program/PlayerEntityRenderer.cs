using Blowfish.Program.Helpers;
using SFML.System;
using System;

namespace Blowfish.Program;

/// <inheritdoc cref="IEntityRenderer" />
[TargetType(typeof(PlayerEntitySnapshot))]
public sealed class PlayerEntityRenderer : IEntityRenderer
{
    private readonly TileSet _tileSet;

    /// <summary>
    ///   Создает новый экземпляр.
    /// </summary>
    ///
    /// <param name="tileSet">Набор тайлов.</param>
    ///
    /// <exception cref="ArgumentNullException">
    ///   Указанный набор тайлов <paramref name="tileSet" /> равен <see langword="null" />.
    /// </exception>
    public PlayerEntityRenderer(
        TileSet tileSet
        )
    {
        #region Проверка аргументов ...

        if (tileSet == null)
        {
            throw new ArgumentNullException(nameof(tileSet), "Указанный набор тайлов равен 'null'.");
        }

        #endregion Проверка аргументов ...

        _tileSet = tileSet;
    }

    /// <inheritdoc />
    public void Render(RenderContext context, IEntitySnapshot snapshot, Vector2f position)
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

        _tileSet.Draw(context.Target, 0, position, new Vector2f(2.0F, 2.0F));
    }
}
