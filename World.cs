/* World class for modeling the entire in-game world
*/

class World {
  Space entry;
  Registry? registry;

  //Magnus: defining key fields to be used by other classes
  public static Item Key1;
  public static Item Key2;
  public static Item Key3;
  public static Item Key4;
  
  public World (Registry registry) {

    Zone StartZone = new Zone("Start", "Starting zone");
    Zone City = new Zone("City", "The zone with Tourism trash!");
    Zone Docks = new Zone("Docks", "The zone with all the fishing gear");
    Zone Mall = new Zone("plastic", "The plastic zone!");
    Zone TrashLand = new Zone("Zigarettes", "The zone with ziggerets!");
    Zone finalboss = new Zone("Final boss", "The final boss!");

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
    Space TL_S6  = new Space(TrashLand, "TL_S6");


    // Start zone edges
    {
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
      TL_S5_Combat.AddEdge("north", TL_S6);
      TL_S6.AddEdge("east", TL_S1_MiniBoss);
      
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

        S_S2.Monster = new Monster (
          "Test Boss", 
          9999999, 
          null, 
          "",
          "wtf man you killed me",
          Flags.S2_mime_dead
        );

        entry = S_S1_Start;


        S_S1_Start.AddWelcomeEvent(new TextSE("Press enter to jump...", "", "", "\"Given that you're the best janitor the UN headquarters had on hand, \nI'm sure it'll be a walk in the park to you. Good luck champ.\""));
        



        S_S1_Start.AddWelcomeEvent(new TextSE("Press enter to test if this shit works...",
        Flags.S1_slime_dead,
        "",
        "\n Display text"));

        S_S2.AddWelcomeEvent(new TextSE("Press enter to test if this shit works too...",
        "",
        Flags.S1_slime_dead,
        "\n Another Display text"));



        S_S2.AddWelcomeEvent(new TextSE("Press enter to suck my nuts...",
        Flags.S2_mime_dead,
        "",
        "\nsomething something you won i guess"));

        S_S5.AddWelcomeEvent(new SpawnMonsterSE(Flags.S2_mime_dead, new Monster("Henrik", 20, null, "physical", "you failed", ""), S_S5));
    }

  public Space GetEntry () {
    return entry;
  }
}

