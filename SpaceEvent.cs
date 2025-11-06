// Dummy template
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
	
	private string textToDisplay;
	
	public TextSE(string text){
		textToDisplay = text;
	}
	
	// Method which does the events intended behavior
	public void Trigger(){
		Console.WriteLine(textToDisplay);
		Console.Write("\nPress enter key to continue... ");
		Console.ReadLine();
		Console.SetCursorPosition(0, Console.CursorTop - 1);
		ClearCurrentConsoleLine();
	}
	
	public static void ClearCurrentConsoleLine()
	{
		int currentLineCursor = Console.CursorTop;
		Console.SetCursorPosition(0, Console.CursorTop);
		Console.Write(new string(' ', Console.WindowWidth)); 
		Console.SetCursorPosition(0, currentLineCursor);
	}
}


