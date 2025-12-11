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

		//Magnus: Checks if there is an item in the current room
		Space current = context.GetCurrent();
		if (current.ItemCheck() == false)
		{
			Console.WriteLine("There's nothing to pick up here");
			return;
		}
		//Troels: Checks if there is a monster in the room and if it's alive
		if (context.IsInCombat())
		{
			Console.WriteLine("You cannot pick up items while a monster is present!");
			return;
		}

		Item foundItem = current.CollectItem();
		if (foundItem.FlagToSet != "")
		{
			foundItem.SetFlag(foundItem.FlagToSet);
		}
		context.InventoryAdd(foundItem);
		Console.WriteLine("You have picked up \"" + foundItem.GetName() + "\".");
		context.GetNewAttack(World.D_Chemicals, World.D_Chemicals, "acid", 7, 10,"chemical", "");
		context.GetNewAttack(World.TL_Bins, World.TL_Bins, "bins", 8, 10,"recycling", Flags.Got_Bins);
		context.GetNewAttack(World.M_Sword, World.M_Sword, "sword", 8, 9,"slice", Flags.Got_Sword);
		context.GetNewAttack(World.C1, World.C2, "lighter", 5, 12, "fire", Flags.Got_Lighter, World.C3);
	}
}