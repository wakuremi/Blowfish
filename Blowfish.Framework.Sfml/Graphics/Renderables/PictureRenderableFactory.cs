﻿using Blowfish.Common.Attributes;
using Blowfish.Framework.Graphics.Renderables;
using System;

namespace Blowfish.Framework.Sfml.Graphics.Renderables;

/// <inheritdoc cref="IRenderableFactory" />
[TargetType(typeof(IPictureRenderable))]
public sealed class PictureRenderableFactory : IRenderableFactory
{
    /// <summary>
    ///   Создает фабрику картинок.
    /// </summary>
    public PictureRenderableFactory()
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

        if (type != typeof(IPictureRenderable))
        {
            throw new NotSupportedException("Указанный тип объекта для отрисовки не поддерживается.");
        }

        if (args is not PictureRenderableFactoryArgs args0)
        {
            throw new NotSupportedException("Указанные аргументы не соответствуют типу создаваемого объекта.");
        }

        PictureRenderable result;

        try
        {
            result = new PictureRenderable(args0.FilePath);
        }
        catch (Exception exception)
        {
            throw new InvalidOperationException("Ошибка создания объекта.", exception);
        }

        return result;
    }
}
