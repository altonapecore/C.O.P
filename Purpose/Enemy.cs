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
        private int gameTime;
        private int frameCounter;
        // Temp field for attacking
        private bool isAttacking;

        // Properties
        public bool Ranged
        {
            get { return ranged; }
            set { ranged = value; }
        }

        // Temp property for attacking
        public bool IsAttacking { get { return isAttacking; } }

        // Normal stuff below
        public bool IsDead{ get { return isDead; }}

        public int GameTime { get { return gameTime; } }
        public int FrameCounter { get { return frameCounter; } set { frameCounter = value; } }

        // Constructor
        public Enemy(Rectangle position, Texture2D texture, Level level, bool ranged, GameTime gameTime) : base(texture)
        {
            //Placeholder for Level. Thought as level increases so does damage or health


            this.ranged = ranged; //Decides whether or not a ranged enemy is spawned
            this.position = position;
            this.gameTime = gameTime.TotalGameTime.Seconds;
            health = 50;
            damage = 10;
            frameCounter = 0;
        }

        // Methods
        public override int Attack(Rectangle rectangle, GameTime gameTime)
        {
            if (this.gameTime + 2 == gameTime.TotalGameTime.Seconds)
            {
                if (position.Intersects(rectangle))
                {
                    isAttacking = true;
                    // Normal code below, keep this
                    this.gameTime = gameTime.TotalGameTime.Seconds;
                    return damage;
                }
                else
                {
                    isAttacking = false;
                    // Normal code below, keep this
                    this.gameTime = gameTime.TotalGameTime.Seconds;
                    return 0;
                }
            }

                // Normal code below, keep this
                isAttacking = false;
                return 0;
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
