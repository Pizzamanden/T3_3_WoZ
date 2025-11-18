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
    public int AttackDamage { get; set; } = 10; // Nicholas: Standard angrebsskade
	public Item? itemToDrop;
    //public string deathText = "You defeated the enemy!";
    public string flipOnDeath;

    private List<IEvent> eventsMonsterDeath = new List<IEvent>();

    // Denne metode køres når et nyt Monster laves
    public Monster(string name, int maxHp, Item item, string weakness, string flipOnDeath)
    {
        this.Name = name;
        this.MaxHp = maxHp;
        this.HP = maxHp;
        this.Weakness = weakness;
		this.itemToDrop = item;
        this.flipOnDeath = flipOnDeath;
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

    /* Peter
        Method to be called when a monster dies
        Flips any flags that have been specified
        Triggers all events specified
    */
    public void OnMonsterDeath(Context context){
        // Flags to flip when the monster dies
        context.SetFlag(flipOnDeath);
        // Events to fire when the monster dies
        while(eventsMonsterDeath.Count > 0)
        {
            eventsMonsterDeath[0].Trigger();
            eventsMonsterDeath.RemoveAt(0);
        }
        // Peter: Drop an item??
        context.GetCurrent().PlaceItem(itemToDrop);
    }

    /* Peter
        Method for adding events to trigger for when the monster dies
    */
    public void AddMonsterDeathEvent(IEvent e)
    {
        this.eventsGoodbye.Add(e);
    }
}
