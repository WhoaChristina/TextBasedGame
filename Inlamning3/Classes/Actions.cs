using System;
using System.Collections.Generic;
using System.Text;

namespace Inlamning3.Classes
{
    public class Actions
    {

        List<Room> rooms = new List<Room>();
        List<Items> inventory = new List<Items>();
        int currentRoom = 0;
        Errors error = new Errors();
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
        public void ChooseFromInventory()
        {
            Console.WriteLine("Which item would you like to have?");
            InventoryLoop();
            //Switch case för item? + en exit knapp
        }
        public void CombineItems ()
        {
            //kolla om items går att kombinera
        }
        public void PickUpItemsInRoom()
        {
            List<Items> temp = rooms[currentRoom].ItemsToPickUp();
            foreach (var item in temp)
            {
                inventory.Add(item);
            }
            rooms[currentRoom].ItemsInRoom.Clear();
            
        }
        public void DropItem()
        {
            Console.WriteLine("Which item would you like to drop?(input number)");
            InventoryLoop();
            int input = int.Parse(Console.ReadLine());
            rooms[currentRoom].ItemsInRoom.Add(inventory[input]);
            inventory.RemoveAt(input);

            
        }
        public void UseItem()
        {
            //använd på guards
        }
        public void Inspect()
        {
            //mer detaljerad "look"
        }
        
        public void InventoryLoop()
        {
            foreach (var item in inventory)
            {
                Console.WriteLine(item);
            }
        }
        

    }
}
