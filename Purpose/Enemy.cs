using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Purpose
{
    class Enemy : Character
    {
        // Fields
        private bool ranged;

        // Properties
        public bool Ranged
        {
            get { return ranged; }
            set { ranged = value; }
        }

        // Constructor
        public Enemy(Rectangle position, Texture2D texture, Level level) : base(texture)
        {
            if (level == Level.Three || level == Level.Four)
            {
                ranged = true;
            }

            else
            {
                ranged = false;
            }
        }

        // Methods
        public override int Attack(Rectangle rectangle)
        {
            int damageDealt = 1;
            if (position.Intersects(rectangle))
            {
                // Code for attack here
                // Temp variable for damage                
                if (ranged)
                {
                    damageDealt = 2;
                    return damageDealt;
                }
                else
                {
                    return damageDealt;
                }
            }
            else
            {
                damageDealt = 0;
                return damageDealt;
            }
        }

        public override void TakeDamage(int damage)
        {
            // Code for taking damage here
        }
    }
}
