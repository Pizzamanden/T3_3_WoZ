namespace WoZ.Commands;

using System;
using WoZ;
using WoZ.Interfaces;
class CommandRetreat : BaseCommand, ICommand {
    public CommandRetreat()
    {
        description = "Exit the combat and retreat";
    }
    public void Execute (Context context, string command, string[] parameters) {
        Player player = context.Player;

        if (!context.IsInCombat())
        {
            Console.WriteLine("You are not currently in combat. You don't need to retreat.\n");
        } else
        {
            Monster? monster = context.GetCurrent().Monster;
            if(context.GetCurrent().GetName() == "TL1" && !Flags.GetFlag(Flags.TL_S1_Second_Encounter))
            {
                monster!.Heal();
                context.Retreat();
            } else
            {
                context.Retreat();
                monster!.Heal();
            }
            
        }
    }
}