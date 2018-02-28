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
        private Texture2D rightJumpSprite;
        private Texture2D leftJumpSprite;
        private UpgradeManager ugManager;

        //physics fields
        private Vector2 velocity;
        private Vector2 gravity = new Vector2(0, -9.8f);

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

            velocity = new Vector2(0,0);
        }

        //methods
        public void Move(KeyboardState kbState, float time)
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
                Jump(time);
            }
            if (kbState.IsKeyDown(Keys.Q))
            {
                if (ugManager.DashActive)
                {
                    if (texture == rightStandingSprite || texture == rightCrouchSprite)
                    {
                        position.X += 15;
                    }
                    else if (texture == leftStandingSprite || texture == leftCrouchSprite)
                    {
                        position.X -= 15;
                    }
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
            health -= damage;
        }

        public void Jump(float time)
        {
            Vector2 positionVector = new Vector2(position.X, position.Y);
            velocity += gravity * time;
            positionVector += velocity * time;
            position.X = (int)positionVector.X;
            position.Y = (int)positionVector.Y;
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

        //use if kb.State == S
        public void GroundPound(List<Enemy> enemies)
        {
            Rectangle groundPoundArea = new Rectangle(position.X, (position.Y + position.Height), 100, 10);
            if (ugManager.GroundPoundActive)
            {
                foreach(Enemy e in enemies)
                {
                    if (groundPoundArea.Intersects(e.Position))
                    {
                        e.TakeDamage(15);
                    }
                }
            }
        }
    }
}
