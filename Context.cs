/* Context class to hold all context relevant to a session.
 */
namespace WoZ;
using System.Runtime.CompilerServices;
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
    Player.AddAttack(new Attack("mop", 2, 40, "physical"));
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
      Console.WriteLine("You cannot go '"+direction+"' from here.\n");
    } else {
      previous = current;
      current.Goodbye();
      current = next;
      current.Welcome();
    }
  }

  public void Retreat()
  {
    if(current.GetName() == "TL1" && !Flags.GetFlag(Flags.TL_S1_Second_Encounter))
    {
      previous = current!.FollowEdge("east"); 
    }
    current.Goodbye();
    current = previous;
    current.Welcome();
  }

  public void Respawn()
  {
    if(current!.GetName() == "TL1" && !Flags.GetFlag(Flags.TL_S1_Second_Encounter))
    {
      previous = current!.FollowEdge("east"); 
    }
    current.Goodbye();
    current!.Monster!.Heal();
    current = previous;
    current!.Welcome();
  }
  
  public void MakeDone () {
    done = true;
  }

    public bool IsInCombat() {
        if(current!.Monster != null && current!.Monster!.IsAlive()) {
            return true;
        }
        else {
            return false;
        }
    }
  
  public bool IsDone () {
    return done;
  }
  
  public void SetEntry(Space entry){
	  this.current = entry;
  }
//Troels: Method to check if the player has two specific items in their inventory to learn a new attack
public void GetNewAttack(Item item1, Item item2, string attackName, int minDamage, int maxDamage, string attackType, string flag)
    {
      if(inventory.Contains(item1) && inventory.Contains(item2) && !Player.HasAttack(attackName.ToLower()) && Flags.GetFlag(flag) == false)
      {
        Player.AddAttack(new Attack(attackName, minDamage, maxDamage, attackType));
        Console.WriteLine("You have learned a new attack: " + attackName + "!");
        Flags.SetFlag(flag);
      }
    }
}