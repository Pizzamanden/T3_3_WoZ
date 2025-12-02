/* Context class to hold all context relevant to a session.
 */

using System.Security;

class Context {
    protected Space? current;
    Space? previous;
    protected bool done = false;

    //Magnus: Inventory list to store multiple items
    private List<Item> inventory = new List<Item>();
 
  public Player Player { get; private set; }
  public Context () {
    Player = new Player("You", 100);
	
	// Peter: Add all player default attacks
	Player.AddAttack(new Attack("fists", 10, "physical"));
	Player.AddAttack(new Attack("torch", 5, "fire"));
  }

  //Magnus: Adding an item to the inventory
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
    return current!;
  }
  
  public void Transition (string direction) {
    Space? next = current!.FollowEdge(direction);
    if (next==null) {
      Console.WriteLine("You are confused, and walk in a circle looking for '"+direction+"'. In the end you give up 😩");
    } else {
      previous = current;
      current.Goodbye();
      current = next;
      current.Welcome();
    }
  }

  public void Retreat()
    {
      if(current.GetName() == "TL_S1 MiniBoss")
      {
        previous = current!.FollowEdge("east"); 
      }
      current.Goodbye();
      current = previous;
      current.Welcome();
    }
  
  public void MakeDone () {
    done = true;
  }
  
  public bool IsDone () {
    return done;
  }
  
  public void SetEntry(Space entry){
	  this.current = entry;
  }
}

