/* Space class for modeling spaces (rooms, caves, ...)
 */

class Space : Node {
	
	private List<IEvent> eventsWelcome;
	//private List<IEvent> eventsGoodbye;
	
  public Space (String name, List<IEvent> eventsWelcome) : base(name)
  {
	  this.eventsWelcome = eventsWelcome;
  }
  
  public Space (String name) : base(name)
  {
	  this.eventsWelcome = new List<IEvent>();
  }
  
  public void Welcome () {
    Console.WriteLine("You are now at "+name);
    HashSet<string> exits = edges.Keys.ToHashSet();
    Console.WriteLine("Current exits are:");
    foreach (String exit in exits) {
      Console.WriteLine(" - "+exit);
    }
	
	// Check if a welcome event has been set
	if(eventsWelcome.Count > 0){
		foreach (IEvent e in eventsWelcome){
			e.Trigger();
		}
	}
	
  }
  
  public void Goodbye () {
	  // Check if a goodbye event has been set
	
  }
  
  public override Space? FollowEdge (string direction) {
    return (this.HasEdge(direction) ? (Space) (base.FollowEdge(direction)!) : null);
  }
  
}
