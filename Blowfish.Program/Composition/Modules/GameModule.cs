using Blowfish.Common.Structures;
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

        _ = Bind<TileMap>()
            .ToSelf()
            .InSingletonScope()
            .WithConstructorArgument(
                "map",
                ctx =>
                {
                    var map = new Map<int>(4, 4);
                    map.Set(0, 0, 1);
                    map.Set(1, 1, 2);

                    return map;
                }
                )
            .WithConstructorArgument("tileWidth", 32.0F)
            .WithConstructorArgument("tileHeight", 32.0F);
    }
}
