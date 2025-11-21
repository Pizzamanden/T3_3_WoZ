class Zone
{
	private string name;
	private string description;
	private List<Space> SpaceList;
    
    public List<Monster> MonsterList;
    public Zone(string _name, string _description)
    {
        name = _name;
        description = _description;
        SpaceList = new List<Space>();
        MonsterList = new List<Monster>();
    }

// Troels: Tjekker om der er levende monstre i zonen
    public bool HasMonsters()
    {
        foreach (Monster monster in MonsterList)
        {
            if (monster.IsAlive())
            {
                return true;
                break;
            }
        }
        return false;
    }
//Troels: Tilføjer et monster til zonen
    public void AddMonster(Monster monster)
    {
        if (!MonsterList.Contains(monster))
        {
            MonsterList.Add(monster);
        }
    }
// Troels: Tjekker om zonen er færdiggjort og fjerner en edge hvis betingelserne er opfyldt
/*
public void ZoneDone(Zone zone, Item item, Context context, Space space, string egdeName)
{
    if (!zone.HasMonsters() && context.GetInventory().Any(i => i.GetName() == item.GetName()))
    {
        space.RemoveEdge(egdeName);
    }
}
*/

    public void AddSpace(Space space)
    {
        if (!SpaceList.Contains(space))
        {
            SpaceList.Add(space);
        }
    }
}