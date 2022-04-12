//Anthony Franklin afranklin18@cnm.edu
//TextBasedAdventureGame
//PortableHidingPlace.cs

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedAdventureGame
{
    public class PortableHidingPlace : GameObject, IPortable, IHidingPlace
    {
        /// <summary>
        /// Represents a PortableHidingPlace
        /// </summary>
        ///
        #region FIELDS
        private GameObject item;
        #endregion

        #region PROPERTIES
        /// <summary>
        /// Represents a hidden inventory item
        /// </summary>
        public GameObject HiddenObject
        { get { return item; } 
          set { item = value; }
        }

        /// <summary>
        /// Represents how many slots an inventory slots a given item requires
        /// </summary>
        public int Size { get; set; }
        #endregion

        #region CONSTRUCTORS
        public PortableHidingPlace(string description) : base(description)
        {
            HiddenObject = new GameObject(description);
            Size = 0;
        }
        #endregion

        #region METHODS
        /// <summary>
        /// Returns HiddenObject; HiddenObject = null;
        /// </summary>
        public GameObject Search()
        {
            GameObject temp = HiddenObject;
            HiddenObject = null;
            return temp;
        }
        #endregion
    }
}
