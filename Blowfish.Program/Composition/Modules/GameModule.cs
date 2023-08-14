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

        _ = Bind<ISnapshotFactory>()
            .To<SnapshotFactoryAggregator>()
            .When(r =>
            {
                // Чтобы агрегатор не инжектился сам в себя.
                return r.Target == null
                    || r.Target.Member.ReflectedType != typeof(SnapshotFactoryAggregator);
            })
            .InSingletonScope();

        _ = Bind<ISnapshotFactory>()
            .To<CreatureSnapshotFactory>()
            .WhenInjectedExactlyInto<SnapshotFactoryAggregator>()
            .InSingletonScope();

        _ = Bind<ISnapshotRenderer>()
            .To<SnapshotRendererAggregator>()
            .When(r =>
            {
                // Чтобы агрегатор не инжектился сам в себя.
                return r.Target == null
                    || r.Target.Member.ReflectedType != typeof(SnapshotRendererAggregator);
            })
            .InSingletonScope();

        _ = Bind<ISnapshotRenderer>()
            .To<CreatureSnapshotRenderer>()
            .WhenInjectedExactlyInto<SnapshotRendererAggregator>()
            .InSingletonScope();

        _ = Bind<ICreatureRenderer>()
            .To<PlayerCreatureRenderer>()
            .InSingletonScope();

        _ = Bind<ICreatureRenderer>()
            .To<CrateCreatureRenderer>()
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
