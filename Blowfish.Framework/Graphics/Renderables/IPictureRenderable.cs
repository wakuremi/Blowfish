using System;

namespace Blowfish.Framework.Graphics.Renderables;

/// <summary>
///   Картинка.
/// </summary>
public interface IPictureRenderable : IRenderable
{
    /// <summary>
    ///   Возвращает ширину.
    /// </summary>
    int Width
    {
        get;
    }

    /// <summary>
    ///   Возвращает высоту.
    /// </summary>
    int Height
    {
        get;
    }

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
    ///   Устанавливает область просмотра.
    /// </summary>
    ///
    /// <param name="x">Позиция по оси X.</param>
    /// <param name="y">Позиция по оси Y.</param>
    /// <param name="width">Ширина.</param>
    /// <param name="height">Высота.</param>
    ///
    /// <exception cref="ObjectDisposedException">
    ///   Объект был уничтожен.
    /// </exception>
    ///
    /// <exception cref="InvalidOperationException">
    ///   Не удалось установить область просмотра.
    /// </exception>
    void SetViewport(int x, int y, int width, int height);
}
