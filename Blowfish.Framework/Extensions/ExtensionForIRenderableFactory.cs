using Blowfish.Common;
using Blowfish.Framework.Graphics.Renderables;
using System;

namespace Blowfish.Framework.Extensions;

/// <summary>
///   Содержит методы-расширения для <see cref="IRenderableFactory" />.
/// </summary>
public static class ExtensionForIRenderableFactory
{
    /// <summary>
    ///   Создает объект для отрисовки.
    /// </summary>
    ///
    /// <typeparam name="T">Тип объекта для отрисовки.</typeparam>
    ///
    /// <param name="factory">Фабрика.</param>
    /// <param name="args">Аргументы.</param>
    ///
    /// <returns>
    ///   Объект для отрисовки.
    /// </returns>
    ///
    /// <exception cref="ArgumentNullException">
    ///   Указанная фабрика <paramref name="factory" /> равна <see langword="null" />.
    /// </exception>
    ///
    /// <exception cref="NotSupportedException">
    ///   1. Указанный тип объекта для отрисовки не поддерживается.
    ///   2. Указанные аргументы не соответствуют типу создаваемого объекта.
    /// </exception>
    ///
    /// <exception cref="InvalidOperationException">
    ///   Ошибка создания объекта.
    /// </exception>
    public static T Create<T>(this IRenderableFactory factory, IRenderableFactoryArgs? args = null) where T : IRenderable
    {
        #region Проверка аргументов ...

        Throw.IfNull(factory);

        #endregion Проверка аргументов ...

        var type = typeof(T);

        var renderable = factory.Create(type, args ?? EmptyRenderableFactoryArgs.Instance);

        return (T) renderable;
    }
}
