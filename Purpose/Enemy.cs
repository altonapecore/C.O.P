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
        private int gameTime;
        private int frameCounter;
        private bool isFacingLeft;
        private Rectangle bullet;
        private bool hasBullet;
        // Temp field for attacking
        private bool isAttacking;
        

        // Properties
        public bool Ranged
        {
            get { return ranged; }
            set { ranged = value; }
        }

        public int FrameCounter
        {
            get { return frameCounter; }
            set { frameCounter = value; }
        }

        public bool IsFacingLeft
        {
            get { return isFacingLeft; }
            set { isFacingLeft = value; }
        }

        public Rectangle Bullet { get { return bullet; } }

        public int BulletX
        {
            get { return bullet.X; }
            set { bullet.X = value; }
        }

        public int BulletY
        {
            get { return bullet.Y; }
            set { bullet.Y = value; }
        }

        public bool HasBullet
        {
            get { return hasBullet; }
            set { hasBullet = value; }
        }

        // Temp property for attacking
        public bool IsAttacking { get { return isAttacking; } }

        // Normal stuff below
        public int GameTime { get { return gameTime; } }

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
            bullet = new Rectangle(0, 0, 0, 0);
            hasBullet = false;
        }

        // Methods
        public override int Attack(Rectangle rectangle, GameTime gameTime)
        {
            if (this.gameTime + 2 == gameTime.TotalGameTime.Seconds)
            {
                if (ranged && hasBullet == false && isFacingLeft)
                {
                    bullet = new Rectangle(position.X, position.Y + 55, 33, 33);
                    hasBullet = true;
                }
                else if (ranged && hasBullet == false && isFacingLeft == false)
                {
                    bullet = new Rectangle(position.X + 147, position.Y + 55, 33, 33);
                    hasBullet = true;
                }

                if (ranged && hasBullet && bullet.Intersects(rectangle))
                {
                    this.gameTime = gameTime.TotalGameTime.Seconds;
                    bullet.X = 0;
                    bullet.Y = 0;
                    hasBullet = false;
                    return damage;
                }

                else if (ranged == false && position.Intersects(rectangle))
                {
                    this.gameTime = gameTime.TotalGameTime.Seconds;
                    return damage;
                }
                else
                {
                    this.gameTime = gameTime.TotalGameTime.Seconds;
                    return 0;
                }
            }
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
