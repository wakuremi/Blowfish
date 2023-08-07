using Blowfish.Program.Composition.Modules;
using Ninject;
using System;

namespace Blowfish.Program.Composition;

/// <summary>
///   Корень композиции.
/// </summary>
public sealed class Root : IDisposable
{
    private readonly StandardKernel _kernel;

    /// <summary>
    ///   Создает корень композиции.
    /// </summary>
    public Root()
    {
        _kernel = new StandardKernel();
        _kernel.Load<CommonModule>();
        _kernel.Load<EngineModule>();
        _kernel.Load<FrameworkModule>();
        _kernel.Load<GameModule>();
        _kernel.Load<LoggingModule>();
    }

    /// <summary>
    ///   Возвращает объект указанного типа.
    /// </summary>
    ///
    /// <typeparam name="T">Тип объекта.</typeparam>
    ///
    /// <returns>
    ///   Объект.
    /// </returns>
    ///
    /// <exception cref="InvalidOperationException">
    ///   Ошибка при резолвинге.
    /// </exception>
    public T Get<T>()
    {
        T instance;

        try
        {
            instance = _kernel.Get<T>();
        }
        catch (Exception exception)
        {
            throw new InvalidOperationException("Ошибка при резолвинге.", exception);
        }

        return instance;
    }

    /// <inheritdoc />
    public void Dispose()
    {
        _kernel.Dispose();
    }
}
