using System;
using System.Collections.Generic;
using System.Text;

namespace Inlamning3.Classes
{
    public class Room1: Room
    {
        public Room1()
        {
            Paths = 1;
            ItemsInRoom.Add(new Bacon());
            ItemsInRoom.Add(new HatPiece1());
            PathFinding.Add(Direction.South, 0);
        }
        public override void Inspection()
        {
            string inspected = "You take a closer look in the room and you find a bush with red berries that look a little bit 'deathy' so you decide to leave them";
            Console.WriteLine(inspected);
        }

    }
}
