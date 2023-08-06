using SFML.Graphics;
using System;

namespace Blowfish.Program;

/// <summary>
///   Контекст отрисовки.
/// </summary>
public sealed class RenderContext
{
    /// <summary>
    ///   Возвращает место отрисовки.
    /// </summary>
    public RenderTarget Target
    {
        get;
    }

    /// <summary>
    ///   Возвращает нормализованное время, которое прошло с момента предыдущего обновления.
    /// </summary>
    public float Delta
    {
        get;
    }

    /// <summary>
    ///   Создает новый экземпляр.
    /// </summary>
    ///
    /// <param name="target">Место отрисовки.</param>
    /// <param name="delta">Нормализованное время, которое прошло с момента предыдущего обновления.</param>
    ///
    /// <exception cref="ArgumentNullException">
    ///   Указанное место отрисовки <paramref name="target" /> равно <see langword="null" />.
    /// </exception>
    public RenderContext(
        RenderTarget target,
        float delta
        )
    {
        #region Проверка аргументов ...

        if (target == null)
        {
            throw new ArgumentNullException(nameof(target), "Указанное место отрисовки равно 'null'.");
        }

        #endregion Проверка аргументов ...

        Target = target;
        Delta = delta;
    }
}
