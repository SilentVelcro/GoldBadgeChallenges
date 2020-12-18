using BadgeRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadgeConsole
{
    class ProgramUI
    {
        private Badge_Repo _badgeRepo = new Badge_Repo();

        public void Run()
        {
            SeeList();
            Menu();
        }
        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {

                Console.WriteLine("Hello Security Admin, What would you like to do?\n" +
                    "1. Add a badge\n" +
                    "2. Edit a badge.\n" +
                    "3. List all Badges\n" +
                    "4. Exit");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        AddABadge();
                        break;
                    case "2":
                        EditABadge();
                        break;
                    case "3":
                        ListAllBadges();
                        break;
                    case "4":
                        Console.WriteLine("Goodbye!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number.");
                        break;
                }
                Console.WriteLine("Please press any key to continue.");
                Console.ReadKey();
                Console.Clear();
            }
        }
        //1 - add
        public void AddABadge()
        {
            Console.Clear();

            Badge entry = new Badge();
            entry.DoorAccess = new List<string>(); 

            Console.WriteLine("What is the number on the badge?");
            entry.BadgeId = int.Parse(Console.ReadLine());

            Console.WriteLine("List a door that it needs access to:");
            string doorAccess = (Console.ReadLine());

            int prevCount = entry.DoorAccess.Count;
            entry.DoorAccess.Add(doorAccess);

            int afterCount = entry.DoorAccess.Count;

            if (afterCount > prevCount)
            {
                Console.WriteLine("door successfully added!");
            }
            else
            {
                Console.WriteLine("could not add door.");
            }

            Console.WriteLine("Any other doors(y/n)?");
            string answer = Console.ReadLine().ToLower();
            while (answer == "y")
            {
                Console.WriteLine("List a door that it needs access to:");
                entry.DoorAccess.Add(Console.ReadLine());

                Console.WriteLine("Any other doors(y/n)?");
                answer = Console.ReadLine().ToLower();
            }
     
            _badgeRepo.AddBadge(entry);
            Console.Clear();
            Menu();
        }
        //2 - edit
        public void EditABadge()
        {
            Badge entry = new Badge();
            entry.DoorAccess = new List<string>();

            Console.Clear();

            Console.WriteLine("Enter the badge number you would like to edit: ");
            entry.BadgeId = int.Parse(Console.ReadLine());

            Console.WriteLine("What would you like to do with {entry.BadgeID}\n" +
                $"1. Add a door\n" +
                $"2. Remove a door\n" +
                $"3. Return to main menu\n");

            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    AddDoor(entry.BadgeId);
                    break;
                case "2":
                    RemoveDoor(entry.BadgeId);
                    break;
                case "3":
                    Menu();
                    break;
            }
        }
        public void AddDoor(int badgeId)
        {
            Console.WriteLine("Enter a door to add:");
            string door = Console.ReadLine();
            _badgeRepo.GrantAccess(badgeId, door);

            Console.WriteLine("Access has been added!");
            Console.ReadKey();
        }

        public void RemoveDoor(int badgeid)
        {
            Console.WriteLine("Enter a door that you would like to remove:");
            string door = Console.ReadLine();
            _badgeRepo.RemoveAccess(badgeid, door);

            Console.WriteLine("Access Removed!");
            Console.ReadKey();
        }
        //3 - list
        public void ListAllBadges()
        {
            Dictionary<int, List<string>> BadgeList = _badgeRepo.GetList();

            foreach (KeyValuePair<int, List<string>> badge in BadgeList)
            {
                Console.WriteLine($"Badge: {badge.Key}");

                foreach (string door in badge.Value)
                {
                    Console.WriteLine(door);
                }
            }
            Console.WriteLine("\nPress any key to return to the menu...");
            Console.ReadLine();
        }
        public void SeeList()
        {
            Badge badgeOne  = new Badge(1, new List<string> { "A1" });
            Badge badgeTwo = new Badge(2,new List<string> { "A1", "A2" });
            _badgeRepo.AddBadge(badgeOne);
            _badgeRepo.AddBadge(badgeTwo);
        }
    }
}
