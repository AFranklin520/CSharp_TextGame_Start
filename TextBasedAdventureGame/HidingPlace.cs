//Anthony Franklin afranklin18@cnm.edu
//TextBasedAdventureGame
//HidingPlace.cs

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedAdventureGame
{
    public class HidingPlace : GameObject, IHidingPlace
    {
        /// <summary>
        /// Represents a HidingPlace on the map
        /// </summary>
        #region FIELDS
        private GameObject hiddenObject;
        #endregion

        #region PROPERTIES
        public GameObject HiddenObject
        {
            get { return hiddenObject; }
            set { hiddenObject = value; }
        }
        #endregion

        #region CONSTRUCTORS

        public HidingPlace(string description) : base(description)
        {
            HiddenObject = new GameObject(description);
        }

        #endregion

        #region METHODS
        public GameObject Search()
        {
            if(HiddenObject != null)
            {
                GameObject temp = HiddenObject;
                HiddenObject = null;
                return temp;
            }
            else return null;
        }
        #endregion
    }
}
