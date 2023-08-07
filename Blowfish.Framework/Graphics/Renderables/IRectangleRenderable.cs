using System;

namespace Blowfish.Framework.Graphics.Renderables;

/// <summary>
///   Прямоугольник.
/// </summary>
public interface IRectangleRenderable : IRenderable
{
    /// <summary>
    ///   Устанавливает позицию.
    /// </summary>
    ///
    /// <param name="x">Позиция по оси X.</param>
    /// <param name="y">Позиция по оси Y.</param>
    ///
    /// <exception cref="ObjectDisposedException">
    ///   Объект был уничтожен.
    /// </exception>
    ///
    /// <exception cref="InvalidOperationException">
    ///   Не удалось установить позицию.
    /// </exception>
    void SetLocation(float x, float y);

    /// <summary>
    ///   Устанавливает размер.
    /// </summary>
    ///
    /// <param name="width">Ширина.</param>
    /// <param name="height">Высота.</param>
    ///
    /// <exception cref="ObjectDisposedException">
    ///   Объект был уничтожен.
    /// </exception>
    ///
    /// <exception cref="InvalidOperationException">
    ///   Не удалось установить размер.
    /// </exception>
    void SetSize(float width, float height);

    /// <summary>
    ///   Устанавливает цвет.
    /// </summary>
    ///
    /// <param name="r">Красный.</param>
    /// <param name="g">Зеленый.</param>
    /// <param name="b">Синий.</param>
    ///
    /// <exception cref="ObjectDisposedException">
    ///   Объект был уничтожен.
    /// </exception>
    ///
    /// <exception cref="InvalidOperationException">
    ///   Не удалось установить цвет.
    /// </exception>
    void SetColor(byte r, byte g, byte b);
}
