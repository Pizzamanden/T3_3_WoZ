/* Command for displaying the map
 */

class CommandMap : BaseCommand, ICommand
{
    public CommandMap()
    {
        description = "Display Island Map";
    }
    public void Execute(Context context, string command, string[] parameters)
    {
        string map = @"
                Welcome to The Trash Island!
    -----------------------------------------------------------

                 ┌──────┐                              ┌──────┐
                 │ Comb │                              │ Comb │
                 └───┬──┘                              └───┬──┘
                     │                                     │
    ┌──────┐     ┌───┴──┐     ┌─────┐     ┌──────┐     ┌───┴──┐
    │ Room │─────│ Room │─────│Start│─────│ Room │─────│ Comb │
    └───┬──┘     └──────┘     └──┬──┘     └──────┘     └──────┘
        │                        │
    ┌───┴──┐                 ┌───┴──┐
    │ Comb │                 │ Room │
    └──────┘                 └───┬──┘
                                 │
                             ┌───┴──┐
                             │ Boss │
                             └──────┘

    -----------------------------------------------------------
                 [Start] = Start   [Room] = Room
                 [Comb] = Combat   [Boss] = Boss
    ";

        Console.Write(map);
    }
}