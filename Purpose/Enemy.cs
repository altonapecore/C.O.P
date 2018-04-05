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
        private bool onPlatform;
        private bool onBasePlatform;
        private int jumpNum;
        private int difficulty;
        private Color color;
        private int velocity;

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

        public bool OnPlatform
        {
            get { return onPlatform; }
            set { onPlatform = value; }
        }

        public bool IsOnBasePlatform
        {
            get { return onBasePlatform; }
            set { onBasePlatform = value; }
        }

        public int JumpNum
        {
            get { return jumpNum; }
            set { jumpNum = value; }
        }

        public Color Color
        {
            get { return color; }
        }

        public int Velocity
        {
            get { return velocity; }
            set { velocity = value; }
        }

        // Temp property for attacking
        public bool IsAttacking { get { return isAttacking; } }

        // Normal stuff below
        public int GameTime { get { return gameTime; } }

        public int Difficulty{get { return difficulty; } }
        // Constructor
        public Enemy(Rectangle position, Texture2D texture, int difficulty, bool ranged, GameTime gameTime) : base(texture)
        {
            this.ranged = ranged; //Decides whether or not a ranged enemy is spawned
            this.position = position;
            this.gameTime = gameTime.TotalGameTime.Seconds;
            this.difficulty = difficulty;
            if (difficulty == 1)
            {
                color = Color.White;
                if (ranged)
                {
                    damage = 7;
                    health = 30;
                }
                else
                {
                    damage = 5;
                    health = 50;
                }
            }
            else if (difficulty == 2)
            {
                color = Color.Firebrick;
                if (ranged)
                {
                    damage = 10;
                    health = 35;
                }
                else
                {
                    damage = 8;
                    health = 55;
                }
            }
            else if (difficulty == 3)
            {
                color = Color.CornflowerBlue;
                if (ranged)
                {
                    damage = 13;
                    health = 40;
                }
                else
                {
                    damage = 11;
                    health = 60;
                }
            }
            frameCounter = 0;
            hasBullet = false;
        }

        // Methods
        /// <summary>
        /// Attack method for enemy. Checks for collision & returns damge if it does collide
        /// </summary>
        /// <param name="playerPosition">Player rectangle to check against</param>
        /// <param name="gameTime">Used for checking to see if the player can attack</param>
        /// <returns></returns>
        public override int Attack(Character player, GameTime gameTime)
        {
            if (this.gameTime + 1 == gameTime.TotalGameTime.Seconds)
            {
                // If the enemy is ranged and doesn't have a bullet, spawn a bullet
                if (ranged && hasBullet == false && isFacingLeft)
                {
                    hasBullet = true;
                    bullet = new Rectangle(position.X, position.Y + 55, 33, 33);
                }
                else if (ranged && hasBullet == false && isFacingLeft == false)
                {
                    hasBullet = true;
                    bullet = new Rectangle(position.X + 147, position.Y + 55, 33, 33);
                }

                //  If they have a bullet, attack and take bullet away
                if (hasBullet && bullet.Intersects(player.Position))
                {
                    this.gameTime = gameTime.TotalGameTime.Seconds;
                    bullet.Height = 0;
                    bullet.Width = 0;
                    hasBullet = false;
                    return damage;
                }

                // Melee attack stuff
                else if (ranged == false && position.Intersects(player.Position))
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

        /// <summary>
        /// Allows the enemy to jump
        /// </summary>
        public void Jump()
        {
            velocity = -30;
            Y += velocity;
        }
    }
}
