using System;
using System.Collections.Generic;
using System.Text;

namespace Inlamning3.Classes
{
    public abstract class Guards
    {
        public string Name { get; set; }
        public bool Guarding { get; set; }
        private List<Items> guardItems = new List<Items>();
        public List<Items> GuardItems
        {
            get { return guardItems; }
            set { guardItems = value; }
        }

    }
}
