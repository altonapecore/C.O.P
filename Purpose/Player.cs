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

        // Temporary constructor for debug purposes
        public Player(String name, Texture2D texture) : base(texture)
        {
            rightCrouchSprite = texture;
            leftCrouchSprite = texture;
            rightJumpSprite = texture;
            leftJumpSprite = texture;
            rightStandingSprite = texture;
            leftStandingSprite = texture;
            ugManager = new UpgradeManager();
            ugManager.DashUpgrade();
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

        public List<Rectangle> Jump(Vector2 ogPlayerPos)
        {
            List<Vector2> jumpPositions = new List<Vector2>();

            ogPlayerPos = new Vector2(position.X, position.Y);
            for (int i = 1; i <= 10; i++)
            {
                Vector2 newPosition = new Vector2(0, 0);
                newPosition += (1.5f * gravity * i * i);
                newPosition += ogPlayerPos;
                jumpPositions.Add(newPosition);
            }

            List<Rectangle> jumpRectangles = new List<Rectangle>();
            for (int i = 0; i < jumpPositions.Count; i++)
            {
                jumpRectangles.Add(new Rectangle((int)jumpPositions[i].X, (int)jumpPositions[i].Y, position.Width, position.Height));
            }

            return jumpRectangles;
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

        //only for debug purposes right now
        public void Upgrade()
        {
            ugManager.DashUpgrade();
        }
    }
}
