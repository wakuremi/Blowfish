namespace Blowfish.Framework.Graphics.Renderables;

/// <summary>
///   Прямоугольник.
/// </summary>
public interface IRectangleRenderable : IRenderable
{
    /// <summary>
    ///   Устанавливает позицию.
    ///   Если объект был уничтожен, то ничего не делает.
    /// </summary>
    ///
    /// <param name="x">Позиция по оси X.</param>
    /// <param name="y">Позиция по оси Y.</param>
    void SetLocation(float x, float y);

    /// <summary>
    ///   Устанавливает размер.
    ///   Если объект был уничтожен, то ничего не делает.
    /// </summary>
    ///
    /// <param name="width">Ширина.</param>
    /// <param name="height">Высота.</param>
    void SetSize(float width, float height);

    /// <summary>
    ///   Устанавливает цвет.
    ///   Если объект был уничтожен, то ничего не делает.
    /// </summary>
    ///
    /// <param name="r">Красный.</param>
    /// <param name="g">Зеленый.</param>
    /// <param name="b">Синий.</param>
    void SetColor(byte r, byte g, byte b);
}
