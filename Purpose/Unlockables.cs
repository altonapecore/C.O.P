using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace Purpose
{
    //Class handles unloackable such as hats for enemies
    //Not game changing, pure look and they stay unlocked
     public class Unlockables
    {
        //Fields
        private int unlockPoints; //Counts the amount of point they have to unlock
        private bool unlocked; //Tells whther or not the unlockable has been unlocked
        private bool equipped; //Tells whether it is unlocked or not
        private int cost; //Accounts for the cost of the unlockable
        private Texture2D texture; //Holds the texture for the item
        private TextureManager textureManager;
        private Dictionary<string, Unlockables> itemsDictionary; //Holds all unlockables makes easier to search by name
        private List<Unlockables> itemsList;

        //Items to be unlocked
        private Unlockables fez;

        //Properties
        public int UnlockPoints
        {
            get { return unlockPoints; }
            set { unlockPoints = value; }
        }

        public bool Unlocked
        {
            get { return unlocked; }
            set { unlocked = value; }
        }
        
        public bool Equipped
        {
            get { return equipped; }
            set { equipped = value; }
        }

        public Dictionary<string, Unlockables> ItemsDictionary
        {
            get { return itemsDictionary; }
            set { itemsDictionary = value; }
        }

        public List<Unlockables> ItemsList
        {
            get { return itemsList; }
            set { itemsList = value; }
        }
        
        public Texture2D Texture
        {
            get { return texture; }
            set { texture = value; }
        }
        public TextureManager TextureManager { get { return textureManager; } }
        public Unlockables Fez { get { return fez; } }
        public int Cost { get { return cost; } }


        
        //Constructor
        //Starts the points at 0
        //Has textureManager to load in textures for the items
        //And loads with it each unlockable (also adds each unloackable to list)
        public Unlockables(TextureManager textureManager)
        {
            unlockPoints = 0;
            this.textureManager = textureManager;
            itemsDictionary = new Dictionary<string, Unlockables>();
            itemsList = new List<Unlockables>();

            fez = new Unlockables(5, textureManager.FezRangedEnemy);
            itemsDictionary.Add("Fez", fez);
            itemsList.Add(fez);
        }

        //Parametrized Constructor
        //Used for each indiviual item 
        public Unlockables(int cost, Texture2D texture)
        {
            this.cost = cost;
            equipped = false;
            unlocked = false;
            this.texture = texture;
        }

        //Mehtod to buy an item
        public void Buy(Unlockables item)
        {
            //Checks if the item isn't already unlocked
            if (item.Unlocked == false)
            {
                //Checks if the user has enough unlock points
                //to buy the item
                if (unlockPoints > item.Cost) 
                {
                    item.Unlocked = true; //Sets the item as unlocked.
                    UnlockPoints -= item.Cost; //Takes the cost and subtracts from users current unlock points 
                }
            }
        }

        //Method to equip unlocked items
        public void Equip(Unlockables item)
        {
            //Checks that the item is unlocked before equipping
            if (item.Unlocked == true)
            {
                //Loops through all the items
                //Sets all unlockables equip status as false
                for(int i = 0; i < itemsList.Count; i++)
                {
                    itemsList[i].Equipped = false;
                }

                item.Equipped = true; //Sets the item wanted to be equipped as true 
            }
        }

        //MEthod used to unequip items
        public void Unequip(Unlockables item)
        {
            //Checks to see if its unlocked
            if(item.Unlocked == true)
            {
                item.Equipped = false; //Sets the item as unequipped
            }
        }
     }
}
