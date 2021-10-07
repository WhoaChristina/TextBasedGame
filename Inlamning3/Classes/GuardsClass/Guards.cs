using System;
using System.Collections.Generic;
using System.Text;

namespace Inlamning3.Classes
{
    public abstract class Guards
    {
        public string Name { get; set; }
        public bool Guarding { get; set; }
        public abstract bool ValidGift(Items input);
    }
}
