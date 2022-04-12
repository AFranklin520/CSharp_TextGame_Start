//Anthony Franklin afranklin18@cnm.edu
//TextBasedAdventureGame
//InventoryItem.cs

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedAdventureGame
{
    public class InventoryItem : GameObject, IPortable
    {
        #region CONSTRUCTORS
        public InventoryItem(string description) : base(description)
        {
            Size = 0;
        }
        #endregion

        #region METHODS
        public int Size { get; set; }
        #endregion
    }
}
