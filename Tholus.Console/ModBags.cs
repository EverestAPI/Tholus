using Cocona;

namespace Tholus.Console;

public class ModBags {

    [Command("add", Description = "Add a mod to a bag")]
    public void Add(ModBagParameters bag, ModSourceParameters mod) {
        System.Console.WriteLine($"TODO: Add new mod to bag: '{bag}' '{mod}'");
    }

    [Command("remove", Description = "Remove a mod from a bag")]
    public void Remove(ModBagParameters bag, ModParameters mod) {
        System.Console.WriteLine($"TODO: Remove mod from bag: '{bag}' '{mod}'");
    }

    [Command("list", Description = "List the mods contained in a bag")]
    public void List(ModBagParameters bag) {
        System.Console.WriteLine($"TODO: List mods of bag: '{bag}'");
    }

    [Command("apply", Description = "Apply a mod bag to an installation")]
    public void Apply(ModBagParameters bag, InstallParameters install) {
        System.Console.WriteLine($"TODO: Apply bag: '{bag}' '{install}'");
    }

    [Command("create", Description = "Create a new empty mod bag")]
    public void Create(ModBagParameters bag) {
        System.Console.WriteLine($"TODO: Create bag: '{bag}'");
    }

    [Command("destroy", Description = "Destroy an existing mod bag")]
    public void Destroy(ModBagParameters bag) {
        System.Console.WriteLine($"TODO: Destroy bag: '{bag}'");
    }
}
