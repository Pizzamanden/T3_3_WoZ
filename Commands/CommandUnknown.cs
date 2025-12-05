/* Fallback for when a command is not implemented
 */
namespace WoZ.Commands;
using WoZ.Interfaces;
class CommandUnknown : BaseCommand, ICommand {
  public void Execute (Context context, string command, string[] parameters) {
    // Mikkel: Changed "command not found" text
    Console.WriteLine("\nCommand: '"+command+"' not found, for list of available commands, type 'help'.\n");
  }
}
