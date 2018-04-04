using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Purpose
{
    public abstract class Character : GameObject
    {
        //fields
        protected int health;
        protected int damage;
        protected bool isDead;

        //properties
        public int Health
        {
            get { return health; }
            set { health = value; }
        }
        public int Damage
        {
            get { return damage; }
            set { damage = value; }
        }

        public bool IsDead
        {
            get { return isDead; }
            set { isDead = value; }
        }

        //constructor
        public Character(Texture2D texture) : base(texture) { }

        //methods
        public abstract int Attack(Character character, GameTime gameTime);

        public abstract void TakeDamage(int damage);
    }
}
