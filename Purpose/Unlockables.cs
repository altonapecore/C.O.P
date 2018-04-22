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
        private List<Unlockables> items; //List of all the unlockables

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
        
        private bool Equipped
        {
            get { return equipped; }
            set { equipped = value; }
        }

        private int Cost { get { return cost; } }
        
        //Constructor
        public Unlockables()
        {
            unlockPoints = 0;
            items = new List<Unlockables>();
        }

        //Parametrized Constructor
        //Used for each indiviual item 
        public Unlockables(int cost)
        {
            this.cost = cost;
            equipped = false;
            unlocked = false;
        }

        //Mehtod to buy an item
        public void Buy(Unlockables buyable)
        {
            //Checks if the item isn't already unlocked
            if (buyable.Unlocked == false)
            {
                //Checks if the user has enough unlock points
                //to buy the item
                if (unlockPoints > buyable.Cost) 
                {
                    buyable.Unlocked = true; //Sets the item as unlocked.
                    UnlockPoints -= buyable.Cost; //Takes the cost and subtracts from users current unlock points 
                }
            }
        }


    }
}
