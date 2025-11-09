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
        Monster? monster = context.GetCurrent().Monster;

        // Nicholas: Tjek om der er et monster at angribe
        if (monster == null || !monster.IsAlive()) // Når man bruger kommandoen og der ikke er noget monster
        {
            Console.WriteLine("Der er ingen fjende at angribe her.");
            return;
        }

        // Nicholas : Tjek om spilleren har angrebsmuligheder
        if (parameters.Length < 1)
        {
            Console.WriteLine("Brug: useattackmove <move_name>");
            return;
        }

        string attackType = parameters[0];
        Console.WriteLine($"Du bruger {attackType} mod {monster.Name}!");

        // Nicholas: Tjek om angrebstypen er gyldig

        // Nicholas: Bestem skaden baseret på angrebstypen og monsterets svaghed
        //int playerDamage = 10;

        if (attackType == monster.Weakness)
        {
            Console.WriteLine("Det var super effektivt!");
        }
        else
        {
            Console.WriteLine("Det var ikke særlig effektivt.");
        }

        // Nicholas: Monsteret angribes og den rapporterer tilbage hvor meget liv monsteret har tilbage
        monster.TakeDamage(context.GetPlayer().AttackDamage * (attackType == monster.Weakness ? 2 : 1));
        Console.WriteLine($"{monster.Name} har {monster.HP} HP tilbage.");

        // Nicholas: Monsteret angriber tilbage, hvis det stadig er i live
        if (monster.IsAlive())
        {
            Console.WriteLine($"{monster.Name} angriber tilbage!");
            context.GetPlayer().TakeDamage(monster.AttackDamage);
            Console.WriteLine($"Du har {context.GetPlayer().HP} HP tilbage.");
			if(!context.GetPlayer().IsAlive()){
				Console.WriteLine("You died.");
			}
        }
        else
        {
            Console.WriteLine($"Du har besejret {monster.Name}!");
            context.GetCurrent().Monster = null; 
        }
    } 
} 