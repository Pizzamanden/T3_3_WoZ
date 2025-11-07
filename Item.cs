//Base class for creating items

class Item
{
	private string name;
	private string keyword;
	
	public Item(string name, string keyword)
	{
	this.name = name;
	this.keyword = keyword;
	}
	
	public string GetName()
	{
		return name;
	}

	public string GetKeyword()
	{
		return keyword;
	}
}
