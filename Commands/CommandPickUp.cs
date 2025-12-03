//Magnus: Implements a class for picking up items
namespace WoZ.Commands;
using WoZ.Interfaces;
class CommandPickUp : BaseCommand, ICommand
{
	public CommandPickUp()
	{
		description = "Picks up an item";
	}
	public void Execute (Context context, string command, string[] parameters) {
        if (context.Player.isInCombat)
        {
            Console.WriteLine("You don't have time to pick anything up.");
            return;
        }

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
		//Troels: Checks if there is a monster in the room and if it's alive
		if (current.GetMonster() != null && current.GetMonster().IsAlive())
		{
			Console.WriteLine("You cannot pick up items while a monster is present!");
			return;
		}
		string commandInput = parameters[0];
		string itemKey = current.GetItem()!.GetKeyword();
		Item foundItem = current.CollectItem();
		//Checks if the user's input matches the keyword
		//If yes, the item is collected and removed from the room. 
		if (commandInput == itemKey || commandInput == foundItem.GetName().ToLower())
		{
			context.InventoryAdd(foundItem);
			Console.WriteLine("You have picked up \"" + foundItem.GetName() + "\".");
			context.GetNewAttack(World.D1, World.D2, "acid", 25, "Chemical");
			context.GetNewAttack(World.TL1, World.TL1, "Bins", 25, "Recycling");
			
		}
		else
		{
			Console.WriteLine("There is no such item here");
		}
	}
}