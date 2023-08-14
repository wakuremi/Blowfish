using Blowfish.Common;
using System.Collections.Generic;
using System.Collections.Immutable;
using System;

namespace Blowfish.Engine.Entities;

/// <summary>
///   Сущность.
/// </summary>
public sealed class Entity
{
    /// <summary>
    ///   Возвращает словарь модулей.
    /// </summary>
    public ImmutableDictionary<Type, IModule> Modules
    {
        get;
    }

    /// <summary>
    ///   Создает сущность.
    /// </summary>
    ///
    /// <param name="modules">Список модулей.</param>
    ///
    /// <exception cref="ArgumentNullException">
    ///   Указанный список модулей <paramref name="modules" /> равен <see langword="null" />.
    /// </exception>
    ///
    /// <exception cref="ArgumentException">
    ///   Указанный список модулей <paramref name="modules" /> содержит <see langword="null" />.
    /// </exception>
    ///
    /// <exception cref="InvalidOperationException">
    ///   Указано несколько модулей одного и того же типа.
    /// </exception>
    public Entity(
        IReadOnlyList<IModule> modules
        )
    {
        #region Проверка аргументов ...

        Throw.IfNull(modules);
        Throw.IfHasNull(modules);

        #endregion Проверка аргументов ...

        Modules = TypeHelper.Separate(modules);
    }
}
