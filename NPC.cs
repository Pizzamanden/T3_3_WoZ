namespace WoZ;
using System.Collections.Specialized;

class NPC
{
    string name;
    string dialogueExhaustedLine;
    List<string> dialogueList;
    int currentDialoguePrompt;
    public string FlagToGet; // Mikkel: Monster can set a flag
    public Item? itemToDrop;

    // Mikkel: Tilføjede lige noget FlagToGet, det er ikke færdigt, men det skal bruges til den npc i Mall,
    // til når du får hans item, så siger han noget andet og giver dig item der
    public NPC(string nameval, string dialogueExhaustedLineVal, List<string> dialogueListval)
    {
        name = nameval;
        dialogueExhaustedLine = dialogueExhaustedLineVal;
        dialogueList = dialogueListval;
        currentDialoguePrompt = 0;
        FlagToGet = "";
    }

    public NPC(string nameval, string dialogueExhaustedLineVal, List<string> dialogueListval , string FlagToGet, Item? item)
    {
        name = nameval;
        dialogueExhaustedLine = dialogueExhaustedLineVal;
        dialogueList = dialogueListval;
        currentDialoguePrompt = 0;
        this.FlagToGet = FlagToGet;
        this.itemToDrop = item;
    }

    public bool HasMoreDialouge()
    {
        return currentDialoguePrompt < dialogueList.Count;   
    }

    public string GetDialoguePrompt()
    {
        string currentPrompt = "";
        if (HasMoreDialouge())
        {
            currentPrompt = dialogueList[currentDialoguePrompt];
        } else
        {
            currentPrompt = (dialogueExhaustedLine == "" ? "That's all the information I have for you." : dialogueExhaustedLine);
        }
        currentDialoguePrompt++;
        return currentPrompt;
    }

    public string GetName()
    {
        return name;
    }

    /*public string GetDescription()
    {
        return description;
    }*/

	public void DropItem(Space space){
		if(itemToDrop != null)
        {
            space.PlaceItem(this.itemToDrop!);
        }
	}

    /* 

    Example use:

    List<string> dialogueListNPC1 = new List<string>
    {
        $"Hello, agent. I'm NPC 1. Do you want to find out more about the monster?",
        "This is the plastic monster. You can defeat him by recycling the trash he's attacking you with."
    };

    NPC npc1 = new NPC("NPC 1", "Example description for NPC 1", dialogueListNPC1);

    */
}