/* Command for transitioning between spaces
 */

class CommandGo : BaseCommand, ICommand {
    public CommandGo () {
        description = "Follow an exit";
    }

    public void Execute(Context context, string command, string[] parameters) {
        if (context.Player.isInCombat)
        {
            Console.WriteLine("The monster is blocking the path. Try the command 'retreat' to go back.");
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
                    "You try to open the door, but it is locked. You realize you do not have all four keys yet");
                return;
            }
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
}
