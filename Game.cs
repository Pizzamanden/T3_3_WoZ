/* Main class for launching the game
 */

class Game {
  static World    world    = new World();
  static Context  context  = new Context(world.GetEntry());
  static ICommand fallback = new CommandUnknown();
  static Registry registry = new Registry(context, fallback);
  
  private static void InitRegistry () {
    ICommand cmdExit = new CommandExit();
    registry.Register("exit", cmdExit);
    registry.Register("quit", cmdExit);
    registry.Register("bye", cmdExit);
    registry.Register("go", new CommandGo());
    registry.Register("help", new CommandHelp(registry));
    registry.Register("attack", new CommandUseAttackMove());
  }
  
  static void Main (string[] args) {
    Console.WriteLine("Welcome to the World of Zuul!");
    
    InitRegistry();
    context.GetCurrent().Welcome();
    
    while (context.IsDone()==false) {
      if (context.Player.IsAlive() == false)
      {
        Console.WriteLine("Du er blevet besejret i kampen. Game Over!");
        context.MakeDone();
        continue;
      }
      Console.Write("> ");
      string? line = Console.ReadLine();
      if (line!=null) registry.Dispatch(line);
    }
    Console.WriteLine("Game Over 😥");
  }
}
