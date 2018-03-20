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
        private UpgradeManager ugManager;
        private TextureManager textureManager;
        private PlayerState playerState;

        //properties
        public int Kills
        {
            get { return kills; }
            set { kills = value; }
        }

        public UpgradeManager UgManager { get { return ugManager; } }

        //secondary temporary constructor for debug purposes
        public Player(String name, Rectangle position, TextureManager textureManager) : base(textureManager.RightStandingSprite)
        {
            playerState = PlayerState.FaceRight;
            this.textureManager = textureManager;
            ugManager = new UpgradeManager();

            this.position = position;
            health = 10000;
            damage = 10;
            texture = textureManager.RightStandingSprite;
        }

        //finished constructor for when the sprites are finished
        public Player(string name, TextureManager textureManager, GraphicsDevice graphicsDevice) : base(textureManager.RightStandingSprite)
        {
            kills = 0;
            upgradePoints = 0;
            damage = 10;
            health = 100;
            position = new Rectangle(0, graphicsDevice.Viewport.Height-100, 25, 10);
            this.textureManager = textureManager;
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
        public bool Crouch(KeyboardState kbState)
        {
            //if the player's current texture isn't the crouch sprite, make the player crouch
            if (texture == textureManager.LeftCrouchSprite || texture == textureManager.RightCrouchSprite)
            {
                Rectangle prevPosition = position;
                position = new Rectangle(prevPosition.X, prevPosition.Y - prevPosition.Height, prevPosition.Width, prevPosition.Height * 2);
                if (texture == textureManager.RightCrouchSprite)
                {
                    texture = textureManager.RightStandingSprite;
                }
                else if (texture == textureManager.LeftCrouchSprite)
                {
                    texture = textureManager.LeftStandingSprite;
                }
                return false;
            }
            else
            {
                Rectangle prevPosition = position;
                position = new Rectangle(prevPosition.X, prevPosition.Y + prevPosition.Height/2, prevPosition.Width, prevPosition.Height/2);
                if (texture == textureManager.RightStandingSprite || texture == textureManager.RightRunningSprite)
                {
                    texture = textureManager.RightCrouchSprite;
                }
                else if (texture == textureManager.LeftStandingSprite || texture == textureManager.LeftRunningSprite)
                {
                    texture = textureManager.LeftCrouchSprite;
                }
                return true;
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
