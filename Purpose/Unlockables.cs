using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using System.IO;

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
        private Texture2D rangeTexture; //Holds the texture for the item
        private Texture2D rightEnemyWalk1;
        private Texture2D rightEnemyWalk2;
        private Texture2D rightEnemyWalk3;
        private Texture2D leftEnemyWalk1;
        private Texture2D leftEnemyWalk2;
        private Texture2D leftEnemyWalk3;
        private TextureManager textureManager;
        private Dictionary<string, Unlockables> itemsDictionary; //Holds all unlockables makes easier to search by name
        private List<Unlockables> itemsList;

        //Items to be unlocked
        private Unlockables fez;
        private Unlockables ushanka;
        private Unlockables beret;
        private Unlockables cowboy;
        private Unlockables sombrero;

        //stream Writer to save Unlockable info
        private StreamWriter output;

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
        
        public Texture2D RangeTexture
        {
            get { return rangeTexture; }
            set { rangeTexture = value; }
        }

        public Texture2D RightEnemyWalk1
        {
            get { return rightEnemyWalk1; }
            set { rightEnemyWalk1 = value; }
        }

        public Texture2D RightEnemyWalk2
        {
            get { return rightEnemyWalk2; }
            set { rightEnemyWalk2 = value; }
        }

        public Texture2D RightEnemyWalk3
        {
            get { return rightEnemyWalk3; }
            set { rightEnemyWalk3 = value; }
        }

        public Texture2D LeftEnemyWalk1
        {
            get { return leftEnemyWalk1; }
            set { leftEnemyWalk1 = value; }
        }

        public Texture2D LeftEnemyWalk2
        {
            get { return leftEnemyWalk2; }
            set { leftEnemyWalk2 = value; }
        }

        public Texture2D LeftEnemyWalk3
        {
            get { return leftEnemyWalk3; }
            set { leftEnemyWalk3 = value; }
        }


        public TextureManager TextureManager { get { return textureManager; } }
        public Unlockables Fez { get { return fez; } }
        public Unlockables Ushanka { get { return ushanka; } }
        public Unlockables Beret { get { return beret; } }
        public Unlockables Cowboy { get { return cowboy; } }
        public Unlockables Sombrero { get { return sombrero; } }
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

            output = new StreamWriter("unlockablesave.txt");

            //Gives the fez unlockable all its textures and cost
            //And adds it to the dictionary and list
            fez = new Unlockables(5, textureManager.FezRangedEnemy, textureManager.RightFezMelee1, textureManager.RightFezMelee2, textureManager.RightFezMelee3,
                textureManager.LeftFezMelee1, textureManager.LeftFezMelee2, textureManager.LeftFezMelee3);
            itemsDictionary.Add("Fez", fez);
            itemsList.Add(fez);

            ushanka = new Unlockables(5, textureManager.UshankaRangedEnemy, textureManager.RightUshankaMelee1, textureManager.RightUshankaMelee2, textureManager.RightUshankaMelee3,
                 textureManager.LeftUshankaMelee1, textureManager.LeftUshankaMelee2, textureManager.LeftUshankaMelee3);
            itemsDictionary.Add("Ushanka", ushanka);
            itemsList.Add(ushanka);

            beret = new Unlockables(5, textureManager.BeretRangedEnemy, textureManager.RightBeretMelee1, textureManager.RightBeretMelee2, textureManager.RightBeretMelee3,
                 textureManager.LeftBeretMelee1, textureManager.LeftBeretMelee2, textureManager.LeftBeretMelee3);
            itemsDictionary.Add("Beret", beret);
            itemsList.Add(beret);

            cowboy = new Unlockables(5, textureManager.CowboyRangedEnemy, textureManager.RightCowboyMelee1, textureManager.RightCowboyMelee2, textureManager.RightCowboyMelee3,
            textureManager.LeftCowboyMelee1, textureManager.LeftCowboyMelee2, textureManager.LeftCowboyMelee3);
            itemsDictionary.Add("Cowboy", cowboy);
            itemsList.Add(cowboy);

            sombrero = new Unlockables(5, textureManager.SombreroRangedEnemy, textureManager.RightSombreroMelee1, textureManager.RightSombreroMelee2, textureManager.RightSombreroMelee3,
            textureManager.LeftSombreroMelee1, textureManager.LeftSombreroMelee2, textureManager.LeftSombreroMelee3);
            itemsDictionary.Add("Sombrero", sombrero);
            itemsList.Add(sombrero);
        }

        //Parametrized Constructor
        //Used for each indiviual item 
        public Unlockables(int cost, Texture2D rangeTexture, Texture2D rightEnemyWalk1, Texture2D rightEnemyWalk2, Texture2D rightEnemyWalk3, Texture2D leftEnemyWalk1,
            Texture2D leftEnemyWalk2, Texture2D leftEnemyWalk3)
        {
            this.cost = cost;
            equipped = false;
            unlocked = false;
            this.rangeTexture = rangeTexture;
            this.rightEnemyWalk1 = rightEnemyWalk1;
            this.rightEnemyWalk2 = rightEnemyWalk2;
            this.rightEnemyWalk3 = rightEnemyWalk3;
            this.leftEnemyWalk1 = leftEnemyWalk1;
            this.leftEnemyWalk2 = leftEnemyWalk2;
            this.leftEnemyWalk3 = leftEnemyWalk3;
        }

        //Mehtod to buy an item
        public void Buy(Unlockables item)
        {
            //Checks if the user has enough unlock points
            //to buy the item
            if (unlockPoints >= item.Cost) 
            {
                item.Unlocked = true; //Sets the item as unlocked.
                UnlockPoints -= item.Cost; //Takes the cost and subtracts from users current unlock points 
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

        //Method to help ensure deafult skins
        public void MakeDefault()
        {
            for(int i = 0; i < ItemsList.Count; i++)
            {
                ItemsList[i].Equipped = false;
            }
        }
        public void UnlockableUpdate(EnemyManager enemyManager)
        {
            //Loops through all the unlockables and checks which is equipped
            for (int i = 0; i < itemsList.Count; i++)
            {
                if (itemsList[i].Equipped == true)
                {
                    //Sets the new equipped texture as the current texture
                    enemyManager.RangedTexture = itemsList[i].RangeTexture;
                    enemyManager.RightEnemyWalk1 = itemsList[i].RightEnemyWalk1;
                    enemyManager.RightEnemyWalk2 = itemsList[i].RightEnemyWalk2;
                    enemyManager.RightEnemyWalk3 = itemsList[i].RightEnemyWalk3;
                    enemyManager.LeftEnemyWalk1 = itemsList[i].LeftEnemyWalk1;
                    enemyManager.LeftEnemyWalk2 = itemsList[i].LeftEnemyWalk2;
                    enemyManager.LeftEnemyWalk3 = itemsList[i].LeftEnemyWalk3;
                    break;
                }
                else
                {
                    //If there are no equipped textures from the unlockables
                    //Set the texture as the default
                    enemyManager.RangedTexture = textureManager.RangedEnemyTexture;
                    enemyManager.RightEnemyWalk1 = textureManager.RightEnemyWalk1;
                    enemyManager.RightEnemyWalk2 = textureManager.RightEnemyWalk2;
                    enemyManager.RightEnemyWalk3 = textureManager.RightEnemyWalk3;
                    enemyManager.LeftEnemyWalk1 = textureManager.LeftEnemyWalk1;
                    enemyManager.LeftEnemyWalk2 = textureManager.LeftEnemyWalk2;
                    enemyManager.LeftEnemyWalk3 = textureManager.LeftEnemyWalk1;
                }
            }
        }
     }
}
