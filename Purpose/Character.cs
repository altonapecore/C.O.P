using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Purpose
{
    abstract class Character : GameObject
    {
        //fields
        string name; 

        //properties

        //constructor
        public Character(string name, Rectangle position, Texture2D texture) : base(position, texture)
        {
            this.name = name;
        }

        //methods
        public abstract void Move(int power);
    }
}
