/* Main class for launching the game
 */
using System.Text;

class Game {
  static Context  context  = new Context();
  static ICommand fallback = new CommandUnknown();
  static Registry registry = new Registry(context, fallback);
  static World    world    = new World(registry);
  
  
  
  private static void InitRegistry () {
    ICommand cmdExit = new CommandExit();
    // registry.Register("exit", cmdExit);
    registry.Register("quit", cmdExit);
    // registry.Register("bye", cmdExit);
    registry.Register("go", new CommandGo());
    registry.Register("help", new CommandHelp(registry));
    //Yarik: Command for talking to npcs
    registry.Register("talk", new CommandTalk());
    //Yarik: Command for exploring the room
    registry.Register("explore", new CommandExploreRoom());
    //Magnus: Command for picking up items
    registry.Register("pickup", new CommandPickUp());
    //Magnus: Command for checking your inventory
    registry.Register("inventory", new CommandCheckInventory());
    registry.Register("attack", new CommandUseAttackMove());
    registry.Register("directions", new CommandDirections());
    registry.Register("rest", new CommandRest());
    registry.Register("map", new CommandMap());
    registry.Register("retreat", new CommandRetreat());
    //Mikkel: Command for checking player HP
    registry.Register("status", new CommandStatus());
  }
  
  static void Main (string[] args) {
	Console.OutputEncoding = Encoding.UTF8;
    // Console.WriteLine("");
    
    Console.Clear();
    InitRegistry();
	  context.SetEntry(world.GetEntry());
    context.GetCurrent().Welcome();
    
    while (context.IsDone()==false) {
      if (context.Player.IsAlive() == false)
      {
        //Mikkel: Made so you respawn in previous room if character dies
        Console.Clear();
        context.Respawn();
        context.Player.FullHeal();
        new CommandMap().ShowMap(context.GetCurrent());
        Console.WriteLine("\nYOU DIED, and wake up in the previous room full of vigour");
        continue;
      }
      Console.Write("\n> ");
      string? line = Console.ReadLine();
      if (line!=null) registry.Dispatch(line);
    }
    Console.WriteLine("Game Over");
  }
}
