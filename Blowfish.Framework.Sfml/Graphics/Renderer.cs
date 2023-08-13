using Blowfish.Common;
using Blowfish.Framework.Graphics;
using Blowfish.Framework.Graphics.Renderables;
using SFML.Graphics;
using System;

namespace Blowfish.Framework.Sfml.Graphics;

/// <inheritdoc cref="IRenderer" />
public sealed class Renderer : IRenderer
{
    private readonly RenderTarget _target;

    /// <summary>
    ///   Создает рендерер.
    /// </summary>
    ///
    /// <param name="target">Место отрисовки.</param>
    ///
    /// <exception cref="ArgumentNullException">
    ///   Указанное место отрисовки <paramref name="target" /> равно <see langword="null" />.
    /// </exception>
    public Renderer(RenderTarget target)
    {
        #region Проверка аргументов ...

        Throw.IfNull(target);

        #endregion Проверка аргументов ...

        _target = target;
    }

    /// <inheritdoc />
    public void Render(IRenderable renderable)
    {
        #region Проверка аргументов ...

        Throw.IfNull(renderable);

        #endregion Проверка аргументов ...

        // Все местные реализации "IRenderable" должны реализовывать и "Drawable", чтобы быть нарисованными здесь.
        // Если на вход пришло что-то инородное, то ничего не делаем.
        // Кривовато, но как сделать лучше - пока не придумал.
        if (renderable is Drawable drawable)
        {
            try
            {
                _target.Draw(drawable);
            }
            catch (Exception exception)
            {
                throw new InvalidOperationException("Ошибка отрисовки.", exception);
            }
        }
        else
        {
            throw new InvalidOperationException($"Ошибка отрисовки: указанный объект не реализует {nameof(Drawable)}.");
        }
    }
}
