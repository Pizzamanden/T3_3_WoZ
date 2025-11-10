/* Command for transitioning between spaces
 */

class CommandGo : BaseCommand, ICommand {
    public CommandGo () {
        description = "Follow an exit";
    }

    public void Execute(Context context, string command, string[] parameters) {
        if (GuardEq(parameters, 1))
        {
            Console.WriteLine("I don't seem to know where that is 🤔");
            return;
        }

/*         if (context.GetCurrent().Monster)
        {
            Monster? monster = context.GetCurrent().Monster;
            if (monster != null || monster!.IsAlive())
            {
                monster.Heal();
            }
        } */

        Monster? monster = context.GetCurrent().Monster;
        if (monster != null && monster!.IsAlive())
        {
            monster.Heal();
        }

        context.Transition(parameters[0]);
    }
}
