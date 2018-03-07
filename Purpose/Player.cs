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
        private Texture2D rightCrouchSprite;
        private Texture2D leftCrouchSprite;
        private Texture2D rightStandingSprite;
        private Texture2D leftStandingSprite;
        private Texture2D rightJumpSprite;
        private Texture2D leftJumpSprite;
        private UpgradeManager ugManager;

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

        // Temporary constructor for debug purposes
        public Player(String name, Texture2D texture, Texture2D tempCrouchTexture, Rectangle position) : base(texture)
        {
            rightCrouchSprite = tempCrouchTexture;
            leftCrouchSprite = tempCrouchTexture;
            rightJumpSprite = texture;
            leftJumpSprite = texture;
            rightStandingSprite = texture;
            leftStandingSprite = texture;
            ugManager = new UpgradeManager();
            ugManager.DashUpgrade();
            this.position = position;
            health = 10000;
        }

        public Player(string name, Texture2D leftCrouchSprite, Texture2D rightCrouchSprite, Texture2D leftStandingSprite, 
            Texture2D rightStandingSprite, Texture2D rightJumpSprite, Texture2D leftJumpSprite, GraphicsDevice graphicsDevice) : base(rightStandingSprite)
        {
            kills = 0;
            upgradePoints = 0;
            damage = 10;
            health = 100;
            position = new Rectangle(0, graphicsDevice.Viewport.Height-100, 25, 10);

            texture = rightStandingSprite;
            this.leftCrouchSprite = leftCrouchSprite;
            this.rightCrouchSprite = rightCrouchSprite;
            this.leftStandingSprite = leftStandingSprite;
            this.rightStandingSprite = rightStandingSprite;
            this.leftJumpSprite = leftJumpSprite;
            this.rightJumpSprite = rightJumpSprite;
            ugManager = new UpgradeManager();
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

        public void Jump()
        {
            position.Y -= 200;
        }

        public bool Crouch()
        {
            if (texture != leftCrouchSprite || texture != rightCrouchSprite)
            {
                texture = rightCrouchSprite;
                int newHeight = rightCrouchSprite.Height;
                position.Height = newHeight;
                return true;
            }
            else
            {
                texture = rightStandingSprite;
                int newHeight = RightStandingSprite.Height;
                position.Height = newHeight;
                return false;
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

        //only for debug purposes right now
        public void Upgrade()
        {
            ugManager.DashUpgrade();
        }
    }
}
