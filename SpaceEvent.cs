// Dummy template
using System.Text;
class DummySE : IEvent{
	
	// Method which does the events intended behavior
	public void Trigger(){
		Console.WriteLine("Dummy event");
	}
}

/*
	An event for displaying one (1) textblock.
	
*/
class TextSE : IEvent{
	
	private string displayText;
    private string actionText;

    public TextSE(string displayText, string actionText = "Press enter to continue..."){
        this.displayText = displayText;
		this.actionText = actionText;

    }
	
	// Method which does the events intended behavior
	// https://stackoverflow.com/questions/8946808/can-console-clear-be-used-to-only-clear-a-line-instead-of-whole-console
	public void Trigger(){
		Console.WriteLine(displayText);
		Console.Write($"\n> {actionText}");
		Console.ReadLine();
		Console.WriteLine("");
		//Console.SetCursorPosition(0, Console.CursorTop - 1);
		//ClearCurrentConsoleLine();
	}
	
	public static void ClearCurrentConsoleLine()
	{
		int currentLineCursor = Console.CursorTop;
		Console.SetCursorPosition(0, Console.CursorTop);
		Console.Write(new string(' ', Console.WindowWidth)); 
		Console.SetCursorPosition(0, currentLineCursor);
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
}


/*
	An event which can talk to an NPC in the given space

class TalkSE : IEvent{
	
	private Space space;
	
	public TalkSE(Space space){
		this.space = space;
	}
	
	public void Trigger(){
		if(space.HasNPC() == true){
			space.GetNPC().Talk();
		}
	}
}*/


/*
	An event which can fight a monster in the given space

class FightSE : IEvent{
	
	private Space space;
	
	public FightSE(Space space){
		this.space = space;
	}
	
	public void Trigger(){
		if(space.HasMonster() == true){
			space.GetMonster().Fight();
		}
	}
}*/


/*
	An event which can talk to an NPC in the given space
*/
class PickUpSE : IEvent{
	
	private Context context;
	private Registry registry;
	private string[] itemName = new string[1];
	
	public PickUpSE(Context context, Registry registry, string itemName){
		this.context = context;
		this.registry = registry;
		this.itemName[0] = itemName;
	}
	
	public void Trigger(){
		registry.GetCommand(CommandNames.CommandPickup).Execute(context, CommandNames.CommandPickup, itemName);
	}
}

/*
	An event which could display some monster
	Currently it just staticly displays text, but we could always make some monster archetypes, like Slime.
	Then you could make more clones of this class and call them DisplaySlimeEvent.
	I donnu about the UTF8 encoding, i cannot get it to work
 */
class DisplayMonsterSE : IEvent{
	
	public void Trigger(){
		Console.OutputEncoding = Encoding.UTF8;
		string art = @"
dadad               dadawdwd ⠿⠿⠿⠿⠿
daddd
		";
		Console.WriteLine(art);
	}
	
}