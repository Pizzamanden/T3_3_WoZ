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
        S_S1_Start.Monster = new Monster("Slime", 30, "fire");
        */

        TL_S1_MiniBoss.Monster = new Monster (
          "Test Boss", 
          30, 
          null, 
          "",
          "With the Sea Devil reduced to not much more than a puddle on the ground, \nyou reach for your walkie talkie, to report your success. \n\n\"I knew you could do it!\", the pilot yells, unnecessarily loud, \"The cleaning crews are setting foot on the island as we speak. Ready to begin cleaning this whole place up, just as you instructed. I'm coming to pick you up now...\" \n\nBefore going you grab the mop from your cleaning cart. And the last thing \nyou see, before you sweep up the remnants of the Sea Devil, is your own \nself reflection...\n\nThe End"
        );

        // Mikkel: Added text, dialouge, monsters, monster-death-dialoug
        S_S1_Start.AddWelcomeEvent(new TextSE("\n\"We're about to reach Trash Island!\" the pilot says, \"I hope you're as good \nas they say you are. This won't be an easy mission. But with all that trash \ngathering like this and those monsters appearing, something bad was bound \nto happen sooner or later.\""));
        S_S1_Start.AddWelcomeEvent(new TextSE("\"It's too dangerous for our cleaning crew to step foot on the island as is. \nAnd even if they could, they wouldn't even know how to handle all that trash.\""));
        S_S1_Start.AddWelcomeEvent(new TextSE("\"That's why we need an expert like you, to swoop in, eliminate those \nmonsters and figure out a proper way to handle the trash in the process. \nThen our team can take care of the rest.\""));
        S_S1_Start.AddWelcomeEvent(new TextSE("\"See that big Tower to the south? According to our intel, that's where the one \nresponsible resides. It doesn't matter how many other monsters you defeat, \nif you don't take care of the one in that tower, more of those things will just appear...\""));
        S_S1_Start.AddWelcomeEvent(new TextSE("\"You can't just waltz on in however, the gate is locked and you'll need 4 parts of a key, each given to one of the 4 Trash Guardians.\""));
        S_S1_Start.AddWelcomeEvent(new TextSE("\"Given that you're the best janitor the UN headquarters had on hand, \nI'm sure it'll be a walk in the park to you. Good luck champ.\"", "Press enter to jump..."));

        S_S1_Start.AddWelcomeEvent(new TextSE("You land in a big pile of trash, saving both yourself and your cleaning cart \nfrom an early GAME OVER screen. The only tools at your disposal are the \nusual cleaning supplies you have in your cart, as well as a walkie talkie."));
        this.entry = S_S1_Start;



        S_S2.AddWelcomeEvent(new TextSE("\nOn your way west, you pass by the island docks to your north. The sudden \nsmell of rotting fish comes across you like a wave."));




        S_S3_NPC.AddWelcomeEvent(new TextSE("\nAs you continue along the road west, you're surprised to find a long line of \npeople in front of you. Looking for where the line starts, you face south, and \nwonder how the travel poster neglected to make any mention of the theme \npark located on the island.", "Press enter to skip line..."));
        S_S3_NPC.AddWelcomeEvent(new TextSE("As you pass the people in line, you notice that they aren't people at all. \nLooking like the insides of trash bins that came to life. These monsters \nresemble large, dull minded tourists, fit with dirty clothes and hats."));


        S_S4_NPC.AddWelcomeEvent(new TextSE("\nYou reach a town. Passing buildings made of wet cardboard, streets of \nbroken glass, and a large statue of what you thought might resemble some \nweird wet creature."));
        // S_S4_NPC NPC dialouge
        List<string> dialogueListNPC3 = new List<string>
        {
            "\nDespite not seeing anyone in the vicinity, you still give the <talk> command \na try. Only to hear a devilish voice, coming from the statue.",
            "\nPretending that didn't scare you a little. The statue tells you about the town. \nExplaining that loud commotion has been heard coming from the mall to the \nnorth. As well as thick white smoke, rising from dark alleyways to the east."
        };

        S_S4_NPC.PlaceNPC(new NPC("voice", "Example description for NPC 1", dialogueListNPC3));




        

        S_S5.AddWelcomeEvent(new TextSE("\nIn front of you stands a large tower. As you walk up to its gate, you see 4 \nkey slots in the door. "));
        // Add text if try to enter tower, without full key

        S_S6_BOSS.AddWelcomeEvent(new TextSE("\nAfter placing all 4 key pieces in their respective slots. You hear a loud clicking sound, followed by the gate, slowly opening.", "Press enter to enter tower..."));
        S_S6_BOSS.AddWelcomeEvent(new TextSE("Inside the tower, you're met with a large set of stairs.", "Press enter to search for an elevator..."));
        S_S6_BOSS.AddWelcomeEvent(new TextSE("You're in luck! You find an elevator in a side room, and it's almost entirely \nwhole. Only missing a side door, a couple of buttons, and a long cable, \nreaching all the way to the top of the tower...", "Press enter to sigh in disappointment..."));
        S_S6_BOSS.AddWelcomeEvent(new TextSE("After spending 30 minutes pushing your cart up the stairs. You reach the top \nroom and enter. In front of you sits a large, humanoid creature, made entirely \nof water..."));
        // S_S6_BOSS NPC dialouge
        List<string> dialogueListNPC6 = new List<string>
        {
            "\nThe creature announces itself as the Sea Devil. A manifestation of the \noceans anger itself. It's intent on enacting revenge on the humans that \ncontinue to poison it.",
            "\nDeciding to gather up all the trash in the oceans, forming it into a single land \nmass. It plans to build an army of monsters, made out of the exact same \ntrash that the humans polluted it with. To destroy human kind."
        };

        S_S6_BOSS.PlaceNPC(new NPC("devil", "Example description for NPC 1", dialogueListNPC6));
        // Add text when combat begins...
        // Add text doing combat...
        
        // Add text when combat begins...
        // Added monster and death-dialouge
        S_S6_BOSS.Monster = new Monster (
          "sea devil", 
          30, 
          null, 
          "",
          "With the Sea Devil reduced to not much more than a puddle on the ground, \nyou reach for your walkie talkie, to report your success. \n\n\"I knew you could do it!\", the pilot yells, unnecessarily loud, \"The cleaning crews are setting foot on the island as we speak. Ready to begin cleaning this whole place up, just as you instructed. I'm coming to pick you up now...\" \n\nBefore going you grab the mop from your cleaning cart. And the last thing \nyou see, before you sweep up the remnants of the Sea Devil, is your own \nself reflection...\n\nThe End"
        );
    }

  public Space GetEntry () {
    return entry;
  }
}

