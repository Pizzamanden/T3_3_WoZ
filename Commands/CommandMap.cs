/* Command for displaying the map
 */
namespace WoZ.Commands;
using WoZ.Interfaces;
using System;
using System.Text;
using System.Runtime.InteropServices;
class CommandMap : BaseCommand, ICommand
{

    public CommandMap()
    {
        description = "Display Island Map";
    }

    public enum MapZone
    {
        StartZone, Docks, City, Mall, TrashLand, Tower
    }
    private readonly Dictionary<string, MapZone> roomToZone = new Dictionary<string, MapZone>
    {
        // StartZone
        { "S1-Start", MapZone.StartZone },
        { "S2", MapZone.StartZone },
        { "S3 NPC", MapZone.StartZone },
        { "S4 NPC", MapZone.StartZone },
        { "S5", MapZone.StartZone },
        { "S6-Boss", MapZone.StartZone },

        // City Zone
        { "C_S1 MiniBoss", MapZone.City },
        { "C_S2 NPC", MapZone.City },
        { "C_S3", MapZone.City },
        { "C_S4 Combat", MapZone.City },
        { "C_S5", MapZone.City },
        { "C_S6 Combat", MapZone.City },


        // Docks Zone
        { "D_S1", MapZone.Docks },
        { "D_S2 Combat", MapZone.Docks },
        { "D_S3 Npc", MapZone.Docks },
        { "D_S4 Combat", MapZone.Docks },
        { "D_S5", MapZone.Docks },
        { "D_S6 MiniBoss", MapZone.Docks },

        // Mall Zone
        { "M_S1 NPC", MapZone.Mall },
        { "M_S2 Combat", MapZone.Mall },
        { "M_S3", MapZone.Mall },
        { "M_S4 Combat", MapZone.Mall },
        { "M_S5", MapZone.Mall },
        { "M_S6 MiniBoss", MapZone.Mall },

        // TrashLand Zone
        { "TL_S1 MiniBoss", MapZone.TrashLand },
        { "TL_S2", MapZone.TrashLand },
        { "TL_S3 Combat", MapZone.TrashLand },
        { "TL_S4 NPC", MapZone.TrashLand },
        { "TL_S5 Combat", MapZone.TrashLand },
        { "TL_S6 NPC", MapZone.TrashLand },

    };
    // Opdatere konsollen så den har funktion til at vise farver
    // Problemet er at standard windows konsoller ikke altid forstår moderne farvekoder
    // Derfor skal vi bruge nogle WinAPI kald for at aktivere ANSI farvekoder på Windows
    //Metoderne GetConsoleMode og SetConsoleMode taler direkte med Windows styresystemet
    //for at "låse op" for muligheden for at bruge farver i terminalen.

    [DllImport("kernel32.dll", SetLastError = true)]
    static extern IntPtr GetStdHandle(int nStdHandle);

    [DllImport("kernel32.dll")]
    static extern bool GetConsoleMode(IntPtr hConsoleHandle, out uint lpMode);

    [DllImport("kernel32.dll")]
    static extern bool SetConsoleMode(IntPtr hConsoleHandle, uint dwMode);

    private static bool AnsiColorsEnabled = false;

