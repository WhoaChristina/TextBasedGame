using System;
using System.Collections.Generic;
using System.Text;

namespace Inlamning3.Classes
{
    public abstract class Items
    {
        public string Name { get; set; }
        public bool CanCombine { get; set; }

        public virtual bool Combindable(Items input) //metod för att kolla itemet kan combineras med
        {
            return false;
        }
        public virtual Items GenerateCombinedItem() //retunerar det "nya" itemet, alltså det man får av att kombinera itemsen
        {
            return null;
        }
    }
}
