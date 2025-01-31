using Cocona;

namespace Tholus.Console;

public class Mods {

    [Command("add", Description = "Add a mod to an installation")]
    public void Add(ModSourceParameters mod, InstallParameters install) {
        System.Console.WriteLine($"TODO: Add new mod: '{install}' '{mod}'");
    }

    [Command("remove", Description = "Remove a mod from an installation")]
    public void Remove(ModParameters mod, InstallParameters install) {
        System.Console.WriteLine($"TODO: Remove mod: '{install}' '{mod}'");
    }

    [Command("list", Description = "List all mods enabled for an installation")]
    public void List(InstallParameters install) {
        System.Console.WriteLine($"TODO: List mods: '{install}'");
    }

    [Command("enable", Description = "Enable a mod for an installation")]
    public void Enable(ModParameters mod, InstallParameters install) {
        System.Console.WriteLine($"TODO: Enable mod: '{install}' '{mod}'");
    }

    [Command("disable", Description = "Disable a mod for an installation")]
    public void Disable(ModParameters mod, InstallParameters install) {
        System.Console.WriteLine($"TODO: Disable mod: '{install}' '{mod}'");
    }

    [Command("create", Description = "Create a new mod from a template")]
    public void Create(ModParameters mod, [Argument(Description = "Template for the mod")] string template, InstallParameters install) {
        System.Console.WriteLine($"TODO: Create mod: '{install}' '{template}' '{mod}'");
    }

    [Command("build", Description = "Build a mod's source code")]
    public void Build(ModParameters mod, InstallParameters install) {
        System.Console.WriteLine($"TODO: Build mod: '{install}' '{mod}'");
    }

    [Command("purge", Description = "Remove outdated or unused dependency mods for an installation")]
    public void Purge(InstallParameters install, bool outdated, bool implicitlyInstalled) {
        System.Console.WriteLine($"TODO: Purge mods: '{install}' Outdated: '{outdated}' ImplicityInstalled: {implicitlyInstalled}");
    }
}
