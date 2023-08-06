using System;

namespace Blowfish.Program;

/// <summary>
///   Контекст обновления.
/// </summary>
public sealed class UpdateContext
{
    /// <summary>
    ///   Возвращает пользовательский ввод.
    /// </summary>
    public IUserInput UserInput
    {
        get;
    }

    /// <summary>
    ///   Создает новый экземпляр.
    /// </summary>
    ///
    /// <param name="userInput">Пользовательский ввод.</param>
    ///
    /// <exception cref="ArgumentNullException">
    ///   Указанный пользовательский ввод <paramref name="userInput" /> равен <see langword="null" />.
    /// </exception>
    public UpdateContext(
        IUserInput userInput
        )
    {
        #region Проверка аргументов ...

        if (userInput == null)
        {
            throw new ArgumentNullException(nameof(userInput), "Указанный пользовательский ввод равен 'null'.");
        }

        #endregion Проверка аргументов ...

        UserInput = userInput;
    }
}
