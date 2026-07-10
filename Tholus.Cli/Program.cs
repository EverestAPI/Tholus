using ConsoleAppFramework;
using Spectre.Console;

namespace Tholus.Cli;

internal static class Program
{
    internal static void Main(string[] args)
    {
        unsafe
        {
            ConsoleApp.Run(args, &HelloWorld);
        }
    }

    private static void HelloWorld()
    {
        AnsiConsole.MarkupLine(":waving_hand: [yellow]Hello, world![/]");
    }
}
