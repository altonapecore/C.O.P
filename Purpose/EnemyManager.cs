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
        #region Fields, Properties, and Constructor
        // Fields
        private List<Enemy> enemies;
        private GraphicsDevice graphicsDevice;
        private TextureManager textureManager;
        private Texture2D rightEnemyWalk1;
        private Texture2D rightEnemyWalk2;
        private Texture2D rightEnemyWalk3;
        private Texture2D leftEnemyWalk1;
        private Texture2D leftEnemyWalk2;
        private Texture2D leftEnemyWalk3;
        private Texture2D rangedTexture;

        // Properties
        public List<Enemy> Enemies
        {
            get { return enemies; }
        }

        public Texture2D RightEnemyWalk1 { get { return rightEnemyWalk1;} set { rightEnemyWalk1 = value; } }
        public Texture2D RightEnemyWalk2 { get { return rightEnemyWalk2;} set { rightEnemyWalk2 = value; } }
        public Texture2D RightEnemyWalk3 { get { return rightEnemyWalk3;} set { rightEnemyWalk3 = value; } }
        public Texture2D LeftEnemyWalk1 { get { return leftEnemyWalk1; } set { leftEnemyWalk1 = value; } }
        public Texture2D LeftEnemyWalk2 { get { return leftEnemyWalk2; } set { leftEnemyWalk2 = value; } }
        public Texture2D LeftEnemyWalk3 { get { return leftEnemyWalk3; } set { leftEnemyWalk3 = value; } }
        public Texture2D RangedTexture { get { return rangedTexture; } set { rangedTexture = value; } } 

        // Constructor
        public EnemyManager(GraphicsDevice graphicsDevice, TextureManager textureManager)
        {
            this.graphicsDevice = graphicsDevice;
            enemies = new List<Enemy>();
            this.textureManager = textureManager;
            rangedTexture = textureManager.RangedEnemyTexture;
            rightEnemyWalk1 = textureManager.RightEnemyWalk1;
            rightEnemyWalk2 = textureManager.RightEnemyWalk2;
            rightEnemyWalk3 = textureManager.RightEnemyWalk3;
            leftEnemyWalk1 = textureManager.LeftEnemyWalk1;
            leftEnemyWalk2 = textureManager.LeftEnemyWalk2;
            leftEnemyWalk3 = textureManager.LeftEnemyWalk3;
        }
        #endregion

        #region Fill Melee List
        /// <summary>
        /// Fills the List of enemies
        /// </summary>
        /// <param name="rng">A random variable to help set the enemies' positions</param>
        /// <param name="numberOfEnemies">The number of enemies to spawn in</param>
        /// <param name="graphicsDevice">The graphics device to help limit the enemies' spawn positions</param>
        /// <param name="enemyTexture">The texture of the enemies</param>
        public void FillEnemyList(Random rng, int numberOfEnemies, int difficulty, GameTime gameTime, 
            PlatformVersion platformVersion)
        {
            switch (platformVersion)
            {
                case PlatformVersion.Easy:
                    // Base level
                    for (int i = 0; i < rng.Next(2, numberOfEnemies + 1) + 1; i++)
                    {
                        Enemy enemy = new Enemy(new Rectangle(rng.Next(-3000, -1000), graphicsDevice.Viewport.Height - 350, 122, 225),
                                RightEnemyWalk1, difficulty, false, gameTime);
                        enemies.Add(enemy);
                    }
                    for (int i = 0; i < rng.Next(2, numberOfEnemies + 1) + 1; i++)
                    {
                        Enemy enemy = new Enemy(new Rectangle(rng.Next(1000,3000), graphicsDevice.Viewport.Height - 350, 122, 225),
                                RightEnemyWalk1, difficulty, false, gameTime);
                        enemies.Add(enemy);
                    }

                    // First level
                    for (int i = 0; i < rng.Next(2, numberOfEnemies + 1) + 1; i++)
                    {
                        Enemy enemy = new Enemy(new Rectangle(rng.Next(-3000, -1250), graphicsDevice.Viewport.Height - 550, 122, 225),
                                RightEnemyWalk1, difficulty, false, gameTime);
                        enemies.Add(enemy);
                    }
                    for (int i = 0; i < rng.Next(2, numberOfEnemies + 1) + 1; i++)
                    {
                        Enemy enemy = new Enemy(new Rectangle(rng.Next(1250, 3000), graphicsDevice.Viewport.Height - 550, 122, 225),
                                RightEnemyWalk1, difficulty, false, gameTime);
                        enemies.Add(enemy);
                    }

                    // Second level
                    for (int i = 0; i < rng.Next(2, numberOfEnemies + 1) + 1; i++)
                    {
                        Enemy enemy = new Enemy(new Rectangle(rng.Next(-1100, -175), graphicsDevice.Viewport.Height - 750, 122, 225),
                                RightEnemyWalk1, difficulty, false, gameTime);
                        enemies.Add(enemy);
                    }
                    for (int i = 0; i < rng.Next(2, numberOfEnemies + 1) + 1; i++)
                    {
                        Enemy enemy = new Enemy(new Rectangle(rng.Next(175, 1100), graphicsDevice.Viewport.Height - 750, 122, 225),
                                RightEnemyWalk1, difficulty, false, gameTime);
                        enemies.Add(enemy);
                    }

                    // third level
                    for (int i = 0; i < rng.Next(2, numberOfEnemies + 1) + 1; i++)
                    {
                        Enemy enemy = new Enemy(new Rectangle(rng.Next(-2500, -500), graphicsDevice.Viewport.Height - 1150, 122, 225),
                                RightEnemyWalk1, difficulty, false, gameTime);
                        enemies.Add(enemy);
                    }
                    for (int i = 0; i < rng.Next(2, numberOfEnemies + 1) + 1; i++)
                    {
                        Enemy enemy = new Enemy(new Rectangle(rng.Next(500, 2500), graphicsDevice.Viewport.Height - 1150, 122, 225),
                                RightEnemyWalk1, difficulty, false, gameTime);
                        enemies.Add(enemy);
                    }
                    break;

                case PlatformVersion.Medium:
                    // bottom level
                    for (int i = 0; i < rng.Next(1, numberOfEnemies + 1) + 1; i++)
                    {
                        Enemy enemy = new Enemy(new Rectangle(rng.Next(-1800, -500), graphicsDevice.Viewport.Height - 350, 122, 225),
                                RightEnemyWalk1, difficulty, false, gameTime);
                        enemies.Add(enemy);
                    }
                    for (int i = 0; i < rng.Next(1, numberOfEnemies + 1) + 1; i++)
                    {
                        Enemy enemy = new Enemy(new Rectangle(rng.Next(800, 1800), graphicsDevice.Viewport.Height - 350, 122, 225),
                                RightEnemyWalk1, difficulty, false, gameTime);
                        enemies.Add(enemy);
                    }

                    // First level
                    for (int i = 0; i < rng.Next(1, numberOfEnemies + 1) + 1; i++)
                    {
                        Enemy enemy = new Enemy(new Rectangle(rng.Next(-1800, -100), graphicsDevice.Viewport.Height - 750, 122, 225),
                                RightEnemyWalk1, difficulty, false, gameTime);
                        enemies.Add(enemy);
                    }
                    for (int i = 0; i < rng.Next(1, numberOfEnemies + 1) + 1; i++)
                    {
                        Enemy enemy = new Enemy(new Rectangle(rng.Next(0, 900), graphicsDevice.Viewport.Height - 750, 122, 225),
                                RightEnemyWalk1, difficulty, false, gameTime);
                        enemies.Add(enemy);
                    }

                    // Second level
                    for (int i = 0; i < rng.Next(1, numberOfEnemies + 1) + 1; i++)
                    {
                        Enemy enemy = new Enemy(new Rectangle(rng.Next(-900, 900), graphicsDevice.Viewport.Height - 1150, 122, 225),
                                RightEnemyWalk1, difficulty, false, gameTime);
                        enemies.Add(enemy);
                    }
                    for (int i = 0; i < rng.Next(1, numberOfEnemies + 1) + 1; i++)
                    {
                        Enemy enemy = new Enemy(new Rectangle(rng.Next(1000, 1800), graphicsDevice.Viewport.Height - 1150, 122, 225),
                                RightEnemyWalk1, difficulty, false, gameTime);
                        enemies.Add(enemy);
                    }

                    // Third level
                    for (int i = 0; i < rng.Next(1, numberOfEnemies + 1) + 1; i++)
                    {
                        Enemy enemy = new Enemy(new Rectangle(rng.Next(-1800, -100), graphicsDevice.Viewport.Height - 1550, 122, 225),
                                RightEnemyWalk1, difficulty, false, gameTime);
                        enemies.Add(enemy);
                    }
                    for (int i = 0; i < rng.Next(1, numberOfEnemies + 1) + 1; i++)
                    {
                        Enemy enemy = new Enemy(new Rectangle(rng.Next(0, 900), graphicsDevice.Viewport.Height - 1550, 122, 225),
                                RightEnemyWalk1, difficulty, false, gameTime);
                        enemies.Add(enemy);
                    }

                    // Fourth level
                    for (int i = 0; i < rng.Next(1, numberOfEnemies + 1) + 1; i++)
                    {
                        Enemy enemy = new Enemy(new Rectangle(rng.Next(-900, 900), graphicsDevice.Viewport.Height - 1950, 122, 225),
                                RightEnemyWalk1, difficulty, false, gameTime);
                        enemies.Add(enemy);
                    }
                    for (int i = 0; i < rng.Next(1, numberOfEnemies + 1) + 1 * 2; i++)
                    {
                        Enemy enemy = new Enemy(new Rectangle(rng.Next(1000, 1800), graphicsDevice.Viewport.Height - 1950, 122, 225),
                                RightEnemyWalk1, difficulty, false, gameTime);
                        enemies.Add(enemy);
                    }

                    // Fifth level
                    for (int i = 0; i < rng.Next(1, numberOfEnemies + 1) + 1 * 2; i++)
                    {
                        Enemy enemy = new Enemy(new Rectangle(rng.Next(-1800, -100), graphicsDevice.Viewport.Height - 2350, 122, 225),
                                RightEnemyWalk1, difficulty, false, gameTime);
                        enemies.Add(enemy);
                    }
                    for (int i = 0; i < rng.Next(1, numberOfEnemies + 1) + 1 * 2; i++)
                    {
                        Enemy enemy = new Enemy(new Rectangle(rng.Next(0, 900), graphicsDevice.Viewport.Height - 2350, 122, 255),
                                RightEnemyWalk1, difficulty, false, gameTime);
                        enemies.Add(enemy);
                    }
                    break;

                case PlatformVersion.Hard:
                    // Base level
                    for (int i = 0; i < rng.Next(0, numberOfEnemies + 1) + 1; i++)
                    {
                        Enemy enemy = new Enemy(new Rectangle(rng.Next(-2800, -500), graphicsDevice.Viewport.Height - 350, 122, 255),
                                RightEnemyWalk1, difficulty, false, gameTime);
                        enemies.Add(enemy);
                    }
                    for (int i = 0; i < rng.Next(0, numberOfEnemies + 1) + 1; i++)
                    {
                        Enemy enemy = new Enemy(new Rectangle(rng.Next(500, 2800), graphicsDevice.Viewport.Height - 350, 122, 255),
                                RightEnemyWalk1, difficulty, false, gameTime);
                        enemies.Add(enemy);
                    }

                    // First level
                    for (int i = 0; i < rng.Next(0, numberOfEnemies + 1) + 1; i++)
                    {
                        Enemy enemy = new Enemy(new Rectangle(rng.Next(-200, 250), graphicsDevice.Viewport.Height - 750, 122, 255),
                                RightEnemyWalk1, difficulty, false, gameTime);
                        enemies.Add(enemy);
                    }

                    // Second level
                    for (int i = 0; i < rng.Next(0, numberOfEnemies + 1) + 1; i++)
                    {
                        Enemy enemy = new Enemy(new Rectangle(rng.Next(-2500, -1700), graphicsDevice.Viewport.Height - 1150, 122, 255),
                                RightEnemyWalk1, difficulty, false, gameTime);
                        enemies.Add(enemy);
                    }
                    for (int i = 0; i < rng.Next(0, numberOfEnemies + 1) + 1; i++)
                    {
                        Enemy enemy = new Enemy(new Rectangle(rng.Next(1700, 2500), graphicsDevice.Viewport.Height - 1150, 122, 255),
                                RightEnemyWalk1, difficulty, false, gameTime);
                        enemies.Add(enemy);
                    }
                    for (int i = 0; i < rng.Next(0, numberOfEnemies + 1) + 1; i++)
                    {
                        Enemy enemy = new Enemy(new Rectangle(rng.Next(-200, 200), graphicsDevice.Viewport.Height - 1150, 122, 255),
                                RightEnemyWalk1, difficulty, false, gameTime);
                        enemies.Add(enemy);
                    }

                    // Third level
                    for (int i = 0; i < rng.Next(0, numberOfEnemies + 1) + 1; i++)
                    {
                        Enemy enemy = new Enemy(new Rectangle(rng.Next(-1800, -500), graphicsDevice.Viewport.Height - 1350, 122, 255),
                                RightEnemyWalk1, difficulty, false, gameTime);
                        enemies.Add(enemy);
                    }
                    for (int i = 0; i < rng.Next(0, numberOfEnemies + 1) + 1; i++)
                    {
                        Enemy enemy = new Enemy(new Rectangle(rng.Next(500, 1800), graphicsDevice.Viewport.Height - 1350, 122, 255),
                                RightEnemyWalk1, difficulty, false, gameTime);
                        enemies.Add(enemy);
                    }

                    // Fourth level
                    for (int i = 0; i < rng.Next(0, numberOfEnemies + 1) + 1; i++)
                    {
                        Enemy enemy = new Enemy(new Rectangle(rng.Next(-250, 250), graphicsDevice.Viewport.Height - 1750, 122, 255),
                                RightEnemyWalk1, difficulty, false, gameTime);
                        enemies.Add(enemy);
                    }
                    break;

                case PlatformVersion.Mean:
                    // Base level
                    for (int i = 0; i < rng.Next(0, numberOfEnemies + 1) + 1; i++)
                    {
                        Enemy enemy = new Enemy(new Rectangle(rng.Next(-3000, -1000), graphicsDevice.Viewport.Height - 350, 122, 255),
                                RightEnemyWalk1, difficulty, false, gameTime);
                        enemies.Add(enemy);
                    }
                    for (int i = 0; i < rng.Next(0, numberOfEnemies + 1) + 1; i++)
                    {
                        Enemy enemy = new Enemy(new Rectangle(rng.Next(1000, 3000), graphicsDevice.Viewport.Height - 350, 122, 255),
                                RightEnemyWalk1, difficulty, false, gameTime);
                        enemies.Add(enemy);
                    }

                    // First level
                    for (int i = 0; i < rng.Next(0, numberOfEnemies + 1) + 1; i++)
                    {
                        Enemy enemy = new Enemy(new Rectangle(rng.Next(-3000, -1250), graphicsDevice.Viewport.Height - 550, 122, 255),
                                RightEnemyWalk1, difficulty, false, gameTime);
                        enemies.Add(enemy);
                    }
                    for (int i = 0; i < rng.Next(0, numberOfEnemies + 1) + 1; i++)
                    {
                        Enemy enemy = new Enemy(new Rectangle(rng.Next(1250, 3000), graphicsDevice.Viewport.Height - 550, 122, 255),
                                RightEnemyWalk1, difficulty, false, gameTime);
                        enemies.Add(enemy);
                    }

                    // Second level
                    for (int i = 0; i < rng.Next(0, numberOfEnemies + 1) + 1; i++)
                    {
                        Enemy enemy = new Enemy(new Rectangle(rng.Next(-1100, -175), graphicsDevice.Viewport.Height - 750, 122, 255),
                                RightEnemyWalk1, difficulty, false, gameTime);
                        enemies.Add(enemy);
                    }
                    for (int i = 0; i < rng.Next(0, numberOfEnemies + 1) + 1; i++)
                    {
                        Enemy enemy = new Enemy(new Rectangle(rng.Next(175, 1100), graphicsDevice.Viewport.Height - 750, 122, 255),
                                RightEnemyWalk1, difficulty, false, gameTime);
                        enemies.Add(enemy);
                    }

                    // third level
                    for (int i = 0; i < rng.Next(0, numberOfEnemies + 1) + 1; i++)
                    {
                        Enemy enemy = new Enemy(new Rectangle(rng.Next(-2500, -500), graphicsDevice.Viewport.Height - 1150, 122, 255),
                                RightEnemyWalk1, difficulty, false, gameTime);
                        enemies.Add(enemy);
                    }
                    for (int i = 0; i < rng.Next(0, numberOfEnemies + 1) + 1; i++)
                    {
                        Enemy enemy = new Enemy(new Rectangle(rng.Next(500, 2500), graphicsDevice.Viewport.Height - 1150, 122, 255),
                                RightEnemyWalk1, difficulty, false, gameTime);
                        enemies.Add(enemy);
                    }
                    break;

                case PlatformVersion.Life:
                    // Base level
                    for (int i = 0; i < rng.Next(0, numberOfEnemies + 1) + 1; i++)
                    {
                        Enemy enemy = new Enemy(new Rectangle(rng.Next(-3000, -1000), graphicsDevice.Viewport.Height - 350, 122, 255),
                                RightEnemyWalk1, difficulty, false, gameTime);
                        enemies.Add(enemy);
                    }
                    for (int i = 0; i < rng.Next(0, numberOfEnemies + 1) + 1; i++)
                    {
                        Enemy enemy = new Enemy(new Rectangle(rng.Next(1000, 3000), graphicsDevice.Viewport.Height - 350, 122, 255),
                                RightEnemyWalk1, difficulty, false, gameTime);
                        enemies.Add(enemy);
                    }

                    // First level
                    for (int i = 0; i < rng.Next(0, numberOfEnemies + 1) + 1; i++)
                    {
                        Enemy enemy = new Enemy(new Rectangle(rng.Next(-3000, -1250), graphicsDevice.Viewport.Height - 550, 122, 255),
                                RightEnemyWalk1, difficulty, false, gameTime);
                        enemies.Add(enemy);
                    }
                    for (int i = 0; i < rng.Next(0, numberOfEnemies + 1) + 1; i++)
                    {
                        Enemy enemy = new Enemy(new Rectangle(rng.Next(1250, 3000), graphicsDevice.Viewport.Height - 550, 122, 255),
                                RightEnemyWalk1, difficulty, false, gameTime);
                        enemies.Add(enemy);
                    }

                    // Second level
                    for (int i = 0; i < rng.Next(0, numberOfEnemies + 1) + 1; i++)
                    {
                        Enemy enemy = new Enemy(new Rectangle(rng.Next(-1100, -175), graphicsDevice.Viewport.Height - 750, 122, 255),
                                RightEnemyWalk1, difficulty, false, gameTime);
                        enemies.Add(enemy);
                    }
                    for (int i = 0; i < rng.Next(0, numberOfEnemies + 1) + 1; i++)
                    {
                        Enemy enemy = new Enemy(new Rectangle(rng.Next(175, 1100), graphicsDevice.Viewport.Height - 750, 122, 255),
                                RightEnemyWalk1, difficulty, false, gameTime);
                        enemies.Add(enemy);
                    }

                    // third level
                    for (int i = 0; i < rng.Next(0, numberOfEnemies + 1) + 1; i++)
                    {
                        Enemy enemy = new Enemy(new Rectangle(rng.Next(-2500, -500), graphicsDevice.Viewport.Height - 1150, 122, 255),
                                RightEnemyWalk1, difficulty, false, gameTime);
                        enemies.Add(enemy);
                    }
                    for (int i = 0; i < rng.Next(0, numberOfEnemies + 1) + 1; i++)
                    {
                        Enemy enemy = new Enemy(new Rectangle(rng.Next(500, 2500), graphicsDevice.Viewport.Height - 1150, 122, 255),
                                RightEnemyWalk1, difficulty, false, gameTime);
                        enemies.Add(enemy);
                    }
                    break;
            }
            
        }
