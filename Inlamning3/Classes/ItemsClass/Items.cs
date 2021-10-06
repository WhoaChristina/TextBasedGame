using System;
using System.Collections.Generic;
using System.Text;

namespace Inlamning3.Classes
{
    public abstract class Items
    {
        public bool CanCombine { get; set; }

        public virtual bool Combindable(Items input)
        {
            return false;
        }
        public virtual Items GenerateCombinedItem()
        {
            return null;
        }

    }
}
