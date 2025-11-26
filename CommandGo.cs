/* Command for transitioning between spaces
 */

class CommandGo : BaseCommand, ICommand {
    public CommandGo () {
        description = "Follow an exit";
    }

    public void Execute(Context context, string command, string[] parameters) {
        if (GuardEq(parameters, 1))
        {
            Console.WriteLine("I don't seem to know where that is 🤔");
            return;
        }

/*         if (context.GetCurrent().Monster)
        {
            Monster? monster = context.GetCurrent().Monster;
            if (monster != null || monster!.IsAlive())
            {
                monster.Heal();
            }
        } */

        Monster? monster = context.GetCurrent().Monster;
        if (monster != null && monster!.IsAlive())
        {
            monster.Heal();
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
                    "You try to open the door, but it is locked. You realize you do not have all four keys yet");
                return;
            }
        }
        //Troels: Checking for keys before entering cleared zones
        //Peter: Modified to extract the repeating code and converting it into a helper method instead
        if (HasCleared(context, "S4 NPC", parameters[0], "north", World.Key3))
        {
            return;
        }
        if (HasCleared(context, "S4 NPC", parameters[0], "east", World.Key1))
        {
            return;
        }
        if (HasCleared(context, "S2", parameters[0], "north", World.Key2))
        {
            return;
        }
        if (HasCleared(context, "S3 NPC", parameters[0], "south", World.Key4))
        {
            return;
        }
        context.Transition(parameters[0]);
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
