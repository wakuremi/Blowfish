using Blowfish.Program.Composition;
using log4net;
using log4net.Config;
using System;
using System.Text;
using System.Windows.Forms;

namespace Blowfish.Program;

public static class Program
{
    [STAThread]
    public static void Main()
    {
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

        _ = XmlConfigurator.Configure();

        var log = LogManager.GetLogger(typeof(Program));

        try
        {
            using (var root = new Root())
            {
                ApplicationConfiguration.Initialize();

                var form = root.GetInstance<Form1>();

                Application.Run(form);
            }
        }
        catch (Exception exception)
        {
            log.Fatal("Необработанное исключение.", exception);
        }

        log.Info("Завершение работы ...");
    }
}
