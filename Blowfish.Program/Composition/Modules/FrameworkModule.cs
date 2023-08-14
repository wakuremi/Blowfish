using Blowfish.Framework;
using Blowfish.Framework.Graphics;
using Blowfish.Framework.Graphics.Renderables;
using Blowfish.Framework.Sfml;
using Blowfish.Framework.Sfml.Graphics;
using Blowfish.Framework.Sfml.Graphics.Renderables;
using Ninject.Extensions.Factory;
using Ninject.Modules;

namespace Blowfish.Program.Composition.Modules;

public sealed class FrameworkModule : NinjectModule
{
    public FrameworkModule()
    {
    }

    public override void Load()
    {
        _ = Bind<IRunner>()
            .To<Runner>()
            .InTransientScope()
            .WithConstructorArgument("width", 640)
            .WithConstructorArgument("height", 480)
            .WithConstructorArgument("title", "Blowfish");

        _ = Bind<IRunnerFactory>()
            .ToFactory()
            .InSingletonScope();

        _ = Bind<IRenderer>()
            .To<Renderer>()
            .InTransientScope();

        _ = Bind<IRendererFactory>()
            .ToFactory()
            .InSingletonScope();

        _ = Bind<IRenderableFactory>()
            .To<RenderableFactoryAggregator>()
            .When(r =>
            {
                // Чтобы агрегатор не инжектился сам в себя.
                return r.Target == null
                    || r.Target.Member.ReflectedType != typeof(RenderableFactoryAggregator);
            })
            .InSingletonScope();

        _ = Bind<IRenderableFactory>()
            .To<CanvasRenderableFactory>()
            .WhenInjectedExactlyInto<RenderableFactoryAggregator>()
            .InSingletonScope();

        _ = Bind<IRenderableFactory>()
            .To<PictureRenderableFactory>()
            .WhenInjectedExactlyInto<RenderableFactoryAggregator>()
            .InSingletonScope();

        _ = Bind<IRenderableFactory>()
            .To<RectangleRenderableFactory>()
            .WhenInjectedExactlyInto<RenderableFactoryAggregator>()
            .InSingletonScope();
    }
}
