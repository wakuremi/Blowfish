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

        if (target == null)
        {
            throw new ArgumentNullException(nameof(target), "Указанное место отрисовки равно 'null'.");
        }

        #endregion Проверка аргументов ...

        _target = target;
    }

    /// <inheritdoc />
    public void Render(IRenderable renderable)
    {
        #region Проверка аргументов ...

        if (renderable == null)
        {
            throw new ArgumentNullException(nameof(renderable), "Указанный объект для отрисовки равен 'null'.");
        }

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
    }
}
