using ConsoleAppFramework;
using Spectre.Console;
using Tholus.Cli.Logging;

namespace Tholus.Cli;

internal static class Program
{
    internal static unsafe void Main(string[] args)
    {
        try
        {
            ConsoleApp.Run(args, &HelloWorld);
        }
        finally
        {
            Logger.FlushAndClose();
        }
    }

    private static void HelloWorld()
    {
        AnsiConsole.MarkupLine(":waving_hand: [yellow]Hello, world![/]");
        Logger.Error("hello, log file as well");
        Logger.Warn("hello, log file as well");
        Logger.Info("hello, log file as well");
        Logger.Debug("hello, log file as well");
    }
}
