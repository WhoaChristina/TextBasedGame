using System;
using System.Collections.Generic;
using System.Text;

namespace Inlamning3.Classes
{ 
    public class EndRoom: Room
    {
        public EndRoom()
        {
            Paths = 1;
            PathFinding.Add(Direction.South, 2);
        }

    }
}
