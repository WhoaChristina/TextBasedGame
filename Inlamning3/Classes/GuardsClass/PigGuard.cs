using System;
using System.Collections.Generic;
using System.Text;

namespace Inlamning3.Classes
{
    public class PigGuard: Guards
    {
        public PigGuard()
        {
            Name = "oink";
            Guarding = true;
            GuardItems.Add(new HatPiece2());
        }
    }
}
