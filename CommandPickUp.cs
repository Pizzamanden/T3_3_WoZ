//Magnus: Implements a class for picking up items

class CommandPickUp : BaseCommand, ICommand
{
	public CommandPickUp()
	{
		description = "Picks up an item";
	}
	public void Execute (Context context, string command, string[] parameters)
	{
	if (GuardEq(parameters, 1)) 
	{
	Console.WriteLine("I cannot pick that up");
     return;
	}
	//Magnus: Checks if there is an item in the current room
	Space current = context.GetCurrent();
	if (current.ItemCheck() == false)
	{
		Console.WriteLine("There's nothing to pick up here");
		return;
	}
	
	string commandInput = parameters[0];
	string itemKey = current.GetItem()!.GetKeyword();
	//Checks if the user's input matches the keyword
	//If yes, the item is collected and removed from the room. 
	if (commandInput == itemKey)
	{
		Item foundItem = current.CollectItem();
		context.InventoryAdd(foundItem);
		Console.WriteLine("You have picked up \"" + foundItem.GetName() + "\".");
	}
	else
	{
		Console.WriteLine("There is no such item here");
	}
}
}