﻿using Blowfish.Program.Composition;
using log4net;
using log4net.Config;
using System;
using System.Text;

namespace Blowfish.Program;

public static class Program
{
    public static void Main()
    {
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

        _ = XmlConfigurator.Configure();

        var log = LogManager.GetLogger(typeof(Program));

        try
        {
            using (var root = new Root())
            {
                var application = root.ResolveAndGet<Application>();
                application.Start();
            }
        }
        catch (Exception exception)
        {
            log.Fatal("Необработанное исключение.", exception);
        }

        log.Info("Выход из программы ...");
    }
}