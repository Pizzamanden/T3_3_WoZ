//Magnus: Implements a class for picking up items

class CommandPickUp : BaseCommand, ICommand
{
	public void Execute (Context context, string command, string[] parameters)
	{
	if (GuardEq(parameters, 1)) 
	{
	Console.WriteLine("I cannot pick that up");
     return;
	}
	
	Space current = context.GetCurrent();
	if (current.ItemCheck() == false)
	{
		Console.WriteLine("There's nothing to pick up here");
		return;
	}

	string commandInput = parameters[0];
	string itemKey = current.GetItem()!.GetKeyword();
	
	if (commandInput == itemKey)
	{
		Item foundItem = current.CollectItem();
		Console.WriteLine("You have picked up \"" + foundItem.GetName() + "\".");
	}
	else
	{
		Console.WriteLine("There is no such item here");
	}
}
}