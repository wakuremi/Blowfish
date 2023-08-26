using System;

namespace Blowfish.Common.Structures;

/// <inheritdoc cref="IMap{T}" />
public sealed class Map<T> : IMap<T>, IReadOnlyMap<T>
{
    private readonly T[,] _array;

    /// <inheritdoc />
    public int Width
    {
        get;
    }

    /// <inheritdoc />
    public int Height
    {
        get;
    }

    /// <summary>
    ///   Создает карту.
    /// </summary>
    ///
    /// <param name="width">Ширина.</param>
    /// <param name="height">Высота.</param>
    ///
    /// <exception cref="ArgumentException">
    ///   1. Указанная ширина <paramref name="width" /> меньше 0.
    ///   2. Указанная высота <paramref name="height" /> меньше 0.
    /// </exception>
    public Map(
        int width,
        int height
        )
    {
        #region Проверка аргументов ...

        Throw.IfLess(width, 0);
        Throw.IfLess(height, 0);

        #endregion Проверка аргументов ...

        _array = new T[width, height];
    }

    /// <inheritdoc />
    public T Get(int x, int y)
    {
        #region Проверка аргументов ...

        Throw.IfOutOfRange(x, 0, Width);
        Throw.IfOutOfRange(y, 0, Height);

        #endregion Проверка аргументов ...

        var value = _array[x, y];

        return value;
    }

    /// <inheritdoc />
    public void Set(int x, int y, T value)
    {
        #region Проверка аргументов ...

        Throw.IfOutOfRange(x, 0, Width);
        Throw.IfOutOfRange(y, 0, Height);

        #endregion Проверка аргументов ...

        _array[x, y] = value;
    }
}
