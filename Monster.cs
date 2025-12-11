namespace WoZ;
using System;


class Monster
{
     // Nicholas : PROPERTIES ---
    // Dette lader andre klasser LÆSE værdierne, 
    // men kun denne klasse kan ÆNDRE dem.
    public string Name { get; private set; }
    public int HP { get; private set; }
    public int MaxHp { get; private set; }
    public string Weakness { get; set; } = "fire"; // Nicholas: Standard svaghed
    public int AttackDamage { get; set; } = 1; // Nicholas: Standard angrebsskade
	public Item? itemToDrop;
    public string deathText = "You defeated the enemy!";
    public string FlagToSet; // Mikkel: Monster can set a flag

    // Denne metode køres når et nyt Monster laves
    public Monster(string name, int maxHp, Item? item, string weakness, string deathText, string FlagToSet)
    {
        this.Name = name;
        this.MaxHp = maxHp;
        this.HP = maxHp;
        this.Weakness = weakness;
		this.itemToDrop = item;
        this.deathText = deathText;
        this.FlagToSet = FlagToSet;
    }

    /*
    * Reducerer spillerens HP med et givent antal.
    * Sørger for, at HP ikke kan falde til under 0.
    */
    public void TakeDamage(int amount)
    {
        // Træk 'amount' fra 'HP'
        HP -= amount;

        // Sikkerheds-tjek, så HP ikke bliver negativt
        if (HP < 0)
        {
            HP = 0;
        }
        // Giver feedback til konsollen
        Console.WriteLine($"{Name} takes {amount} damage! HP is now {HP}/{MaxHp}.");
    }

    public void Heal()
    {
        HP = MaxHp;
        Console.WriteLine($"You fled the battle! {Name} is now fully recovered. HP is now {HP}/{MaxHp}.");
    }
    
     /*
    * metode til at tjekke, om Monstret er i live.
    * Den vil blive brugt i vores 'Game.cs' loop.
    */
    public bool IsAlive()
    {
        return HP > 0;
    }

    public void OnMonsterDeath(Space space){
        if(deathText != "")
        {
            Console.WriteLine(deathText);
        }
        if (FlagToSet != "")
        {
            Flags.SetFlag(FlagToSet);
        }
        //space.RunWelcomeEvents();
    }
	
	// Peter: Drop the set item on the monsters space
	public void DropItem(Space space){
		if(itemToDrop != null)
        {
            space.PlaceItem(this.itemToDrop!);
        }
	}


}
