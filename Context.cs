/* Context class to hold all context relevant to a session.
 */

using System.Security;

class Context {
  Space current;
  bool done = false;
  
  public Player player { get; private set; }
  

  public Context (Space node) {
    current = node;
    player = new Player("Bro", 100);
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

