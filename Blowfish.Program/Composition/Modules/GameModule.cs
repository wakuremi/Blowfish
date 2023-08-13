using Blowfish.Engine.Entities;
using Blowfish.Framework;
using Blowfish.Game;
using Blowfish.Game.Entities.Components;
using Blowfish.Game.Entities.Renderers;
using Blowfish.Game.Entities.Snapshots;
using Blowfish.Game.Entities.Updaters;
using Ninject;
using Ninject.Extensions.Factory;
using Ninject.Modules;

namespace Blowfish.Program.Composition.Modules;

public sealed class GameModule : NinjectModule
{
    public GameModule()
    {
    }

    public override void Load()
    {
        _ = Bind<IGame>()
            .To<BlowfishGame>()
            .InTransientScope();

        _ = Bind<IGameFactory>()
            .ToFactory()
            .InSingletonScope();

        _ = Bind<IComponentSnapshotFactory>()
            .To<ComponentSnapshotFactoryAggregator>()
            .When(r =>
            {
                // Чтобы агрегатор не инжектился сам в себя.
                return r.Target == null
                    || r.Target.Member.ReflectedType != typeof(ComponentSnapshotFactoryAggregator);
            })
            .InSingletonScope();

        _ = Bind<IComponentSnapshotFactory>()
            .To<LocationComponentSnapshotFactory>()
            .WhenInjectedExactlyInto<ComponentSnapshotFactoryAggregator>()
            .InSingletonScope();

        _ = Bind<IComponentSnapshotFactory>()
            .To<PreviousLocationComponentSnapshotFactory>()
            .WhenInjectedExactlyInto<ComponentSnapshotFactoryAggregator>()
            .InSingletonScope();

        _ = Bind<IComponentSnapshotFactory>()
            .To<EntityTypeComponentSnapshotFactory>()
            .WhenInjectedExactlyInto<ComponentSnapshotFactoryAggregator>()
            .InSingletonScope();

        _ = Bind<IEntityUpdater>()
            .To<EntityUpdaterAggregator>()
            .InSingletonScope()
            .WithConstructorArgument(
                "updaters", // Порядок важен, поэтому определяем его явно.
                ctx => new IEntityUpdater[]
                {
                    ctx.Kernel.Get<PreviousLocationEntityUpdater>(),
                    ctx.Kernel.Get<FireEntityUpdater>(),
                    ctx.Kernel.Get<UserInputEntityUpdater>(),
                    ctx.Kernel.Get<MovementEntityUpdater>()
                }
                );

        _ = Bind<PreviousLocationComponent>()
            .ToSelf()
            .InSingletonScope();

        _ = Bind<FireEntityUpdater>()
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
            .To<PlayerEntityRenderer>()
            .WhenInjectedExactlyInto<EntityRendererAggregator>()
            .InSingletonScope();

        _ = Bind<IEntityRenderer>()
            .To<BulletEntityRenderer>()
            .WhenInjectedExactlyInto<EntityRendererAggregator>()
            .InSingletonScope();
    }
}
