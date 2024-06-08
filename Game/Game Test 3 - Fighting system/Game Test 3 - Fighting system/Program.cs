using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Test_3___Fighting_system
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int playerHealth = 100;
            int playerDamage = 5;
            int monsterHealth = 24;
            int monsterDamage = 2;
            FightMechanic(ref playerHealth, ref playerDamage, monsterHealth, monsterDamage);
            FightMechanic(ref playerHealth, ref playerDamage, monsterHealth, monsterDamage);

        }
        public static void FightMechanic(ref int playerHealth, ref int playerDamage, int monsterHealth, int monsterDamage)
        {
            int round = 1;
            while(playerHealth > 0 && monsterHealth > 0)
            {
                Console.WriteLine($"Round: {round++}");
                monsterHealth -= playerDamage;
                Console.WriteLine($"Player attacked the monster\nMonster Health: {monsterHealth}\n");
                
            }
            while (playerHealth > 0 && monsterHealth > 0)
            {
                playerHealth -= monsterDamage;
                Console.WriteLine($"Monster attacked the player\nPlayer Health: {playerHealth}\n");
            }

                if (playerHealth > 0 && monsterHealth <= 0)
            {
                Console.WriteLine("Player defeated the monster");
            }
            else if (playerHealth <= 0)
            {
                Console.WriteLine("The Monster defeated the player.\nYou lost!");
            }
        }
    }
}
