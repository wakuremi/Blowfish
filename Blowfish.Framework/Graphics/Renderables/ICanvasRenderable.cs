namespace Blowfish.Framework.Graphics.Renderables;

/// <summary>
///   Холст.
/// </summary>
public interface ICanvasRenderable : IRenderable, IRenderer
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
}
