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
        protected string name;
        protected int health;
        protected int damage;

        //properties

        //constructor
        public Character(string name, Rectangle position, Texture2D texture) : base(position, texture)
        {
            this.name = name;
        }

        //methods
        public abstract int Attack(Rectangle rectangle);

        public abstract void TakeDamage(int damage);
    }
}
