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
    public class Player : Character
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
        private Texture2D rightRunningSprite;
        private Texture2D leftRunningSprite;
        private UpgradeManager ugManager;

        //properties
        public int Kills
        {
            get { return kills; }
            set { kills = value; }
        }

        public UpgradeManager UgManager { get { return ugManager; } }

        //sprite properties
        public Texture2D RightCrouchSprite { get { return rightCrouchSprite; } }
        public Texture2D LeftCrouchSprite { get { return leftCrouchSprite; } }
        public Texture2D RightStandingSprite { get { return rightStandingSprite; } }
        public Texture2D LeftStandingSprite { get { return leftStandingSprite; } }
        public Texture2D RightJumpSprite { get { return rightJumpSprite; } }
        public Texture2D LeftJumpSprite { get { return leftJumpSprite; } }
        public Texture2D RightRunningSprite { get { return rightRunningSprite; } }
        public Texture2D LeftRunningSprite { get { return leftRunningSprite; } }

        //constructors

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

            this.position = position;
            health = 10000;
            damage = 10;
        }

        //secondary temporary constructor for debug purposes
        public Player(String name, Rectangle position, Texture2D leftCrouchSprite, Texture2D rightCrouchSprite, Texture2D leftStandingSprite,
            Texture2D rightStandingSprite, Texture2D leftRunningSprite, Texture2D rightRunningSprite) : base(rightStandingSprite)
        {
            this.rightCrouchSprite = rightCrouchSprite;
            this.leftCrouchSprite = leftCrouchSprite;
            this.rightStandingSprite = rightStandingSprite;
            this.leftStandingSprite = leftStandingSprite;
            this.rightRunningSprite = rightRunningSprite;
            this.leftRunningSprite = leftRunningSprite;

            rightJumpSprite = rightStandingSprite;
            leftJumpSprite = leftStandingSprite;

            ugManager = new UpgradeManager();

            this.position = position;
            health = 10000;
            damage = 10;
        }

        //finished constructor for when the sprites are finished
        public Player(string name, Texture2D leftCrouchSprite, Texture2D rightCrouchSprite, Texture2D leftStandingSprite, 
            Texture2D rightStandingSprite, Texture2D rightJumpSprite, Texture2D leftJumpSprite, Texture2D leftRunningSprite,
            Texture2D rightRunningSprite, GraphicsDevice graphicsDevice) : base(rightStandingSprite)
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
        /// <summary>
        /// Allows the player to attack by checking if the player is intersecting with another character's position
        /// </summary>
        /// <param name="enemyPosition">The position of the enemy</param>
        /// <returns>Returns an integer value for the damage done</returns>
        public override int Attack(Rectangle enemyPosition)
        {
            if (position.Intersects(enemyPosition))
            {
                return damage;
            }
            return 0;
        }

        /// <summary>
        /// Allows the player to take damage
        /// </summary>
        /// <param name="damage">The damage done to the player</param>
        public override void TakeDamage(int damage)
        {
            health -= damage;
        }

        /// <summary>
        /// Allows the player to jump
        /// </summary>
        public void Jump()
        {
            position.Y -= 200;
        }

        /// <summary>
        /// Allows the player to crouch
        /// </summary>
        /// <returns>Returns a boolean representing if the player is crouching or not</returns>
        public bool Crouch()
        {
            //if the player's current texture isn't the crouch sprite, make the player crouch
            if (texture != rightCrouchSprite)
            {
                Rectangle prevPosition = position;
                position = new Rectangle(prevPosition.X, prevPosition.Y + prevPosition.Height/2, prevPosition.Width, prevPosition.Height/2);
                texture = rightCrouchSprite;
                return true;
            }
            else
            {
                Rectangle prevPosition = position;
                position = new Rectangle(prevPosition.X, prevPosition.Y - prevPosition.Height, prevPosition.Width, prevPosition.Height*2);
                texture = rightStandingSprite;
                return false;
            }
        }

        /// <summary>
        /// Allows the player to execute their ground pound attack
        /// </summary>
        /// <param name="enemies">The list of enemies in the game</param>
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
