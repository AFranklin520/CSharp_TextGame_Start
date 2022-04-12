//Anthony Franklin afranklin18@cnm.edu
//TextBasedAdventureGame
//IHidingPlace.cs

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedAdventureGame
{
    /// <summary>
    /// Represents a HidingPlace interface
    /// </summary>
    public interface IHidingPlace
    {
        #region PROPERTIES
        GameObject HiddenObject { get; set; }
        #endregion

        #region METHODS
        GameObject Search();
        #endregion
    }
}
