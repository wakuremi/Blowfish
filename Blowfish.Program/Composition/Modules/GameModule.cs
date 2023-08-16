using Blowfish.Engine.Entities;
using Blowfish.Engine.Graphics;
using Blowfish.Game;
using Blowfish.Game.Creatures;
using Blowfish.Game.Creatures.Renderers;
using Blowfish.Game.Creatures.Updaters;
using Ninject;
using Ninject.Modules;

namespace Blowfish.Program.Composition.Modules;

public sealed class GameModule : NinjectModule
{
    public GameModule()
    {
    }

    public override void Load()
    {
        _ = Bind<IEntityUpdater>()
            .To<EntityUpdaterAggregator>()
            .InSingletonScope()
            .WithConstructorArgument(
                "updaters",
                ctx => new IEntityUpdater[]
                {
                    ctx.Kernel.Get<InitializerEntityUpdater>(),
                    ctx.Kernel.Get<TrackEntityUpdater>(),
                    ctx.Kernel.Get<UserInputEntityUpdater>(),
                    ctx.Kernel.Get<MovementEntityUpdater>()
                }
                );

        _ = Bind<InitializerEntityUpdater>()
            .ToSelf()
            .InSingletonScope();

        _ = Bind<TrackEntityUpdater>()
            .ToSelf()
            .InSingletonScope();

        _ = Bind<UserInputEntityUpdater>()
            .ToSelf()
            .InSingletonScope();

        _ = Bind<MovementEntityUpdater>()
            .ToSelf()
            .InSingletonScope();

        _ = Bind<IEntityRenderer>()
            .To<EntityRendererAggregator>()
            .When(r =>
            {
                // Чтобы агрегатор не инжектился сам в себя.
                return r.Target == null
                    || r.Target.Member.ReflectedType != typeof(EntityRendererAggregator);
            })
            .InSingletonScope();

        _ = Bind<IEntityRenderer>()
            .To<CreatureEntityRenderer>()
            .WhenInjectedExactlyInto<EntityRendererAggregator>()
            .InSingletonScope();

        _ = Bind<ICreatureRenderer>()
            .To<CreatureRendererAggregator>()
            .When(r =>
            {
                // Чтобы агрегатор не инжектился сам в себя.
                return r.Target == null
                    || r.Target.Member.ReflectedType != typeof(CreatureRendererAggregator);
            })
            .InSingletonScope();

        _ = Bind<ICreatureRenderer>()
            .To<PlayerCreatureRenderer>()
            .WhenInjectedExactlyInto<CreatureRendererAggregator>()
            .InSingletonScope();

        _ = Bind<ICreatureRenderer>()
            .To<CrateCreatureRenderer>()
            .WhenInjectedExactlyInto<CreatureRendererAggregator>()
            .InSingletonScope();

        // TODO: temp
        _ = Bind<SpriteSheet>()
            .ToSelf()
            .InSingletonScope()
            .WithConstructorArgument("filePath", "Assets/Sprites.png")
            .WithConstructorArgument("spriteWidth", 16)
            .WithConstructorArgument("spriteHeight", 16);
    }
}
