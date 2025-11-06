/* World class for modeling the entire in-game world
 */

class World {
  Space entry;
  Registry registry;
  
  public World (Registry registry) {
	  this.registry = registry; // Access to registry for SpaceEvents
    Space entry    = new Space("Entry");
    Space corridor = new Space("Corridor");
    Space cave     = new Space("Cave");
	Space pit      = new Space("Darkest Pit");
    Space outside  = new Space("Outside");
    
    entry.AddEdge("door", corridor);
    corridor.AddEdge("door", cave);
    cave.AddEdge("north", pit);
    cave.AddEdge("south", outside);
    pit.AddEdge("door", cave);
    outside.AddEdge("door", cave);
	
	
	// Add welcome events to the cave
	cave.AddWelcomeEvent(new TextSE("Cave is spoopy.\n I cry in cavs.\n Hold my hands?"));
	cave.AddWelcomeEvent(new TextSE("You hold hands for 4 seconds, but then you piss pants. \n Very cringe, you should go."));
    cave.AddWelcomeEvent(new ExitsListSE(cave));
	
	
    this.entry = entry;
  }
  
  public Space GetEntry () {
    return entry;
  }
}

