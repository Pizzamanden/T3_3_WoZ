using System;
using Microsoft.Win32;

//Nicholas: Denne klasse her indeholder kommandoen til at bruge et angreb mod et monster.
class CommandUseAttackMove : BaseCommand, ICommand
{
    public CommandUseAttackMove()
    {
        description = "Brug et angreb mod et monster i den nuværende lokation.";
    }

    public void Execute(Context context, string command, string[] parameters)
    {
        Monster? monster = context.GetCurrent().CurrentMonster;

        // Check if there is a monster to attack
        if (monster == null || !monster.IsAlive()) // Using !monster.IsAlive() is more standard than == false
        {
            Console.WriteLine("Der er ingen fjende at angribe her.");
            return;
        }

        // Check if an attack name was provided
        if (parameters.Length < 1)
        {
            Console.WriteLine("Brug: useattackmove <move_name>");
            return;
        }

        string attackType = parameters[0];
        Console.WriteLine($"Du bruger {attackType} mod {monster.Name}!");

        // --- All logic below was incorrectly placed outside the Execute method ---

        // Calculate player damage
        int playerDamage = 10;

        if (attackType == monster.Weakness)
        {
            playerDamage *= 2;
            Console.WriteLine("Det var super effektivt!");
        }
        else
        {
            Console.WriteLine("Det var ikke særlig effektivt.");
        }

        // Apply damage and report monster health
        monster.TakeDamage(playerDamage);
        Console.WriteLine($"{monster.Name} har {monster.Health} HP tilbage.");

        // Check if monster survives and attacks back
        if (monster.IsAlive())
        {
            Console.WriteLine($"{monster.Name} angriber tilbage!");
            context.Player.TakeDamage(monster.AttackDamage);
            Console.WriteLine($"Du har {context.Player.Health} HP tilbage.");
        }
        else
        {
            Console.WriteLine($"Du har besejret {monster.Name}!");
            context.GetCurrent().CurrentMonster = null; 
        }
    } 
} 