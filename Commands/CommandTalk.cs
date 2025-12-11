/* Command for talking to NPCs
*/
namespace WoZ.Commands;
using WoZ.Interfaces;
using WoZ.Texts;
class CommandTalk : BaseCommand, ICommand {
    public CommandTalk () {
        description = "Talk to an NPC";
    }
    
    public void Execute (Context context, string command, string[] parameters) {
     /*   if (GuardEq(parameters, 1))
        {
            Console.WriteLine("I don't seem to know who that is");
            return;
        }*/
    
        Space current = context.GetCurrent();
        if (current.GetName() == "C2" && !Flags.GetFlag(Flags.C_S6_Monster_Dead))
        {
            Console.WriteLine("Ivan smiles at you. \"See you later, my friend\" he says.");
            return;
        }
        if (current.NPCCheck() == false)
        {
            Console.WriteLine("There's no one to talk to here");
            return;
        }

       // string commandInput = parameters[0];
        string npcKey = current.GetNPC()!.GetName();
        //Checks if the user's input matches the keyword
        //If yes, the item is collected and removed from the room. 
       // if (commandInput == npcKey)
        //{
        //Magnus: Special case for the Samurai in Mall after the Barbie Doll has been picked up
        if (current.GetName() == "M1" && Flags.GetFlag(Flags.M_S3_Pickup_Barbie))
        {
            Console.WriteLine(Mall_Text.M_S1_Talk_2);
            return;
        }

        NPC currentNPC = current.GetNPC()!;
            Console.WriteLine(currentNPC.GetDialoguePrompt());
        //}
        /*else
        {
            Console.WriteLine("There is no such NPC here");
        }*/
    }
}