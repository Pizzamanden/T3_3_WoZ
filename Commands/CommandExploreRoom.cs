//Yarik: Command to get all items and NPCs in the room
class CommandExploreRoom : BaseCommand, ICommand
{
    public CommandExploreRoom()
    {
        description = "See what other things are in this room";
    }
    public void Execute(Context context, string command, string[] parameters)
    {
        Space current = context.GetCurrent();
        Item? item = current.GetItem();
        NPC? npc = current.GetNPC();
        Monster? monster = current.Monster;

        //show items
        if (item == null)
        {
            Console.WriteLine("There are no items in this room.");
        }
        else
        {
            Console.WriteLine($"Items in the current room: {item.GetName()}");
        }

        //show npcs
        if (npc == null)
        {
            Console.WriteLine("There are no NPCs in this room.");
        }
        else
        {
            Console.WriteLine($"NPC in the current room: {npc.GetName()}");
        }

        // Peter: Show monsters
        if (monster == null)
        {
            Console.WriteLine("There are no monsters in this room.");
        }
        else
        {
            Console.WriteLine($"Monster in the current room: {monster.Name}");
        }

    }
}