/* Command for transitioning between spaces
 */
namespace WoZ.Commands;
using WoZ.Interfaces;
using System;
using System.Collections.Generic;

class CommandGo : BaseCommand, ICommand {
    public CommandGo () {
        description = "Follow an exit: Type \"go <direction>\" to follow a direction.\n";
    }

    public void Execute(Context context, string command, string[] parameters) {
        if (context.Player.isInCombat)
        {
            Console.WriteLine($"\n{context.GetCurrent().Monster!.Name} is blocking the path. Try the command <retreat> to go back, or <attack> to list all available attacks.\n");
            return;
        }

        if (GuardEq(parameters, 1))
        {
            Console.WriteLine("I don't seem to know where that is 🤔");
            return;
        }
        
        //Checking for keys before entering the tower section of the map
        if (context.GetCurrent().GetName() == "S5" && parameters[0] == "south")
        {
            List<Item> inventory = context.GetInventory();

            if (!(inventory.Contains(World.Key1) &&
                  inventory.Contains(World.Key2) &&
                  inventory.Contains(World.Key3) &&
                  inventory.Contains(World.Key4)))
            {
                Console.WriteLine( 
                    "You're surprised to find the gate locked… realizing you probably \nshould have paid more attention to the pilot earlier. \nYou realize you still do not have all four key parts yet\n");
                return;
            }
        }

        //Troels: Checking for keys before entering cleared zones
        //Peter: Modified to extract the repeating code and converting it into a helper method instead
        if (HasCleared(context, "S4", parameters[0], "north", World.Key3))
        {
            return;
        }
        if (HasCleared(context, "S4", parameters[0], "east", World.Key1))
        {
            return;
        }
        if (HasCleared(context, "S2", parameters[0], "north", World.Key2))
        {
            return;
        }
        if (HasCleared(context, "S3", parameters[0], "south", World.Key4))
        {
            return;
        }

        context.Transition(parameters[0]);
        Monster? monster = context.GetCurrent().Monster;
        if (monster != null && monster!.IsAlive())
        {
            context.Player.isInCombat = true;
        } else
        {
            context.Player.isInCombat = false;
        }

    }

    private bool HasCleared(Context context, string currentSpace, string param, string direction, Item item)
    {
        if (context.GetCurrent().GetName() == currentSpace && param == direction)
        {
            List<Item> inventory = context.GetInventory();
            if (inventory.Contains(item))
            {
                Console.WriteLine(
                            "You have cleared this zone for monsters and the cleaning crews are doing their job.");
                    return true;
            }
        }
        return false;
        
    }
}
