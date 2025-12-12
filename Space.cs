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

        if (Monster != null)
        {
            PrintMonsterAlert();
        }
  }

    /*Peter
     * Method to print monster alert when entering a space with a monster, or when a monster spawns in the space
     */
    public void PrintMonsterAlert()
    {
        // Print the current monster and a little extra decoration
        int borderLength = "---------------------------------------------------------------------------------".Length;
        string monsterText = $"{Monster!.Name} threatens you. Defeat it to proceed, or retreat for now";
        int padding = ((borderLength - monsterText.Length) / 2);
        monsterText = monsterText.PadLeft(borderLength - padding - 2, '-').PadRight(borderLength - 2, '-');
        monsterText = "!" + monsterText + "!";
        Console.WriteLine(monsterText);
        Console.WriteLine("Type <attack> to list all available attacks.\n");
    }
  
  public void Goodbye () {
	  while(eventsGoodbye.Count > 0)
      {
          if (eventsGoodbye[0].CanRun())
          {
              eventsGoodbye[0].Trigger();
              eventsGoodbye.RemoveAt(0);                
          }
          else
          {
              break;
          }
      }
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

    static public void PickupHint(Item item)
    {
        if (item != null){
            Console.WriteLine($"You should probably <pickup> the {item.GetName()}...\n");
        }
    }

    static public void TalkHint(NPC npc)
    {
        if(npc == null) return;
        bool ivanTalk = (npc.HasMoreDialouge() && npc.GetName() == "Ivan Nalive" && Flags.GetFlag(Flags.C_S6_Monster_Dead));
        bool samuraiTalk = (npc.HasMoreDialouge() && npc.GetName() == "Samurai" && Flags.GetFlag(Flags.M_S3_Pickup_Barbie));
        if ((npc.GetName() != "Ivan Nalive" && npc.GetName() != "Samurai" && npc.HasMoreDialouge()) || ivanTalk || samuraiTalk)
        {
          Console.WriteLine($"Seems like {npc.GetName()} wants to <talk>...\n");
        }
    }
}