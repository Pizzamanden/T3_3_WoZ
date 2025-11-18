/*
	An event for displaying one (1) textblock.
*/
class EventText : IEvent{
	
	private string displayText;
    private string actionText;

    public EventText(string displayText, string actionText = "Press enter to continue..."){
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