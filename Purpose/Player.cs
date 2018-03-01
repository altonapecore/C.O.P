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
        bool isJumping;
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

        public UpgradeManager UgManager { get { return ugManager; } }

        public Texture2D RightCrouchSprite { get { return rightCrouchSprite; } }
        public Texture2D LeftCrouchSprite { get { return leftCrouchSprite; } }
        public Texture2D RightStandingSprite { get { return rightStandingSprite; } }
        public Texture2D LeftStandingSprite { get { return leftStandingSprite; } }
        public Texture2D RightJumpSprite { get { return rightJumpSprite; } }
        public Texture2D LeftJumpSprite { get { return leftJumpSprite; } }



        //constructor
        // Temporary constructor
        public Player(String name, Texture2D texture) : base(texture)
        {
            rightCrouchSprite = texture;
            leftCrouchSprite = texture;
            rightJumpSprite = texture;
            leftJumpSprite = texture;
            rightStandingSprite = texture;
            leftStandingSprite = texture;
        }
        public Player(string name, Texture2D leftCrouchSprite, Texture2D rightCrouchSprite, Texture2D leftStandingSprite, 
            Texture2D rightStandingSprite, Texture2D rightJumpSprite, Texture2D leftJumpSprite, GraphicsDevice graphicsDevice) : base(rightStandingSprite)
        {
            kills = 0;
            upgradePoints = 0;
            damage = 10;
            health = 100;
            isJumping = false;
            position = new Rectangle(0, graphicsDevice.Viewport.Height, 25, 10);

            texture = rightStandingSprite;
            this.leftCrouchSprite = leftCrouchSprite;
            this.rightCrouchSprite = rightCrouchSprite;
            this.leftStandingSprite = leftStandingSprite;
            this.rightStandingSprite = rightStandingSprite;
            this.leftJumpSprite = leftJumpSprite;
            this.rightJumpSprite = rightJumpSprite;
            ugManager = new UpgradeManager();

            velocity = new Vector2(0,0);
        }

        //methods
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
