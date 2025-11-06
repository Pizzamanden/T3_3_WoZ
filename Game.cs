/* Main class for launching the game
 */

class Game {
  static Context  context  = new Context();
  static ICommand fallback = new CommandUnknown();
  static Registry registry = new Registry(context, fallback);
  static World    world    = new World(registry);
  
  
  
  private static void InitRegistry () {
    ICommand cmdExit = new CommandExit();
    registry.Register("exit", cmdExit);
    registry.Register("quit", cmdExit);
    registry.Register("bye", cmdExit);
    registry.Register("go", new CommandGo());
    registry.Register("help", new CommandHelp(registry));
  }
  
  static void Main (string[] args) {
    Console.WriteLine("Welcome to the World of Zuul!");
    
    InitRegistry();
	context.SetEntry(world.GetEntry());
    context.GetCurrent().Welcome();
    
    while (context.IsDone()==false) {
	Console.WriteLine("\nWhat would you like to do?");
      Console.Write("> ");
      string? line = Console.ReadLine();
      if (line!=null) registry.Dispatch(line);
    }
    Console.WriteLine("Game Over 😥");
  }
}
