using Blowfish.Engine.Entities;

namespace Blowfish.Engine.Extensions;

/// <summary>
///   Сущность и ее модули.
/// </summary>
///
/// <typeparam name="T">Тип модуля.</typeparam>
///
/// <param name="Entity">Сущность.</param>
/// <param name="Module">Модуль.</param>
public record struct EntityTuple<T>(Entity Entity, T Module);

/// <summary>
///   Сущность и ее модули.
/// </summary>
///
/// <typeparam name="T1">Тип модуля 1.</typeparam>
/// <typeparam name="T2">Тип модуля 2.</typeparam>
///
/// <param name="Entity">Сущность.</param>
/// <param name="Module1">Модуль 1.</param>
/// <param name="Module2">Модуль 2.</param>
public record struct EntityTuple<T1, T2>(Entity Entity, T1 Module1, T2 Module2);

/// <summary>
///   Сущность и ее модули.
/// </summary>
///
/// <typeparam name="T1">Тип модуля 1.</typeparam>
/// <typeparam name="T2">Тип модуля 2.</typeparam>
///
/// <param name="Entity">Сущность.</param>
/// <param name="Module1">Модуль 1.</param>
/// <param name="Module2">Модуль 2.</param>
public record struct EntityTuple<T1, T2, T3>(Entity Entity, T1 Module1, T2 Module2, T3 Module);
