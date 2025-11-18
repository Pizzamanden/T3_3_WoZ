/* World class for modeling the entire in-game world
*/

class World {
  Space entry;
  Registry? registry;
  
  public World (Registry registry) {

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
        
    }

  public Space GetEntry () {
    return entry;
  }
}

