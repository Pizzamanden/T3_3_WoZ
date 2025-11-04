using System;


public class Monster
{
     // --- PROPERTIES ---
    // Dette lader andre klasser LÆSE værdierne, 
    // men kun denne klasse kan ÆNDRE dem.
    public string Name { get; private set; }
    public int HP { get; private set; }
    public int MaxHp { get; private set; }

    public Monster(string name, int maxHp)
    {
        this.Name = name;
        this.MaxHp = maxHp;
        this.HP = maxHp;
    }

    public void TakeDamage(int amount)
    {
        HP -= amount;

        if (HP < 0)
        {
            HP = 0;
        }

        Console.WriteLine($"{Name} takes {amount} damage! HP is now {HP}/{MaxHp}.");
    }



}
