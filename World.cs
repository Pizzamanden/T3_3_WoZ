/* World class for modeling the entire in-game world
*/

class World {
  Space entry;
  Registry? registry;
  
  public World (Registry registry) {

    Zone startzone    = new Zone("Start", "Starting zone");
    Zone turism = new Zone("Turism", "The zone with Tourism trash!");
    Zone fishing = new Zone("Fishing", "The zone with all the fishing gear");
    Zone plastic = new Zone("plastic", "The plastic zone!");
    Zone ziggeretzone = new Zone("Zigarettes", "The zone with ziggerets!");
    Zone finalboss = new Zone("Final boss", "The final boss!");


    Space R1  = new Space(startzone, "dropzone");
    Space R2  = new Space(fishing,"Køgebugt motorway");
    Space R3  = new Space(fishing,"Brøndby Strand");
    Space R4  = new Space(turism,"Road to turism");
    Space R5  = new Space(turism,"Turism trash place");
    Space R6  = new Space(plastic, "Plastic pathway");
    Space R7  = new Space(plastic, "Plastic palace");
    Space R8  = new Space(ziggeretzone, "Ziggzone");
    Space R9  = new Space(finalboss, "The wasteway");
    Space R10 = new Space(finalboss, "Slagelse");



        R1.AddEdge("west", R2);
        R1.AddEdge("south", R9);
        R1.AddEdge("east", R6);
        R2.AddEdge("east", R1);
        R2.AddEdge("north", R3);
        R2.AddEdge("west", R4);
        R3.AddEdge("south", R2);
        R4.AddEdge("south", R5);
        R4.AddEdge("east", R2);
        R5.AddEdge("north", R4);
        R6.AddEdge("west", R1);
        R6.AddEdge("north", R7);
        R6.AddEdge("east", R8);
        R7.AddEdge("south", R6);
        R8.AddEdge("west", R6);
        R9.AddEdge("north", R1);
        R9.AddEdge("south", R10);
        R10.AddEdge("north", R9);


        //Magnus: Adding keys and weapons to spaces
        R1.PlaceItem(new Item("Key part 1", "key"));

        /*
        //Yarik: Adding NPCs to spaces
        List<string> dialogueListNPC1 = new List<string>
        {
        "\nHello, agent. I'm NPC 1. Do you want to find out more about the monster?",
        "\nThis is the plastic monster. You can defeat him by recycling the trash he's attacking you with."
        };
        R1.PlaceNPC(new NPC("NPC1", "Example description for NPC 1", dialogueListNPC1));
        */

        /*
        // Peter: Monster adding
        R1.Monster = new Monster("Slime", 30, "fire");
        */

        // Mikkel: Added text, dialouge, monsters, monster-death-dialoug
        R1.AddWelcomeEvent(new TextSE("\n\"We're about to reach Trash Island!\" the pilot says, \"I hope you're as good \nas they say you are. This won't be an easy mission. But with all that trash \ngathering like this and those monsters appearing, something bad was bound \nto happen sooner or later.\""));
        R1.AddWelcomeEvent(new TextSE("\"It's too dangerous for our cleaning crew to step foot on the island as is. \nAnd even if they could, they wouldn't even know how to handle all that trash.\""));
        R1.AddWelcomeEvent(new TextSE("\"That's why we need an expert like you, to swoop in, eliminate those \nmonsters and figure out a proper way to handle the trash in the process. \nThen our team can take care of the rest.\""));
        R1.AddWelcomeEvent(new TextSE("\"See that big Tower to the south? According to our intel, that's where the one \nresponsible resides. It doesn't matter how many other monsters you defeat, \nif you don't take care of the one in that tower, more of those things will just appear...\""));
        R1.AddWelcomeEvent(new TextSE("\"You can't just waltz on in however, the gate is locked and you'll need 4 parts of a key, each given to one of the 4 Trash Guardians.\""));
        R1.AddWelcomeEvent(new TextSE("\"Given that you're the best janitor the UN headquarters had on hand, \nI'm sure it'll be a walk in the park to you. Good luck champ.\"", "Press enter to jump..."));

        R1.AddWelcomeEvent(new TextSE("You land in a big pile of trash, saving both yourself and your cleaning cart \nfrom an early GAME OVER screen. The only tools at your disposal are the \nusual cleaning supplies you have in your cart, as well as a walkie talkie."));
        this.entry = R1;



        R2.AddWelcomeEvent(new TextSE("\nOn your way west, you pass by the island docks to your north. The sudden \nsmell of rotting fish comes across you like a wave."));



        R3.AddWelcomeEvent(new TextSE("\nYou make your way to the docks, holding your fingers tight around your \nnose. The entire place feels haunted, and you get caught in multiple nets as \nyou make your way around the place."));
        R3.AddWelcomeEvent(new TextSE("As you approach the pier, something begins to rise from the ocean. An \nenormous sea turtle that crushes the harbor as it lumbers towards you. Its \nmovements slowed down by the countless fishing nets that envelop its body."));
        // R3 NPC dialouge
        List<string> dialogueListNPC1 = new List<string>
        {
            "\nAs you approach the beast with polite conversation and small talk, you're \nsurprised to find that turtles talk in a very loud, almost roar-ish, screaming \nlanguage. \n\n   ...\"Maybe it doesn't like the weather?\", you think...",
            "\nNope. Differently doesn't like the weather...",
            "\nRealizing you can't win, you decide to run, and manage to escape around a \nbuilding. Trying to think of a plan, you take a look back at the beast, and see \nit's still attacking everything around it indiscriminately. \n\nYou realize it wasn't attacking you out of spite. More likely, being stuck \nin those nets, was what made it lash out in anger. So you reach for the \nchemicals in your cart, mixing them into a concoction strong enough to melt \nthe nets. \n\n(Pretend you got a new attack here)"
        };

        R3.PlaceNPC(new NPC("turtle", "Example description for NPC 1", dialogueListNPC1));
        // Add text when combat begins...
        // Added monster and death-dialouge
        R3.Monster = new Monster (
          "turle", 
          20, 
          new Item("keypiece", 
          "Key Piece"), 
          "acid",
          "Finally being freed from those nets. The turtle begins to calm down. It opens \nits mouth, revealing a key piece to you, placed on its tongue.\n\nYou contact HQ, telling them it's safe for the crew to come in and take care \nof the rest.\n\nYou also relay to them the importance of using chemicals to break down old \nfishing gear."
        );



        R4.AddWelcomeEvent(new TextSE("\nAs you continue along the road west, you're surprised to find a long line of \npeople in front of you. Looking for where the line starts, you face south, and \nwonder how the travel poster neglected to make any mention of the theme \npark located on the island.", "Press enter to skip line..."));
        R4.AddWelcomeEvent(new TextSE("As you pass the people in line, you notice that they aren't people at all. \nLooking like the insides of trash bins that came to life. These monsters \nresemble large, dull minded tourists, fit with dirty clothes and hats."));



        R5.AddWelcomeEvent(new TextSE("\nYou search the park for the key piece.", "Press enter to try cotton candy"));
        R5.AddWelcomeEvent(new TextSE("You immediately regret your decision...\n\nContinuing on your search for the key, you can't help but shake the thought \"there's no way it was THAT bad...\"", "Press enter to go back for seconds..."));
        R5.AddWelcomeEvent(new TextSE("It was that bad...\n\nConsidering the entire place is made of garbage, you probably should have \nseen this coming..."));
        R5.AddWelcomeEvent(new TextSE("Rushing for something to wash it down with, you bump into a large mascot."));
        // R5 NPC dialouge
        List<string> dialogueListNPC2 = new List<string>
        {
            "\nEven their mascot looked dull minded. Only vaguely resembling a large \nanimal, it was made up entirely of a mixture between cardboard cups, candy \nwraps and leftover bits of food.",
            "\nThe mascot doesn't react. He's properly instructed to never talk to the guest \nwhile in costume.",
            "\nWith each punch, the monster quickly regenerates its body, using the \nsurrounding trash to suck towards it, and heal it. Thinking back to your years \nof training, you remember your masters old words... \n\n \"...Do. Or do not. There is no try, when using the recycling bins...\", he would say, in a mysterious voice.\n\nYou grab some small recycling bins from your cart, and place them around \nthe mascot. It seems to work, as the trash now gets sucked towards \nthe recycling bins, whenever the monster tries to heal.\n\n(Pretend you got a new attack here)"
        };

        R5.PlaceNPC(new NPC("mascot", "Example description for NPC 1", dialogueListNPC2));
        // Add text when combat begins...
        // Added monster and death-dialouge
        R5.Monster = new Monster (
          "turle", 
          20, 
          new Item("keypiece", 
          "Key Piece"), 
          "recycle",
          "After finally throwing the last parts of the mascot into the correct bins. All \nthere's left now is a key piece of the ground.\n\nYou contact HQ, telling them it's safe for the crew to come in and take care of the rest. \n\nYou also relay to them the importance of disposing trash in the correct \ngarbage bins."
        );
        


        R6.AddWelcomeEvent(new TextSE("\nYou reach a town. Passing buildings made of wet cardboard, streets of \nbroken glass, and a large statue of what you thought might resemble some \nweird wet creature."));
        // R6 NPC dialouge
        List<string> dialogueListNPC3 = new List<string>
        {
            "\nDespite not seeing anyone in the vicinity, you still give the <talk> command \na try. Only to hear a devilish voice, coming from the statue.",
            "\nPretending that didn't scare you a little. The statue tells you about the town. \nExplaining that loud commotion has been heard coming from the mall to the \nnorth. As well as thick white smoke, rising from dark alleyways to the east."
        };

        R6.PlaceNPC(new NPC("voice", "Example description for NPC 1", dialogueListNPC3));



        R7.AddWelcomeEvent(new TextSE("\nAs you search the mall floors, not at all surprised by their terrible deals. You \ncome across a toy store, where you suddenly stand face to face with two \nmonsters, looking like they're ready for action."));
        // R7 NPC dialouge
        List<string> dialogueListNPC4 = new List<string>
        {
            "\nThe two announce themselves as Action Man and Bottle Boy. The former \nresembles an 8 foot tall amalgamation of different action figures, fit with a \nlarge sword on its back. While the latter looked more like a small boy, made \nup of old plastic bottles, with two googly eyes on his head.",
            "\nYou can't think of a clevor one liner fast enough, so you just end up making a weird sound while pointing at them",
            "\nAfter discovering how much it hurts to get punched repetitively with hard \nplastic, you look up and see that all you've managed to do so far is give \nthem some light cuts here and there. This does give you the idea that it \nmight be easier to cut plastic to pieces, rather than punch it. \n\nFlinging Bottle Boy by his Bottleneck. You hit Action Man right in the face, \ndistracting them both long enough to grab the sword..\n\n(Pretend you got a new attack here)"
        };
        R7.PlaceNPC(new NPC("villains", "Example description for NPC 1", dialogueListNPC4));
        // Add text when combat begins...
        // Added monster and death-dialouge
        R7.Monster = new Monster (
          "villains", 
          20, 
          new Item("keypiece", 
          "Key Piece"), 
          "cut",
          "With the monsters finally defeated. You see a key piece sticking out from \ninside Bottle Boy's bottle cap. \n\nYou pick up the key piece, and contact HQ telling them it's safe for the crew \nto come in, and take care of the rest. \n\nYou also relay to them the importance of shredding plastic into smaller \npieces. Before it can be melted down and reused."
        );



        R8.AddWelcomeEvent(new TextSE("\nAs you get closer and closer to the alleys, the more cigarette butts appear \non the ground, until there's barely any ground left to see."));
        R8.AddWelcomeEvent(new TextSE("With the stench of smoke so strong, only a grandmother would be able to \nwash it out of your clothes. You march into the darkness."));
        R8.AddWelcomeEvent(new TextSE("You continue searching the dark alleyways, until you finally meet a \nmysterious figure, standing against a wall."));
        // R8 NPC dialouge
        List<string> dialogueListNPC5 = new List<string>
        {
            "\nThe figure lights a cigarette, revealing itself to be thousands of cigarettes in \na trench coat and a fedora. Shocked by what it's willing to do to one of its \nbrothers, you ready yourself for a fight.",
            "\n\"M'lady\", the figure says, tipping his fedora",
            "\nDespite not being made up of more than paper and dried leaves. The \nmysterious figure is surprisingly sturdy. With a hard punch you get knocked \nto the ground. \n\nAfter seeing stars next to all those cigarette butts, you suddenly remember \nhow flammable paper and dried leaves are. In a last ditch attempt, You \nlaunch yourself at the mysterious figure, grabbing its lighter, to use as a \nweapon against it...\n\n(Pretend you got a new attack here)"
        };

        R8.PlaceNPC(new NPC("figure", "Example description for NPC 1", dialogueListNPC5));
        // Add text when combat begins...
        // Added monster and death-dialouge
        R8.Monster = new Monster (
          "mysterious figure", 
          20, 
          new Item("keypiece", 
          "Key Piece"), 
          "fire",
          "With not much more than a crisp on the ground, you see a key piece sticking \nout from the ashes. \n\nYou pick up the key piece, and contact HQ, telling them it's safe for the crew \nto come in, and take care of the rest. \n\nYou also relay to them the importance of burning cigarette waste."
        );

        R9.AddWelcomeEvent(new TextSE("\nIn front of you stands a large tower. As you walk up to its gate, you see 4 \nkey slots in the door. "));
        // Add text if try to enter tower, without full key

        R10.AddWelcomeEvent(new TextSE("\nAfter placing all 4 key pieces in their respective slots. You hear a loud clicking sound, followed by the gate, slowly opening.", "Press enter to enter tower..."));
        R10.AddWelcomeEvent(new TextSE("Inside the tower, you're met with a large set of stairs.", "Press enter to search for an elevator..."));
        R10.AddWelcomeEvent(new TextSE("You're in luck! You find an elevator in a side room, and it's almost entirely \nwhole. Only missing a side door, a couple of buttons, and a long cable, \nreaching all the way to the top of the tower...", "Press enter to sigh in disappointment..."));
        R10.AddWelcomeEvent(new TextSE("After spending 30 minutes pushing your cart up the stairs. You reach the top \nroom and enter. In front of you sits a large, humanoid creature, made entirely \nof water..."));
        // R10 NPC dialouge
        List<string> dialogueListNPC6 = new List<string>
        {
            "\nThe creature announces itself as the Sea Devil. A manifestation of the \noceans anger itself. It's intent on enacting revenge on the humans that \ncontinue to poison it.",
            "\nDeciding to gather up all the trash in the oceans, forming it into a single land \nmass. It plans to build an army of monsters, made out of the exact same \ntrash that the humans polluted it with. To destroy human kind."
        };

        R10.PlaceNPC(new NPC("devil", "Example description for NPC 1", dialogueListNPC6));
        // Add text when combat begins...
        // Add text doing combat...
        
        // Add text when combat begins...
        // Added monster and death-dialouge
        R10.Monster = new Monster (
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

