using System;
using System.Collections.Generic;
using System.Text;

namespace Inlamning3.Classes
{
    public class Player
    {
        public string Name { get; set; }
        private List<Items> Inventory = new List<Items>();

        public List<Items> inventory
        {
            get { return Inventory; }
            set { Inventory = value; }
        }
    }
}
