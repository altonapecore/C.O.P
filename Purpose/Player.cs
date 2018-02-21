using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Purpose
{
    class Player : Character
    {
        //fields
        private int kills;

        //properties
        public int Kills
        {
            get { return kills; }
            set { kills = value; }
        }

        //constructor
        public Player(string name, Rectangle position, Texture2D texture) : base(name, position, texture)
        {
            kills = 0;
        }

        //methods
        public override void Move(int power)
        {
            //this is just an idea for player movement
            //it might work to pass in an int representing how long
            //the user has been holding down a key to represent the power
            //that the player moves with
            //It could help with physics calculations
        }
    }
}
