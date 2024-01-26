using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager
{
    internal class Contact
    {
        static void Main(string[] args)
        {
                bool keepAplicationOpen = true; 
                string[,] contactList = new string[10, 3];
                Console.WriteLine("1.New Contact\n2.Display all contacts\n3.Search for contact\n4.Delete contact\n5.Exit");
            do {
                Console.Write($"\nChoose an option:");
                int option = int.Parse(Console.ReadLine());
                if (option == 1)
                {
                    AddNewContact(contactList);  
                }
                else if (option == 2)
                {
                    DisplayAllContact(contactList);
                }
                else if (option == 3)
                {
                    SearchForContact(contactList);
                }
                else if (option == 4)
                {
                    DeleteContact(contactList);
                }
                else if (option == 5)
                {
                    Console.WriteLine("Are you sure you want to exit?");
                    string exitOption = Console.ReadLine();
                    if (exitOption == "yes" || exitOption == "Yes")
                    {
                        keepAplicationOpen = false;
                    }
                    else break;
                }
                else if (option >= 6 ){ Console.WriteLine("Invalid option, choose another."); }
            } while (keepAplicationOpen);
        }
        static void AddNewContact(string[,] contactList)
        {

            int listPlace = 0;
            for (int i = 0; i < contactList.GetLength(0); i++)
            {
                if (contactList[i,0] == null)
                {
                    listPlace = i;
                    break;
                }
            }

            Console.Write("Enter contact detail \nName: ");
            string contactName = Console.ReadLine();
            contactList[listPlace,0] = contactName;

            Console.Write("Phone number: ");
            string contactNumber = Console.ReadLine();
            contactList[listPlace, 1] = contactNumber;

            Console.Write("Email address: ");
            string contactEmail = Console.ReadLine();
            contactList[listPlace, 2] = contactEmail;         
        }
        static void DisplayAllContact(string[,] contacList)
        {
            Console.WriteLine("Name\t\tPhone Number\t\tEmail\t\t");
            for (int i = 0;i < contacList.GetLength(0); i++)
            {
                for(int j = 0; j < contacList.GetLength(1); j++)
                {
                    Console.Write($"{contacList[i,j]} \t\t");
                }
                Console.WriteLine();
            }
        }
        static void SearchForContact(string[,] contactList)
        {
            bool canFindContact = false;
            Console.Write("Enter name to search for:");
            string userSearch = Console.ReadLine();
            Console.WriteLine("Name\t\tPhone Number\t\tEmail address");
            for (int i = 0; i < contactList.GetLength(0); i++)
            {
                if (contactList[i,0] == userSearch)
                {
                    for (int j = 0; j < contactList.GetLength(1);j++)
                    {
                        Console.Write($"{contactList[i,j]}\t\t");
                    }
                        canFindContact = true;
                        break;
                }
            }
            if (!canFindContact)
            {
                Console.WriteLine("We couldnt find your contact.");
            }
        }
        static void DeleteContact(string[,] contactList)
        {
            bool canFindContact = false;
            Console.Write("\nWhat contact do you want to delete: ");
            string userDelete = Console.ReadLine();
            for (int i = 0; i < contactList.GetLength(0); i++)
            {
                if (contactList[i, 0] == userDelete)
                {
                    for (int j = 0; j < contactList.GetLength(1); j++)
                    {
                        contactList[i, j] = null;
                    }
                        canFindContact = true;
                        Console.WriteLine("Contact successfuly deleted.");
                        break;
                }
            }
            if (!canFindContact)
            {
                        Console.WriteLine("We couldnt find your contact.");
            }
        }
    }
}
