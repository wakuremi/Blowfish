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
    ///   Устанавливает область просмотра.
    ///   Если объект был уничтожен, то ничего не делает.
    /// </summary>
    ///
    /// <param name="x">Позиция по оси X.</param>
    /// <param name="y">Позиция по оси Y.</param>
    /// <param name="width">Ширина.</param>
    /// <param name="height">Высота.</param>
    void SetViewport(int x, int y, int width, int height);
}
