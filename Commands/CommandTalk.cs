/* Command for talking to NPCs
*/
namespace WoZ.Commands;
using WoZ.Interfaces;
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
            NPC currentNPC = current.GetNPC()!;
            Console.WriteLine(currentNPC.GetDialoguePrompt());
        //}
        /*else
        {
            Console.WriteLine("There is no such NPC here");
        }*/
    }
}