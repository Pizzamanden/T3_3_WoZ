namespace WoZ;
using System;

public class Player
{
    // Nicholas --- PROPERTIES ---
    // Dette lader andre klasser LÆSE værdierne, 
    // men kun denne klasse kan ÆNDRE dem.
    public string Name { get; private set; }
    public int HP { get; private set; }
    public int MaxHP { get; private set; }

    public int AttackDamage { get; set; } = 15; // Nicholas: Standard angrebsskade
	
	public Dictionary<string, Attack> AttackList { get; set;} = new Dictionary<string, Attack>();

    public bool isInCombat = false;

    // --- CONSTRUCTOR ---
    // Denne metode kører, når en ny Player laves
    public Player(string name, int maxhp)
    {
        this.Name = name;
        this.MaxHP = maxhp;
        this.HP = maxhp; // Nicholas: Start med fuldt liv
        this.isInCombat = isInCombat;
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
        Console.WriteLine($"{Name} take {amount} damage! HP is now {HP}/{MaxHP}.\n");
    }

    public void Heal(int amount)
    {
        if (HP + amount >= MaxHP)
        {
            HP = MaxHP;
            Console.WriteLine($"\n{Name} are now fully rested. HP is now {HP}/{MaxHP}.");
        }
        else
        {
            HP += amount;
            Console.WriteLine($"\n{Name} rests for an hour and replenishes {amount} HP! HP is now {HP}/{MaxHP}.");
        }
    }

    // Mikkel: Made a full heal method
    public void FullHeal()
    {
        HP = MaxHP;
    }

    /*
    * metode til at tjekke, om spilleren er i live.
    * Den vil blive brugt i vores 'Game.cs' loop.
    */
    public bool IsAlive()
    {
        return HP > 0;
    }
	
	/*
	*	Method for checking if an attack exists
	*/
	public bool HasAttack(string name){
		return AttackList.ContainsKey(name);
	}
	
	/*
	*	Method for adding an attack to the player.
	*	Returns true if the attack was added
	*	Returns false if either the attack is null, or if an attack by that name already exists
	*/
	public bool AddAttack(Attack attack){
		if(attack == null) return false; // Return false if attack is null
		if(AttackList.ContainsKey(attack.Name)){
			return false; // Return false if an attack with the same name already exists
		} else {
			AttackList.Add(attack.Name, attack);
			return true; // Return true since it should have been added
		}
	}
	
	/*
	*	Method for removing an attack from the player.
	*	Returns true if the attack was removed
	*	Returns false if either the attack is null, or if an attack by that name didnt exist
	*/
	public bool RemoveAttack(Attack attack){
		if(attack == null) return false; // Return false if attack is null
		return AttackList.Remove(attack.Name); // This method cannot throw that one exception, no check should be needed
	}
	
	/*
	*	Method for removing an attack from the player using its name.
	*	Returns true if the attack was removed
	*	Returns false if an attack by that name didnt exist
	*/
	public bool RemoveAttack(string name){
		return AttackList.Remove(name); // This method cannot throw that one exception, no check should be needed
	}
   
}