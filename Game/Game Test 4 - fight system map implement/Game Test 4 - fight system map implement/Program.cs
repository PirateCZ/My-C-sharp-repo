using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] gameMap = new int[25, 25];
            string[] playerInventory = new string[9];
            int playerHealth = 100;
            string playerMainHand = null;
            int emptySpaceValue = 0;
            int playerValue = 1;
            int itemValue = 2;
            int monsterValue = 3;
            int playerPosX = 13;
            int playerPosY = 13;
            bool keepGameOpen = true;
            gameMap[playerPosX, playerPosY] = playerValue;
            gameMap[14, 14] = itemValue;
            gameMap[12, 12] = monsterValue;
            playerInventory[1] = "tata";
            playerInventory[2] = "mama";
            do
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                switch (keyInfo.Key)
                {
                    case ConsoleKey.W:
                        playerPosX--;
                        Console.WriteLine("You moved up");
                        break;
                    case ConsoleKey.S:
                        playerPosX++;
                        Console.WriteLine("You moved down");
                        break;
                    case ConsoleKey.A:
                        playerPosY--;
                        Console.WriteLine("You moved left");
                        break;
                    case ConsoleKey.D:
                        playerPosY++;
                        Console.WriteLine("You moved right");
                        break;
                    case ConsoleKey.I:
                        ShowInventory(ref playerInventory);
                        ShowEquipedWeapon(ref playerMainHand);
                        break;
                    case ConsoleKey.M:
                        ShowMap(gameMap);
                        break;
                    case ConsoleKey.E:
                        EquipItem(ref playerInventory, ref playerMainHand);
                        break;
                    case ConsoleKey.Escape:
                        keepGameOpen = false;
                        break;
                    default:
                        Console.WriteLine("Invalid input.");
                        continue;
                }
                Clamp(ref playerPosX, 0, gameMap.GetLength(0) - 1);
                Clamp(ref playerPosY, 0, gameMap.GetLength(1) - 1);
                CheckForValue(ref gameMap, ref playerPosX, ref playerPosY, ref playerInventory, ref playerHealth,CalculateDamage(ref playerMainHand), 120, 25, ref keepGameOpen);
                UpdateMap(ref gameMap, ref playerPosX, ref playerPosY, ref playerValue, ref emptySpaceValue);
            } while (keepGameOpen);
        }
        public static void Clamp<T>(ref T val, T min, T max) where T : IComparable<T>
        {
            if (val.CompareTo(min) < 0) val = min;
            else if (val.CompareTo(max) > 0) val = max;
        }

        public static void UpdateMap(ref int[,] gameMap, ref int playerPosX, ref int playerPosY, ref int playerValue, ref int emptySpaceValue)
        {
            for (int i = 0; i < gameMap.GetLength(0); i++)
            {
                for (int j = 0; j < gameMap.GetLength(1); j++)
                {
                    if (gameMap[i, j] == 1)
                    {
                        gameMap[i, j] = emptySpaceValue;
                        break;
                    }
                }
            }
            gameMap[playerPosX, playerPosY] = playerValue;
        }
        public static void ShowMap(int[,] gameMap)
        {
            for (int i = 0; i < gameMap.GetLength(0); i++)
            {
                for (int j = 0; j < gameMap.GetLength(1); j++)
                {
                    Console.Write(gameMap[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        public static void CheckForValue(ref int[,] gameMap, ref int playerPosX, ref int playerPosY, ref string[] playerInventory
            , ref int playerHealth, int playerDamage, int monsterHealth, int monsterDamage, ref bool keepGameOpen )
        {
            if (gameMap[playerPosX, playerPosY] == 0)
            {
                return;
            }
            else if (gameMap[playerPosX, playerPosY] == 2)
            {
                Console.WriteLine("You picked up an item");
                PickUpItem(ref playerInventory, "Axe");
            }
            else if (gameMap[playerPosX, playerPosY] == 3)
            {
                Console.WriteLine("You encountered a monster");
                FightMechanic(ref playerHealth,ref playerDamage, monsterHealth, monsterDamage, ref keepGameOpen);

            }
        }
        public static void PickUpItem(ref string[] playerInventory, string playerItem)
        {
            for (int i = 0; i < playerInventory.Length; i++)
            {
                if (playerInventory[i] == null)
                {
                    playerInventory[i] = playerItem;
                    return;
                }
                else
                {
                    Console.WriteLine("Your inventory is full");
                }
            }
        }
        public static void EquipItem(ref string[] playerInventory, ref string playerMainHand)
        {
            Console.WriteLine("What item do you wanna equip.");
            ShowInventory(ref playerInventory);
            if (playerMainHand == null)
            {

            }
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            switch (keyInfo.Key)
            {
                case ConsoleKey.D1:
                    playerMainHand = playerInventory[0];
                    Console.WriteLine($"You equiped {playerInventory[0]}");
                    playerInventory[0] = null;
                    break;
                case ConsoleKey.D2:
                    playerMainHand = playerInventory[1];
                    Console.WriteLine($"You equiped {playerInventory[1]}");
                    playerInventory[1] = null;
                    break;
                case ConsoleKey.D3:
                    playerMainHand = playerInventory[2];
                    Console.WriteLine($"You equiped {playerInventory[2]}");
                    playerInventory[2] = null;
                    break;

                case ConsoleKey.D4:
                    playerMainHand = playerInventory[3];
                    Console.WriteLine($"You equiped {playerInventory[3]}");
                    playerInventory[3] = null;
                    break;
                case ConsoleKey.D5:
                    playerMainHand = playerInventory[4];
                    Console.WriteLine($"You equiped {playerInventory[4]}");
                    playerInventory[4] = null;
                    break;
                case ConsoleKey.D6:
                    playerMainHand = playerInventory[5];
                    Console.WriteLine($"You equiped {playerInventory[5]}");
                    playerInventory[5] = null;
                    break;
                case ConsoleKey.D7:
                    playerMainHand = playerInventory[6];
                    Console.WriteLine($"You equiped {playerInventory[6]}");
                    playerInventory[6] = null;
                    break;
                case ConsoleKey.D8:
                    playerMainHand = playerInventory[7];
                    Console.WriteLine($"You equiped {playerInventory[7]}");
                    playerInventory[7] = null;
                    break;
                case ConsoleKey.D9:
                    playerMainHand = playerInventory[8];
                    Console.WriteLine($"You equiped {playerInventory[8]}");
                    playerInventory[8] = null;
                    break;
                default:
                    Console.WriteLine("Invalid input");
                    break;
            }
            if (playerMainHand == null)
            {
                Console.WriteLine("Invalid Input");
                EquipItem(ref playerInventory, ref playerMainHand);
            }
        }
        public static void ShowEquipedWeapon(ref string playerMainHand)
        {
            if (playerMainHand == null)
            {
                playerMainHand = "None";
            }
            Console.WriteLine($"Equiped: {playerMainHand}");
            playerMainHand = null;
        }
        public static void ShowInventory(ref string[] playerInventory)
        {
            Console.WriteLine($"Inventory");
            for (int i = 0; i < playerInventory.Length; i++)
            {
                if (playerInventory[i] == null)
                {
                    Console.WriteLine(i + 1 + ". Empty");
                }
                else
                {
                    Console.WriteLine(i + 1 + ". " + playerInventory[i]);
                }
            }
        }
        public static int CalculateDamage(ref string mainPlayerHand)
        {
            if (mainPlayerHand == null) {
                return 5;
            }
            else if (mainPlayerHand == "Axe") {
                return 12;
            }
            else if (mainPlayerHand == "Rapier") {
                return 10;
            }
            else {
                return 5;
            }
        }
        public static void FightMechanic(ref int playerHealth,ref int playerDamage, int monsterHealth, int monsterDamage, ref bool keepGameOpen)
        {
            int round = 1;  
            while(playerHealth > 0 && monsterHealth > 0)
            {
                if(playerHealth > 0 && monsterHealth > 0)
                {
                    Console.WriteLine($"Round: {round++}");
                    monsterHealth -= playerDamage;
                    Console.WriteLine($"Player attacked the monster\nMonster Health: {monsterHealth}\n");
                }
                if (playerHealth > 0 && monsterHealth > 0)
                {
                    playerHealth -= monsterDamage;
                    Console.WriteLine($"Monster attacked the player\nPlayer Health: {playerHealth}\n");
                }
            }

            if (playerHealth > 0 && monsterHealth <= 0)
            {
                Console.WriteLine("Player defeated the monster");
            }
            else if (playerHealth <= 0)
            {
                Console.WriteLine("The Monster defeated the player.\nYou lost!");
                keepGameOpen = false;
                return;
            }
        }

    }
}