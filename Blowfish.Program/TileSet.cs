using SFML.Graphics;
using SFML.System;
using System;
using System.IO;

namespace Blowfish.Program;

/// <summary>
///   Набор тайлов.
/// </summary>
public sealed class TileSet : IDisposable
{
    private readonly Texture _texture;
    private readonly int _rows;
    private readonly Sprite _sprite;
    private readonly int _tileWidth;
    private readonly int _tileHeight;

    /// <summary>
    ///   Создает новый экземпляр.
    /// </summary>
    ///
    /// <param name="tileWidth">Ширина тайла.</param>
    /// <param name="tileHeight">Высота тайла.</param>
    /// <param name="filePath">Путь к файлу изображения.</param>
    ///
    /// <exception cref="ArgumentException">
    ///   1. Указанная ширина тайла меньше 1.
    ///   2. Указанная высота тайла меньше 1.
    /// </exception>
    /// 
    /// <exception cref="ArgumentNullException">
    ///   Указанный путь к файлу изображения <paramref name="filePath" /> равен <see langword="null" />.
    /// </exception>
    ///
    /// <exception cref="IOException">
    ///   Не удалось загрузить текстуру из файла.
    /// </exception>
    ///
    /// <exception cref="InvalidOperationException">
    ///   Недопустимый размер загруженной текстуры.
    /// </exception>
    public TileSet(
        int tileWidth,
        int tileHeight,
        string filePath
        )
    {
        #region Проверка аргументов ...

        if (tileWidth < 1)
        {
            throw new ArgumentException("Указанная ширина тайла меньше 1.", nameof(tileWidth));
        }

        if (tileHeight < 1)
        {
            throw new ArgumentException("Указанная высота тайла меньше 1.", nameof(tileHeight));
        }

        if (filePath == null)
        {
            throw new ArgumentNullException(nameof(filePath), "Указанный путь к файлу равен 'null'.");
        }

        #endregion Проверка аргументов ...

        try
        {
            _texture = new Texture(filePath);
        }
        catch (SFML.LoadingFailedException exception)
        {
            throw new IOException("Не удалось загрузить текстуру из файла.", exception);
        }

        var width = _texture.Size.X;
        var height = _texture.Size.Y;

        if (width < tileWidth || width > int.MaxValue
            || height < tileHeight || height > int.MaxValue)
        {
            // Так как текстура уже загружена, то ее нужно уничтожить!
            _texture.Dispose();

            throw new InvalidOperationException("Недопустимый размер загруженной текстуры.");
        }

        _rows = (int) width / tileWidth;

        _sprite = new Sprite(_texture);

        _tileWidth = tileWidth;
        _tileHeight = tileHeight;
    }

    /// <summary>
    ///   Рисует тайл.
    /// </summary>
    ///
    /// <param name="target">Место отрисовки.</param>
    /// <param name="tileIndex">Порядковый номер тайла.</param>
    /// <param name="x">Позиция отрисовки по оси X.</param>
    /// <param name="y">Позиция отрисовки по оси Y.</param>
    /// <param name="width">Ширина отрисовки.</param>
    /// <param name="height">Высота отрисовки.</param>
    ///
    /// <exception cref="ArgumentNullException">
    ///   Указанное место отрисовки <paramref name="target" /> равно <see langword="null" />.
    /// </exception>
    public void Draw(
        RenderTarget target,
        int tileIndex,
        float x,
        float y,
        float width,
        float height
        )
    {
        #region Проверка аргументов ...

        if (target == null)
        {
            throw new ArgumentNullException(nameof(target), "Указанное место отрисовки равно 'null'.");
        }

        #endregion Проверка аргументов ...

        // Никаких ограничений на порядковый номер тайла не накладываем.
        // Если указали ерунду, то и нарисуется ерунда :)

        var row = tileIndex / _rows;
        var col = tileIndex % _rows;

        _sprite.TextureRect = new IntRect(
            row * _tileWidth,
            col * _tileHeight,
            _tileWidth,
            _tileHeight
            );

        _sprite.Position = new Vector2f(x, y);
        _sprite.Scale = new Vector2f(width / _tileWidth, height / _tileHeight);

        target.Draw(_sprite);
    }

    /// <inheritdoc />
    public void Dispose()
    {
        _sprite.Dispose();
        _texture.Dispose();
    }
}
