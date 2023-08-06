using SFML.System;
using System;
using System.Collections.Immutable;

namespace Blowfish.Program;

/// <summary>
///   Сцена.
/// </summary>
public sealed class Scene
{
    private readonly IEntityRenderer _renderer;
    private readonly EntityStage _stage;

    private ImmutableList<IEntitySnapshot> _snapshots;
    private ImmutableDictionary<Guid, Vector2f> _positions;

    /// <summary>
    ///   Создает новый экземпляр.
    /// </summary>
    ///
    /// <param name="renderer">Рендерер сущностей.</param>
    /// <param name="stage">Стейдж.</param>
    ///
    /// <exception cref="ArgumentNullException">
    ///   1. Указанный рендерер сущностей <paramref name="renderer" /> равен <see langword="null" />.
    ///   2. Указанный стейдж <paramref name="stage" /> равен <see langword="null" />.
    /// </exception>
    public Scene(
        IEntityRenderer renderer,
        EntityStage stage
        )
    {
        #region Проверка аргументов ...

        if (renderer == null)
        {
            throw new ArgumentNullException(nameof(renderer), "Указанный рендерер сущностей равен 'null'.");
        }

        if (stage == null)
        {
            throw new ArgumentNullException(nameof(stage), "Указанный стейдж равен 'null'.");
        }

        #endregion Проверка аргументов ...

        _renderer = renderer;
        _stage = stage;

        _snapshots = ImmutableList<IEntitySnapshot>.Empty;
        _positions = ImmutableDictionary<Guid, Vector2f>.Empty;
    }

    /// <summary>
    ///   Выполняет обновление.
    /// </summary>
    ///
    /// <param name="context">Контекст обновления.</param>
    ///
    /// <exception cref="ArgumentNullException">
    ///   Указанный контекст обновления <paramref name="context" /> равен <see langword="null" />.
    /// </exception>
    public void Update(UpdateContext context)
    {
        #region Проверка аргументов ...

        if (context == null)
        {
            throw new ArgumentNullException(nameof(context), "Указанный контекст обновления равен 'null'.");
        }

        #endregion Проверка аргументов ...

        _positions = _snapshots.ToImmutableDictionary(x => x.EntityGuid, x => x.Position);

        _snapshots = _stage.Update(context);
    }

    /// <summary>
    ///   Выполняет отрисовку.
    /// </summary>
    ///
    /// <param name="context">Контекст отрисовки.</param>
    ///
    /// <exception cref="ArgumentNullException">
    ///   Указанный контекст отрисовки <paramref name="context" /> равен <see langword="null" />.
    /// </exception>
    public void Render(RenderContext context)
    {
        #region Проверка аргументов ...

        if (context == null)
        {
            throw new ArgumentNullException(nameof(context), "Указанный отрисовки обновления равен 'null'.");
        }

        #endregion Проверка аргументов ...

        foreach (var snapshot in _snapshots)
        {
            Render(context, snapshot);
        }
    }

    /// <summary>
    ///   Рисует сущность.
    /// </summary>
    ///
    /// <param name="context">Контекст отрисовки.</param>
    /// <param name="snapshot">Снимок сущности.</param>
    ///
    /// <exception cref="NullReferenceException">
    ///   1. Указанный контекст отрисовки <paramref name="context" /> равен <see langword="null" />.
    ///   2. Указанный снимок сущности <paramref name="snapshot" /> равен <see langword="null" />.
    /// </exception>
    private void Render(RenderContext context, IEntitySnapshot snapshot)
    {
        Vector2f intermediate;

        if (_positions.TryGetValue(snapshot.EntityGuid, out var position))
        {
            intermediate = position + (snapshot.Position - position) * context.Delta;
        }
        else
        {
            intermediate = snapshot.Position;
        }

        _renderer.Render(context, snapshot, intermediate);
    }
}
