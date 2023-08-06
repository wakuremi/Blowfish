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
    ///   Создает новый экземпляр.
    /// </summary>
    public Root()
    {
        _kernel = new StandardKernel();
        _kernel.Load<MiscModule>();
    }

    /// <summary>
    ///   Резолвит и возвращает объект указанного типа.
    /// </summary>
    ///
    /// <typeparam name="T">Тип объекта.</typeparam>
    ///
    /// <returns>
    ///   Объект.
    /// </returns>
    ///
    /// <exception cref="InvalidOperationException">
    ///   Ошибка резолвинга.
    /// </exception>
    public T ResolveAndGet<T>()
    {
        T instance;

        try
        {
            instance = _kernel.Get<T>();
        }
        catch (Exception exception)
        {
            throw new InvalidOperationException("Ошибка резолвинга.", exception);
        }

        return instance;
    }

    /// <summary>
    ///   Высвобождает ресурсы.
    /// </summary>
    public void Dispose()
    {
        _kernel.Dispose();
    }
}
