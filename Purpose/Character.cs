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
        protected int health;
        protected int damage;

        //properties
        public int Health { get { return health; } }

        //constructor
        public Character(Texture2D texture) : base(texture) { }

        //methods
        public abstract int Attack(Rectangle rectangle);

        public abstract void TakeDamage(int damage);
    }
}
