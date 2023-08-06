using log4net;
using System;

namespace Blowfish.Program;

/// <summary>
///   Игра.
/// </summary>
public sealed class Game
{
    private readonly Scene _scene;
    private readonly ILog _log;

    public Game(
        Scene scene,
        LogProvider logProvider
        )
    {
        #region Проверка аргументов ...

        if (scene == null)
        {
            throw new ArgumentNullException(nameof(scene), "Указанная сцена равна 'null'.");
        }

        if (logProvider == null)
        {
            throw new ArgumentNullException(nameof(logProvider), "Указанный провайдер журналов равен 'null'.");
        }

        #endregion Проверка аргументов ...

        _scene = scene;
        _log = logProvider.Get();
    }

    /// <summary>
    ///   Выполняет обновление.
    /// </summary>
    ///
    /// <param name="context">Контекст обновления.</param>
    ///
    /// <exception cref="ArgumentNullException">
    ///   Указанный контекст обновления <paramref name="context" /> равен <see langword="null" />.
    /// </exception>
    public void Update(UpdateContext context)
    {
        #region Проверка аргументов ...

        if (context == null)
        {
            throw new ArgumentNullException(nameof(context), "Указанный контекст обновления равен 'null'.");
        }

        #endregion Проверка аргументов ...

        _scene.Update(context);
    }

    /// <summary>
    ///   Выполняет отрисовку.
    /// </summary>
    ///
    /// <param name="context">Контекст отрисовки.</param>
    ///
    /// <exception cref="ArgumentNullException">
    ///   Указанный контекст отрисовки <paramref name="context" /> равен <see langword="null" />.
    /// </exception>
    public void Render(RenderContext context)
    {
        #region Проверка аргументов ...

        if (context == null)
        {
            throw new ArgumentNullException(nameof(context), "Указанный контекст отрисовки равен 'null'.");
        }

        #endregion Проверка аргументов ...

        _scene.Render(context);
    }
}
