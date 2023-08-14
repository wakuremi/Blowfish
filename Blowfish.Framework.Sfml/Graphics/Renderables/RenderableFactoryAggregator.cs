using Blowfish.Common;
using Blowfish.Common.Attributes;
using Blowfish.Framework.Graphics.Renderables;
using System;
using System.Collections.Immutable;

namespace Blowfish.Framework.Sfml.Graphics.Renderables;

/// <inheritdoc cref="IRenderableFactory" />
public sealed class RenderableFactoryAggregator : IRenderableFactory
{
    private readonly ImmutableDictionary<Type, IRenderableFactory> _factories;

    /// <summary>
    ///   Создает агрегатор фабрик объектов для отрисовки.
    /// </summary>
    ///
    /// <param name="factories">Массив фабрик, для которых задан целевой тип.</param>
    ///
    /// <exception cref="ArgumentNullException">
    ///   Указанный массив фабрик <paramref name="factories" /> равен <see langword="null" />.
    /// </exception>
    ///
    /// <exception cref="ArgumentException">
    ///   Указанный массив фабрик <paramref name="factories" /> содержит <see langword="null" />.
    /// </exception>
    ///
    /// <exception cref="InvalidOperationException">
    ///   1. Ошибка формирования списка атрибутов.
    ///   2. Целевой тип не указан.
    ///   3. Целевой тип фигурирует более одного раза.
    /// </exception>
    public RenderableFactoryAggregator(
        IRenderableFactory[] factories
        )
    {
        #region Проверка аргументов ...

        Throw.IfNull(factories);
        Throw.IfHasNull(factories);

        #endregion Проверка аргументов ...

        _factories = TargetAttributeHelper.Separate<Type, IRenderableFactory>(factories);
    }

    /// <inheritdoc />
    public IRenderable Create(Type type, IRenderableFactoryArgs args)
    {
        #region Проверка аргументов ...

        Throw.IfNull(type);
        Throw.IfNull(args);

        #endregion Проверка аргументов ...

        if (!_factories.TryGetValue(type, out var factory))
        {
            throw new NotSupportedException("Указанный тип объекта для отрисовки не поддерживается.");
        }

        var renderable = factory.Create(type, args);

        return renderable;
    }
}
