namespace WoZ.Commands;
using WoZ.Interfaces;
class CommandRetreat : BaseCommand, ICommand {
    public CommandRetreat()
    {
        description = "Exit the combat and retreat";
    }
    public void Execute (Context context, string command, string[] parameters) {
        Player player = context.Player;

        if (context.IsInCombat())
        {
            Console.WriteLine("You are not currently in combat. You don't need to retreat.\n");
        } else
        {
            Monster? monster = context.GetCurrent().Monster;
            monster!.Heal();
            //context.Transition(parameters[0]);
            context.Retreat();
            monster = context.GetCurrent().Monster;
        }
    }
}