using Cocona;
using Tholus.Console;

public record InstallParameters(
    [Argument("install", Description = "Name of the target installation")]
    string? Name
) : ICommandParameterSet;

public record ModBagParameters(
    [Argument("bag", Description = "Name of the target mod bag")]
    string Name
) : ICommandParameterSet;

public record ModParameters(
    [Argument("name", Description = "Name of the mod")]
    string Name
) : ICommandParameterSet;

public record ModSourceParameters(
    [Argument("source", Description = "Source of the mod to be installed")]
    string Source
) : ICommandParameterSet;

[HasSubCommands(typeof(Mods), Description = "Manage individual mods of installations")]
[HasSubCommands(typeof(ModBags), Description = "Manage collections of mods which can be applied to installations")]
public class Program
{
    public static void Main(string[] args)
    {
        CoconaApp.Run<Program>(args, options =>
        {
            options.TreatPublicMethodsAsCommands = false;
        });
    }

    [Command("add", Description = "Add an existing installation to the list Tholus knows about")]
    public static void Add(string name, string path)
    {
        System.Console.WriteLine($"TODO: Add new install: '{name}' '{path}'");
    }

    [Command("remove", Description = "Remove an installation from the list Tholus knows about")]
    public static void Remove(string name)
    {
        System.Console.WriteLine($"TODO: Remove install: '{name}'");
    }

    [Command("list", Description = "List all known installations")]
    public static void List()
    {
        System.Console.WriteLine($"TODO: List installs");
    }

    [Command("install", Description = "Install Everest to an installation")]
    public static void InstallEverest(string name, string everestVersion)
    {
        System.Console.WriteLine($"TODO: Install Everest: '{name}' '{everestVersion}'");
    }

    [Command("uninstall", Description = "Uninstall Everest from an installation")]
    public static void UninstallEverest(string name)
    {
        System.Console.WriteLine($"TODO: Uninstall Everest: '{name}'");
    }

    [Command("launch", Description = "Launch an installation")]
    public static void Launch(string name, bool vanilla)
    {
        System.Console.WriteLine($"TODO: Launch install: '{name}' Vanilla: {vanilla}");
    }
}
