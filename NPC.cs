using System.Collections.Specialized;

class NPC
{
    string name;
    string description;
    List<string> dialogueList;

    public NPC(string nameval, string descriptionval, List<string> dialogueListval)
    {
        name = nameval;
        description = descriptionval;
        dialogueList = dialogueListval;
    }


    /* 

    Example use:

    List<string> dialogueListNPC1 = new List<string>
    {
        $"Hello, agent. I'm NPC 1. Do you want to find out more about the monster?",
        "This is the plastic monster. You can defeat him by recycling the trash he's attacking you with."
    };

    npc1 = new NPC("NPC 1", "Example description for NPC 1", dialogueListNPC1);

    */
}