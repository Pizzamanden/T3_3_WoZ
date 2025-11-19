//Magnus: Class for checking your inventory
class CommandCheckInventory : BaseCommand, ICommand
{
    public CommandCheckInventory()
    {
        description = "Show items currently in your inventory";
    }
    public void Execute(Context context, string command, string[] parameters)
    {
        List<Item> items = context.GetInventory();

        if (items.Count == 0)
        {
            Console.WriteLine("Your inventory is currently empty");
            return;
        }
        else
        {
            Console.WriteLine("You are currently carrying:");
            foreach (Item item in items)
            {
                Console.WriteLine(" > " + item.GetName());
            }
        }

    }
}
