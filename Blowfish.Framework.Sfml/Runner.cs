﻿using Blowfish.Common;
using Blowfish.Framework.Graphics;
using Blowfish.Framework.Input;
using Blowfish.Framework.Sfml.Graphics;
using Blowfish.Framework.Sfml.Helpers;
using Blowfish.Logging;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Immutable;

namespace Blowfish.Framework.Sfml;

/// <inheritdoc cref="IRunner" />
public sealed class Runner : IRunner, IKeyboard, IMouse, IDisposable
{
    private readonly ILogger _logger;

    private ImmutableHashSet<KeyEnum> _keys;
    private ImmutableHashSet<ButtonEnum> _buttons;
    private float _pointerX;
    private float _pointerY;

    private readonly RenderWindow _window;
    private readonly View _view;
    private readonly FloatRect _rect;

    private readonly IRenderer _renderer;

    /// <summary>
    ///   Создает раннер.
    /// </summary>
    ///
    /// <param name="rendererFactory">Фабрика рендереров.</param>
    /// <param name="loggerProvider">Провайдер логгеров.</param>
    /// <param name="width">Ширина окна.</param>
    /// <param name="height">Высота окна.</param>
    /// <param name="title">Заголовок окна.</param>
    ///
    /// <exception cref="ArgumentNullException">
    ///   1. Указанная фабрика рендереров <paramref name="rendererFactory" /> равна <see langword="null" />.
    ///   1. Указанный провайдер логгеров <paramref name="loggerProvider" /> равен <see langword="null" />.
    ///   2. Указанный заголовок окна <paramref name="title" /> равен <see langword="null" />.
    /// </exception>
    ///
    /// <exception cref="ArgumentException">
    ///   1. Указанная ширина окна <paramref name="width" /> меньше 1.
    ///   2. Указанная высота окна <paramref name="height" /> меньше 1.
    /// </exception>
    public Runner(
        IRendererFactory rendererFactory,
        ILoggerProvider loggerProvider,
        int width,
        int height,
        string title
        )
    {
        #region Проверка аргументов ...

        Throw.IfNull(rendererFactory);
        Throw.IfNull(loggerProvider);
        Throw.IfLess(width, 1);
        Throw.IfLess(height, 1);
        Throw.IfNull(title);

        #endregion Проверка аргументов ...

        _logger = loggerProvider.Get();

        _keys = ImmutableHashSet<KeyEnum>.Empty;
        _buttons = ImmutableHashSet<ButtonEnum>.Empty;

        var mode = new VideoMode((uint) width, (uint) height);

        _window = new RenderWindow(mode, "Blowfish");

        _window.Closed += HandleClosed;
        _window.KeyPressed += HandleKeyPressed;
        _window.KeyReleased += HandleKeyReleased;
        _window.MouseButtonPressed += HandleButtonPressed;
        _window.MouseButtonReleased += HandleMouseButtonReleased;
        _window.MouseMoved += HandlePointerMoved;

        // Примечание: "DefaultView" всегда создает новый объект.
        // Делаем это однократно здесь, а также запоминаем размеры представления "по умолчанию" для последующего сброса.
        _view = _window.DefaultView;
        _rect = new FloatRect(_view.Center - _view.Size / 2.0F, _view.Size);

        _renderer = rendererFactory.Create(_window, _view);

        _logger.Info("Окно инициализировано.");
    }

    #region Обработка событий ...

    /// <summary>
    ///   Обрабатывает нажатие на кнопку закрыть.
    /// </summary>
    ///
    /// <param name="sender">Отправитель.</param>
    /// <param name="args">Аргументы события.</param>
    private void HandleClosed(object? sender, EventArgs args)
    {
        if (sender is RenderWindow window)
        {
            window.Close();
        }
    }

    /// <summary>
    ///   Обрабатывает нажатие клавиши.
    /// </summary>
    ///
    /// <param name="sender">Отправитель.</param>
    /// <param name="args">Аргументы события.</param>
    private void HandleKeyPressed(object? sender, KeyEventArgs args)
    {
        if (args != null)
        {
            var key = InputHelper.ToNative(args.Code);

            if (key.HasValue)
            {
                _keys = _keys.Add(key.Value);
            }
            else
            {
                _logger.Warn($"Нажата неизвестная клавиша '{args.Code}'.");
            }
        }
    }

    /// <summary>
    ///   Обрабатывает отпускание клавиши.
    /// </summary>
    ///
    /// <param name="sender">Отправитель.</param>
    /// <param name="args">Аргументы события.</param>
    private void HandleKeyReleased(object? sender, KeyEventArgs args)
    {
        if (args != null)
        {
            var key = InputHelper.ToNative(args.Code);

            if (key.HasValue)
            {
                _keys = _keys.Remove(key.Value);
            }
            else
            {
                _logger.Warn($"Отпущена неизвестная клавиша '{args.Code}'.");
            }
        }
    }

