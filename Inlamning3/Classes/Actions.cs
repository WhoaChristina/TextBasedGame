using System;
using System.Collections.Generic;
using System.Text;

namespace Inlamning3.Classes
{
    public class Actions
    {
        public static bool gameDone = false;
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
            if (rooms[currentRoom].PathFinding.ContainsKey(Room.Direction.North)) //if kollar om det faktiskt finns en path åt det hållet
            {
                int room = rooms[currentRoom].PathFinding[Room.Direction.North]; //denna och nästa är för att hålla koll på vart man är
                currentRoom = room;
                Console.WriteLine(PlayerMoved()); // meddelande så spelaren vet att de flyttat
                rooms[currentRoom].EndRoomStory(player.inventory); //om spelare är i end room kommer denna kallas
            }
            else //felmeddelande
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
                Console.WriteLine(PlayerMoved());
                rooms[currentRoom].EndRoomStory(player.inventory);
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
                Console.WriteLine(PlayerMoved());
                rooms[currentRoom].EndRoomStory(player.inventory);
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
                Console.WriteLine(PlayerMoved());
                rooms[currentRoom].EndRoomStory(player.inventory);
            }
            else
            {
                error.NotValidMove();
            }
        }
        public void Look() //skriver ut items i rummet + paths och om det finns en guard så guarden också
        {
            List<Items> temp = rooms[currentRoom].ItemsInRoom;
            Console.WriteLine("These are the paths in this section: " );
            foreach (var path in rooms[currentRoom].PathFinding.Keys)
            {
                Console.WriteLine(path.ToString());
            }
            Console.WriteLine("These are the items in this section: ");
            foreach (var item in temp)
            {
                Console.WriteLine(item.Name);
            }
            if (rooms[currentRoom].GuardInRoom.Count > 0)
            {
                Console.WriteLine("These are the guards in the room: ");
                foreach (var guard in rooms[currentRoom].GuardInRoom)
                {
                    Console.WriteLine(guard.Name);
                }
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
            Console.WriteLine("Which items would you like to combine? Enter the number of the item, one at a time");
            LoopInventory();
            try //siffra ska inputtas, behöver try catch ifall man försöker inputta något annat
            {
                item1 = int.Parse(Console.ReadLine());
                item2 = int.Parse(Console.ReadLine());
                //Nästa rad, kollar om items går att kombineras, om det går så kollar den om de kan kombineras med varandra.
                if (player.inventory[item1].CanCombine && player.inventory[item2].CanCombine && player.inventory[item1].Combindable(player.inventory[item2])) 
                {
                    Items newItem = player.inventory[item1].GenerateCombinedItem(); //lägger till det nya itemet i inventory
                    player.inventory.Add(newItem);
                    int big = Math.Max(item1, item2); //tar bort de två som kombinerats
                    int small = Math.Min(item1, item2);
                    player.inventory.RemoveAt(big);
                    player.inventory.RemoveAt(small);
                    Console.WriteLine("You combined the items and got a: " + newItem.Name); 
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
            if (rooms[currentRoom].ItemsInRoom.Count > 0)
            {
                List<Items> temp = rooms[currentRoom].ItemsToPickUp();
                foreach (var item in temp)
                {
                    player.inventory.Add(item);
                }
                rooms[currentRoom].ItemsInRoom.Clear();
            }
            else
            {
                Console.WriteLine("*Oops, no items to pick up in this room*");
            }
        }
        public void DropItem()
        {
            try //input är siffra, så precis som innan används den ifall någon försöker inputta något annat.
            {
                Console.WriteLine("Which item would you like to drop? enter number");
                InventoryLoop();
                int input = int.Parse(Console.ReadLine());
                rooms[currentRoom].ItemsInRoom.Add(player.inventory[input]);
                player.inventory.RemoveAt(input);
            }
            catch (Exception)
            {
                error.NotValidInput();
            }

        }
        public void UseItem()
        {
            if (rooms[currentRoom].GuardInRoom.Count > 0) //use item går endast om det finns en guard i rummet, annars retunerar else.
            {
                Console.WriteLine("Which item would you like to use on the guard? Enter number");
                InventoryLoop();
                try
                {
                    int input = int.Parse(Console.ReadLine());
                    foreach (var guard in rooms[currentRoom].GuardInRoom)
                    {
                        if (guard.ValidGift(player.inventory[input])) //kollar så att itemet använt är valid
                        {
                            Console.WriteLine("*The guard was happy with your gift and walked away*"); 
                            rooms[currentRoom].GuardInRoom.Remove(guard); 
                            player.inventory.RemoveAt(input);
                            break;
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
            rooms[currentRoom].Inspection(); //denna ser olika ut i rummen. metoden som kunde overridas
        }
        public void InventoryLoop() //metod för att loopa inventory med siffra
        {

            for (int i = 0; i < player.inventory.Count; i++)
            {
                Items item = player.inventory[i];
                Console.WriteLine(i + " " + item.Name);
            }
        }
        public string PlayerMoved() //för att tydliggöra att spelaren har "bytt plats"
        {
            string moved = "You took the chosen path";
            return moved;
        }
    }
}