    // Metode til at farvelægge det nuværende rum på kortet
    // Den sikre først at ANSI farver er aktiveret i konsollen
    // Den finder spillerens rum-navn i teksten og erstatter det med en version,
    // der er pakket ind i en farvekode (i dette tilfælde en grøn farve: RGB 50, 255, 50)
    private static string ColorizeRoom(string map, string roomName, int r, int g, int b)
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            if (!AnsiColorsEnabled) {
                const int STD_OUTPUT_HANDLE = -11;
                var handle = GetStdHandle(STD_OUTPUT_HANDLE);

                if (GetConsoleMode(handle, out uint mode)) {
                    mode |= 0x0004; 
                    SetConsoleMode(handle, mode);
                    AnsiColorsEnabled = true;
                }
            }
        }       

        string colored = $"\x1b[38;2;{r};{g};{b}m{roomName}\x1b[0m";
        return map.Replace(roomName, colored);
    }   

    // Metode til at vise kortet for Start Zone
    private void displayStartZoneMap(string currentRoomName)
    {
        var sb = new StringBuilder();
        sb.AppendLine("                               Welcome to Trash Island                ");
        sb.AppendLine("---------------------------------------------------------------------------------");
        sb.AppendLine("                                 ↑                            ↑");
        sb.AppendLine("                 ┌──────┐     ┌──────┐     ┌────────┐     ┌──────┐");
        sb.AppendLine("                 │S3 NPC│─────│  S2  │─────│S1-Start│─────│S4 NPC│ →");
        sb.AppendLine("                 └──────┘     └──────┘     └────┬───┘     └──────┘");
        sb.AppendLine("                    ↓                           │");
        sb.AppendLine("                                            ┌───┴──┐");
        sb.AppendLine("                                            │  S5  │");
        sb.AppendLine("                                            └───┬──┘");
        sb.AppendLine("                                                │");
        sb.AppendLine("                                            ┌───┴───┐");
        sb.AppendLine("                                            │S6-Boss│");
        sb.AppendLine("                                            └───────┘");
        sb.AppendLine("---------------------------------------------------------------------------------");
        sb.AppendLine("[NPC]           = Non-Player Character — Maybe they'd like to talk!");
        sb.AppendLine("S_ C_ TL_ D_ M_ = Space Number");
        sb.AppendLine("[Directions]    North ↑    West ←    East →    South ↓");
        sb.AppendLine("<help>          = For a list of available commands");
        sb.AppendLine("---------------------------------------------------------------------------------");


        // Generer kortet som en streng og farvelægger det nuværende rum

        string mapTower = sb.ToString();
        mapTower = ColorizeRoom(mapTower, currentRoomName, 50, 255, 50);
        Console.Write(mapTower);
    }
    
    // Metode til at vise kortet for City Zone
    private void displayCityZoneMap(string currentRoomName)
    {
        var sb = new StringBuilder();
        sb.AppendLine("                               Welcome to the City Zone                ");
        sb.AppendLine("---------------------------------------------------------------------------------");
        sb.AppendLine("                            ┌──────────────┐    ┌───────────────┐");
        sb.AppendLine("                            │   C_S3       │────│ C_S4 Combat   │");
        sb.AppendLine("                            └──────┬───────┘    └───────────────┘");
        sb.AppendLine("                                   │");
        sb.AppendLine("            ┌────────────────┐  ┌──┴──────────┐");
        sb.AppendLine("          ← │C_S1 MiniBoss   │──│  C_S2 NPC   │");
        sb.AppendLine("            └────────────────┘  └────┬────────┘");
        sb.AppendLine("                                     │");
        sb.AppendLine("                            ┌────────┴──────────┐    ┌───────────────┐");
        sb.AppendLine("                            │     C_S5          │────│ C_S6 Combat   │");
        sb.AppendLine("                            └───────────────────┘    └───────────────┘");
        sb.AppendLine("---------------------------------------------------------------------------------");
        sb.AppendLine("[NPC]           = Non-Player Character — Maybe they'd like to talk!");
        sb.AppendLine("S_ C_ TL_ D_ M_ = Space Number");
        sb.AppendLine("[Directions]    North ↑    West ←    East →    South ↓");
        sb.AppendLine("<help>          = For a list of available commands");
        sb.AppendLine("---------------------------------------------------------------------------------");

        // Generer kortet som en streng og farvelægger det nuværende rum
        string mapCity = sb.ToString();
        mapCity = ColorizeRoom(mapCity, currentRoomName, 50, 255, 50);
        Console.Write(mapCity);
    }


    // Metode til at vise kortet for Docks Zone
    private void displayDocksZoneMap(string currentRoomName)
    {
        var sb = new StringBuilder();
        sb.AppendLine("                               Welcome to the Docks Zone                        ");
        sb.AppendLine("---------------------------------------------------------------------------------");
        sb.AppendLine("   ┌───────────────┐");
        sb.AppendLine("   │D_S6 MiniBoss  │");
        sb.AppendLine("   └──────┬────────┘");
        sb.AppendLine("          │");
        sb.AppendLine("   ┌──────┴───────┐ ┌─────────────┐ ┌──────────────┐ ┌─────────────┐ ┌────────────┐");
        sb.AppendLine("   │    D_S5      │-│D_S4 Combat  │-│    D_S1      │-│D_S2 Combat  │-│ D_S3 Npc   │");
        sb.AppendLine("   └──────────────┘ └─────────────┘ └──────────────┘ └─────────────┘ └────────────┘");
        sb.AppendLine("                                           ↓");
        sb.AppendLine("---------------------------------------------------------------------------------");
        sb.AppendLine("[NPC]           = Non-Player Character — Maybe they'd like to talk!");
        sb.AppendLine("S_ C_ TL_ D_ M_ = Space Number");
        sb.AppendLine("[Directions]    North ↑    West ←    East →    South ↓");
        sb.AppendLine("<help>          = For a list of available commands");
        sb.AppendLine("---------------------------------------------------------------------------------");


        // Generer kortet som en streng og farvelægger det nuværende rum
        string mapDocks = sb.ToString();
        mapDocks = ColorizeRoom(mapDocks, currentRoomName, 50, 255, 50);
        Console.Write(mapDocks);
    }

    // Metode til at vise kortet for Mall Zone
    private void displayMallZoneMap(string currentRoomName)
    {
        var sb = new StringBuilder();
        sb.AppendLine("                               Welcome to the Mall Zone                        ");
        sb.AppendLine("---------------------------------------------------------------------------------");
        sb.AppendLine("                          ┌────────────┐   ┌───────────────┐");
        sb.AppendLine("                          │   M_S5     │───│M_S6 MiniBoss  │");
        sb.AppendLine("                          └─────┬──────┘   └───────────────┘");
        sb.AppendLine("                                │                  ");
        sb.AppendLine("                          ┌─────┴──────┐   ┌──────────────┐");
        sb.AppendLine("                          │M_S4 Combat │───│    M_S3      │");
        sb.AppendLine("                          └────────────┘   └──────┬───────┘");
        sb.AppendLine("                                                  │");
        sb.AppendLine("                          ┌────────────┐   ┌──────┴───────┐");
        sb.AppendLine("                          │M_S1 NPC    │───│M_S2 Combat   │");
        sb.AppendLine("                          └────────────┘   └──────────────┘");
        sb.AppendLine("                                ↓");
        sb.AppendLine("---------------------------------------------------------------------------------");
        sb.AppendLine("[NPC]           = Non-Player Character — Maybe they'd like to talk!");
        sb.AppendLine("S_ C_ TL_ D_ M_ = Space Number");
        sb.AppendLine("[Directions]    North ↑    West ←    East →    South ↓");
        sb.AppendLine("<help>          = For a list of available commands");
        sb.AppendLine("---------------------------------------------------------------------------------");


        // Generer kortet som en streng og farvelægger det nuværende rum
        string mapMall = sb.ToString();
        mapMall = ColorizeRoom(mapMall, currentRoomName, 50, 255, 50);
        Console.Write(mapMall);
    }

    // Metode til at vise kortet for TrashLand Zone
    private void displayTrashLandZoneMap(string currentRoomName)
    {
    var sb = new StringBuilder();
    sb.AppendLine("                                 Welcome to Trash Land                        ");
    sb.AppendLine("---------------------------------------------------------------------------------");
    sb.AppendLine("                                          ↑");
    sb.AppendLine("                 ┌──────────┐      ┌──────────────┐      ┌───────────┐");
    sb.AppendLine("                 │TL_S6 NPC │─────>│TL_S1 MiniBoss│─────>│   TL_S2   │");
    sb.AppendLine("                 └─────┬────┘      └──────────────┘      └─────┬─────┘");
    sb.AppendLine("                       │                                       │     ");
    sb.AppendLine("                 ┌─────┴──────┐    ┌──────────────┐    ┌───────┴──────┐");
    sb.AppendLine("                 │TL_S5 Combat│<───│ TL_S4 NPC    │<───│TL_S3 Combat  │");
    sb.AppendLine("                 └────────────┘    └──────────────┘    └──────────────┘");
    sb.AppendLine("---------------------------------------------------------------------------------");
    sb.AppendLine("[NPC]           = Non-Player Character — Maybe they'd like to talk!");
    sb.AppendLine("S_ C_ TL_ D_ M_ = Space Number");
    sb.AppendLine("[Directions]    North ↑    West ←    East →    South ↓");
    sb.AppendLine("<help>          = For a list of available commands");
    sb.AppendLine("---------------------------------------------------------------------------------");


    // Generer kortet som en streng og farvelægger det nuværende rum
    string mapTrash = sb.ToString();
    mapTrash = ColorizeRoom(mapTrash, currentRoomName, 50, 255, 50);
    Console.Write(mapTrash);
    }



   // Execute metoden til at vise kortet baseret på den nuværende zone
    public void Execute(Context context, string command, string[] parameters)
    {
        ShowMap(context.GetCurrent());
    }

    public void ShowMap(Space space)
    {
        string currentRoomName = space.GetName();
        // Console.WriteLine($"\nYou are currently in: {currentRoomName}\n");

        MapZone currentZone =  roomToZone[currentRoomName]; 
        if (currentZone == MapZone.StartZone)
        {
            displayStartZoneMap(currentRoomName);
        }
        else if (currentZone == MapZone.City)
        {
            displayCityZoneMap(currentRoomName);
        }
        else if (currentZone == MapZone.Docks)
        {
            displayDocksZoneMap(currentRoomName);
        }
        else if (currentZone == MapZone.Mall)
        {
            displayMallZoneMap(currentRoomName);
        }
        else if (currentZone == MapZone.TrashLand)
        {
            displayTrashLandZoneMap(currentRoomName);
        }
        else
        {
            Console.WriteLine("Map not available for this zone.");
        }
    }
}