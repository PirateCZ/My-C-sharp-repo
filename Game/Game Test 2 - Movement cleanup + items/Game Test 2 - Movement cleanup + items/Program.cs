using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Game_Test_2___Movement_cleanup___items
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Sup niggers this is ma game hope u enjoy :*");

            int[,] gameMap = new int[25, 25];
            string[] playerInventory = new string[10]; 
            int emptySpaceValue = 0;
            int playerValue = 1;
            int itemValue = 2;
            int playerPosX = 13;
            int playerPosY = 13;
            bool keepGameOpen = true;
            gameMap[14, 14] = itemValue;
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
                        break;
                    case ConsoleKey.M:
                        ShowMap(gameMap);
                        break;
                    case ConsoleKey.Escape:
                        keepGameOpen = false;
                        break;
                    default:
                        Console.WriteLine("Invalid input.");
                        continue;
                }
                Clamp(ref playerPosX, 0, gameMap.GetLength(0)-1);
                Clamp(ref playerPosY, 0, gameMap.GetLength(1)-1);
                CheckForValue(ref gameMap,ref playerPosX,ref playerPosY,ref playerInventory);
                UpdateMap(ref gameMap, ref playerPosX, ref playerPosY, ref playerValue, ref emptySpaceValue);
                //ShowMap(gameMap);
            } while (keepGameOpen);
        }
        public static void Clamp<T>(ref T val, T min, T max) where T : IComparable<T>
        {
            if (val.CompareTo(min) < 0) val = min;
            else if (val.CompareTo(max) > 0) val = max;
        }

        public static void UpdateMap(ref int[,] gameMap, ref int playerPosX,ref int playerPosY, ref int playerValue,ref int emptySpaceValue)
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
            //lukasovo insane straty pro vypisovani mapy na jedno misto
            //ve finalnim projektu nevyuzito
            for (int i = 0; i < gameMap.GetLength(0); i++)
            {
                String line = "";
                for (int j = 0; j < gameMap.GetLength(1); j++)
                {
                    line += gameMap[i, j] + " ";
                }
                Console.SetCursorPosition(0, i);
                Console.WriteLine(line);
            }
        }
        public static void CheckForValue(ref int[,] gameMap, ref int playerPosX, ref int playerPosY, ref string[] playerInventory)
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
        }
        //items system
        public static void PickUpItem(ref string[] playerInventory, string item)
        {
            for (int i = 0; i < playerInventory.Length; i++)
            {
                if (playerInventory[i] == null)
                {
                    playerInventory[i] = item;
                    return;
                }
                else
                {
                    Console.WriteLine("Your inventory is full");
                }
            }
        }
        public static void ShowInventory(ref string[] playerInventory)
        {
            Console.WriteLine("Inventory");
            for (int i = 0;i < playerInventory.Length; i++)
            {
                if (playerInventory[i] == null)
                {
                    break;
                }
                else
                {
                    Console.WriteLine(playerInventory[i]);
                }
            }
        }
    }
}