    /// <summary>
    ///   Обрабатывает нажатие кнопки.
    /// </summary>
    ///
    /// <param name="sender">Отправитель.</param>
    /// <param name="args">Аргументы события.</param>
    private void HandleButtonPressed(object? sender, MouseButtonEventArgs args)
    {
        if (args != null)
        {
            var button = InputHelper.ToNative(args.Button);

            if (button.HasValue)
            {
                _buttons = _buttons.Add(button.Value);
            }
            else
            {
                _logger.Warn($"Нажата неизвестная кнопка '{args.Button}'.");
            }
        }
    }

    /// <summary>
    ///   Обрабатывает отпускание кнопки.
    /// </summary>
    ///
    /// <param name="sender">Отправитель.</param>
    /// <param name="args">Аргументы события.</param>
    private void HandleMouseButtonReleased(object? sender, MouseButtonEventArgs args)
    {
        if (args != null)
        {
            var button = InputHelper.ToNative(args.Button);

            if (button.HasValue)
            {
                _buttons = _buttons.Remove(button.Value);
            }
            else
            {
                _logger.Warn($"Отпущена неизвестная кнопка '{args.Button}'.");
            }
        }
    }

    /// <summary>
    ///   Обрабатывает перемещение указателя.
    /// </summary>
    ///
    /// <param name="sender">Отправитель.</param>
    /// <param name="args">Аргументы события.</param>
    private void HandlePointerMoved(object? sender, MouseMoveEventArgs args)
    {
        if (sender is RenderWindow window
            && args != null)
        {
            var pixel = new Vector2i(args.X, args.Y);

            var coords = window.MapPixelToCoords(pixel);

            _pointerX = coords.X;
            _pointerY = coords.Y;
        }
    }

    #endregion Обработка событий ...

    /// <inheritdoc />
    public void Run(IRunnable runnable)
    {
        #region Проверка аргументов ...

        Throw.IfNull(runnable);

        #endregion Проверка аргументов ...

        _logger.Info("Запуск игрового цикла ...");

        // 20.0 - среднее количество обновлений в секунду.
        const float Micros = 1_000_000.0F / 20.0F;

        var clock = new Clock();
        var lag = 0.0F;

        var updates = 0;
        var renders = 0;

        var timer = new Clock();

        while (_window.IsOpen)
        {
            _window.DispatchEvents();

            lag += clock.Restart().AsMicroseconds();

            while (lag >= Micros)
            {
                Update(runnable);
                updates++;

                lag -= Micros;
            }

            var delta = lag / Micros;

            Render(runnable, delta);
            renders++;

            var time = timer.ElapsedTime;
            if (time > Time.FromSeconds(1))
            {
                _ = timer.Restart();

                _logger.Debug($"{updates}, {renders}");

                updates = 0;
                renders = 0;
            }
        }

        _logger.Info("Игровой цикл завершен.");
    }

    /// <summary>
    ///   Выполняет обновление указанного объекта.
    /// </summary>
    ///
    /// <param name="runnable">Объект для выполнения.</param>
    ///
    /// <exception cref="NullReferenceException">
    ///   Указанный объект для выполнения <paramref name="runnable" /> равен <see langword="null" />.
    /// </exception>
    private void Update(IRunnable runnable)
    {
        var context = new UpdateContext(this, this);

        runnable.Update(context);
    }

    /// <summary>
    ///   Выполняет отрисовку указанного объекта.
    /// </summary>
    ///
    /// <param name="runnable">Объект для выполнения.</param>
    /// <param name="delta">Дельта времени.</param>
    ///
    /// <exception cref="NullReferenceException">
    ///   Указанный объект для выполнения <paramref name="runnable" /> равен <see langword="null" />.
    /// </exception>
    private void Render(IRunnable runnable, float delta)
    {
        var context = new RenderContext(_renderer, delta);

        _window.Clear(Color.White);

        // Выполняем сброс представления.
        _view.Reset(_rect);

        _window.SetView(_view);

        runnable.Render(context);

        _window.Display();
    }

    /// <inheritdoc />
    public bool IsKeyPressed(KeyEnum key)
    {
        return _keys.Contains(key);
    }

    /// <inheritdoc />
    public bool IsButtonPressed(ButtonEnum button)
    {
        return _buttons.Contains(button);
    }

    /// <inheritdoc />
    public float GetPointerX()
    {
        return _pointerX;
    }

    /// <inheritdoc />
    public float GetPointerY()
    {
        return _pointerY;
    }

    /// <inheritdoc />
    public void Dispose()
    {
        _window.Closed -= HandleClosed;
        _window.KeyPressed -= HandleKeyPressed;
        _window.KeyReleased -= HandleKeyReleased;
        _window.MouseButtonPressed -= HandleButtonPressed;
        _window.MouseButtonReleased -= HandleMouseButtonReleased;
        _window.MouseMoved -= HandlePointerMoved;

        _window.Close();
        _window.Dispose();

        _logger.Warn("Окно уничтожено.");
    }
}
