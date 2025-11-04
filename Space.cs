/* Space class for modeling spaces (rooms, caves, ...)
 */

class Space : Node {
  
  private Item? item;
  
  public Space (String name) : base(name)
  {
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
