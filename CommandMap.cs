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
    string currentRoomName = context.GetCurrent().GetName();
    Console.WriteLine($"\nYou are currently in: {currentRoomName}\n");

    //Center
    string dpR1 = "[Start]"; 

    //Vest Grenen
    string dpR2 = "[Room1]";
    string dpR3 = "[Comb1]";
    string dpR4 = "[Boss1]";
    string dpR5 = "[Trash]";

//Øst Grenen
    string dpR6 = "[  R6 ]";
    string dpR7 = "[  R7 ]";
    string dpR8 = "[  R8 ]";
//Syd Grenen
    string dpR9 = "[  R9 ]";
    string dpR10 = "[ R10 ]";

if (currentRoomName == "Dropzone")
        {
            dpR1 = "[**X**]";
        }
        else if (currentRoomName == "Køgebugt motorway")
        {
            dpR2 = "[**X**]";
        }
        else if (currentRoomName == "Brøndby Strand")
        {
            dpR3 = "[**X**]";
        }
        else if (currentRoomName == "Road to turism")
        {
            dpR4 = "[**X**]";
        }
        else if (currentRoomName == "Turism trash place")
        {
            dpR5 = "[**X**]";
        }
        else if (currentRoomName == "plastic pathway")
        {
            dpR6 = "[**X**]";
        }
        else if (currentRoomName == "plastic palace")
        {
            dpR7 = "[**X**]";
        }
        else if (currentRoomName == "Ziggzone")
        {
            dpR8 = "[**X**]";
        }
        else if (currentRoomName == "The wasteway")
        {
            dpR9 = "[**X**]";
        }
        else if (currentRoomName == "Slagelse")
        {
            dpR10 = "[**X**]";
        }

        string map = $@"
                Welcome to The Trash Island!
    -----------------------------------------------------------

                  ┌───────┐                                  ┌───────┐
                  │{dpR3}│                                  │{dpR8}│
                  └───┬───┘                                  └───┬───┘
                      │                                          │
    ┌───────┐     ┌───┴───┐     ┌───────┐     ┌───────┐      ┌───┴───┐
    │{dpR4}│─────│{dpR2}│─────│{dpR1}│─────│{dpR6}│───── │{dpR7}│
    └───┬───┘     └───────┘     └──┬────┘     └───────┘      └───────┘
        │                          │
    ┌───┴───┐                  ┌───┴───┐
    │{dpR5}│                  │{dpR9}│
    └───────┘                  └───┬───┘
                                   │
                               ┌───┴───┐
                               │{dpR10}│
                               └───────┘

    -----------------------------------------------------------
                 [Start] = Start   [Room] = Room
                 [Comb] = Combat   [Boss] = Boss ☠
    ";

        Console.Write(map);
    }
}