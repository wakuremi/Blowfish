using System;

namespace Blowfish.Common.Structures;

/// <summary>
///   Карта.
/// </summary>
///
/// <typeparam name="T">Тип элементов.</typeparam>
public interface IMap<T>
{
    /// <summary>
    ///   Возвращает ширину. Гарантируется, что возвращаемое значение больше 0.
    /// </summary>
    int Width
    {
        get;
    }

    /// <summary>
    ///   Возвращает высоту. Гарантируется, что возвращаемое значение больше 0.
    /// </summary>
    int Height
    {
        get;
    }

    T this[int x, int y]
    {
        get => Get(x, y);

        set => Set(x, y, value);
    }

    /// <summary>
    ///   Возвращает значение в указанной точке.
    /// </summary>
    ///
    /// <param name="x">Позиция точки по оси точки X.</param>
    /// <param name="y">Позиция точки по оси точки Y.</param>
    ///
    /// <returns>
    ///   Значение или <see langword="default" />, если в указанной точке его нет.
    /// </returns>
    ///
    /// <exception cref="ArgumentOutOfRangeException">
    ///   1. Указанная позиция точки по оси X <paramref name="x" /> меньше 0 или больше или равна <see cref="Width" />.
    ///   2. Указанная позиция точки по оси Y <paramref name="y" /> меньше 0 или больше или равна <see cref="Width" />.
    /// </exception>
    T Get(int x, int y);

    /// <summary>
    ///   Устанавливает значение в указанной точке.
    /// </summary>
    ///
    /// <param name="x">Позиция точки по оси точки X.</param>
    /// <param name="y">Позиция точки по оси точки Y.</param>
    /// <param name="value">Значение.</param>
    ///
    /// <exception cref="ArgumentOutOfRangeException">
    ///   1. Указанная позиция точки по оси X <paramref name="x" /> меньше 0 или больше или равна <see cref="Width" />.
    ///   2. Указанная позиция точки по оси Y <paramref name="y" /> меньше 0 или больше или равна <see cref="Width" />.
    /// </exception>
    void Set(int x, int y, T value);
}
