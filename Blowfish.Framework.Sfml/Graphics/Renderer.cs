using Blowfish.Common;
using Blowfish.Framework.Graphics;
using Blowfish.Framework.Graphics.Renderables;
using SFML.Graphics;
using SFML.System;
using System;

namespace Blowfish.Framework.Sfml.Graphics;

/// <inheritdoc cref="IRenderer" />
public sealed class Renderer : IRenderer
{
    private readonly RenderTarget _target;
    private readonly View _view;

    /// <summary>
    ///   Создает рендерер.
    /// </summary>
    ///
    /// <param name="target">Место отрисовки.</param>
    /// <param name="view">Представление.</param>
    ///
    /// <exception cref="ArgumentNullException">
    ///   1. Указанное место отрисовки <paramref name="target" /> равно <see langword="null" />.
    ///   2. Указанное представление <paramref name="view" /> равно <see langword="null" />.
    /// </exception>
    public Renderer(RenderTarget target, View view)
    {
        #region Проверка аргументов ...

        Throw.IfNull(target);
        Throw.IfNull(view);

        #endregion Проверка аргументов ...

        _target = target;
        _view = view;
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

    /// <inheritdoc />
    public void Translate(float x, float y)
    {
        try
        {
            var offset = new Vector2f(x, y);

            _view.Move(offset);

            _target.SetView(_view);
        }
        catch (Exception exception)
        {
            throw new InvalidOperationException("Ошибка перемещения.", exception);
        }
    }
}
