//Base class for creating items

class Item
{
	private string name;
	
	public Item(string name)
	{
	this.name = name;
	}
	
	public string GetName()
	{
		return name;
	}
}
