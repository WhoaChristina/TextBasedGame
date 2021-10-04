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
                NotValidMove();
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
                NotValidMove();
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
                NotValidMove();
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
                NotValidMove();
            }
        }
        public void Look()
        {

            //kollar runt i "rummet"
        }
        public void ChooseFromInventory()
        {
            foreach (var item in inventory)
            {
                Console.WriteLine(item);
            }
            //visar inventory och kan välja items, GLÖM INTE EXIT ifall man inte vill "ta" något
        }
        public void CombineItems ()
        {
            //kombinera items
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
            foreach (var item in inventory)
            {
                Console.WriteLine(item);
            }
            int input = int.Parse(Console.ReadLine());
            rooms[currentRoom].ItemsInRoom.Add(inventory[input]);
            inventory.RemoveAt(input);

            
        }
        public void UseChosenItem()
        {
            //använd på guards
        }
        public void Inspect()
        {
            //mer detaljerad "look"
        }
        public void NotValidMove()
        {
            Console.WriteLine("*you tried to walk into the woods without a path, unfortunately the forrest is protected with magic which won't allow you to do this*");
        }

    }
}
