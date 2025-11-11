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
    ----------------------------------------------------

               ┌────┐                           ┌────┐
               │  K │                           │  K │
               │(R3)│                           │(R7)│
               └──┬─┘                           └──┬─┘
                  │                                │
    ┌────┐     ┌──┴─┐     ┌────┐     ┌────┐     ┌──┴─┐
    │  R │     │  R │     │  S │     │  R │     │  K │
    │(R4)│‾‾‾‾‾│(R2)│‾‾‾‾‾│(R1)│‾‾‾‾‾│(R6)│‾‾‾‾‾│(R8)│
    └─┬──┘     └────┘     └─┬──┘     └────┘     └────┘
      │                     │
    ┌─┴──┐               ┌──┴──┐
    │  K │               │  R  │
    │(R5)│               │ (R9)│
    └────┘               └──┬──┘
                            │
                         ┌──┴──┐
                         │  B  │
                         │(R10)│
                         └─────┘

    ----------------------------------------------------
                 [S] = Start   [R] = Room
                 [K] = Combat  [B] = Boss
    ";

        Console.Write(map);
    }
}