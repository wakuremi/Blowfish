using Blowfish.Engine.Entities;
using Blowfish.Engine.Graphics;
using Ninject.Modules;

namespace Blowfish.Program.Composition.Modules;

public sealed class GameModule : NinjectModule
{
    public GameModule()
    {
    }

    public override void Load()
    {
        _ = Bind<SpriteSheet>()
            .ToSelf()
            .InSingletonScope()
            .WithConstructorArgument("filePath", "Assets/Sprites.png")
            .WithConstructorArgument("spriteWidth", 16)
            .WithConstructorArgument("spriteHeight", 16);
    }
}
