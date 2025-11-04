/* World class for modeling the entire in-game world
 */

class World {
  Space entry;
  
  public World () {
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
    
    //Magnus: Adding keys to spaces
    entry.PlaceItem(new Item("Key part 1"));
    pit.PlaceItem(new Item("Key part 2"));
    
    this.entry = entry;
  }
  
  public Space GetEntry () {
    return entry;
  }
}

