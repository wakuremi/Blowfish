using Blowfish.Common;
using Blowfish.Framework;
using System;
using Blowfish.Engine.Entities;

namespace Blowfish.Engine;

/// <summary>
///   Игра.
/// </summary>
public sealed class Game : IRunnable
{
    private readonly Stage _stage;

    /// <summary>
    ///   Создает игру.
    /// </summary>
    ///
    /// <param name="stage">Стейдж.</param>
    ///
    /// <exception cref="ArgumentNullException">
    ///   Указанный стейдж <paramref name="stage" /> равен <see langword="null" />.
    /// </exception>
    public Game(Stage stage)
    {
        #region Проверка аргументов ...

        Throw.IfNull(stage);

        #endregion Проверка аргументов ...

        _stage = stage;
    }

    /// <inheritdoc />
    public void Update(UpdateContext context)
    {
        _stage.Update(context);
    }

    /// <inheritdoc />
    public void Render(RenderContext context)
    {
        _stage.Render(context);
    }
}
