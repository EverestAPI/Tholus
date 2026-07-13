using ConsoleAppFramework;
using Spectre.Console;
using Tholus.Cli.Config;
using Tholus.Cli.Logging;

namespace Tholus.Cli;

internal static class Tholus
{
    private static async Task Initialize()
    {
        await TholusConfig.ReadConfig();
    }

    internal static async Task Main(string[] args)
    {
        try
        {
            await Initialize();
            await ConsoleApp.RunAsync(args, HelloWorld);
        }
        finally
        {
            Finalize();
        }
    }

    private static async Task HelloWorld()
    {
        AnsiConsole.MarkupLine(":waving_hand: [yellow]Hello, world![/]");
        int runCount = ++TholusConfig.Instance.RunCount;
        Logger.Info($"Incrementing run count to {runCount}.");
        AnsiConsole.MarkupLineInterpolated($"Tholus has been run [cyan]{runCount}[/] times.");
        await TholusConfig.WriteConfig();
    }

    // this is a static class lmao
    #pragma warning disable CS0465 // Introducing a 'Finalize' method can interfere with destructor invocation
    private static void Finalize()
    {
        Logger.FlushAndClose();
    }
    #pragma warning restore CS0465 // Introducing a 'Finalize' method can interfere with destructor invocation
}
