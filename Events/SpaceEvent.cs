namespace WoZ.Events;
using System;
using WoZ;
using WoZ.Commands;
using WoZ.Interfaces;
using WoZ.Text;
/*
    Larger class for all space events.
    These events are triggered in spaces, and can have various effects such as spawning items or monsters, clearing the console, displaying text, etc.
*/

/*
    Event for placing items
    Can take a flag to await
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

/*
    Event for spawning monsters
    Can take a flag to await
 */
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
	An event which clears the console
	Can take a flag to await
 */
class RefreshScreenSE : IEvent
{

    private string flagToCheck;
    private Space space;

    public RefreshScreenSE(string flagToCheck, Space space)
    {
        this.flagToCheck = flagToCheck;
        this.space = space; 
    }

    // Method which does the events intended behavior
    public void Trigger()
    {
        Console.Clear();
        new CommandMap().ShowMap(space);
        Console.WriteLine("");
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
    An event which displays the monster alert for a space
    Can take a flag to await
 */
class MonsterAlertSE : IEvent
{

    private string flagToCheck;
    private Space space;

    public MonsterAlertSE(string flagToCheck, Space space)
    {
        this.flagToCheck = flagToCheck;
        this.space = space;
    }

    // Method which does the events intended behavior
    public void Trigger()
    {
        if(space.Monster != null)
        {
            space.PrintMonsterAlert();
        }
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
    Can take a flag to await
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
	
	// Method from interface which does the events intended behavior
	public void Trigger(){
		Console.WriteLine(displayText + "\n");
		if (actionText != "")
		{
			Console.Write($"> Press enter to {actionText}...");
			Console.ReadLine();
            Console.WriteLine("");
		}
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
    Can take a flag to await
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
