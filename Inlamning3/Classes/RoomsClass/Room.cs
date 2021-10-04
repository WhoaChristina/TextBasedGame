﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Inlamning3.Classes
{
    public abstract class Room
    {
        public int Paths { get; set; }
        private Dictionary<Direction, int> pathFinding = new Dictionary<Direction, int>();
        private List<Items> itemsInRoom = new List<Items>();
        public List<Items> ItemsInRoom
        {
            get { return itemsInRoom; }
            set { itemsInRoom = value; }
        }
        public Dictionary<Direction, int> PathFinding
        {
            get { return pathFinding; }
            set { pathFinding = value; }
        }
        public void PrintPaths()
        {
            foreach (var path in pathFinding.Keys)
            {
                Console.WriteLine(path);
            }
        }
        public List<Items> ItemsToPickUp()
        {
            return itemsInRoom;
        }
        public void ItemsDropped()
        {
            //lägg till i itemsInRoom
        }
        public virtual void Inspection ()
        {
            string inspection = "There is nothing to inspect";
            Console.WriteLine(inspection);
        }
        public enum Direction
        {
            North = 1,
            South = 2,
            East = 3,
            West = 4
        }

    }
}