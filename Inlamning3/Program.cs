using System;

namespace Inlamning3.Classes
{
    class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;
            Actions action = new Actions();
            Story story = new Story();
            story.Start();

            while (exit != true)
            {
                Console.WriteLine("What would you like to do? Input a number: ");
                int input = int.Parse(Console.ReadLine());
                switch (input)
                {
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
                        action.ChooseFromInventory();
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
                        exit = true;
                        break;

                }
            }
            
        }
    }
}
