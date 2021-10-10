using System;
using System.Collections.Generic;
using System.Text;

namespace Inlamning3.Classes
{
    public abstract class Room
    {
        public int Paths { get; set; }
        private Dictionary<Direction, int> pathFinding = new Dictionary<Direction, int>(); //för att hålla kolla på vilket rum man är i
        private List<Items> itemsInRoom = new List<Items>();
        private List<Guards> guardsInRoom = new List<Guards>();
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
        public List<Guards> GuardInRoom
        {
            get { return guardsInRoom; }
            set { guardsInRoom = value; }
        }
        public List<Items> ItemsToPickUp() 
        {
            return itemsInRoom;
        }
        public virtual void Inspection () //defult inspection, denna kan overridas med andra saker i ärvande klasser
        {
            string inspection = "*There is nothing to inspect*";
            Console.WriteLine(inspection);
        }
        public enum Direction 
        {
            North = 1,
            South = 2,
            East = 3,
            West = 4
        }
        public virtual void EndRoomStory(List<Items> inventory)
        {

        }
    }
}
