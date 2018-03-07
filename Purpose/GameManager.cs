using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace Purpose
{
    class GameManager
    {
        //fields
        private List<Enemy> enemies;
        private Player player;
        private List<Platform> platforms;
        bool isCrouching;
        GraphicsDevice graphicsDevice;

        //properties
        public List<Enemy> Enemies { get { return enemies; } }
        public Player Player { get { return player; } }
        public List<Platform> Platforms { get { return platforms; } }
        
        //constructor
        public GameManager(Player player, List<Platform> platforms, GraphicsDevice graphicsDevice)
        {
            this.player = player;
            this.platforms = platforms;
            isCrouching = false;
            enemies = new List<Enemy>();
            this.graphicsDevice = graphicsDevice;
        }
        public GameManager(string playerName, Texture2D leftCrouchSprite, Texture2D rightCrouchSprite, Texture2D leftStandingSprite, 
            Texture2D rightStandingSprite, Texture2D rightJumpSprite, Texture2D leftJumpSprite, GraphicsDevice graphicsDevice, Random rng, int numberOfEnemies, Texture2D enemyTexture)
        {
            enemies = new List<Enemy>();
            this.graphicsDevice = graphicsDevice;
            FillEnemyList(rng, numberOfEnemies, graphicsDevice, enemyTexture);
            player = new Player(playerName, leftCrouchSprite, rightCrouchSprite, leftStandingSprite, rightStandingSprite, rightJumpSprite, leftJumpSprite, graphicsDevice);
        }

        //methods
        public void PlayerMove(KeyboardState kbState, KeyboardState previouskbState, MouseState ms, MouseState previousMs)
        {
            bool onPlatform = false;

            foreach (Platform p in platforms)
            {
                if (player.Position.Intersects(p.Position))
                {
                    onPlatform = true;
                    break;
                }
            }
            if (!onPlatform)
            {
                player.Y += 5;
            }

            if (kbState.IsKeyDown(Keys.A) || kbState.IsKeyDown(Keys.Left))
            {
                player.X -= 8;
            }
            if (kbState.IsKeyDown(Keys.D) || kbState.IsKeyDown(Keys.Right)) 
            {
                player.X += 8;
            }
            if (kbState.IsKeyDown(Keys.Space) && !previouskbState.IsKeyDown(Keys.Space) && player.Y > 300 && !isCrouching)
            {
                player.Jump();
            }
            if (kbState.IsKeyDown(Keys.Q) && !previouskbState.IsKeyDown(Keys.Q) && !kbState.IsKeyDown(Keys.Space))
            {
                if (player.UgManager.DashActive)
                {
                    if (player.Texture == player.RightStandingSprite || player.Texture == player.RightCrouchSprite)
                    {
                        player.X += 100;
                    }
                    else if (player.Texture == player.LeftStandingSprite || player.Texture == player.LeftCrouchSprite)
                    {
                        player.X -= 100;
                    }
                }
            }
            if (kbState.IsKeyDown(Keys.S) //|| kbState.IsKeyDown(Keys.Down) 
                && previouskbState.IsKeyUp(Keys.S) //|| previouskbState.IsKeyUp(Keys.Down) 
                && !kbState.IsKeyDown(Keys.Space) && onPlatform)
            {
                isCrouching = player.Crouch();
            }
            // Player attack done here as well as enemy takeDamage
            if (ms.LeftButton == ButtonState.Pressed && previousMs.LeftButton == ButtonState.Released)
            {
                for(int i = 0; i < enemies.Count; i++)
                {
                    enemies[i].TakeDamage(player.Attack(enemies[i].Position));
                    if (enemies[i].IsDead)
                    {
                        enemies.RemoveAt(i);
                    }
                }
            }
            //if (ms.LeftButton == ButtonState.Pressed)
            //{
            //    foreach (Enemy e in enemies)
            //    {
            //        e.TakeDamage(player.Attack(e.Position));
            //    }
            //}

            if (player.X <= -150)
            {
                player.X = -150;
            }
            if (player.X >= graphicsDevice.Viewport.Width-265)
            {
                player.X = graphicsDevice.Viewport.Width-265;
            }
            if (player.Y >= graphicsDevice.Viewport.Height-260)
            {
                player.Y = graphicsDevice.Viewport.Height-360;
            }
        }

        public void FillEnemyList(Random rng, int numberOfEnemies, GraphicsDevice graphicsDevice, Texture2D enemyTexture)
        {
            for (int i = 0; i < numberOfEnemies; i++)
            {
                Enemy enemy = new Enemy(new Rectangle(rng.Next(0, graphicsDevice.Viewport.Width), graphicsDevice.Viewport.Height - 450, 147, 147), enemyTexture, Level.One);
                enemies.Add(enemy);

                
            }

        }

        public void EnemyMove()
        {
            // On platform and gravity code
            bool onPlatform = false;
            foreach (Enemy e in enemies)

            {
                foreach (Platform p in platforms)
                {
                    if (e.Position.Intersects(p.Position))
                    {
                        onPlatform = true;
                        break;
                    }
                }
                if (!onPlatform)
                {
                    e.Y += 5;
                }
            }
        }
    }
}
