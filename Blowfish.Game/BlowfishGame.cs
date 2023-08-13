using Blowfish.Engine.Entities;
using Blowfish.Framework;
using Blowfish.Game.Entities.Components;
using Blowfish.Logging;
using System;

namespace Blowfish.Game;

/// <inheritdoc cref="IGame" />
public sealed class BlowfishGame : IGame, IDisposable
{
    private readonly EntityStage _stage;
    private readonly ILogger _logger;

    public BlowfishGame(
        EntityStageFactory stageFactory,
        ILoggerProvider loggerProvider
        )
    {
        #region Проверка аргументов ...

        if (stageFactory == null)
        {
            throw new ArgumentNullException(nameof(stageFactory));
        }

        if (loggerProvider == null)
        {
            throw new ArgumentNullException(nameof(loggerProvider));
        }

        #endregion Проверка аргументов ...

        _stage = stageFactory.Create(
            new Entity[]
            {
                new Entity(
                    new IComponent[]
                    {
                        new EntityTypeComponent(EntityTypeEnum.Player),
                        new LocationComponent() { X = 32.0F, Y = 32.0F },
                        new VelocityComponent(),
                        new PreviousLocationComponent(),
                        new FireComponent()
                    }
                    )
            }
            );

        _logger = loggerProvider.Get();
    }

    /// <inheritdoc />
    public void Update(UpdateContext context)
    {
        #region Проверка аргументов ...

        if (context == null)
        {
            throw new ArgumentNullException(nameof(context), "Указанный контекст обновления равен 'null'.");
        }

        #endregion Проверка аргументов ...

        _stage.Update(context);
    }

    /// <inheritdoc />
    public void Render(RenderContext context)
    {
        #region Проверка аргументов ...

        if (context == null)
        {
            throw new ArgumentNullException(nameof(context), "Указанный контекст отрисовки равен 'null'.");
        }

        #endregion Проверка аргументов ...

        _stage.Render(context);
    }

    /// <inheritdoc />
    public void Dispose()
    {
        _logger.Warn("Игра уничтожена.");
    }
}
