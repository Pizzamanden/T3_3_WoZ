/* World class for modeling the entire in-game world
 */

class World {
  Space entry;
  
  public World () {
    Space entry    = new Space("Entry");
    Space corridor = new Space("Corridor");
	
	List<IEvent> caveWelcomeEvents = new List<IEvent>();
	caveWelcomeEvents.Add(new TextSE("Cave is spoopy.\n I cry in cavs.\n Hold my hands?"));
	caveWelcomeEvents.Add(new TextSE("You hold hands for 4 seconds, but then you piss pants. \n Very cringe, you should go."));
    Space cave     = new Space("Cave", caveWelcomeEvents);
    
	Space pit      = new Space("Darkest Pit");
    Space outside  = new Space("Outside");
    
    entry.AddEdge("door", corridor);
    corridor.AddEdge("door", cave);
    cave.AddEdge("north", pit);
    cave.AddEdge("south", outside);
    pit.AddEdge("door", cave);
    outside.AddEdge("door", cave);
    
    this.entry = entry;
  }
  
  public Space GetEntry () {
    return entry;
  }
}

