//Yarik: Command to get all items and NPCs in the room
class CommandExploreRoom : BaseCommand, ICommand
{
    public CommandExploreRoom()
    {
        description = "Show items currently in your inventory";
    }
    public void Execute(Context context, string command, string[] parameters)
    {
        Space current = context.GetCurrent();
        Item item = current.GetItem()!;
        NPC npc = current.GetNPC()!;

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
            Console.WriteLine($"NPCs in the current room: {npc.GetName()}");
        }

    }
}