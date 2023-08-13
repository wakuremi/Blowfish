﻿using Blowfish.Common;
using System;

namespace Blowfish.Engine.Entities;

/// <summary>
///   Содержит методы-расширения для <see cref="Entity" />.
/// </summary>
public static class ExtensionsForEntity
{
    /// <summary>
    ///   Возвращает компонент указанного типа.
    /// </summary>
    ///
    /// <typeparam name="T">Тип.</typeparam>
    ///
    /// <returns>
    ///   Компонент или <see langword="null" />, если таковой отсутствует.
    /// </returns>
    ///
    /// <exception cref="ArgumentNullException">
    ///   Указанная сущность <paramref name="entity" /> равна <see langword="null" />.
    /// </exception>
    public static T? GetComponent<T>(this Entity entity) where T : IComponent
    {
        #region Проверка аргументов ...

        Throw.IfNull(entity);

        #endregion Проверка аргументов ...

        var type = typeof(T);

        if (!entity.Components.TryGetValue(type, out var component))
        {
            return default;
        }

        return (T) component;
    }
}
