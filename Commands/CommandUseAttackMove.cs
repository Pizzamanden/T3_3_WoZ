namespace WoZ.Commands;
using System;
using System.Runtime.CompilerServices;
using Microsoft.Win32;
using WoZ.Interfaces;
//Nicholas: This class contains the command to use an attack move against a monster.
class CommandUseAttackMove : BaseCommand, ICommand
{
    private static Random randomDamage = new Random();
    public CommandUseAttackMove()
    {
        description = "Use an attack move in the current location.";
    }

    public void Execute(Context context, string command, string[] parameters)
    {
        Monster? monster = context.GetCurrent().Monster;

        // Nicholas: Check if there is a monster to attack
        if (monster == null || !monster.IsAlive()) // When you use the command and there isn't any monster nearby
        {
            Console.WriteLine("There is no enemy to attack here.");
            return;
        }

        
        // Nicholas: Check if the player has any attack moves
        if (parameters.Length < 1)
        {
            Console.WriteLine("To use an attack type: attack <move_name>");
            listAttacks(context);
            return;
        }

        string attackType = parameters[0];
        // Peter: Check if attack exists
        if (!context.Player.HasAttack(attackType.ToLower()))
        {
            // Attack was not found
            Console.WriteLine("That attack could not be found.");
            listAttacks(context);
            return;
        }
        Attack attack = context.Player.AttackList[attackType.ToLower()];

        Console.WriteLine($"You use {attack.Name} against {monster.Name}!");

        if (attack.Type == monster.Weakness)
        { // Monster is weak to this!
            Console.WriteLine("It's super effective! You deal double the normal damage!");
        }

        // Nicholas: The monster is attacked and it reports back how much HP the monster has left
        int baseDamage = randomDamage.Next(attack.MinDamage, attack.MaxDamage + 1);
        int finalDamage = baseDamage * (attack.Type == monster.Weakness ? 2 : 1);
        monster.TakeDamage(finalDamage);
        
        // Nicholas: The monster strikes back if it is still alive
        if (monster.IsAlive())
        {
            Console.WriteLine($"\n{monster.Name} Strikes back!");
            context.Player.TakeDamage(monster.AttackDamage);
        }
        else
        {
            monster!.OnMonsterDeath(context.GetCurrent());
            context.Player.isInCombat  = false;
            // Peter: Drop an item if the monster should drop an item
            context.GetCurrent().Monster!.DropItem(context.GetCurrent());
            // Then remove it from the Space
            context.GetCurrent().Monster = null;
        }
    }

    private void listAttacks(Context context)
    {
        Console.WriteLine("List of moves you can use, their damage and their types:");
        // Peter: List available attacks
        foreach (KeyValuePair<string, Attack> item in context.Player.AttackList)
        {
            Attack attack = item.Value;
            Console.WriteLine($" - {attack.Name}, DMG: {attack.MinDamage}-{attack.MaxDamage}, type = {attack.Type}");
        }
    }
} 