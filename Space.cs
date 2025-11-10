/* Space class for modeling spaces (rooms, caves, ...)
*/

class Space : Node {
<<<<<<< HEAD


    public Zone zone;
    private Item? item;
    private NPC? npc;

    public Space(Zone zone, string name) : base(name)
    {
        this.zone = zone;
        zone.AddSpace(this); // registrerer rummet i zonen
=======
   public Monster? Monster { get; set; }
  public Space (String name) : base(name)
    {
        
>>>>>>> origin/NHS_player
    }
  
  public void Welcome () {
    Console.WriteLine("You are now at "+name);
    HashSet<string> exits = edges.Keys.ToHashSet();
    Console.WriteLine("Current exits are:");
    foreach (String exit in exits) {
      Console.WriteLine(" - "+exit);
    }
  }
  
  public void Goodbye () {
  }
  
  public override Space FollowEdge (string direction) {
    return (Space) (base.FollowEdge(direction));
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
  
  //Magnus: Picks up the item and removes it
  public Item CollectItem()
  {
  	Item collected = item!;
  	item = null;
  	return collected;
  }
}
