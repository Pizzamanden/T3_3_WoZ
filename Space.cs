/* Space class for modeling spaces (rooms, caves, ...)
*/
namespace WoZ;
using WoZ.Events;
using WoZ.Commands;
using WoZ.Interfaces;

class Space : Node {

  public Zone zone;
  private Item? item;
  private NPC? npc;
  public Monster? Monster { get; set; }

  private List<IEvent> eventsWelcome = new List<IEvent>();
  private List<IEvent> eventsGoodbye = new List<IEvent>();

  public Space(Zone zone, string name) : base(name)
  {
      this.zone = zone;
      zone.AddSpace(this); // registrerer rummet i zonen
  }
  
  // Mikkel: Console clear and map shows when you enter new space
  public void Welcome () {
        if (this.name != "S1-TrueStart")
        {
            Console.Clear();
            new CommandMap().ShowMap(this);
            Console.WriteLine("");
        }

        RunWelcomeEvents();

    

    if (Monster == null)
    {
        // ExitList(this);
    }
    else
    {
        Console.WriteLine("A monster threatens. You must either defeat it, or retreat, to proceede.");
    }
  }
  
  public void Goodbye () {
	  // Check if a goodbye event has been set
  }
  
  public void RunWelcomeEvents()
  {
      while(eventsWelcome.Count > 0)
      {
          if (eventsWelcome[0].CanRun())
          {
              eventsWelcome[0].Trigger();
              eventsWelcome.RemoveAt(0);                
          }
          else
          {
              break;
          }
      }
  }


  public override Space? FollowEdge (string direction) {
    return (this.HasEdge(direction) ? (Space) (base.FollowEdge(direction)!) : null);
  }
  
  // Add an event to this space, which will trigger inside the Welcome() method
  // The order of adding events matter, first added is first played
  public void AddWelcomeEvent(IEvent e){
    this.eventsWelcome.Add(e);
  }
  public void AddGoodbyeEvent(IEvent e)
  {
      this.eventsGoodbye.Add(e);
  }

    //Yarik: Places npc in a space
    public void PlaceNPC(NPC npc)
	{
		this.npc = npc;
	}
  //Yarik: Checks if npc is in a space
  public bool NPCCheck()
  {
    return npc != null;
  }

	//Yarik: returns the item without removing it
	public NPC? GetNPC()
	{
		return npc;
	}

  
  //Magnus: Places the item on a space
  public void PlaceItem(Item item)
  {
  	this.item = item;
  }
  
  //Magnus: Returns true if the space holds an item
  public bool ItemCheck()
  {
  	return item != null;
  }
  
  //Magnus: returns the item without removing it
  public Item? GetItem()
  {
  	return item;
  }
  // Troels: returns the inventory of the space (either empty or with one item)
  public List<Item> GetInventory()
  {
    List<Item> items = new List<Item>();
    if (item != null)
    {
        items.Add(item);
    }
    return items;
  }
// Troels: returns the monster in the space
public Monster GetMonster()
    {
        return Monster!;
    }

  //Magnus: Picks up the item and removes it
  public Item CollectItem()
  {
  	Item collected = item!;
  	item = null;
  	return collected;
  }

  static public void ExitList(Space space)
  {
    HashSet<string> exits = space.GetEdges();
		Console.WriteLine("Current options are:");
		foreach (String exit in exits) {
		  Console.WriteLine(" - "+exit);
  }
}
}
