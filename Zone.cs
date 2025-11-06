class Zone
{
	private string name;
	private string description;
	private List<Space> SpaceList;

    public Zone(string _name, string _description)
    {
        name = _name;
        description = _description;
        SpaceList = new List<Space>();
    }

    public void AddSpace(Space space)
    {
        if (!SpaceList.Contains(space))
        {
            SpaceList.Add(space);
        }
    }

    public override string ToString()
    {
        return $"{name}: {description}";
    }
}