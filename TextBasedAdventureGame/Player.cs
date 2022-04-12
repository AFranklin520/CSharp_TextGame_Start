//Anthony Franklin afranklin18@cnm.edu
//TextBasedAdventureGame
//Player.cs

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedAdventureGame
{
    public class Player
    {
        /// <summary>
        /// Represents the Player on the map
        /// </summary>
        #region FIELDS
        private int inventorySize;
        #endregion

        #region PROPERTIES
        public List<IPortable> Inventory { get; set; }
        public MapLocation Location { get; set; }
        public int MaxInventory { get; set; }

        #endregion
        #region CONSTRUCTORS
        public Player(MapLocation location)
        {
            Inventory = new List<IPortable>();
            Location = location;
            inventorySize = 0;
            MaxInventory = 3;
        }
        #endregion
        #region METHODS
        public bool AddInventoryItem(IPortable item) 
        {
            /// <summary>
            /// Calculates current inventory size and adds new item if enough size, else returns false
            /// </summary>

            if (item.ToString() == "Leather Satchel") MaxInventory += 4;
            if (item.ToString() == "Tattered canvas bag") MaxInventory += 3;
            Calc();
            if(inventorySize + item.Size <= MaxInventory)
            {
                Inventory.Add(item);
                return true;
            }
            return false;
        }
        public void RemoveInventoryItem(IPortable item) 
        {/// <summary>
         /// Removes item from inventory if present, subtracts item.Size from inventorySize
         /// </summary>
       
            if(Inventory.Contains(item))
            {
                Inventory.Remove(item);
                inventorySize -= item.Size;
            }
        }
        public void Calc() 
        {
            foreach(var item in Inventory)
            {
                inventorySize += item.Size;
            }
        }
        #endregion
    }
}
