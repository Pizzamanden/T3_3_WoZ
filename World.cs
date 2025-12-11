/* World class for modeling the entire in-game world
*/
namespace WoZ;
using WoZ.Events;
using WoZ.Texts;

class World {
  Space entry;

  //Magnus: defining key fields to be used by other classes
  public static Item Key1 = new Item("Key1", "key", Flags.C_S1_Got_Key);
  public static Item Key2 = new Item("Key2", "key", Flags.D_S6_Got_Key);
  public static Item Key3 = new Item("Key3", "key", Flags.M_S6_Got_Key);
  public static Item Key4 = new Item("Key4", "key", Flags.TL_S1_Got_Key);
  public static Item TL_Bins = new Item("Bins", "Bins", Flags.TL_S1_Real_Combat);
  public static Item M_Barbie = new Item("Barbie", "Barbie", Flags.M_S3_Pickup_Barbie);
  public static Item M_Sword = new Item("Sword", "Sword");
  public static Item D_Chemicals = new Item("Chemical", "Chemical", Flags.Got_Chemicals);
  public static Item C1 = new Item("LighterFluid", "LighterFluid", Flags.C_S4_LighterFluid_Pickup);
  public static Item C2 = new Item("MetalComponents", "MetalComponents");
    public static Item C3 = new Item("LighterParts", "LighterParts");
    public static string DefAct = "continue";

