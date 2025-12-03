//Base class for creating items

class Item
{
	private string name;
	private string keyword;
	public string FlagToSet;
	
	public Item(string name, string keyword)
	{
	this.name = name;
	this.keyword = keyword;
	this.FlagToSet = "";
	}
	public Item(string name, string keyword, string FlagToSet)
    {
	this.name = name;
	this.keyword = keyword;
	this.FlagToSet = FlagToSet;
    }
	
	public string GetName()
	{
		return name;
	}

	public string GetKeyword()
	{
		return keyword;
	}
	public void SetFlag(string FlagToSet)
	{
		if (FlagToSet != "")
        {
            Flags.SetFlag(FlagToSet);
        }
	}
}
