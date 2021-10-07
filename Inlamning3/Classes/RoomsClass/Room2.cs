using System;
using System.Collections.Generic;
using System.Text;

namespace Inlamning3.Classes
{
    public class Room2: Room
    {
        public Room2()
        {
            Paths = 2;
            PathFinding.Add(Direction.West, 0);
            PathFinding.Add(Direction.North, 3);
            ItemsInRoom.Add(new HatPiece2());
            GuardInRoom.Add(new PigGuard());
        }
    }
}
