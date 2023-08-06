using System;

namespace Blowfish.Program;

/// <summary>
///   Сущность.
/// </summary>
public interface IEntity
{
    /// <summary>
    ///   Выполняет обновление.
    /// </summary>
    ///
    /// <param name="context">Контекст обновления.</param>
    ///
    /// <returns>
    ///   Снимок сущности.
    /// </returns>
    ///
    /// <exception cref="ArgumentNullException">
    ///   Указанный контекст обновления <paramref name="context" /> равен <see langword="null" />.
    /// </exception>
    IEntitySnapshot Update(UpdateContext context);
}
