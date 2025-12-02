/* Space class for modeling spaces (rooms, caves, ...)
*/

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
  
  public void Welcome () {
    this.AddWelcomeEvent(new ExitsListSE(this));
	    
    while(eventsWelcome.Count > 0)
        {
            eventsWelcome[0].Trigger();
            eventsWelcome.RemoveAt(0);
        }

  }
  
  public void Goodbye () {
	  // Check if a goodbye event has been set
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
}
