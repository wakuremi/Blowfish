using log4net;
using System.Diagnostics;

namespace Blowfish.Program;

/// <summary>
///   Провайдер журналов.
/// </summary>
public sealed class LogProvider
{
    /// <summary>
    ///   Создает новый экземпляр.
    /// </summary>
    public LogProvider()
    {
    }

    /// <summary>
    ///   Возвращает журнал для класса, в котором данный метод был вызван.
    /// </summary>
    ///
    /// <returns>
    ///   Журнал.
    /// </returns>
    public ILog Get()
    {
        var type = new StackFrame(1).GetMethod()?.ReflectedType;

        var log = type == null
            ? LogManager.GetLogger("ANONYMOUS")
            : LogManager.GetLogger(type);

        return log;
    }
}
