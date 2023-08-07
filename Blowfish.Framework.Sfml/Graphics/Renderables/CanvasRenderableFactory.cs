using Blowfish.Common.Attributes;
using Blowfish.Framework.Graphics.Renderables;
using System;

namespace Blowfish.Framework.Sfml.Graphics.Renderables;

/// <inheritdoc cref="IRenderableFactory" />
[TargetType(typeof(ICanvasRenderable))]
public sealed class CanvasRenderableFactory : IRenderableFactory
{
    private readonly IRendererFactory _rendererFactory;

    /// <summary>
    ///   Создает фабрику холстов.
    /// </summary>
    ///
    /// <param name="rendererFactory">Фабрика рендереров.</param>
    ///
    /// <exception cref="ArgumentNullException">
    ///   Указанная фабрика рендереров <paramref name="rendererFactory" /> равна <see langword="null" />.
    /// </exception>
    public CanvasRenderableFactory(
        IRendererFactory rendererFactory
        )
    {
        #region Проверка аргументов ...

        if (rendererFactory == null)
        {
            throw new ArgumentNullException(nameof(rendererFactory), "Указанная фабрика рендереров равна 'null'.");
        }

        #endregion Проверка аргументов ...

        _rendererFactory = rendererFactory;
    }

    /// <inheritdoc />
    public IRenderable Create(Type type, IRenderableFactoryArgs args)
    {
        #region Проверка аргументов ...

        if (type == null)
        {
            throw new ArgumentNullException(nameof(type), "Указанный тип объекта для отрисовки равен 'null'.");
        }

        if (args == null)
        {
            throw new ArgumentNullException(nameof(args), "Указанные аргументы равны 'null'.");
        }

        #endregion Проверка аргументов ...

        if (type != typeof(ICanvasRenderable))
        {
            throw new NotSupportedException("Указанный тип объекта для отрисовки не поддерживается.");
        }

        if (args is not CanvasRenderableFactoryArgs args0)
        {
            throw new NotSupportedException("Указанные аргументы не соответствуют типу создаваемого объекта.");
        }

        CanvasRenderable result;

        try
        {
            result = new CanvasRenderable(_rendererFactory, args0.Width, args0.Height);
        }
        catch (Exception exception)
        {
            throw new InvalidOperationException("Ошибка создания объекта.", exception);
        }

        return result;
    }
}
