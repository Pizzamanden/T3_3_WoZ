/* Context class to hold all context relevant to a session.
 */

class Context {
  Space current;
  bool done = false;
  
  //Magnus: Inventory list to store multiple items
  private List<Item> inventory = new List<Item>();
  
  public Context (Space node) {
    current = node;
  }

  //Magnus: Adding a pickup up item to the inventory
  public void InventoryAdd(Item item)
  {
    inventory.Add(item);
  }

  //Magnus: Returning the inventory
  public List<Item> GetInventory()
  {
    return inventory;
  }
  
  public Space GetCurrent() {
    return current;
  }
  
  public void Transition (string direction) {
    Space next = current.FollowEdge(direction);
    if (next==null) {
      Console.WriteLine("You are confused, and walk in a circle looking for '"+direction+"'. In the end you give up 😩");
    } else {
      current.Goodbye();
      current = next;
      current.Welcome();
    }
  }
  
  public void MakeDone () {
    done = true;
  }
  
  public bool IsDone () {
    return done;
  }
}