#endregion

        #region Fill Ranged List
        /// <summary>
        /// Fills enemy list with Ranged Enemies
        /// </summary>
        /// <param name="rng">Variable to set position</param>
        /// <param name="numberOfRanged">The number to spawn</param>
        /// <param name="graphicsDevice">Limits the enemies spawn point</param>
        /// <param name="rangeTexture">The texture for the Ranged Enemies</param>
        public void FillRangedList(Random rng, int numberOfRanged, int difficulty,
            GameTime gameTime, PlatformVersion platformVersion)
        {
            if (numberOfRanged > 0)
            {
                switch (platformVersion)
                {
                    case PlatformVersion.Easy:
                        // Base level
                        for (int i = 0; i < rng.Next(1, numberOfRanged + 1) + 1; i++)
                        {
                            Enemy enemy = new Enemy(new Rectangle(rng.Next(-3000, -1000), graphicsDevice.Viewport.Height - 350, 122, 255),
                                    RangedTexture, difficulty, true, gameTime);
                            enemies.Add(enemy);
                        }
                        for (int i = 0; i < rng.Next(1, numberOfRanged + 1) + 1; i++)
                        {
                            Enemy enemy = new Enemy(new Rectangle(rng.Next(1000, 3000), graphicsDevice.Viewport.Height - 350, 122, 255),
                                    RangedTexture, difficulty, true, gameTime);
                            enemies.Add(enemy);
                        }

                        // First level
                        for (int i = 0; i < rng.Next(1, numberOfRanged + 1) + 1; i++)
                        {
                            Enemy enemy = new Enemy(new Rectangle(rng.Next(-3000, -1250), graphicsDevice.Viewport.Height - 550, 122, 255),
                                    RangedTexture, difficulty, true, gameTime);
                            enemies.Add(enemy);
                        }
                        for (int i = 0; i < rng.Next(1, numberOfRanged + 1) + 1; i++)
                        {
                            Enemy enemy = new Enemy(new Rectangle(rng.Next(1250, 3000), graphicsDevice.Viewport.Height - 550, 122, 255),
                                    RangedTexture, difficulty, true, gameTime);
                            enemies.Add(enemy);
                        }

                        // Second level
                        for (int i = 0; i < rng.Next(1, numberOfRanged + 1) + 1; i++)
                        {
                            Enemy enemy = new Enemy(new Rectangle(rng.Next(-1100, -175), graphicsDevice.Viewport.Height - 750, 122, 255),
                                    RangedTexture, difficulty, true, gameTime);
                            enemies.Add(enemy);
                        }
                        for (int i = 0; i < rng.Next(1, numberOfRanged + 1) + 1; i++)
                        {
                            Enemy enemy = new Enemy(new Rectangle(rng.Next(175, 1100), graphicsDevice.Viewport.Height - 750, 122, 255),
                                    RangedTexture, difficulty, true, gameTime);
                            enemies.Add(enemy);
                        }

                        // third level
                        for (int i = 0; i < rng.Next(1, numberOfRanged + 1) + 1; i++)
                        {
                            Enemy enemy = new Enemy(new Rectangle(rng.Next(-2500, -500), graphicsDevice.Viewport.Height - 1150, 122, 255),
                                    RangedTexture, difficulty, true, gameTime);
                            enemies.Add(enemy);
                        }
                        for (int i = 0; i < rng.Next(1, numberOfRanged + 1) + 1; i++)
                        {
                            Enemy enemy = new Enemy(new Rectangle(rng.Next(500, 2500), graphicsDevice.Viewport.Height - 1150, 122, 255),
                                    RangedTexture, difficulty, true, gameTime);
                            enemies.Add(enemy);
                        }
                        break;

                    case PlatformVersion.Medium:
                        // bottom level
                        for (int i = 0; i < rng.Next(1, numberOfRanged + 1) + 1; i++)
                        {
                            Enemy enemy = new Enemy(new Rectangle(rng.Next(-1800, -500), graphicsDevice.Viewport.Height - 350, 122, 255),
                                    RangedTexture, difficulty, true, gameTime);
                            enemies.Add(enemy);
                        }
                        for (int i = 0; i < rng.Next(1, numberOfRanged + 1) + 1; i++)
                        {
                            Enemy enemy = new Enemy(new Rectangle(rng.Next(800, 1800), graphicsDevice.Viewport.Height - 350, 122, 255),
                                    RangedTexture, difficulty, true, gameTime);
                            enemies.Add(enemy);
                        }

                        // First level
                        for (int i = 0; i < rng.Next(1, numberOfRanged + 1) + 1; i++)
                        {
                            Enemy enemy = new Enemy(new Rectangle(rng.Next(-1800, -100), graphicsDevice.Viewport.Height - 750, 122, 255),
                                    RangedTexture, difficulty, true, gameTime);
                            enemies.Add(enemy);
                        }
                        for (int i = 0; i < rng.Next(1, numberOfRanged + 1) + 1; i++)
                        {
                            Enemy enemy = new Enemy(new Rectangle(rng.Next(0, 900), graphicsDevice.Viewport.Height - 750, 122, 255),
                                    RangedTexture, difficulty, true, gameTime);
                            enemies.Add(enemy);
                        }

                        // Second level
                        for (int i = 0; i < rng.Next(1, numberOfRanged + 1) + 1; i++)
                        {
                            Enemy enemy = new Enemy(new Rectangle(rng.Next(-900, 900), graphicsDevice.Viewport.Height - 1150, 122, 255),
                                    RangedTexture, difficulty, true, gameTime);
                            enemies.Add(enemy);
                        }
                        for (int i = 0; i < rng.Next(1, numberOfRanged + 1) + 1; i++)
                        {
                            Enemy enemy = new Enemy(new Rectangle(rng.Next(1000, 1800), graphicsDevice.Viewport.Height - 1150, 122, 255),
                                    RangedTexture, difficulty, true, gameTime);
                            enemies.Add(enemy);
                        }

                        // Third level
                        for (int i = 0; i < rng.Next(1, numberOfRanged + 1) + 1; i++)
                        {
                            Enemy enemy = new Enemy(new Rectangle(rng.Next(-1800, -100), graphicsDevice.Viewport.Height - 1550, 122, 255),
                                    RangedTexture, difficulty, true, gameTime);
                            enemies.Add(enemy);
                        }
                        for (int i = 0; i < rng.Next(1, numberOfRanged + 1) + 1; i++)
                        {
                            Enemy enemy = new Enemy(new Rectangle(rng.Next(0, 900), graphicsDevice.Viewport.Height - 1550, 122, 255),
                                    RangedTexture, difficulty, true, gameTime);
                            enemies.Add(enemy);
                        }

                        // Fourth level
                        for (int i = 0; i < rng.Next(1, numberOfRanged + 1) + 1; i++)
                        {
                            Enemy enemy = new Enemy(new Rectangle(rng.Next(-900, 900), graphicsDevice.Viewport.Height - 1950, 122, 255),
                                    RangedTexture, difficulty, true, gameTime);
                            enemies.Add(enemy);
                        }
                        for (int i = 0; i < rng.Next(1, numberOfRanged + 1) + 1 * 2; i++)
                        {
                            Enemy enemy = new Enemy(new Rectangle(rng.Next(1000, 1800), graphicsDevice.Viewport.Height - 1950, 122, 255),
                                    RangedTexture, difficulty, true, gameTime);
                            enemies.Add(enemy);
                        }

                        // Fifth level
                        for (int i = 0; i < rng.Next(1, numberOfRanged + 1) + 1 * 2; i++)
                        {
                            Enemy enemy = new Enemy(new Rectangle(rng.Next(-1800, -100), graphicsDevice.Viewport.Height - 2350, 122, 255),
                                    RangedTexture, difficulty, true, gameTime);
                            enemies.Add(enemy);
                        }
                        for (int i = 0; i < rng.Next(1, numberOfRanged + 1) + 1 * 2; i++)
                        {
                            Enemy enemy = new Enemy(new Rectangle(rng.Next(0, 900), graphicsDevice.Viewport.Height - 2350, 122, 255),
                                    RangedTexture, difficulty, true, gameTime);
                            enemies.Add(enemy);
                        }
                        break;

                    case PlatformVersion.Hard:
                        // Base level
                        for (int i = 0; i < rng.Next(0, numberOfRanged + 1) + 1; i++)
                        {
                            Enemy enemy = new Enemy(new Rectangle(rng.Next(-2800, -500), graphicsDevice.Viewport.Height - 350, 122, 255),
                                    RangedTexture, difficulty, true, gameTime);
                            enemies.Add(enemy);
                        }
                        for (int i = 0; i < rng.Next(0, numberOfRanged + 1) + 1; i++)
                        {
                            Enemy enemy = new Enemy(new Rectangle(rng.Next(500, 2800), graphicsDevice.Viewport.Height - 350, 122, 255),
                                    RangedTexture, difficulty, true, gameTime);
                            enemies.Add(enemy);
                        }

                        // First level
                        for (int i = 0; i < rng.Next(0, numberOfRanged + 1) + 1; i++)
                        {
                            Enemy enemy = new Enemy(new Rectangle(rng.Next(-200, 250), graphicsDevice.Viewport.Height - 750, 122, 255),
                                    RangedTexture, difficulty, true, gameTime);
                            enemies.Add(enemy);
                        }

                        // Second level
                        for (int i = 0; i < rng.Next(0, numberOfRanged + 1) + 1; i++)
                        {
                            Enemy enemy = new Enemy(new Rectangle(rng.Next(-2500, -1700), graphicsDevice.Viewport.Height - 1150, 122, 255),
                                    RangedTexture, difficulty, true, gameTime);
                            enemies.Add(enemy);
                        }
                        for (int i = 0; i < rng.Next(0, numberOfRanged + 1) + 1; i++)
                        {
                            Enemy enemy = new Enemy(new Rectangle(rng.Next(1700, 2500), graphicsDevice.Viewport.Height - 1150, 122, 255),
                                    RangedTexture, difficulty, true, gameTime);
                            enemies.Add(enemy);
                        }
                        for (int i = 0; i < rng.Next(0, numberOfRanged + 1) + 1; i++)
                        {
                            Enemy enemy = new Enemy(new Rectangle(rng.Next(-200, 200), graphicsDevice.Viewport.Height - 1150, 122, 255),
                                    RangedTexture, difficulty, true, gameTime);
                            enemies.Add(enemy);
                        }

                        // Third level
                        for (int i = 0; i < rng.Next(0, numberOfRanged + 1) + 1; i++)
                        {
                            Enemy enemy = new Enemy(new Rectangle(rng.Next(-1800, -500), graphicsDevice.Viewport.Height - 1350, 122, 255),
                                    RangedTexture, difficulty, true, gameTime);
                            enemies.Add(enemy);
                        }
                        for (int i = 0; i < rng.Next(0, numberOfRanged + 1) + 1; i++)
                        {
                            Enemy enemy = new Enemy(new Rectangle(rng.Next(500, 1800), graphicsDevice.Viewport.Height - 1350, 122, 255),
                                    RangedTexture, difficulty, true, gameTime);
                            enemies.Add(enemy);
                        }

                        // Fourth level
                        for (int i = 0; i < rng.Next(0, numberOfRanged + 1) + 1; i++)
                        {
                            Enemy enemy = new Enemy(new Rectangle(rng.Next(-250, 250), graphicsDevice.Viewport.Height - 1750, 122, 255),
                                    RangedTexture, difficulty, true, gameTime);
                            enemies.Add(enemy);
                        }
                        break;

                    case PlatformVersion.Mean:
                        // Base level
                        for (int i = 0; i < rng.Next(0, numberOfRanged + 1) + 1; i++)
                        {
                            Enemy enemy = new Enemy(new Rectangle(rng.Next(-3000, -1000), graphicsDevice.Viewport.Height - 350, 122, 255),
                                    RangedTexture, difficulty, true, gameTime);
                            enemies.Add(enemy);
                        }
                        for (int i = 0; i < rng.Next(0, numberOfRanged + 1) + 1; i++)
                        {
                            Enemy enemy = new Enemy(new Rectangle(rng.Next(1000, 3000), graphicsDevice.Viewport.Height - 350, 122, 255),
                                    RangedTexture, difficulty, true, gameTime);
                            enemies.Add(enemy);
                        }

                        // First level
                        for (int i = 0; i < rng.Next(0, numberOfRanged + 1) + 1; i++)
                        {
                            Enemy enemy = new Enemy(new Rectangle(rng.Next(-3000, -1250), graphicsDevice.Viewport.Height - 550, 122, 255),
                                    RangedTexture, difficulty, true, gameTime);
                            enemies.Add(enemy);
                        }
                        for (int i = 0; i < rng.Next(0, numberOfRanged + 1) + 1; i++)
                        {
                            Enemy enemy = new Enemy(new Rectangle(rng.Next(1250, 3000), graphicsDevice.Viewport.Height - 550, 122, 255),
                                    RangedTexture, difficulty, true, gameTime);
                            enemies.Add(enemy);
                        }

                        // Second level
                        for (int i = 0; i < rng.Next(0, numberOfRanged + 1) + 1; i++)
                        {
                            Enemy enemy = new Enemy(new Rectangle(rng.Next(-1100, -175), graphicsDevice.Viewport.Height - 750, 122, 255),
                                    RangedTexture, difficulty, true, gameTime);
                            enemies.Add(enemy);
                        }
                        for (int i = 0; i < rng.Next(0, numberOfRanged + 1) + 1; i++)
                        {
                            Enemy enemy = new Enemy(new Rectangle(rng.Next(175, 1100), graphicsDevice.Viewport.Height - 750, 122, 255),
                                    RangedTexture, difficulty, true, gameTime);
                            enemies.Add(enemy);
                        }

                        // third level
                        for (int i = 0; i < rng.Next(0, numberOfRanged + 1) + 1; i++)
                        {
                            Enemy enemy = new Enemy(new Rectangle(rng.Next(-2500, -500), graphicsDevice.Viewport.Height - 1150, 122, 255),
                                    RangedTexture, difficulty, true, gameTime);
                            enemies.Add(enemy);
                        }
                        for (int i = 0; i < rng.Next(0, numberOfRanged + 1) + 1; i++)
                        {
                            Enemy enemy = new Enemy(new Rectangle(rng.Next(500, 2500), graphicsDevice.Viewport.Height - 1150, 122, 255),
                                    RangedTexture, difficulty, true, gameTime);
                            enemies.Add(enemy);
                        }
                        break;

                    case PlatformVersion.Life:
                        // Base level
                        for (int i = 0; i < rng.Next(0, numberOfRanged + 1) + 1; i++)
                        {
                            Enemy enemy = new Enemy(new Rectangle(rng.Next(-3000, -1000), graphicsDevice.Viewport.Height - 350, 122, 225),
                                    RangedTexture, difficulty, true, gameTime);
                            enemies.Add(enemy);
                        }
                        for (int i = 0; i < rng.Next(0, numberOfRanged + 1) + 1; i++)
                        {
                            Enemy enemy = new Enemy(new Rectangle(rng.Next(1000, 3000), graphicsDevice.Viewport.Height - 350, 122, 255),
                                    RangedTexture, difficulty, true, gameTime);
                            enemies.Add(enemy);
                        }

                        // First level
                        for (int i = 0; i < rng.Next(0, numberOfRanged + 1) + 1; i++)
                        {
                            Enemy enemy = new Enemy(new Rectangle(rng.Next(-3000, -1250), graphicsDevice.Viewport.Height - 550, 122, 255),
                                    RangedTexture, difficulty, true, gameTime);
                            enemies.Add(enemy);
                        }
                        for (int i = 0; i < rng.Next(0, numberOfRanged + 1) + 1; i++)
                        {
                            Enemy enemy = new Enemy(new Rectangle(rng.Next(1250, 3000), graphicsDevice.Viewport.Height - 550, 122, 255),
                                    RangedTexture, difficulty, true, gameTime);
                            enemies.Add(enemy);
                        }

                        // Second level
                        for (int i = 0; i < rng.Next(0, numberOfRanged + 1) + 1; i++)
                        {
                            Enemy enemy = new Enemy(new Rectangle(rng.Next(-1100, -175), graphicsDevice.Viewport.Height - 750, 122, 255),
                                    RangedTexture, difficulty, true, gameTime);
                            enemies.Add(enemy);
                        }
                        for (int i = 0; i < rng.Next(0, numberOfRanged + 1) + 1; i++)
                        {
                            Enemy enemy = new Enemy(new Rectangle(rng.Next(175, 1100), graphicsDevice.Viewport.Height - 750, 122, 255),
                                    RangedTexture, difficulty, true, gameTime);
                            enemies.Add(enemy);
                        }

                        // third level
                        for (int i = 0; i < rng.Next(0, numberOfRanged + 1) + 1; i++)
                        {
                            Enemy enemy = new Enemy(new Rectangle(rng.Next(-2500, -500), graphicsDevice.Viewport.Height - 1150, 122, 255),
                                    RangedTexture, difficulty, true, gameTime);
                            enemies.Add(enemy);
                        }
                        for (int i = 0; i < rng.Next(0, numberOfRanged + 1) + 1; i++)
                        {
                            Enemy enemy = new Enemy(new Rectangle(rng.Next(500, 2500), graphicsDevice.Viewport.Height - 1150, 122, 255),
                                    RangedTexture, difficulty, true, gameTime);
                            enemies.Add(enemy);
                        }
                        break;
                }
            }
        }
        #endregion

        #region Enemy Move Method
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
                    if (new Rectangle(e.X, e.Y + 175, e.Position.Width, e.Position.Height - 175).Intersects(p.Position))
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

                // If left of player, move right and update frame and texture
                if (enemies[i].X > player.X - 1250 && enemies[i].X < player.X - 15 && enemies[i].Ranged == false 
                    && enemies[i].Y >= player.Y && enemies[i].Y - 200 <= player.Y)
                {
                    enemies[i].IsFacingLeft = false;
                    if (enemies[i].Texture == leftEnemyWalk1 || enemies[i].Texture == leftEnemyWalk2
                        || enemies[i].Texture == leftEnemyWalk3)
                    {
                        enemies[i].Texture = rightEnemyWalk1;
                        enemies[i].FrameCounter = 0;
                    }
                    enemies[i].FrameCounter++;
                    enemies[i].X += 5;
                    if (enemies[i].FrameCounter >= 5)
                    {
                        if (enemies[i].Texture == rightEnemyWalk1)
                        {
                            enemies[i].Texture = rightEnemyWalk2;
                        }
                        else if (enemies[i].Texture == rightEnemyWalk2)
                        {
                            enemies[i].Texture = rightEnemyWalk3;
                        }
                        else if (enemies[i].Texture == rightEnemyWalk3)
                        {
                            enemies[i].Texture = rightEnemyWalk1;
                        }
                        enemies[i].FrameCounter = 0;
                    }
                }

                // If right of player, move left and update frame and texture
                else if (enemies[i].X < player.X + 1250 && enemies[i].X > player.X + 15 && enemies[i].Ranged == false 
                    && enemies[i].Y >= player.Y && enemies[i].Y - 200 <= player.Y)
                {
                    enemies[i].IsFacingLeft = true;
                    if (enemies[i].Texture == rightEnemyWalk1 || enemies[i].Texture == rightEnemyWalk2
                        || enemies[i].Texture == rightEnemyWalk3)
                    {
                        enemies[i].Texture = leftEnemyWalk1;
                        enemies[i].FrameCounter = 0;
                    }
                    enemies[i].FrameCounter++;
                    enemies[i].X -= 5;
                    if (enemies[i].FrameCounter >= 5)
                    {
                        if (enemies[i].Texture == leftEnemyWalk1)
                        {
                            enemies[i].Texture = leftEnemyWalk2;
                        }
                        else if (enemies[i].Texture == leftEnemyWalk2)
                        {
                            enemies[i].Texture = leftEnemyWalk3;
                        }
                        else if (enemies[i].Texture == leftEnemyWalk3)
                        {
                            enemies[i].Texture = leftEnemyWalk1;
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
                
                // If left of player, move right and update frame and texture
                if (enemies[i].X > player.X - 1250 && enemies[i].X < player.X - 555 && enemies[i].Ranged
                    && enemies[i].Y >= player.Y && enemies[i].Y - 200 <= player.Y)
                {
                    enemies[i].IsFacingLeft = false;
                    enemies[i].X += 5;
                }

                // If right of player, move left and update frame and texture
                else if (enemies[i].X < player.X + 1250 && enemies[i].X > player.X + 15 && enemies[i].Ranged
                    && enemies[i].Y >= player.Y && enemies[i].Y - 200 <= player.Y)
                {
                    enemies[i].IsFacingLeft = true;
                    enemies[i].X -= 5;
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

            // Moving the bullets along
            foreach (Enemy e in enemies)
            {
                if (e.HasBullet && e.IsFacingLeft)
                {
                    e.BulletX -= 25;
                }

                if (e.HasBullet && e.IsFacingLeft == false)
                {
                    e.BulletX += 25;
                }

                if (e.BulletX > 3000 || e.BulletX < -3000)
                {
                    e.HasBullet = false;
                }
            }
        }
        #endregion
    }
}
