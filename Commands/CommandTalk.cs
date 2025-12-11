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
    
        Space current = context.GetCurrent();
        //Magnus: Special case to make sure Ivan NPC talk doesn't trigger too early
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
        string npcKey = current.GetNPC()!.GetName();

        //Magnus: Special case for the Samurai in Mall after the Barbie Doll has been picked up
        if (current.GetName() == "M1" && !Flags.GetFlag(Flags.M_S3_Pickup_Barbie))
        {
            Console.WriteLine(Mall_Text.M_S1_Talk_2);
            return;
        }
        // Get their dialogue
        NPC currentNPC = current.GetNPC()!;
        Console.WriteLine(currentNPC.GetDialoguePrompt());
    }
}