    public World (Context context) {

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
    Space S_S3  = new Space(StartZone,"S3");
    Space S_S4  = new Space(StartZone, "S4");
    Space S_S5  = new Space(StartZone, "S5");
    Space S_S6 = new Space(StartZone, "S6");

    // City-zonen
    Space C_S1  = new Space(City, "C1");
    Space C_S2  = new Space(City, "C2");
    Space C_S3  = new Space(City, "C3");
    Space C_S4  = new Space(City, "C4");      
    Space C_S5  = new Space(City, "C5");
    Space C_S6  = new Space(City, "C6");

    // Docks-zonen
    Space D_S1  = new Space(Docks, "D1");
    Space D_S2  = new Space(Docks, "D2");
    Space D_S3  = new Space(Docks, "D3");
    Space D_S4  = new Space(Docks, "D4");
    Space D_S5  = new Space(Docks, "D5");
    Space D_S6  = new Space(Docks, "D6");

    // Mall-zonen
    Space M_S1  = new Space(Mall, "M1");
    Space M_S2  = new Space(Mall, "M2");
    Space M_S3  = new Space(Mall, "M3");
    Space M_S4  = new Space(Mall, "M4");
    Space M_S5  = new Space(Mall, "M5");
    Space M_S6  = new Space(Mall, "M6");

    // TrashLand-zonen
    Space TL_S1 = new Space(TrashLand, "TL1");
    Space TL_S2 = new Space(TrashLand, "TL2");
    Space TL_S3 = new Space(TrashLand, "TL3");
    Space TL_S4 = new Space(TrashLand, "TL4");
    Space TL_S5 = new Space(TrashLand, "TL5");
    Space TL_S6 = new Space(TrashLand, "TL6");


        // Set starting space
        entry = S_S1_TrueStart;

        // Start zone edges
        {
        S_S1_TrueStart.AddEdge("starter", S_S1_Start);
        S_S1_Start.AddEdge("west", S_S2);
        S_S1_Start.AddEdge("south", S_S5);
        S_S1_Start.AddEdge("east", S_S4);
        S_S2.AddEdge("east", S_S1_Start);
        S_S2.AddEdge("west", S_S3);
        S_S3.AddEdge("east", S_S2);
        S_S4.AddEdge("west", S_S1_Start);
        S_S5.AddEdge("north", S_S1_Start);
        S_S5.AddEdge("south", S_S6);
        S_S6.AddEdge("north", S_S5);
    }

    
    // City zone edges
    {
      C_S1.AddEdge("east", C_S2);
      C_S2.AddEdge("west", C_S1);
      C_S2.AddEdge("north", C_S3);
      C_S2.AddEdge("south", C_S5);
      C_S5.AddEdge("north", C_S2);
      C_S3.AddEdge("south", C_S2);
      C_S3.AddEdge("east", C_S4);
      C_S4.AddEdge("west", C_S3);
      C_S5.AddEdge("east", C_S6);
      C_S6.AddEdge("west", C_S5);
    }   

 
    // Docks zone edges
    {
      D_S1.AddEdge("east", D_S2);
      D_S1.AddEdge("west", D_S4);
      D_S2.AddEdge("west", D_S1);
      D_S2.AddEdge("east", D_S3);
      D_S3.AddEdge("west", D_S2);
      D_S4.AddEdge("east", D_S1);
      D_S4.AddEdge("west", D_S5);
      D_S5.AddEdge("east", D_S4);
      D_S5.AddEdge("north", D_S6);
      D_S6.AddEdge("south", D_S5);
    }
      

    // Mall zone edges
    {
      M_S1.AddEdge("east", M_S2);
      M_S2.AddEdge("west", M_S1);
      M_S2.AddEdge("north", M_S3);
      M_S3.AddEdge("south", M_S2);
      M_S3.AddEdge("west", M_S4);
      M_S4.AddEdge("east", M_S3);
      M_S4.AddEdge("north", M_S5);
      M_S5.AddEdge("south", M_S4);
      M_S5.AddEdge("east", M_S6);
      M_S6.AddEdge("west", M_S5);
    }

    // TrashLand zone edges
    {
      TL_S1.AddEdge("east", TL_S2);
      TL_S2.AddEdge("south", TL_S3);
      TL_S3.AddEdge("west", TL_S4);
      TL_S3.AddEdge("north", TL_S2);
      TL_S4.AddEdge("west", TL_S5);
      TL_S4.AddEdge("east", TL_S3);
      TL_S5.AddEdge("north", TL_S6);
      TL_S5.AddEdge("east", TL_S4);
      TL_S6.AddEdge("east", TL_S1);
      TL_S6.AddEdge("south", TL_S5);


    }

    // Connecting zones
    {

      //Fra Start til Docks og omvendt
      S_S2.AddEdge("north", D_S1);
      D_S1.AddEdge("south", S_S2);

      //Fra Start til TrashLand og omvendt
      S_S3.AddEdge("south", TL_S1);
      TL_S1.AddEdge("north", S_S3);

      //Fra Start til Mall og omvendt
      S_S4.AddEdge("north", M_S1);
      M_S1.AddEdge("south", S_S4);

      //Fra Start til City og omvendt
      S_S4.AddEdge("east", C_S1);
      C_S1.AddEdge("west", S_S4);
    }
    
        //Magnus: Adding items to spaces
        M_S3.PlaceItem(M_Barbie);


        /* - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - STARTER - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - */
        // Monsters
        Monster S_S6_BOSS_1 = new Monster(
          "Octopus",
          1,
          null,
          "chemical",
          "",
          Flags.S_S6_BOSS_1_Dead
        );

        Monster S_S6_BOSS_2 = new Monster(
          "Vending Machine",
          1,
          null,
          "recycling",
          "",
          Flags.S_S6_BOSS_2_Dead
        );

        Monster S_S6_BOSS_3 = new Monster(
          "Dragon",
          1,
          null,
          "slice",
          "",
          Flags.S_S6_BOSS_3_Dead
        );

        Monster S_S6_BOSS_4 = new Monster(
          "Cigarette Army",
          1,
          null,
          "fire",
          "",
          Flags.S_S6_BOSS_4_Dead
        );

        S_S4.PlaceNPC(new NPC(
          "Wet creature statue",
          "The statue is silent... like a statue should be.",
          new List<string>
          {
            StartZone_Text.S_S4_Talk
          },
          "",
          null
        ));

        // Zone events
        // S1, both the actual start with text crawl and the starter space one can move from
        S_S1_TrueStart.AddWelcomeEvent(new TextSE(DefAct, "", "", StartZone_Text.S_S1_Start_1));
        S_S1_TrueStart.AddWelcomeEvent(new ClearConsoleSE(""));
        S_S1_TrueStart.AddWelcomeEvent(new TextSE(DefAct, "", "", StartZone_Text.S_S1_Start_2));
        S_S1_TrueStart.AddWelcomeEvent(new TextSE("jump", "", "", StartZone_Text.S_S1_Start_3));
        S_S1_Start.AddWelcomeEvent(new TextSE("", "", "", StartZone_Text.S_S1_Start_4));

        // S_S2 text
        S_S2.AddWelcomeEvent(new TextSE("", "", "", StartZone_Text.S_S2_1));

        // S_S3
        S_S3.AddWelcomeEvent(new TextSE("skip line", "", "", StartZone_Text.S_S3_1));
        S_S3.AddWelcomeEvent(new TextSE("", "", "", StartZone_Text.S_S3_2));

        // S_S4
        S_S4.AddWelcomeEvent(new TextSE("", "", "", StartZone_Text.S_S4_1));

        // S_S5
        S_S5.AddWelcomeEvent(new TextSE("", "", "", StartZone_Text.S_S5_1));

        // S_S6
        S_S6.Monster = S_S6_BOSS_1; // Set first boss
        S_S6.AddWelcomeEvent(new TextSE("search for an elevator", "", "", StartZone_Text.S_S6_1));
        S_S6.AddWelcomeEvent(new TextSE("sigh in disappointment", "", "", StartZone_Text.S_S6_2));
        S_S6.AddWelcomeEvent(new TextSE("prepare to fight", "", "", StartZone_Text.S_S6_3));
        S_S6.AddWelcomeEvent(new TextSE("", "", "", StartZone_Text.S_S6_4));

        // First boss dies, event then spawn
        S_S6.AddWelcomeEvent(new RefreshScreenSE(Flags.S_S6_BOSS_1_Dead, S_S6));
        S_S6.AddWelcomeEvent(new TextSE("", "", "", StartZone_Text.S_S6_BossDeath_1));
        S_S6.AddWelcomeEvent(new TextSE("gather yourself for another fight", Flags.S_S6_BOSS_1_Dead, "", StartZone_Text.S_S6_5));
        S_S6.AddWelcomeEvent(new SpawnMonsterSE(Flags.S_S6_BOSS_1_Dead, S_S6_BOSS_2, S_S6));
        S_S6.AddWelcomeEvent(new MonsterAlertSE("", S_S6));
        // Second boss dies, event then spawn third boss
        S_S6.AddWelcomeEvent(new RefreshScreenSE(Flags.S_S6_BOSS_2_Dead, S_S6));
        S_S6.AddWelcomeEvent(new TextSE("", "", "", StartZone_Text.S_S6_BossDeath_2));
        S_S6.AddWelcomeEvent(new TextSE("endure just a little longer", Flags.S_S6_BOSS_2_Dead, "", StartZone_Text.S_S6_6));
        S_S6.AddWelcomeEvent(new SpawnMonsterSE(Flags.S_S6_BOSS_2_Dead, S_S6_BOSS_3, S_S6));
        S_S6.AddWelcomeEvent(new MonsterAlertSE("", S_S6));
        // Third boss dies, event then spawn
        S_S6.AddWelcomeEvent(new RefreshScreenSE(Flags.S_S6_BOSS_3_Dead, S_S6));
        S_S6.AddWelcomeEvent(new TextSE("", "", "", StartZone_Text.S_S6_BossDeath_3));
        S_S6.AddWelcomeEvent(new TextSE("realize this will be the last", Flags.S_S6_BOSS_3_Dead, "", StartZone_Text.S_S6_7));
        S_S6.AddWelcomeEvent(new SpawnMonsterSE(Flags.S_S6_BOSS_3_Dead, S_S6_BOSS_4, S_S6));
        S_S6.AddWelcomeEvent(new MonsterAlertSE("", S_S6));
        // You won!
        S_S6.AddWelcomeEvent(new RefreshScreenSE(Flags.S_S6_BOSS_4_Dead, S_S6));
        S_S6.AddWelcomeEvent(new TextSE("", "", "", StartZone_Text.S_S6_BossDeath_4));
        S_S6.AddWelcomeEvent(new TextSE("be glad that it's over", Flags.S_S6_BOSS_4_Dead, "", StartZone_Text.S_S6_8));
        S_S6.AddWelcomeEvent(new TextSE("end this", Flags.S_S6_BOSS_4_Dead, "", StartZone_Text.S_S6_9));
        // TODO: set EndGameSE event here
        S_S6.AddWelcomeEvent(new EndGameSE(Flags.S_S6_BOSS_4_Dead, context));


        /* - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - MALL - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - */
        // Troels made this:
        // M_S1 text
        M_S1.AddWelcomeEvent(new TextSE("show confidence in your abilities to win", "", "", Mall_Text.M_S1_1));
        M_S1.AddWelcomeEvent(new TextSE("pretend to care", "", "", Mall_Text.M_S1_2));
        M_S1.AddWelcomeEvent(new TextSE("", "", "", Mall_Text.M_S1_3));
        M_S1.AddWelcomeEvent(new TextSE("give him the doll", Flags.M_S3_Pickup_Barbie, "", Mall_Text.M_S1_4));
        M_S1.AddWelcomeEvent(new TextSE("", Flags.M_S3_Pickup_Barbie, "", Mall_Text.M_S1_5));
        M_S1.AddWelcomeEvent(new SpawnItemSE(Flags.M_S3_Pickup_Barbie, M_Sword, M_S1));
        
        // M_S2 text
        M_S2.AddWelcomeEvent(new TextSE("continue onwards from the food court", "", "", Mall_Text.M_S2_1));
        M_S2.AddWelcomeEvent(new TextSE("cough loudly and clutch your chest", "", "", Mall_Text.M_S2_2));
        M_S2.AddWelcomeEvent(new TextSE("", "", "", Mall_Text.M_S2_3));

        // M_S3 text
        M_S3.AddWelcomeEvent(new TextSE("", "", "", Mall_Text.M_S3_1));
        
        // M_S4 text
        M_S4.AddWelcomeEvent(new TextSE("", "", "", Mall_Text.M_S4_1));
        M_S4.AddWelcomeEvent(new TextSE("", "", "", Mall_Text.M_S4_2));
        // Text for after combat
        M_S4.AddWelcomeEvent(new TextSE("", Flags.M_S4_Combat_dead, "", Mall_Text.M_S4_3));

        // M_S5 text
        M_S5.AddWelcomeEvent(new TextSE("", "", "", Mall_Text.M_S5_1));

        // M_S6 text
        M_S6.AddWelcomeEvent(new TextSE("", "", "", Mall_Text.M_S6_1));
        M_S6.AddWelcomeEvent(new TextSE("", "", "", Mall_Text.M_S6_2));
        // Text for after combat
        M_S6.AddWelcomeEvent(new TextSE("", Flags.M_S6_Combat_dead, "", Mall_Text.M_S6_3));
        M_S6.AddWelcomeEvent(new TextSE("", Flags.M_S6_Got_Key, "", Mall_Text.M_S6_4));

        //adding NPCS
        M_S1.PlaceNPC(new NPC(
          "Samurai",
          "Get me the item further up and you can have the sword *more fake snoring*",
          new List<string>
          {
            Mall_Text.M_S1_Talk_1
          },
          "",
          null
        ));
        M_S3.PlaceNPC(new NPC(
          "Old woman",
          "*Cough*",
          new List<string>
          {
            Mall_Text.M_S3_Talk
          },
          "",
          null
        ));

        //adding monsters to mall Zone
        M_S2.Monster = new Monster(
          "Plastic Cook",
          30,
          null,
          "slice",
          "The Plastic Cook dissolves into tiny pieces of plastic.",
          ""
        );
        M_S2.Monster.AttackDamage = 1;

        M_S4.Monster = new Monster(
          "Funko Pop fan",
          40,
          null,
          "slice",
          "",
          Flags.M_S4_Combat_dead
        );
        M_S4.Monster.AttackDamage = 1;

        M_S6.Monster = new Monster(
          "Action Man and Bottle Boy",
          120,
          Key3,
          "slice",
          "",
          Flags.M_S6_Combat_dead
        );
        M_S6.Monster.AttackDamage = 10;

        /* - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - DOCKS - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - */
        //Magnus:
        // D_S1 text
        D_S1.AddWelcomeEvent(new TextSE("", "", "", Docks_Text.D_S1_1));

        // D_S2 text
        D_S2.AddWelcomeEvent(new TextSE("", "", "", Docks_Text.D_S2_1));

        // D_S3 text
        D_S3.AddWelcomeEvent(new TextSE("buy medicine", "", "", Docks_Text.D_S3_1));
        D_S3.AddWelcomeEvent(new TextSE("", "", "", Docks_Text.D_S3_2));

        // D_S4 text
        D_S4.AddWelcomeEvent(new TextSE("", "", "", Docks_Text.D_S4_1));
        D_S4.AddWelcomeEvent(new TextSE("", Flags.D_S4_Combat_dead, "", Docks_Text.D_S4_2));

        // D_S5 text
        D_S5.AddWelcomeEvent(new TextSE("", "", "", Docks_Text.D_S5_1));

        // D_S6 text
        D_S6.AddWelcomeEvent(new TextSE("approach him", "", "", Docks_Text.D_S6_1));
        D_S6.AddWelcomeEvent(new TextSE("", "", "", Docks_Text.D_S6_2));
        D_S6.AddWelcomeEvent(new TextSE("", Flags.D_S6_Combat_dead, "", Docks_Text.D_S6_3));
        D_S6.AddWelcomeEvent(new TextSE("", Flags.D_S6_Got_Key, "", Docks_Text.D_S6_4));

        // Place weapon (Chemicals)
        D_S3.PlaceItem(D_Chemicals);
        
        // Monsters
        D_S2.Monster = new Monster(
          "Sick Customer",
          30,
          null,
          "chemical",
          "As you land the final hit, the sick customer collapses.",
          Flags.D_S2_Combat_dead
        );
        D_S2.Monster.AttackDamage = 20;

        D_S4.Monster = new Monster(
          "Massive Net Turtle",
          40,
          null,
          "chemical",
          "",
          Flags.D_S4_Combat_dead
        );
        D_S4.Monster.AttackDamage = 20;

        D_S6.Monster = new Monster(
          "Old Fisherman",
          100,
          Key2,
          "chemical",
          "",
          Flags.D_S6_Combat_dead
        );
        D_S6.Monster.AttackDamage = 30;
        
        //adding NPCS
        D_S3.PlaceNPC(new NPC(
          "Dr. Spill",
          "♪Chemicals break ghost fishing gear♪",
          new List<string>
          {
            Docks_Text.D_S3_Talk 
          },
          "",
          null
        ));
        D_S5.PlaceNPC(new NPC(
          "Diver",
          "Stupid ghost fishing gear. It's everywhere.",
          new List<string>
          {
            Docks_Text.D_S5_Talk
          },
          "",
          null
        ));

        /* - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - TRASH LAND - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - */
        // Mikkel:
        // COMBATS:
        TL_S1.Monster = new Monster(
          "Trash Land Mascot",
          100,
          Key4,
          "recycling",
          TrashLand_Text.TL_S1_5,
          ""
        );
        TL_S1.Monster.AttackDamage = 99;

        TL_S3.Monster = new Monster(
          "Trash Land Employee",
          40,
          null,
          "recycling",
          "The employee falls apart into separate pieces of trash.",
          ""
        );
        TL_S3.Monster.AttackDamage = 1;

        TL_S5.Monster = new Monster(
          "Teacup Enthusiast",
          40,
          null,
          "recycling",
          "You throw the final pieces of the monster into your newly acquired bins.",
          ""
        );
        TL_S5.Monster.AttackDamage = 1;

        // NPCs:
        TL_S4.PlaceNPC(new NPC(
          "Old Janitor",
          "You're our only hope.",
          new List<string>
          {
              TrashLand_Text.TL_S4_Talk,
          },
          "",
          null
        ));

        TL_S6.PlaceNPC(new NPC(
          "Cashier",
          "\"I'm not going to sell you anything.\"",
          new List<string>
          {
              TrashLand_Text.TL_S6_Talk_1,
              TrashLand_Text.TL_S6_Talk_2
          },
          "",
          null
        ));

        // Place bins
        TL_S4.PlaceItem(TL_Bins);

        // TL_S1 text (First time) (Mangler at fikse combat elementet af den)
        TL_S1.AddWelcomeEvent(new TextSE("turn around", "", "", TrashLand_Text.TL_S1_1));
        TL_S1.AddWelcomeEvent(new TextSE("", "", "", TrashLand_Text.TL_S1_2));
        // TL_S1 text (First time, post combat) (Lige nu køre den med det samme, )
        TL_S1.AddGoodbyeEvent(new TextSE("fly you fool", "", "", TrashLand_Text.TL_S1_3));

        // TL_S2 text
        TL_S2.AddWelcomeEvent(new TextSE("try cotton candy", "", "", TrashLand_Text.TL_S2_1));
        TL_S2.AddWelcomeEvent(new TextSE("go back for seconds", "", "", TrashLand_Text.TL_S2_2));
        TL_S2.AddWelcomeEvent(new TextSE("", "", "", TrashLand_Text.TL_S2_3));

        // TL_S3 text 
        TL_S3.AddWelcomeEvent(new TextSE("", "", Flags.TL_S1_Second_Encounter, TrashLand_Text.TL_S3_1));

        // TL_S4 text 
        TL_S4.AddWelcomeEvent(new TextSE("enter shack", "", "", TrashLand_Text.TL_S4_1));
        TL_S4.AddWelcomeEvent(new TextSE("", "", "", TrashLand_Text.TL_S4_2));
        TL_S4.AddWelcomeEvent(new TextSE("", "", "", TrashLand_Text.TL_S4_3));
        TL_S4.AddWelcomeEvent(new TextSE("", "", "", TrashLand_Text.TL_S4_4));
        TL_S4.AddWelcomeEvent(new UpdateMonsterDamageSE(Flags.TL_S1_Real_Combat, TL_S1.Monster, 15));

        // TL_S5 text 
        TL_S5.AddWelcomeEvent(new TextSE("watch", "", "", TrashLand_Text.TL_S5_1));
        TL_S5.AddWelcomeEvent(new TextSE("", "", "", TrashLand_Text.TL_S5_2));

        // TL_S6 text 
        TL_S6.AddWelcomeEvent(new TextSE("", "", "", TrashLand_Text.TL_S6_1));

        // TL_S1 text (Second time)
        TL_S1.AddWelcomeEvent(new TextSE("", Flags.TL_S1_Real_Combat, "", TrashLand_Text.TL_S1_4));
        TL_S1.AddWelcomeEvent(new TextSE("", Flags.TL_S1_Got_Key, "", TrashLand_Text.TL_S1_6));



        /* - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - CITY - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - */
        // Peter

        // Monsters
        Monster C_S1_MiniBoss_Boss = new Monster(
            "Jack",
            1,
            Key1,
            "fire",
            "",
            Flags.C_S1_MiniBoss_Boss_Dead
        );
        Monster C_S4_Combat_Monster = new Monster(
            "Crazy guy",
            1,
            C1,
            "fire",
            "",
            Flags.C_S4_Monster_Dead
        );
        Monster C_S6_Combat_Monster = new Monster(
            "Sulphur",
            1,
            C2,
            "fire",
            "",
            Flags.C_S6_Monster_Dead
        );

        // NPCs
        C_S2.PlaceNPC(new NPC(
          "Ivan",
          "Still dead...",
          new List<string>
          {
            City_Text.C_S2_Talk,
          },
          "",
          null
        ));

        C_S5.PlaceNPC(new NPC(
          "Frail man",
          "\"It could all heal, we would only need to take small steps at a steady pace.\"",
          new List<string>
          {
            City_Text.C_S5_talk_1,
            City_Text.C_S5_talk_2,
            City_Text.C_S5_talk_3
          },
          "",
          null
        ));


        // Normal events for S1
        C_S1.AddWelcomeEvent(new TextSE(DefAct, "", "", City_Text.C_S1_1));
        C_S1.AddWelcomeEvent(new TextSE("stay silent", "", "", City_Text.C_S1_2));
        C_S1.AddWelcomeEvent(new TextSE("", "", "", City_Text.C_S1_3));
        // Space with Jack, spawn him when Flags.C_S6_Monster_Dead has been set
        C_S1.AddWelcomeEvent(new TextSE("give a cheesy one-liner", Flags.C_S6_Monster_Dead, "", City_Text.C_S1_4));
        C_S1.AddWelcomeEvent(new TextSE("", Flags.C_S6_Monster_Dead, "", City_Text.C_S1_5));
        C_S1.AddWelcomeEvent(new SpawnMonsterSE(Flags.C_S6_Monster_Dead, C_S1_MiniBoss_Boss, C_S1));
        // Jack dies
        C_S1.AddWelcomeEvent(new TextSE("", Flags.C_S1_MiniBoss_Boss_Dead, "", City_Text.C_S1_6));
        // Trigger when key picked up
        C_S1.AddWelcomeEvent(new TextSE("", Flags.C_S1_Got_Key, "", City_Text.C_S1_7));

        // First diner
        C_S2.AddWelcomeEvent(new TextSE("order one glass of orange juice, pancakes with maple syrup and butter, 2 eggs, and one of their famous cherry pies", "", "", City_Text.C_S2_1));
        C_S2.AddWelcomeEvent(new TextSE("thank him", "", "", City_Text.C_S2_2));
        C_S2.AddWelcomeEvent(new TextSE("", "", "", City_Text.C_S2_3));
        // Second diner
        C_S2.AddWelcomeEvent(new TextSE("offer him some coffee as well", Flags.C_S4_Monster_Dead, "", City_Text.C_S2_4));
        C_S2.AddWelcomeEvent(new TextSE("express your happiness for him", Flags.C_S4_Monster_Dead, "", City_Text.C_S2_5));
        C_S2.AddWelcomeEvent(new TextSE("take your leave", Flags.C_S4_Monster_Dead, "", City_Text.C_S2_6));
        //Third diner
        C_S2.AddWelcomeEvent(new TextSE("approach", Flags.C_S6_Monster_Dead, "", City_Text.C_S2_7));
        C_S2.AddWelcomeEvent(new TextSE("clutch his hands tightly", Flags.C_S6_Monster_Dead, "", City_Text.C_S2_8));
        C_S2.AddWelcomeEvent(new TextSE("promise him he’s gonna be alright", Flags.C_S6_Monster_Dead, "", City_Text.C_S2_9));
        C_S2.AddWelcomeEvent(new TextSE("curse Jack the cigarette guys name into the air while the camera — from a birds eye view — zooms slowly away", Flags.C_S6_Monster_Dead, "", City_Text.C_S2_10));
        C_S2.AddWelcomeEvent(new SpawnItemSE(Flags.C_S6_Monster_Dead, C3, C_S2));

        // C_S3
        C_S3.AddWelcomeEvent(new TextSE("listen in", "", "", City_Text.C_S3_1));
        C_S3.AddWelcomeEvent(new TextSE("make your way to the lieutenant in charge", "", "", City_Text.C_S3_2));
        C_S3.AddWelcomeEvent(new TextSE("", "", "", City_Text.C_S3_3));

        // Water treatment facility events
        C_S4.Monster = C_S4_Combat_Monster;
        C_S4.AddWelcomeEvent(new TextSE("tell him to stand down", "", "", City_Text.C_S4_1));
        C_S4.AddWelcomeEvent(new TextSE("", "", "", City_Text.C_S4_2));
        // After combat
        C_S4.AddWelcomeEvent(new TextSE("", Flags.C_S4_Monster_Dead, "", City_Text.C_S4_3));
        C_S4.AddGoodbyeEvent(new TextSE("put on sunglasses", Flags.C_S4_LighterFluid_Pickup, "", City_Text.C_S4_4));

        // C_S5
        // Beach event which always happens
        C_S5.AddWelcomeEvent(new TextSE("enjoy the \"fresh\" air", "", "", City_Text.C_S5_Beach));
        C_S5.AddWelcomeEvent(new TextSE("", Flags.C_S4_Monster_Dead, "", City_Text.C_S5_1));
        // Beach event which always happens
        C_S6.AddWelcomeEvent(new TextSE("continue your walk on the beach", "", "", City_Text.C_S6_Beach));
        // These events happen when Flags.C_S4_Monster_Dead is set
        C_S6.AddWelcomeEvent(new SpawnMonsterSE(Flags.C_S4_Monster_Dead, C_S6_Combat_Monster, C_S6));
        C_S6.AddWelcomeEvent(new TextSE("", Flags.C_S4_Monster_Dead, "", City_Text.C_S6_1));
        C_S6.AddWelcomeEvent(new TextSE("", Flags.C_S4_Monster_Dead, "", City_Text.C_S6_2));
        C_S6.AddWelcomeEvent(new TextSE("", Flags.C_S4_Monster_Dead, "", City_Text.C_S6_3));
        // He dies
        C_S6.AddWelcomeEvent(new TextSE("", Flags.C_S6_Monster_Dead, "", City_Text.C_S6_4));

    }

    public Space GetEntry () {
    return entry;
  }




}