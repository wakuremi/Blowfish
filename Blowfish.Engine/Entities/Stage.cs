using Blowfish.Common;
using Blowfish.Framework;
using System;

namespace Blowfish.Engine.Entities;

/// <summary>
///   Стейдж.
/// </summary>
public sealed class Stage
{
    private readonly IEntityUpdater _updater;
    private readonly IEntityRenderer _renderer;

    private readonly EntityController _controller;

    /// <summary>
    ///   Создает стейдж.
    /// </summary>
    ///
    /// <param name="updater">Апдейтер сущностей.</param>
    /// <param name="renderer">Рендерер сущностей.</param>
    ///
    /// <exception cref="ArgumentNullException">
    ///   1. Указанный апдейтер сущностей <paramref name="updater" /> равен <see langword="null" />.
    ///   2. Указанный рендерер сущностей <paramref name="renderer" /> равен <see langword="null" />.
    /// </exception>
    public Stage(
        IEntityUpdater updater,
        IEntityRenderer renderer
        )
    {
        #region Проверка аргументов ...

        Throw.IfNull(updater);
        Throw.IfNull(renderer);

        #endregion Проверка аргументов ...

        _updater = updater;
        _renderer = renderer;

        _controller = new EntityController();
    }

    /// <summary>
    ///   Выполняет обновление.
    /// </summary>
    ///
    /// <param name="context">Контекст обновления.</param>
    public void Update(UpdateContext context)
    {
        _updater.Update(context, _controller);

        _controller.Commit();
    }

    /// <summary>
    ///   Выполняет отрисовку.
    /// </summary>
    ///
    /// <param name="context">Контекст отрисовки.</param>
    public void Render(RenderContext context)
    {
        var entities = _controller.Entities;

        for (var i = 0; i < entities.Count; i++)
        {
            var entity = entities[i];

            _renderer.Render(context, entity);
        }
    }
}
