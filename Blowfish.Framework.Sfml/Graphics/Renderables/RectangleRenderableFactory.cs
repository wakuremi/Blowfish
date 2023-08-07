using Blowfish.Common.Attributes;
using Blowfish.Framework.Graphics.Renderables;
using System;

namespace Blowfish.Framework.Sfml.Graphics.Renderables;

/// <inheritdoc cref="IRenderableFactory" />
[TargetType(typeof(IRectangleRenderable))]
public sealed class RectangleRenderableFactory : IRenderableFactory
{
    /// <summary>
    ///   Создает фабрику прямоугольников.
    /// </summary>
    public RectangleRenderableFactory()
    {
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

        if (type != typeof(IRectangleRenderable))
        {
            throw new NotSupportedException("Указанный тип объекта для отрисовки не поддерживается.");
        }

        if (args is not EmptyRenderableFactoryArgs)
        {
            throw new NotSupportedException("Указанные аргументы не соответствуют типу создаваемого объекта.");
        }

        RectangleRenderable result;

        try
        {
            result = new RectangleRenderable();
        }
        catch (Exception exception)
        {
            throw new InvalidOperationException("Ошибка создания объекта.", exception);
        }

        return result;
    }
}
