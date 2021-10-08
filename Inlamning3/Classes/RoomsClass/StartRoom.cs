using System;
using System.Collections.Generic;
using System.Text;

namespace Inlamning3.Classes
{
    public class StartRoom: Room
    {
        public StartRoom()
        {
            Paths = 2;
            ItemsInRoom.Add(new Carrot());
            ItemsInRoom.Add(new Apple());
            PathFinding.Add(Direction.North, 1);
            PathFinding.Add(Direction.East, 2); 
        }
    }
}
