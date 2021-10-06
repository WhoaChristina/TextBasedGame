using System;
using System.Collections.Generic;
using System.Text;

namespace Inlamning3.Classes
{
    public class Actions
    {

        List<Room> rooms = new List<Room>();
        int currentRoom = 0;
        Errors error = new Errors();
        Player player = new Player();
        public int ChosenAction { get; set; }
        public Actions()
        {
            rooms.Add(new StartRoom());
            rooms.Add(new Room1());
            rooms.Add(new Room2());
            rooms.Add(new EndRoom());
        }
        public void MoveNorth ()
        {
            if (rooms[currentRoom].PathFinding.ContainsKey(Room.Direction.North))
            {
                int room = rooms[currentRoom].PathFinding[Room.Direction.North];
                currentRoom = room;
            }
            else
            {
                error.NotValidMove();
            }
        }
        public void MoveSouth()
        {
            if (rooms[currentRoom].PathFinding.ContainsKey(Room.Direction.South))
            {
                int room = rooms[currentRoom].PathFinding[Room.Direction.South];
                currentRoom = room;
            }
            else
            {
                error.NotValidMove();
            }
        }
        public void MoveEast()
        {
            if (rooms[currentRoom].PathFinding.ContainsKey(Room.Direction.East))
            {
                int room = rooms[currentRoom].PathFinding[Room.Direction.East];
                currentRoom = room;
            }
            else
            {
                error.NotValidMove();
            }
        }
        public void MoveWest()
        {
            if (rooms[currentRoom].PathFinding.ContainsKey(Room.Direction.West))
            {
                int room = rooms[currentRoom].PathFinding[Room.Direction.West];
                currentRoom = room;
            }
            else
            {
                error.NotValidMove();
            }
        }
        public void Look()
        {
            List<Items> temp = rooms[currentRoom].ItemsInRoom;
            Console.WriteLine("These are the paths in this section: " + rooms[currentRoom].PathFinding.Keys);
            Console.WriteLine("These are the items in this section: ");
            foreach (var item in temp)
            {
                Console.WriteLine(item);
            }
        }
        public void LoopInventory()
        {
            InventoryLoop();
        }
        public void CombineItems()
        {
            
            int item1;
            int item2;
            Console.WriteLine("Which items would you like to combine? enter one number at a time");
            LoopInventory();
            try
            {
                item1 = int.Parse(Console.ReadLine());
                item2 = int.Parse(Console.ReadLine());
                if (player.inventory[item1].CanCombine && player.inventory[item2].CanCombine && player.inventory[item1].Combindable(player.inventory[item2]))
                {
                    Items newItem = player.inventory[item1].GenerateCombinedItem();
                    player.inventory.Add(newItem);
                    int big = Math.Max(item1, item2);
                    int small = Math.Min(item1, item2);
                    player.inventory.RemoveAt(big);
                    player.inventory.RemoveAt(small);
                }
                else
                {
                    error.NotValidCombination();
                }
            }
            catch (Exception)
            {

                error.NotValidInput();
            }
        }
        public void PickUpItemsInRoom()
        {
            List<Items> temp = rooms[currentRoom].ItemsToPickUp();
            foreach (var item in temp)
            {
                player.inventory.Add(item);
            }
            rooms[currentRoom].ItemsInRoom.Clear();
            
        }
        public void DropItem()
        {
            Console.WriteLine("Which item would you like to drop?(input number)");
            InventoryLoop();
            int input = int.Parse(Console.ReadLine());
            rooms[currentRoom].ItemsInRoom.Add(player.inventory[input]);
            player.inventory.RemoveAt(input);

            
        }
        public void UseItem()
        {
            if (rooms[currentRoom].GuardInRoom.Count > 0)
            {
                Console.WriteLine("Which item would you like to use on the guard?");
                try
                {
                    int input = int.Parse(Console.ReadLine());
                    foreach (var guard in rooms[currentRoom].GuardInRoom)
                    {
                        if (guard.ValidGift(player.inventory[input]))
                        {
                            Console.WriteLine("*The guard was happy with your gift and walked away*");
                            rooms[currentRoom].GuardInRoom.Remove(guard);
                            player.inventory.RemoveAt(input);
                        }
                        else
                        {
                            error.NotValidGift();
                        }
                    }
                }
                catch (Exception)
                {
                    error.NotValidInput();
                }
            }
            else
            {
                Console.WriteLine("*There is no one to give anything to*");
            }
        }
        public void Inspect()
        {
            rooms[currentRoom].Inspection();
        }
        
        public void InventoryLoop()
        {
            foreach (var item in player.inventory)
            {
                Console.WriteLine(item);
            }
        }
        

    }
}
