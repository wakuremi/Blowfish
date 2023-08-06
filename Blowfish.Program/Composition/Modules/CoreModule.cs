using Ninject;
using Ninject.Modules;
using SFML.System;

namespace Blowfish.Program.Composition.Modules;

public sealed class CoreModule : NinjectModule
{
    public CoreModule()
    {
    }

    public override void Load()
    {
        _ = Bind<Application>()
            .ToSelf()
            .InSingletonScope();

        _ = Bind<GameWindow>()
            .ToSelf()
            .InSingletonScope();

        _ = Bind<Game>()
            .ToSelf()
            .InSingletonScope();

        _ = Bind<IAssetProvider>()
            .To<AssetProvider>()
            .InSingletonScope();

        _ = Bind<EntityStage>()
            .ToSelf()
            .InSingletonScope();

        _ = Bind<IEntity>()
            .To<PlayerEntity>()
            .InSingletonScope()
            .WithConstructorArgument("position", new Vector2f(32.0F, 32.0F));

        _ = Bind<IEntity>()
            .To<PlayerEntity>()
            .InSingletonScope()
            .WithConstructorArgument("position", new Vector2f(64.0F, 128.0F));

        _ = Bind<IEntityRenderer>()
            .To<PlayerEntityRenderer>()
            .WhenInjectedExactlyInto<EntityRendererDispatcher>()
            .InSingletonScope()
            .WithConstructorArgument("tileSet", ctx => ctx.Kernel.Get<IAssetProvider>().GetTileSet("sprites"));

        _ = Bind<IEntityRenderer>()
            .To<EntityRendererDispatcher>()
            .When(r => r.Target == null || r.Target.Member.ReflectedType != typeof(EntityRendererDispatcher)) // Чтобы он не инжектился в себя.
            .InSingletonScope();

        _ = Bind<Scene>()
            .ToSelf()
            .InSingletonScope();
    }
}
