using Blowfish.Program.Helpers;
using SFML.System;
using System;
using System.Collections.Immutable;
using System.Linq;

namespace Blowfish.Program;

/// <inheritdoc cref="IEntityRenderer" />
public sealed class EntityRendererDispatcher : IEntityRenderer
{
    private readonly ImmutableDictionary<Type, IEntityRenderer> _renderers;

    /// <summary>
    ///   Создает новый экземпляр.
    /// </summary>
    ///
    /// <param name="renderers">Массив рендереров.</param>
    /// <param name="logProvider">Провайдер журналов.</param>
    ///
    /// <exception cref="ArgumentNullException">
    ///   1. Указанный массив рендереров <paramref name="renderers" /> равен <see langword="null" />.
    ///   2. Указанный провайдер журналов <paramref name="logProvider" /> равен <see langword="null" />.
    /// </exception>
    ///
    /// <exception cref="ArgumentException">
    ///   Указанный массив рендереров <paramref name="renderers" /> содержит <see langword="null" />.
    /// </exception>
    public EntityRendererDispatcher(
        IEntityRenderer[] renderers,
        LogProvider logProvider
        )
    {
        #region Проверка аргументов ...

        if (renderers == null)
        {
            throw new ArgumentNullException(nameof(renderers), "Указанный массив рендереров равен 'null'.");
        }

        if (renderers.Any(x => x == null))
        {
            throw new ArgumentException("Указанный массив рендереров содержит 'null'.", nameof(renderers));
        }

        if (logProvider == null)
        {
            throw new ArgumentNullException(nameof(logProvider), "Указанный провайдер журналов равен 'null'.");
        }

        #endregion Проверка аргументов ...

        var log = logProvider.Get();

        var builder = ImmutableDictionary.CreateBuilder<Type, IEntityRenderer>();

        foreach (var renderer in renderers)
        {
            var type = TargetTypeAttributeHelper.GetTargetType(renderer);

            if (type == null)
            {
                log.Warn($"Указанный рендерер '{type}' не помечен атрибутом целевого типа.");
            }
            else
            {
                builder.Add(type, renderer);
            }
        }

        _renderers = builder.ToImmutable();
    }

    /// <inheritdoc />
    public void Render(RenderContext context, IEntitySnapshot snapshot, Vector2f position)
    {
        #region Проверка аргументов ...

        if (context == null)
        {
            throw new ArgumentNullException(nameof(context));
        }

        if (snapshot == null)
        {
            throw new ArgumentNullException(nameof(snapshot));
        }

        #endregion Проверка аргументов ...

        var type = snapshot.GetType();

        if (_renderers.TryGetValue(type, out var renderer))
        {
            renderer.Render(context, snapshot, position);
        }

        // Соответствующий рендерер не найден. Ничего не поделать :)
    }
}
