/* World class for modeling the entire in-game world
*/

class World {
  Space entry;
  
  public World () {

    Zone startzone    = new Zone("Start", "Starting zone");
    Zone turism = new Zone("Turism", "The zone with Tourism trash!");
    Zone fishing = new Zone("Fishing", "The zone with all the fishing gear");
    Zone plastic = new Zone("plastic", "The plastic zone!");
    Zone ziggeretzone = new Zone("Zigarettes", "The zone with ziggerets!");
    Zone finalboss = new Zone("Final boss", "The final boss!");


    Space R1  = new Space(startzone, "dropzone");
    Space R2  = new Space(fishing,"Køgebugt motorway");
    Space R3  = new Space(fishing,"Brøndby Strand");
    Space R4  = new Space(turism,"Road to turism");
    Space R5  = new Space(turism,"Turism trash place");
    Space R6  = new Space(plastic, "Plastic pathway");
    Space R7  = new Space(plastic, "Plastic palace");
    Space R8  = new Space(ziggeretzone, "Ziggzone");
    Space R9  = new Space(finalboss, "The wasteway");
    Space R10 = new Space(finalboss, "Slagelse");



        R1.AddEdge("west", R2);
        R1.AddEdge("south", R9);
        R1.AddEdge("east", R6);
        R2.AddEdge("north", R3);
        R2.AddEdge("west", R4);
        R3.AddEdge("south", R2);
        R4.AddEdge("south", R5);
        R4.AddEdge("east", R2);
        R5.AddEdge("north", R4);
        R6.AddEdge("west", R1);
        R6.AddEdge("north", R7);
        R6.AddEdge("east", R8);
        R7.AddEdge("south", R6);
        R8.AddEdge("west", R6);
        R9.AddEdge("north", R1);
        R9.AddEdge("south", R10);
        R10.AddEdge("north", R9);    
        
        
        //Magnus: Adding keys and weapons to spaces
        /*entry.PlaceItem(new Item("Key part 1", "key"));
        pit.PlaceItem(new Item("Key part 2", "key"));
        corridor.PlaceItem(new Item("Weapon part 1", "weapon"));*/


        //Yarik: Adding NPCs to spaces
        /*List<string> dialogueListNPC1 = new List<string>
        {
        "Hello, agent. I'm NPC 1. Do you want to find out more about the monster?",
        "This is the plastic monster. You can defeat him by recycling the trash he's attacking you with."
        };
        cave.PlaceNPC(new NPC("NPC1", "Example description for NPC 1", dialogueListNPC1));
        corridor.PlaceNPC(new NPC("NPC2", "Example description for NPC 2", dialogueListNPC1));
        entry.PlaceNPC(new NPC("NPC3", "Example description for NPC 3", dialogueListNPC1));*/

        this.entry = R1;
    }

    public Space GetEntry () {
        return entry;
    }
}

