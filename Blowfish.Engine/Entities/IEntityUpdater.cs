﻿using Blowfish.Framework;
using System;
using System.Collections.Immutable;

namespace Blowfish.Engine.Entities;

/// <summary>
///   Апдейтер сущностей.
/// </summary>
public interface IEntityUpdater
{
    /// <summary>
    ///   Обновляет указанные сущности.
    /// </summary>
    ///
    /// <param name="context">Контекст обновления.</param>
    /// <param name="controller">Контроллер сущностей.</param>
    /// <param name="entities">Список сущностей.</param>
    ///
    /// <exception cref="ArgumentNullException">
    ///   1. Указанный контекст обновления <paramref name="context" /> равен <see langword="null" />.
    ///   2. Указанный контроллер сущностей <paramref name="controller" /> равен <see langword="null" />.
    ///   3. Указанный список сущностей <paramref name="entities" /> равен <see langword="null" />.
    /// </exception>
    ///
    /// <exception cref="ArgumentException">
    ///   Указанный список сущностей <paramref name="entities" /> содержит <see langword="null" />.
    /// </exception>
    void Update(UpdateContext context, IEntityController controller, ImmutableList<Entity> entities);
}
