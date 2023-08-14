using Blowfish.Framework;
using System;

namespace Blowfish.Engine.Entities;

/// <summary>
///   Апдейтер сущностей.
/// </summary>
public interface IEntityUpdater
{
    /// <summary>
    ///   Выполняет обновление.
    /// </summary>
    ///
    /// <param name="context">Контекст обновления.</param>
    /// <param name="controller">Контроллер сущностей.</param>
    ///
    /// <exception cref="ArgumentNullException">
    ///   1. Указанный контекст обновления <paramref name="context" /> равен <see langword="null" />.
    ///   2. Указанный контроллер сущностей <paramref name="controller" /> равен <see langword="null" />.
    /// </exception>
    void Update(UpdateContext context, IEntityController controller);
}
