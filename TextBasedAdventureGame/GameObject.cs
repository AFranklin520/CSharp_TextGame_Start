//Anthony Franklin afranklin18@cnm.edu
//TextBasedAdventureGame
//GameObject.cs

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedAdventureGame
{
    /// <summary>
    /// Represents an object on the map
    /// </summary>
    public class GameObject
    {
        #region PROPERTIES
        public string Description { get; set; }
        #endregion

        #region CONSTRUCTORS
        public GameObject(string description)
        {
            Description = description;
        }
        #endregion

        #region METHODS

        public override string ToString()
        {
            return Description;
        }
        #endregion
    }
}
