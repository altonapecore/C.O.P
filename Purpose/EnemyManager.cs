using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Purpose
{
    public class EnemyManager
    {
        // Fields
        private List<Enemy> enemies;
        private GraphicsDevice graphicsDevice;
        private TextureManager textureManager;

        // Properties
        public List<Enemy> Enemies
        {
            get { return enemies; }
        }

        // Constructor
        public EnemyManager(GraphicsDevice graphicsDevice, TextureManager textureManager)
        {
            this.graphicsDevice = graphicsDevice;
            enemies = new List<Enemy>();
            this.textureManager = textureManager;
        }


        /// <summary>
        /// Fills the List of enemies
        /// </summary>
        /// <param name="rng">A random variable to help set the enemies' positions</param>
        /// <param name="numberOfEnemies">The number of enemies to spawn in</param>
        /// <param name="graphicsDevice">The graphics device to help limit the enemies' spawn positions</param>
        /// <param name="enemyTexture">The texture of the enemies</param>
        public void FillEnemyList(Random rng, int numberOfEnemies, int difficulty, int worldLeftEndWidth, int worldRightEndWidth, GameTime gameTime)
        {
            for (int i = 0; i < numberOfEnemies; i++)
            {
                int choice = rng.Next(1, 5);
                if (choice == 1)
                {
                    Enemy enemy = new Enemy(new Rectangle(rng.Next(worldLeftEndWidth, 0), graphicsDevice.Viewport.Height - 350, 122, 250),
                        textureManager.RightEnemyWalk1, difficulty, false, gameTime);
                    enemies.Add(enemy);
                }

                else if (choice == 2)
                {
                    Enemy enemy = new Enemy(new Rectangle(rng.Next(0, worldRightEndWidth), graphicsDevice.Viewport.Height - 350, 122, 250),
                        textureManager.LeftEnemyWalk1, difficulty, false, gameTime);
                    enemies.Add(enemy);
                }

                else if (choice == 3)
                {
                    Enemy enemy = new Enemy(new Rectangle(rng.Next(worldLeftEndWidth, -1250), graphicsDevice.Viewport.Height - 550, 122, 250),
                        textureManager.RightEnemyWalk1, difficulty, false, gameTime);
                    enemies.Add(enemy);
                }

                else if (choice == 4)
                {
                    Enemy enemy = new Enemy(new Rectangle(rng.Next(1250, worldRightEndWidth), graphicsDevice.Viewport.Height - 550, 122, 250),
                        textureManager.LeftEnemyWalk1, difficulty, false, gameTime);
                    enemies.Add(enemy);
                }
            }
        }

        /// <summary>
        /// Fills enemy list with Ranged Enemies
        /// </summary>
        /// <param name="rng">Variable to set position</param>
        /// <param name="numberOfRanged">The number to spawn</param>
        /// <param name="graphicsDevice">Limits the enemies spawn point</param>
        /// <param name="rangeTexture">The texture for the Ranged Enemies</param>
        public void FillRangedList(Random rng, int numberOfRanged, int difficulty, int worldLeftEndWidth, int worldRightEndWidth, Texture2D rangeTexture,
            GameTime gameTime)
        {
            for (int i = 0; i < numberOfRanged; i++)
            {

                int choice = rng.Next(1, 5);
                if (choice == 1)
                {
                    Enemy enemy = new Enemy(new Rectangle(rng.Next(worldLeftEndWidth, 0), graphicsDevice.Viewport.Height - 247, 147, 147),
                        rangeTexture, difficulty, true, gameTime);
                    enemies.Add(enemy);
                }

                else if (choice == 2)
                {
                    Enemy enemy = new Enemy(new Rectangle(rng.Next(0, worldRightEndWidth), graphicsDevice.Viewport.Height - 247, 147, 147),
                        rangeTexture, difficulty, true, gameTime);
                    enemies.Add(enemy);
                }

                else if (choice == 3)
                {
                    Enemy enemy = new Enemy(new Rectangle(rng.Next(worldLeftEndWidth, -1250), graphicsDevice.Viewport.Height - 447, 147, 147),
                        rangeTexture, difficulty, true, gameTime);
                    enemies.Add(enemy);
                }

                else if (choice == 4)
                {
                    Enemy enemy = new Enemy(new Rectangle(rng.Next(1250, worldRightEndWidth), graphicsDevice.Viewport.Height - 447, 147, 147),
                        rangeTexture, difficulty, true, gameTime);
                    enemies.Add(enemy);
                }
            }
        }

        /// <summary>
        /// Allows the enemy to move
        /// </summary>
        public void EnemyMove(GameTime gameTime, List<Platform> platforms, Player player)
        {
            // On platform and gravity stuff

            foreach (Enemy e in enemies)
            {
                e.OnPlatform = false;
                foreach (Platform p in platforms)
                {
                    if (new Rectangle(e.X, e.Y + 130, e.Position.Width, e.Position.Height - 130).Intersects(p.Position))
                    {
                        e.OnPlatform = true;
                        break;
                    }

                    //else if (!e.Position.Intersects(p.Position))
                    //{
                    //    e.OnPlatform = false;
                    //    
                    //}
                }
                if (!e.OnPlatform)
                {
                    e.Y += 5;
                }
            }

            for (int i = 0; i < enemies.Count; i++)
            {
                // Limiting stuff for melee enemies
                if (enemies[i].X == player.X - 15 && enemies[i].Ranged == false)
                {
                    enemies[i].X = enemies[i].X;
                }

                if (enemies[i].X == player.X + 15 && enemies[i].Ranged == false)
                {
                    enemies[i].X = enemies[i].X;
                }

                // If right of player, move left and update frame and texture
                if (enemies[i].X < player.X - 15 && enemies[i].Ranged == false)
                {
                    enemies[i].IsFacingLeft = false;
                    if (enemies[i].Texture == textureManager.LeftEnemyWalk1 || enemies[i].Texture == textureManager.LeftEnemyWalk2
                        || enemies[i].Texture == textureManager.LeftEnemyWalk3)
                    {
                        enemies[i].Texture = textureManager.RightEnemyWalk1;
                        enemies[i].FrameCounter = 0;
                    }
                    enemies[i].FrameCounter++;
                    enemies[i].X += 5;
                    if (enemies[i].FrameCounter >= 5)
                    {
                        if (enemies[i].Texture == textureManager.RightEnemyWalk1)
                        {
                            enemies[i].Texture = textureManager.RightEnemyWalk2;
                        }
                        else if (enemies[i].Texture == textureManager.RightEnemyWalk2)
                        {
                            enemies[i].Texture = textureManager.RightEnemyWalk3;
                        }
                        else if (enemies[i].Texture == textureManager.RightEnemyWalk3)
                        {
                            enemies[i].Texture = textureManager.RightEnemyWalk1;
                        }
                        enemies[i].FrameCounter = 0;
                    }
                }

                // If right of player, move left and update frame and texture
                else if (enemies[i].X > player.X + 15 && enemies[i].Ranged == false)
                {
                    enemies[i].IsFacingLeft = true;
                    if (enemies[i].Texture == textureManager.RightEnemyWalk1 || enemies[i].Texture == textureManager.RightEnemyWalk2
                        || enemies[i].Texture == textureManager.RightEnemyWalk3)
                    {
                        enemies[i].Texture = textureManager.LeftEnemyWalk1;
                        enemies[i].FrameCounter = 0;
                    }
                    enemies[i].FrameCounter++;
                    enemies[i].X -= 5;
                    if (enemies[i].FrameCounter >= 5)
                    {
                        if (enemies[i].Texture == textureManager.LeftEnemyWalk1)
                        {
                            enemies[i].Texture = textureManager.LeftEnemyWalk2;
                        }
                        else if (enemies[i].Texture == textureManager.LeftEnemyWalk2)
                        {
                            enemies[i].Texture = textureManager.LeftEnemyWalk3;
                        }
                        else if (enemies[i].Texture == textureManager.LeftEnemyWalk3)
                        {
                            enemies[i].Texture = textureManager.LeftEnemyWalk1;
                        }
                        enemies[i].FrameCounter = 0;
                    }
                }

                // Limiting movement for ranged enemies
                if (enemies[i].X == player.X - 555 && enemies[i].Ranged)
                {
                    enemies[i].X = enemies[i].X;
                }

                if (enemies[i].X == player.X + 555 && enemies[i].Ranged)
                {
                    enemies[i].X = enemies[i].X;
                }

                // If on right of player, move left and update frames and texture
                if (enemies[i].X < player.X - 555 && enemies[i].Ranged)
                {
                    enemies[i].IsFacingLeft = false;
                    if (enemies[i].Texture == textureManager.LeftEnemyWalk1 || enemies[i].Texture == textureManager.LeftEnemyWalk2
                        || enemies[i].Texture == textureManager.LeftEnemyWalk3)
                    {
                        enemies[i].Texture = textureManager.RightEnemyWalk1;
                        enemies[i].FrameCounter = 0;
                    }
                    enemies[i].FrameCounter++;
                    enemies[i].X += 5;
                    if (enemies[i].FrameCounter >= 5)
                    {
                        if (enemies[i].Texture == textureManager.RightEnemyWalk1)
                        {
                            enemies[i].Texture = textureManager.RightEnemyWalk2;
                        }
                        else if (enemies[i].Texture == textureManager.RightEnemyWalk2)
                        {
                            enemies[i].Texture = textureManager.RightEnemyWalk3;
                        }
                        else if (enemies[i].Texture == textureManager.RightEnemyWalk3)
                        {
                            enemies[i].Texture = textureManager.RightEnemyWalk1;
                        }
                        enemies[i].FrameCounter = 0;
                    }
                }

                // If left of player, move right and update frame and texture
                else if (enemies[i].X > player.X + 555 && enemies[i].Ranged)
                {
                    enemies[i].IsFacingLeft = true;
                    if (enemies[i].Texture == textureManager.RightEnemyWalk1 || enemies[i].Texture == textureManager.RightEnemyWalk2
                        || enemies[i].Texture == textureManager.RightEnemyWalk3)
                    {
                        enemies[i].Texture = textureManager.LeftEnemyWalk1;
                        enemies[i].FrameCounter = 0;
                    }
                    enemies[i].FrameCounter++;
                    enemies[i].X -= 5;
                    if (enemies[i].FrameCounter >= 5)
                    {
                        if (enemies[i].Texture == textureManager.LeftEnemyWalk1)
                        {
                            enemies[i].Texture = textureManager.LeftEnemyWalk2;
                        }
                        else if (enemies[i].Texture == textureManager.LeftEnemyWalk2)
                        {
                            enemies[i].Texture = textureManager.LeftEnemyWalk3;
                        }
                        else if (enemies[i].Texture == textureManager.LeftEnemyWalk3)
                        {
                            enemies[i].Texture = textureManager.LeftEnemyWalk1;
                        }
                        enemies[i].FrameCounter = 0;
                    }
                }
            }

            // If enemies fall through the floor, kill em
            for (int i = 0; i < enemies.Count; i++)
            {
                if (enemies[i].Y >= 745)
                {
                    enemies.Remove(enemies[i]);
                }
            }
        }
    }
}
