namespace WoZ.Commands;
using WoZ;
using WoZ.Interfaces;
class CommandStatus : BaseCommand, ICommand {
  public CommandStatus()
  {
    description = "Check current HP";
  }
  public void Execute (Context context, string command, string[] parameters) {
    Console.WriteLine($"Current HP: {context.Player.HP}");
  }
}