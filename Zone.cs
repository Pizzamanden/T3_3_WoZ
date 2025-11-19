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
// Troels: Tjekker om zonen er færdiggjort
    public bool ZoneDone(Zone zone, string key)
    {
        if (zone.HasMonsters() == true && GetInventory.Contains(key) == false)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public void AddSpace(Space space)
    {
        if (!SpaceList.Contains(space))
        {
            SpaceList.Add(space);
        }
    }
}