//Anthony Franklin afranklin18@cnm.edu
//TextBasedAdventureGame
//IPortable.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedAdventureGame
{
    public interface IPortable
    {
        /// <summary>
        /// Represents a Portable interface
        /// </summary>
        #region PROPERTIES
        /// <summary>
        /// Represents how many slots an inventory slots a given item requires
        /// </summary>
        int Size { get; set; }
        #endregion
    }
}
