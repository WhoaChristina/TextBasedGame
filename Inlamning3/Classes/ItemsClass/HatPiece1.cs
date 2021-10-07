using System;
using System.Collections.Generic;
using System.Text;

namespace Inlamning3.Classes
{
    public class HatPiece1: Items
    {
        public HatPiece1()
        {
            Name = "Frisbee with no middle";
            CanCombine = true;
        }
        public override bool Combindable(Items input)
        {
            return input is HatPiece2;
        }
        public override Items GenerateCombinedItem()
        {
            return new Hat();
        }
    }
}
