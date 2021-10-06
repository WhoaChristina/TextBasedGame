using System;
using System.Collections.Generic;
using System.Text;

namespace Inlamning3.Classes
{
    public class HatPiece2: Items
    {
        public HatPiece2()
        {
            CanCombine = true;
        }
        public override bool Combindable(Items input)
        {
            return input is HatPiece1;
        }
        public override Items GenerateCombinedItem()
        {
            return new Hat();
        }
    }
}
