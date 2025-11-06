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

    // --- CONSTRUCTOR ---
    // Denne metode kører, når en ny Player laves
    public Player(string name, int maxhp)
    {
        this.Name = name;
        this.MaxHP = maxhp;
        this.HP = maxhp; // Nicholas: Start med fuldt liv
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
        Console.WriteLine($"{Name} takes {amount} damage! HP is now {HP}/{MaxHP}.");
    }


    /*
    * metode til at tjekke, om spilleren er i live.
    * Den vil blive brugt i vores 'Game.cs' loop.
    */
    public bool IsAlive()
    {
        return HP > 0;
    }

   
}


