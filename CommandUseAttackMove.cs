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
            Console.WriteLine("To use an attack type: attack <move_name>");
			listAttacks(context);
            return;
        }

        string attackType = parameters[0];
		// Peter: Check if attack exists
		if(!context.Player.HasAttack(attackType.ToLower())){
			// Attack was not found
			Console.WriteLine("That attack could not be found.");
			listAttacks(context);
			return;
		}
		Attack attack = context.Player.AttackList[attackType.ToLower()];
		
        Console.WriteLine($"Du bruger {attack.Name} mod {monster.Name}!");
		
		if(attack.Type == monster.Weakness){ // Monster is weak to this!
			Console.WriteLine("It's super effective! You deal double the normal damage!");
		}

        // Nicholas: Monsteret angribes og den rapporterer tilbage hvor meget liv monsteret har tilbage
        monster.TakeDamage(attack.Damage * (attack.Type == monster.Weakness ? 2 : 1));
        Console.WriteLine($"{monster.Name} har {monster.HP} HP tilbage.");

        // Nicholas: Monsteret angriber tilbage, hvis det stadig er i live
        if (monster.IsAlive())
        {
            Console.WriteLine($"{monster.Name} angriber tilbage!");
            context.Player.TakeDamage(monster.AttackDamage);
            Console.WriteLine($"Du har {context.Player.HP} HP tilbage.");
			if(!context.Player.IsAlive()){
				Console.WriteLine("You died.");
			}
        }
        else
        {
            Console.WriteLine($"Du har besejret {monster.Name}!");
			// Peter: Drop an item if the monster should drop an item
			//context.GetCurrent().Monster.DropItem(context.GetCurrent());
			// Then remove it from the Space
            context.GetCurrent().Monster = null; 
        }
    }
	
	private void listAttacks(Context context){
		Console.WriteLine("List of moves you can use, their damage and their types:");
		// Peter: List available attacks
		foreach (KeyValuePair<string,Attack> item in context.Player.AttackList){
			Attack attack = item.Value;
			Console.WriteLine($" - {attack.Name}, DMG: {attack.Damage}, type = {attack.Type}");
		}
	}
} 