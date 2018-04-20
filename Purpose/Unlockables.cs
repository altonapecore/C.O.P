using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Purpose
{
    //Class handles unloackable such as hats for enemies
    //Not game changing, pure look and they stay unlocked
    class Unlockables
    {
        //Fields
        private int unlockPoints; //Counts the amount of point they have to unlock
        private bool unlocked; //Tells whther or not the unlockable has been unlocked
        private bool equipped; //Tells whether it is unlocked or not
        private int cost; //Accounts for the cost of the unlockable

        //Properties
        private int UnlockPoints
        {
            get { return unlockPoints; }
            set { unlockPoints = value; }
        }

        private bool Unlocked
        {
            get { return unlocked; }
            set { unlocked = value; }
        }
    }
}
