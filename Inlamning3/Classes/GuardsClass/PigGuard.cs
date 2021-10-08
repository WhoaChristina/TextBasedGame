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
        }
        public override bool ValidGift(Items input) 
        {
            if (input is Apple)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
