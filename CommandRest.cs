/*
    Command for replenishing HP
*/

class CommandRest : BaseCommand, ICommand {
    
    public CommandRest()
    {
        description = "Rest to replenish HP";
    }
    public void Execute (Context context, string command, string[] parameters) {
        Monster? monster = context.GetCurrent().Monster;

        if (monster == null || !monster.IsAlive())
        {
            context.Player.Heal(10);
        }
        else
        {
            Console.WriteLine("You can't rest when a monster is nearby.");
        }


    }
}