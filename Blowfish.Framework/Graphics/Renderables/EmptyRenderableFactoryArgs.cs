namespace Blowfish.Framework.Graphics.Renderables;

/// <summary>
///   Пустые аргументы фабрики.
/// </summary>
public sealed class EmptyRenderableFactoryArgs : IRenderableFactoryArgs
{
    /// <summary>
    ///   Пустые аргументы фабрики.
    /// </summary>
    public static readonly EmptyRenderableFactoryArgs Instance = new EmptyRenderableFactoryArgs();

    /// <summary>
    ///   Создает пустые аргументы фабрики.
    /// </summary>
    private EmptyRenderableFactoryArgs()
    {
    }
}
