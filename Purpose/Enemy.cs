using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Purpose
{
    public class Enemy : Character
    {
        // Fields
        private bool ranged;
        private bool isDead;

        // Properties
        public bool Ranged
        {
            get { return ranged; }
            set { ranged = value; }
        }

        public bool IsDead
        {
            get { return isDead; }
        }

        // Constructor
        public Enemy(Rectangle position, Texture2D texture, Level level, bool ranged) : base(texture)
        {
            //Placeholder for Level. Thought as level increases so does damage or health


            this.ranged = ranged; //Decides whether or not a ranged enemy is spawned
            this.position = position;
            health = 50;
        }

        // Methods
        public override int Attack(Rectangle rectangle)
        {
            if (position.Intersects(rectangle))
            {
                // Code for attack here
                // Temp variable for damage                
                if (ranged)
                {
                    return 2;
                }
                else
                {
                    return 1;
                }
            }
            else
            {
                return 0;
            }
        }

        public override void TakeDamage(int damage)
        {
            // Code for taking damage here
            health -= damage;
            if(health <= 0)
            {
                isDead = true;
            }
        }

        
    }
}
