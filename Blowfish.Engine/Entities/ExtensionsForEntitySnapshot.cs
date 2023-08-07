using System;

namespace Blowfish.Engine.Entities;

/// <summary>
///   Содержит методы-расширения для <see cref="EntitySnapshot" />.
/// </summary>
public static class ExtensionsForEntitySnapshot
{
    /// <summary>
    ///   Возвращает снимок компонента указанного типа.
    /// </summary>
    ///
    /// <typeparam name="T">Тип.</typeparam>
    ///
    /// <returns>
    ///   Снимок компонента или <see langword="null" />, если таковой отсутствует.
    /// </returns>
    ///
    /// <exception cref="ArgumentNullException">
    ///   Указанный снимок сущности <paramref name="snapshot" /> равен <see langword="null" />.
    /// </exception>
    public static T? GetComponentSnapshot<T>(this EntitySnapshot snapshot) where T : IComponentSnapshot
    {
        #region Проверка аргументов ...

        if (snapshot == null)
        {
            throw new ArgumentNullException(nameof(snapshot), "Указанная сущность равна 'null'.");
        }

        #endregion Проверка аргументов ...

        var type = typeof(T);

        if (!snapshot.ComponentSnapshots.TryGetValue(type, out var componentSnapshot))
        {
            return default;
        }

        return (T) componentSnapshot;
    }
}
