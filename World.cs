/* World class for modeling the entire in-game world
*/
namespace WoZ;
using WoZ.Events;
using WoZ.Texts;

class World {
  Space entry;
  Registry? registry;

  //Magnus: defining key fields to be used by other classes
  public static Item Key1;
  public static Item Key2;
  public static Item Key3;
  public static Item Key4;
  public static Item D1 = new Item("D1", "Whatever");
  public static Item D2 = new Item("D2", "Whatever");
  public static Item TL_Bins = new Item("Recycling bins", "Whatever");
  public static Item M_Barbie = new Item("Barbie", "Barbie", Flags.M_S3_Pickup_Barbie);
  public static Item M_Sword = new Item("Sword", "Sword");

    public World (Registry registry) {

    Zone StartZone = new Zone("Start", "Starting zone");
    Zone City = new Zone("City", "The zone with Tourism trash!");
    Zone Docks = new Zone("Docks", "The zone with all the fishing gear");
    Zone Mall = new Zone("plastic", "The plastic zone!");
    Zone TrashLand = new Zone("Zigarettes", "The zone with ziggerets!");
    Zone finalboss = new Zone("Final boss", "The final boss!");

    // Fake start spot
    Space S_S1_TrueStart = new Space(StartZone, "S1-TrueStart");

    // Start-zonen
    Space S_S1_Start  = new Space(StartZone, "S1-Start");
    Space S_S2  = new Space(StartZone,"S2");
    Space S_S3_NPC  = new Space(StartZone,"S3 NPC");
    Space S_S4_NPC  = new Space(StartZone, "S4 NPC");
    Space S_S5  = new Space(StartZone, "S5");
    Space S_S6_BOSS = new Space(StartZone, "S6-Boss");

    // City-zonen
    Space C_S1_MiniBoss  = new Space(City, "C_S1 MiniBoss");
    Space C_S2_NPC  = new Space(City, "C_S2 NPC");
    Space C_S3  = new Space(City, "C_S3");
    Space C_S4_Combat  = new Space(City, "C_S4 Combat");      
    Space C_S5  = new Space(City, "C_S5");
    Space C_S6_Combat  = new Space(City, "C_S6 Combat");

    // Docks-zonen
    Space D_S1  = new Space(Docks, "D_S1");
    Space D_S2_Combat  = new Space(Docks, "D_S2 Combat");
    Space D_S3_NPC  = new Space(Docks, "D_S3 Npc");
    Space D_S4_Combat  = new Space(Docks, "D_S4 Combat");
    Space D_S5  = new Space(Docks, "D_S5");
    Space D_S6_MiniBoss  = new Space(Docks, "D_S6 MiniBoss");

    // Mall-zonen
    Space M_S1_NPC  = new Space(Mall, "M_S1 NPC");
    Space M_S2_Combat  = new Space(Mall, "M_S2 Combat");
    Space M_S3  = new Space(Mall, "M_S3");
    Space M_S4_Combat  = new Space(Mall, "M_S4 Combat");
    Space M_S5  = new Space(Mall, "M_S5");
    Space M_S6_MiniBoss  = new Space(Mall, "M_S6 MiniBoss");

    // TrashLand-zonen
    Space TL_S1_MiniBoss  = new Space(TrashLand, "TL_S1 MiniBoss");
    Space TL_S2  = new Space(TrashLand, "TL_S2 ");
    Space TL_S3_Combat  = new Space(TrashLand, "TL_S3 Combat");
    Space TL_S4_NPC  = new Space(TrashLand, "TL_S4 NPC");
    Space TL_S5_Combat  = new Space(TrashLand, "TL_S5 Combat");
    Space TL_S6_NPC  = new Space(TrashLand, "TL_S6 NPC");


        // Set starting space
        entry = S_S1_TrueStart;

        // Start zone edges
        {
        S_S1_TrueStart.AddEdge("starter", S_S1_Start);
        S_S1_Start.AddEdge("west", S_S2);
        S_S1_Start.AddEdge("south", S_S5);
        S_S1_Start.AddEdge("east", S_S4_NPC);
        S_S2.AddEdge("east", S_S1_Start);
        S_S2.AddEdge("west", S_S3_NPC);
        S_S3_NPC.AddEdge("east", S_S2);
        S_S4_NPC.AddEdge("west", S_S1_Start);
        S_S5.AddEdge("north", S_S1_Start);
        S_S5.AddEdge("south", S_S6_BOSS);
        S_S6_BOSS.AddEdge("north", S_S5);
    }

    
    // City zone edges
    {
      C_S1_MiniBoss.AddEdge("east", C_S2_NPC);
      C_S2_NPC.AddEdge("west", C_S1_MiniBoss);
      C_S2_NPC.AddEdge("north", C_S3);
      C_S2_NPC.AddEdge("south", C_S5);
      C_S5.AddEdge("north", C_S2_NPC);
      C_S3.AddEdge("south", C_S2_NPC);
      C_S3.AddEdge("east", C_S4_Combat);
      C_S4_Combat.AddEdge("west", C_S3);
      C_S5.AddEdge("east", C_S6_Combat);
      C_S6_Combat.AddEdge("west", C_S5);
    }   


 
    // Docks zone edges
    {
      D_S1.AddEdge("east", D_S2_Combat);
      D_S1.AddEdge("west", D_S4_Combat);
      D_S2_Combat.AddEdge("west", D_S1);
      D_S2_Combat.AddEdge("east", D_S3_NPC);
      D_S3_NPC.AddEdge("west", D_S2_Combat);
      D_S4_Combat.AddEdge("east", D_S1);
      D_S4_Combat.AddEdge("west", D_S5);
      D_S5.AddEdge("east", D_S4_Combat);
      D_S5.AddEdge("north", D_S6_MiniBoss);
      D_S6_MiniBoss.AddEdge("south", D_S5);
    }
      


    // Mall zone edges
    {
      M_S1_NPC.AddEdge("east", M_S2_Combat);
      M_S2_Combat.AddEdge("west", M_S1_NPC);
      M_S2_Combat.AddEdge("north", M_S3);
      M_S3.AddEdge("south", M_S2_Combat);
      M_S3.AddEdge("west", M_S4_Combat);
      M_S4_Combat.AddEdge("east", M_S3);
      M_S4_Combat.AddEdge("north", M_S5);
      M_S5.AddEdge("south", M_S4_Combat);
      M_S5.AddEdge("east", M_S6_MiniBoss);
      M_S6_MiniBoss.AddEdge("west", M_S5);
    }

    // TrashLand zone edges
    {
      TL_S1_MiniBoss.AddEdge("east", TL_S2);
      TL_S2.AddEdge("south", TL_S3_Combat);
      TL_S3_Combat.AddEdge("west", TL_S4_NPC);
      TL_S4_NPC.AddEdge("west", TL_S5_Combat);
      TL_S5_Combat.AddEdge("north", TL_S6_NPC);
      TL_S6_NPC.AddEdge("east", TL_S1_MiniBoss);
      
    }

    // Connecting zones
    {
      //Fra Start til Docks og omvendt
      S_S2.AddEdge("north", D_S1);
      D_S1.AddEdge("south", S_S2);

      //Fra Start til TrashLand og omvendt
      S_S3_NPC.AddEdge("south", TL_S1_MiniBoss);
      TL_S1_MiniBoss.AddEdge("north", S_S3_NPC);

      //Fra Start til Mall og omvendt
      S_S4_NPC.AddEdge("north", M_S1_NPC);
      M_S1_NPC.AddEdge("south", S_S4_NPC);

      //Fra Start til City og omvendt
      S_S4_NPC.AddEdge("east", C_S1_MiniBoss);
      C_S1_MiniBoss.AddEdge("west", S_S4_NPC);
    }
    
        //Magnus: Adding keys and weapons to spaces
        Key1 = new Item("Key1", "key");
        Key2 = new Item("Key2", "key");
        Key3 = new Item("Key3", "key");
        Key4 = new Item("Key4", "key");
        
        C_S1_MiniBoss.PlaceItem(Key1);
        D_S6_MiniBoss.PlaceItem(Key2);
        M_S6_MiniBoss.PlaceItem(Key3);
        TL_S1_MiniBoss.PlaceItem(Key4);
        D_S2_Combat.PlaceItem(D1);
        D_S3_NPC.PlaceItem(D2);
        M_S3.PlaceItem(M_Barbie);
        /*
        //Yarik: Adding NPCs to spaces
        List<string> dialogueListNPC1 = new List<string>
        {
        "\nHello, agent. I'm NPC 1. Do you want to find out more about the monster?",
        "\nThis is the plastic monster. You can defeat him by recycling the trash he's attacking you with."
        };
        S_S1_Start.PlaceNPC(new NPC("NPC1", "Example description for NPC 1", dialogueListNPC1));
        */

        /*
        // Peter: Monster adding
        S_S1_Start.Monster = new Monster("Slime", 100, "fire");
        */

        // COMBATS:
        // Docks combats:
        D_S2_Combat.Monster = new Monster (
          "Sick customer", 
          30, 
          D1, 
          "physical",
          "",
          Flags.D_S2_Combat_dead
        );
        D_S2_Combat.Monster.AttackDamage = 1;

        D_S4_Combat.Monster = new Monster(
          "The Massive Net Turtle",
          40,
          null,
          "Chemical",
          "",
          Flags.D_S4_Combat_dead
        );
        D_S4_Combat.Monster.AttackDamage = 1;

        D_S6_MiniBoss.Monster = new Monster(
          "Old Fisherman",
          100,
          Key2,
          "Chemicals",
          "The storm starts to settle, as the ghostly figure fades away, and a \nkey piece drops to the ground…",
          Flags.D_S6_Combat_dead
        );
        D_S6_MiniBoss.Monster.AttackDamage = 1;

        // Trash Land combats:
        // Minibossen er ikke helt klar endnu, mangler det med første og anden combat med den
        TL_S1_MiniBoss.Monster = new Monster(
          "Trash Land Mascot",
          100,
          Key1,
          "Recycling",
          TrashLand_Text.TL_S1_5,
          ""
        );
        TL_S1_MiniBoss.Monster.AttackDamage = 1;

        TL_S3_Combat.Monster = new Monster(
          "Trash Land Employee",
          40,
          null,
          "physical",
          "",
          ""
        );
        TL_S3_Combat.Monster.AttackDamage = 1;

        TL_S5_Combat.Monster = new Monster(
          "Teacup Enthusiast",
          40,
          null,
          "Recycling",
          "",
          ""
        );
        TL_S5_Combat.Monster.AttackDamage = 1;


        // NPC's
        // Test NPC???
        M_S1_NPC.PlaceNPC(new NPC(
          "shopkeeper", 
          "A weary shopkeeper stands behind a makeshift counter, surrounded by heaps of discarded plastic items. \nHis eyes reflect a mix of hope and desperation as he clutches a worn-out recycling manual.", 
          new List<string>
          {
            "\n\"Ah, a fellow agent! These plastics have taken over my shop. If only someone could help me sort them out...\"",
            "\n\"The plastic monster is wreaking havoc in this area. I've heard that recycling the trash it throws at you can weaken it.\""
          },
          Flags.M_S3_Pickup_Barbie,
          null
        ));
        M_S3.AddWelcomeEvent(new SpawnItemSE(Flags.M_S3_Pickup_Barbie, M_Sword, M_S1_NPC));
        
        // Docks NPCs:

        // Trash Land NPCs: (Hverken Old Janitor eller Cashier er helt klar endnu, har ikke fikset det med de press enter to... tekste)
        TL_S4_NPC.PlaceNPC(new NPC(
          "Old Janitor",
          "", //ved ikke helt hvad der skal stå her
          new List<string>
          {
              TrashLand_Text.TL_S4_Talk
          },
          "",
          TL_Bins
        ));

        TL_S6_NPC.PlaceNPC(new NPC(
          "Cashier",
          "",
          new List<string>
          {
              TrashLand_Text.TL_S6_Talk_1,
              TrashLand_Text.TL_S6_Talk_2
          },
          "",
          null
        ));
        
        
        // STARTZONE:
        // Intro + S_S1_Start text
        S_S1_TrueStart.AddWelcomeEvent(new TextSE("", "", "", StartZone_Text.S_S1_Start_1));
        S_S1_TrueStart.AddWelcomeEvent(new TextSE("", "", "", StartZone_Text.S_S1_Start_2));
        S_S1_TrueStart.AddWelcomeEvent(new TextSE("", "", "", StartZone_Text.S_S1_Start_3));
        S_S1_Start.AddWelcomeEvent(new TextSE("", "", "", StartZone_Text.S_S1_Start_4));

        // S_S2 text
        S_S2.AddWelcomeEvent(new TextSE("", "", "", StartZone_Text.S_S2_1));

        // DOCKS: (Mikkel)
        // D_S1 text
        D_S1.AddWelcomeEvent(new TextSE("", "", "", Docks_Text.D_S1_1));

        // D_S2 text
        D_S2_Combat.AddWelcomeEvent(new TextSE("", "", "", Docks_Text.D_S2_1));

        // D_S3 text
        D_S3_NPC.AddWelcomeEvent(new TextSE("", "", "", Docks_Text.D_S3_1));
        D_S3_NPC.AddWelcomeEvent(new TextSE("", "", "", Docks_Text.D_S3_2));

        // D_S4 text
        D_S4_Combat.AddWelcomeEvent(new TextSE("", "", "", Docks_Text.D_S4_1));

        // D_S5 text
        D_S5.AddWelcomeEvent(new TextSE("", "", "", Docks_Text.D_S5_1));

        // D_S6 text
        D_S6_MiniBoss.AddWelcomeEvent(new TextSE("", "", "", Docks_Text.D_S6_1));
        D_S6_MiniBoss.AddWelcomeEvent(new TextSE("", "", "", Docks_Text.D_S6_2));


        // TRASH LAND: (Mikkel)
        // Lige nu køre hele teksten i TL_S1 med det samme
        // TL_S1 text (First time) 
        TL_S1_MiniBoss.AddWelcomeEvent(new TextSE("Press enter to turn around...", "", "", TrashLand_Text.TL_S1_1));
        TL_S1_MiniBoss.AddWelcomeEvent(new TextSE("", "", "", TrashLand_Text.TL_S1_2));
        TL_S1_MiniBoss.AddWelcomeEvent(new TextSE("", "", "", TrashLand_Text.TL_S1_3));
        // TL_S1 text (Second time)
        TL_S1_MiniBoss.AddWelcomeEvent(new TextSE("", "", "", TrashLand_Text.TL_S1_4));
        // TL_S1_MiniBoss.AddWelcomeEvent(new TextSE("", "", "", TrashLand_Text.TL_S1_5));
        TL_S1_MiniBoss.AddWelcomeEvent(new TextSE("", "", "", TrashLand_Text.TL_S1_6));

        // TL_S2 text
        TL_S2.AddWelcomeEvent(new TextSE("Press enter to try cotton candy...", "", "", TrashLand_Text.TL_S2_1));
        TL_S2.AddWelcomeEvent(new TextSE("Press enter to go back for seconds...", "", "", TrashLand_Text.TL_S2_2));
        TL_S2.AddWelcomeEvent(new TextSE("", "", "", TrashLand_Text.TL_S2_3));

        // TL_S3 text 
        TL_S3_Combat.AddWelcomeEvent(new TextSE("", "", "", TrashLand_Text.TL_S3_1));

        // TL_S4 text 
        TL_S4_NPC.AddWelcomeEvent(new TextSE("Press enter to enter shack...", "", "", TrashLand_Text.TL_S4_1));
        TL_S4_NPC.AddWelcomeEvent(new TextSE("", "", "", TrashLand_Text.TL_S4_2));
        TL_S4_NPC.AddWelcomeEvent(new TextSE("", "", "", TrashLand_Text.TL_S4_3));
        TL_S4_NPC.AddWelcomeEvent(new TextSE("", "", "", TrashLand_Text.TL_S4_4));

        // TL_S5 text 
        TL_S5_Combat.AddWelcomeEvent(new TextSE("Press enter to watch...", "", "", TrashLand_Text.TL_S5_1));
        TL_S5_Combat.AddWelcomeEvent(new TextSE("", "", "", TrashLand_Text.TL_S5_2));

        // TL_S6 text 
        TL_S6_NPC.AddWelcomeEvent(new TextSE("", "", "", TrashLand_Text.TL_S6_1));

    }

  public Space GetEntry () {
    return entry;
  }
}