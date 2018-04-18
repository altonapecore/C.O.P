using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Purpose
{
    public enum SpawnLevel
    {
        baseLevel,
        firstLevelLeft,
        firstLevelCenter,
        firstLevelRight,
        secondLevelLeft,
        secondLevelCenter,
        secondLevelRight,
        thirdLevelLeft,
        thirdLevelCenter,
        thirdLevelRight,
        fourthLevelLeft,
        fourthLevelCenter,
        fourthLevelRight,
        fifthLevel
    }
    public class Enemy : Character
    {
        // Fields
        private bool ranged;
        private float meleeAttackTimer;
        private float rangedAttackTimer;
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

        // Normal stuff below
        public float AttackTime { get { return meleeAttackTimer; } set { meleeAttackTimer = value; } }

        public int Difficulty{get { return difficulty; } }
        // Constructor
        public Enemy(Rectangle position, Texture2D texture, int difficulty, bool ranged, GameTime gameTime) : base(texture)
        {
            this.ranged = ranged; //Decides whether or not a ranged enemy is spawned
            this.position = position;
            this.meleeAttackTimer = 0;
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
            else
            {
                damage = 5;
                health = 50;
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
            meleeAttackTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (meleeAttackTimer >= 1)
            {
                
                // Melee attack stuff
                if (!ranged && position.Intersects(player.Position))
                {
                    meleeAttackTimer = 0;
                    return damage;
                }
                else
                {
                    meleeAttackTimer = 0;
                    return 0;
                }
            }

            rangedAttackTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if(rangedAttackTimer >= 3 && player.Y <= Y && player.Y >= Y - 150)
            {
                // If the enemy is ranged and doesn't have a bullet, spawn a bullet
                if (ranged && !hasBullet && isFacingLeft)
                {
                    hasBullet = true;
                    bullet = new Rectangle(position.X, position.Y + 55, 33, 33);
                    rangedAttackTimer = 0;
                }
                else if (ranged && !hasBullet && isFacingLeft == false)
                {
                    hasBullet = true;
                    bullet = new Rectangle(position.X + 147, position.Y + 55, 33, 33);
                    rangedAttackTimer = 0;
                }
            }

            //  If they have a bullet, attack and take bullet away
            if (hasBullet && bullet.Intersects(player.Position))
            {
                meleeAttackTimer = 0;
                bullet.Height = 0;
                bullet.Width = 0;
                hasBullet = false;
                return 2;
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
