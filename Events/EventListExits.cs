/*
	An event which seeks to replace the current behavior of the Welcome() method.
	It prints the list of exits when triggered.
	It takes a Space in its constructor, for which it will print all exits which exists when the trigger is called.
*/
class EventListExits : IEvent{

	private Space space;
	
	public EventListExits(Space space){
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