// Dummy template
namespace WoZ.Events;


using WoZ;
using WoZ.Commands;
using WoZ.Interfaces;
using WoZ.Text;

class DummySE : IEvent{
    public bool CanRun()
    {
        return true;
    }

    // Method which does the events intended behavior
    public void Trigger(){
		Console.WriteLine("Dummy event");
	}
}


/*
 Event for placing items
 */
class SpawnItemSE : IEvent
{
    private string flagToCheck;
    private Item item;
    private Space space;

    public SpawnItemSE(string flagToCheck, Item itemToSpawn, Space spaceToSpawnIn)
    {
        this.flagToCheck = flagToCheck;
        this.item = itemToSpawn;
        this.space = spaceToSpawnIn;
    }

    public bool CanRun()
    {
        if (flagToCheck == "")
        {
            return true;
        }
        return Flags.GetFlag(flagToCheck);
    }

    public void Trigger()
    {
        space.PlaceItem(item);
    }
}

class SpawnMonsterSE : IEvent{
    private string flagToCheck;
	private Monster monster;
	private Space space;

	public SpawnMonsterSE(string flagToCheck, Monster monsterToSpawn, Space spaceToSpawnIn) 
    {
        this.flagToCheck = flagToCheck;
		this.monster = monsterToSpawn;
		this.space = spaceToSpawnIn;
    }
	
	public bool CanRun()
    {
        if (flagToCheck == "")
        {
            return true;
        }
        return Flags.GetFlag(flagToCheck);
    }

    public void Trigger()
	{
		space.Monster = monster;
	}
}

/*
	An event which clears the console
	Can take a flag to await
 */
class ClearConsoleSE : IEvent{

    private string flagToCheck;

    public ClearConsoleSE(string flagToCheck)
    {
        this.flagToCheck = flagToCheck;
    }

    // Method which does the events intended behavior
    public void Trigger(){
		Console.Clear();
	}

	public bool CanRun()
    {
        if (flagToCheck == "")
        {
            return true;
        }
        return Flags.GetFlag(flagToCheck);
    }
}

/*
	An event for displaying one (1) textblock.
*/
class TextSE : IEvent{
	
	private string displayText;
    private string actionText;
	private string flagToCheck;
	private string flagToSet;

    public TextSE(string actionText, string flagToCheck, string flagToSet, string displayText){
        this.displayText = displayText;
		this.actionText = actionText;
		this.flagToCheck = flagToCheck;
		this.flagToSet = flagToSet;
    }

	public bool CanRun()
    {
		if (flagToCheck == "")
        {
            return true;
        }
        return Flags.GetFlag(flagToCheck);
    }
	
	// Method which does the events intended behavior
	// Code which clears line (Not currently used, preserving link)
	// https://stackoverflow.com/questions/8946808/can-console-clear-be-used-to-only-clear-a-line-instead-of-whole-console
	public void Trigger(){
		Console.WriteLine(displayText);
		if (actionText != "")
		{
			Console.Write($"> Press enter to {actionText}...");
			Console.ReadLine();
		}
		Console.WriteLine("");
		if (flagToSet != "")
        {
            Flags.SetFlag(flagToSet);
        }
	}
}

/*
	An event which seeks to replace the current behavior of the Welcome() method.
	It prints the list of exits when triggered.
	It takes a Space in its constructor, for which it will print all exits which exists when the trigger is called.
*/
class ExitsListSE : IEvent{

	private Space space;
	
	public ExitsListSE(Space space){
		this.space = space;
	}
	
	public void Trigger(){
		HashSet<string> exits = space.GetEdges();
		Console.WriteLine("Current options are:");
		foreach (String exit in exits) {
			Console.WriteLine(" - "+exit);
		}
	}

	public bool CanRun()
    {
        return true;
    }
}


/*
	An event which ends the game
*/
class EndGameSE : IEvent{
	
	private Context context;
	private string flagToCheck;

	public bool CanRun()
    {
        if (flagToCheck == "")
        {
            return true;
        }
        return Flags.GetFlag(flagToCheck);
    }

    public EndGameSE(string flagToCheck, Context context){
		this.context = context;
        this.flagToCheck = flagToCheck;
    }
	
	public void Trigger(){
		context.MakeDone();
    }
}

/*
	An event which can talk to an NPC in the given space
*/
class PickUpSE : IEvent{
	
	private Context context;
	private Registry registry;
	private string[] itemName = new string[1];
	private string flagToCheck;
	
	public PickUpSE(string flagToCheck, Context context, Registry registry, string itemName){
		this.context = context;
		this.registry = registry;
		this.itemName[0] = itemName;
		this.flagToCheck = flagToCheck;

    }
	
	public void Trigger(){
		registry.GetCommand(CommandNames.Pickup).Execute(context, CommandNames.Pickup, itemName);
	}

	public bool CanRun()
    {
        if (flagToCheck == "")
        {
            return true;
        }
        return Flags.GetFlag(flagToCheck);
    }
}

class UpdateMonsterDamageSE : IEvent{
    private string flagToCheck;
	private Monster monster;
	private int newDamage;

	public UpdateMonsterDamageSE(string flagToCheck, Monster monsterToUpdate, int newDamage) 
    {
        this.flagToCheck = flagToCheck;
		this.monster = monsterToUpdate;
		this.newDamage = newDamage;
    }
	
	public bool CanRun()
    {
        if (flagToCheck == "")
        {
            return true;
        }
        return Flags.GetFlag(flagToCheck);
    }

    public void Trigger()
	{
		monster.AttackDamage = newDamage;
	}
}
