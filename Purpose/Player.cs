using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace Purpose
{
    class Player : Character
    {
        //fields
        private int kills;
        private int upgradePoints;
        private int passiveTier;
        private int stealthTier;
        private int damageTier;
        private Texture2D rightCrouchSprite;
        private Texture2D leftCrouchSprite;
        private Texture2D rightStandingSprite;
        private Texture2D leftStandingSprite;
        private UpgradeManager ugManager;

        //properties
        public int Kills
        {
            get { return kills; }
            set { kills = value; }
        }

        //constructor
        public Player(string name, Texture2D leftCrouchSprite, Texture2D rightCrouchSprite, Texture2D leftStandingSprite, 
            Texture2D rightStandingSprite, Rectangle position) : base(name, position, rightStandingSprite)
        {
            kills = 0;
            upgradePoints = 0;
            damage = 10;
            health = 100;
            passiveTier = 1;
            stealthTier = 1;
            damageTier = 1;
            texture = rightStandingSprite;
            this.leftCrouchSprite = leftCrouchSprite;
            this.rightCrouchSprite = rightCrouchSprite;
            this.leftStandingSprite = leftStandingSprite;
            this.rightStandingSprite = rightStandingSprite;
            ugManager = new UpgradeManager();
        }

        //methods
        public void Move(KeyboardState kbState)
        {
            if (kbState.IsKeyDown(Keys.A))
            {
                position.X -= 5;
            }
            if (kbState.IsKeyDown(Keys.D))
            {
                position.X += 5;
            }
            if (kbState.IsKeyDown(Keys.Space))
            {
                Jump();
            }
            if (kbState.IsKeyDown(Keys.Q))
            {
                if (ugManager.DashActive)
                {

                }
            }
            if (kbState.IsKeyDown(Keys.E))
            {
                if (ugManager.GroundPoundActive)
                {

                }
            }
            if (kbState.IsKeyDown(Keys.S))
            {
                Crouch();
            }
        }

        public override int Attack(Rectangle rectangle)
        {
            if (position.Intersects(rectangle))
            {
                return damage;
            }
            return 0;
        }

        public override void TakeDamage(int damage)
        {
            
        }

        public void Jump()
        {

        }

        public void Crouch()
        {
            if (texture != leftCrouchSprite || texture != rightCrouchSprite)
            {
                position.Height /= 2;
                texture = rightCrouchSprite;
            }
            else
            {
                texture = rightStandingSprite;
                position.Height *= 2;
            }
        }
    }
}
