/* Command for replenishing HP
 */
namespace WoZ.Commands;
using WoZ;
using WoZ.Interfaces;
class CommandRest : BaseCommand, ICommand {
    public CommandRest()
    {
        description = "Rest to replenish HP";
    }
    public void Execute (Context context, string command, string[] parameters) {
        if (context.Player.isInCombat)
        {
            Console.WriteLine("You can't rest when a monster is nearby.");
            return;
        } else
        {
            context.Player.Heal(10);
        }
    }
}