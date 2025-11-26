class CommandRetreat : BaseCommand, ICommand {
    public CommandRetreat()
    {
        description = "Exit the combat and retreat";
    }
    public void Execute (Context context, string command, string[] parameters) {
        Player player = context.Player;

        if (!player.isInCombat)
        {
            Console.WriteLine("You are not currently in combat. You don't need to retreat.");
        } else
        {
            Monster? monster = context.GetCurrent().Monster;
            monster.Heal();
            //context.Transition(parameters[0]);
            context.Retreat();
            monster = context.GetCurrent().Monster;
            if (monster != null && monster!.IsAlive())
            {
                context.Player.isInCombat = true;
            } else
            {
                context.Player.isInCombat = false;
            }
        }
    }
}