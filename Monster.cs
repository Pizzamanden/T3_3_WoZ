using System;


public class Monster
{
     // Nicholas : PROPERTIES ---
    // Dette lader andre klasser LÆSE værdierne, 
    // men kun denne klasse kan ÆNDRE dem.
    public string Name { get; private set; }
    public int HP { get; private set; }
    public int MaxHp { get; private set; }

    // Denne metode køres når et nyt Monster laves
    public Monster(string name, int maxHp)
    {
        this.Name = name;
        this.MaxHp = maxHp;
        this.HP = maxHp;
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
    
     /*
    * metode til at tjekke, om Monstret er i live.
    * Den vil blive brugt i vores 'Game.cs' loop.
    */
 public bool IsAlive()
    {
        return HP > 0;
    }


}
