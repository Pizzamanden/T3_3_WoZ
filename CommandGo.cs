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
        if (context.GetCurrent().GetName() == "S4 NPC" && parameters[0] == "east")
        {
            List<Item> inventory = context.GetInventory();

            if (inventory.Contains(World.Key1))
                  
            {
                Console.WriteLine(
                    "You have cleared this zone for monsters and the cleaning crews are doing their job.");
                return;
            }
        }
        if (context.GetCurrent().GetName() == "S2" && parameters[0] == "north")
        {
            List<Item> inventory = context.GetInventory();

            if (inventory.Contains(World.Key2))
                  
            {
                Console.WriteLine(
                    "You have cleared this zone for monsters and the cleaning crews are doing their job.");
                return;
            }
        }if (context.GetCurrent().GetName() == "S4 NPC" && parameters[0] == "north")
        {
            List<Item> inventory = context.GetInventory();

            if (inventory.Contains(World.Key3))
                  
            {
                Console.WriteLine(
                    "You have cleared this zone for monsters and the cleaning crews are doing their job.");
                return;
            }
        }
        if (context.GetCurrent().GetName() == "S3 NPC" && parameters[0] == "south")
        {
            List<Item> inventory = context.GetInventory();

            if (inventory.Contains(World.Key4))
                  
            {
                Console.WriteLine(
                    "You have cleared this zone for monsters and the cleaning crews are doing their job.");
                return;
            }
        }
        context.Transition(parameters[0]);
        }
    }
