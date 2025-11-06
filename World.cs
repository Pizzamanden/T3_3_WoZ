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
    
    List<string> dialogueListNPC1 = new List<string>
    {
      "Hello, agent. I'm NPC 1. Do you want to find out more about the monster?",
      "This is the plastic monster. You can defeat him by recycling the trash he's attacking you with."
    };
    
    cave.PlaceNPC(new NPC("NPC1", "Example description for NPC 1", dialogueListNPC1));

    this.entry = entry;
  }
  
  public Space GetEntry () {
    return entry;
  }
}

