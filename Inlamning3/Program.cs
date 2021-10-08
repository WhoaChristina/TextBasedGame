using System;

namespace Inlamning3.Classes
{
    class Program
    {
        static void Main(string[] args)
        {
            Errors error = new Errors();
            bool exit = false;
            Actions action = new Actions();
            Story story = new Story();
            story.Start();
            PrintOptions(); //skriver ut options en gång i början, upplevde att det var svårt att se "spelet" annars
            while (exit != true && Actions.gameDone != true) 
            {
                string input ="";
                Console.WriteLine("What would you like to do? You can at any time write help for a full commando list: ");
                try
                {
                    input = Console.ReadLine();
                }
                catch (Exception)
                {
                    error.NotValidInput();
                }
                int convertInput = LoopOptions(input); //jag hade redan börjat göra spelet och tänkte att det skulle vara siffer styrt, såg sent att det inte skulle vara det
                switch (convertInput)
                {
                    case -1: error.NotValidInput();
                        break;
                    case 1:
                        action.MoveNorth();
                        break;
                    case 2:
                        action.MoveSouth();
                        break;
                    case 3:
                        action.MoveEast();
                        break;
                    case 4:
                        action.MoveWest();
                        break;
                    case 5:
                        action.Look();
                        break;
                    case 6:
                        action.LoopInventory();
                        break;
                    case 7:
                        action.CombineItems();
                        break;
                    case 8:
                        action.PickUpItemsInRoom();
                        break;
                    case 9:
                        action.DropItem();
                        break;
                    case 10:
                        action.UseItem();
                        break;
                    case 11:
                        action.Inspect();
                        break;
                    case 12:
                        PrintOptions();
                        break;
                    case 13:
                        exit = true;
                        break;
                }
            }  
        }
        public static int LoopOptions(string input)
        {
            input.ToLower();
            switch (input)
            {
                case "move north":
                    return 1;
                case "move south":
                    return 2;
                case "move east":
                    return 3;
                case "move west":
                    return 4;
                case "look":
                    return 5;
                case "loop inventory":
                    return 6;
                case "combine items":
                    return 7;
                case "pick up items in room":
                    return 8;
                case "drop item":
                    return 9;
                case "use item":
                    return 10;
                case "inspect":
                    return 11;
                case "help":
                    return 12;
                case "exit":
                    return 13;
            }
            return -1;
        }
        public static void PrintOptions() 
        {
            Console.WriteLine("move north");
            Console.WriteLine("move south");
            Console.WriteLine("move east");
            Console.WriteLine("move west");
            Console.WriteLine("look");
            Console.WriteLine("loop inventory");
            Console.WriteLine("combine items");
            Console.WriteLine("pick up items in room");
            Console.WriteLine("drop item");
            Console.WriteLine("use item");
            Console.WriteLine("inspect");
            Console.WriteLine("exit");
        }
    }
}
