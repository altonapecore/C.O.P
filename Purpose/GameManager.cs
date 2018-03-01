using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Purpose
{
    class GameManager
    {
        //fields
        private List<Enemy> enemies;
        private Player player;
        bool isJumping; 
        
        //constructor
        public GameManager(string playerName, Texture2D leftCrouchSprite, Texture2D rightCrouchSprite, Texture2D leftStandingSprite, 
            Texture2D rightStandingSprite, Texture2D rightJumpSprite, Texture2D leftJumpSprite, GraphicsDevice graphicsDevice)
        {
            enemies = new List<Enemy>();
            player = new Player(playerName, leftCrouchSprite, rightCrouchSprite, leftStandingSprite, rightStandingSprite, rightJumpSprite, leftJumpSprite, graphicsDevice);
        }

        //methods
        /// <summary>
        /// Moves the player depending on keyboard input
        /// </summary>
        /// <param name="kbState">The current state of the keyboard</param>
        /// <param name="time">A time parameter for physics</param>
        public void Move(KeyboardState kbState, float time, MouseState ms, List<Enemy> enemies)
        {
            if (kbState.IsKeyDown(Keys.A) && !isJumping)
            {
                player.X -= 5;
            }
            if (kbState.IsKeyDown(Keys.D) && !isJumping)
            {
                player.X += 5;
            }
            if (kbState.IsKeyDown(Keys.Space) && !isJumping)
            {
                player.Jump(time);
            }
            if (kbState.IsKeyDown(Keys.Q) && !isJumping)
            {
                if (player.UgManager.DashActive)
                {
                    if (player.Texture == player.RightStandingSprite || player.Texture == player.RightCrouchSprite)
                    {
                        player.X += 15;
                    }
                    else if (player.Texture == player.LeftStandingSprite || player.Texture == player.LeftCrouchSprite)
                    {
                        player.X -= 15;
                    }
                }
            }
            if (kbState.IsKeyDown(Keys.S) && !isJumping)
            {
                player.Crouch();
            }
            if (ms.LeftButton == ButtonState.Pressed)
            {
                foreach (Enemy e in enemies)
                {
                    e.TakeDamage(player.Attack(e.Position));
                }
            }
        }

    }
}
