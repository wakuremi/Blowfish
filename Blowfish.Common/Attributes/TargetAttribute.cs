using System;

namespace Blowfish.Common.Attributes;

/// <summary>
///   Атрибут для указания цели.
/// </summary>
[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public sealed class TargetAttribute<T> : Attribute where T : notnull
{
    /// <summary>
    ///   Возвращает цель.
    /// </summary>
    public T Target
    {
        get;
    }

    /// <summary>
    ///   Создает атрибут.
    /// </summary>
    ///
    /// <param name="target">Цель.</param>
    ///
    /// <exception cref="ArgumentNullException">
    ///   Указанная цель <paramref name="target" /> равна <see langword="null" />.
    /// </exception>
    public TargetAttribute(T target)
    {
        #region Проверка аргументов ...

        Throw.IfNull(target);

        #endregion Проверка аргументов ...

        Target = target;
    }
}
