﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using MonoGame.Extended;
using System.Threading;

namespace Purpose
{
    public enum Background
    {
        WhiteBackground,
        MetalBackground,
        RustBackground
    }
    public class GameManager
    {
        //fields
        private List<Enemy> enemies;
        private Player player;
        private List<Platform> platforms;
        private bool isCrouching;
        private GraphicsDevice graphicsDevice;
        private GameState gameState;
        private Texture2D background;
        private Background backgroundSelection;
        private int jumpNum;
        private bool abovePlatform;
        private WaveNumber waveNumber;

        ////Deals with the enemies
        //private int numberOfEnemies;
        //private int numberOfRanged;
        //private int difficulty;

        //private List<Wave> waves;
        private List<Wave> waves;

        private TextureManager textureManager;
        private Texture2D rangeTexture;

        int keyCounter;
        int frameCounter;

        //properties
        public List<Enemy> Enemies { get { return enemies; } }
        public Player Player { get { return player; } }
        public List<Platform> Platforms { get { return platforms; } }
        public bool IsCrouching
        {
            get { return isCrouching; }
            set { isCrouching = value; }
        }
        public GraphicsDevice GraphicsDevice { get { return graphicsDevice; } }

        public GameState GameState
        {
            get { return gameState; }
            set { gameState = value; }
        }

        public Texture2D Background
        {
            get { return background; }
            set { background = value; }
        }

        public Background BackgroundSelection
        {
            get { return backgroundSelection; }
            set { backgroundSelection = value; }
        }

        public List<Wave> Waves
        {
            get { return waves; }
            set { waves = value; }
        }

        // This is for jump logic
        public int JumpNum
        {
            get { return jumpNum; }
            set { jumpNum = value; }
        }

        public Texture2D RangeTexture
        {
            get { return rangeTexture; }
            set { rangeTexture = value; }
        }

        public WaveNumber WaveNumber { get { return waveNumber; } set { waveNumber = value; } }

        //constructor

        //temporary constructor
        public GameManager(Player player, List<Platform> platforms, GraphicsDevice graphicsDevice, TextureManager textureManager)
        {
            this.player = player;
            this.platforms = platforms;
            isCrouching = false;
            enemies = new List<Enemy>();
            this.graphicsDevice = graphicsDevice;
            backgroundSelection = Purpose.Background.WhiteBackground;
            this.textureManager = textureManager;
            waves = new List<Wave>();
            rangeTexture = textureManager.RangedEnemyTexture;
            waveNumber = WaveNumber.One;
        }

        //methods
        /// <summary>
        /// Allows the player to move and activate abilities
        /// </summary>
        /// <param name="kbState">The current state of teh keyboard</param>
        /// <param name="previouskbState">The previous state of the keyboard</param>
        /// <param name="ms">The current mouse state</param>
        /// <param name="previousMs">The previous mouse state</param>
        public void PlayerMove(KeyboardState kbState, KeyboardState previouskbState, MouseState ms, MouseState previousMs, Camera2D camera, List<Platform> platforms, GameTime gameTime)
        {
            //a boolean representing if the player is on the platform
            bool onPlatform = false;

            //a loop to check if the player is on the platform
            foreach (Platform p in platforms)
            {
                abovePlatform = p.AbovePlatform(platforms);
                if (player.Position.Intersects(p.Position))
                {
                    onPlatform = true;
                    break;
                }
            }
            //if not, make them fall
            if (!onPlatform)
            {
                player.Y += 5;
                // moving camera with player
                camera.LookAt(new Vector2(player.X, player.Y - 250));
            }

            if (player.Texture == textureManager.LeftPlayerAttack1)
            {
                frameCounter++;
                if (frameCounter == 5)
                {
                    player.Texture = textureManager.LeftPlayerAttack2;
                    frameCounter = 0;
                }
                return;
            }
            else if (player.Texture == textureManager.RightPlayerAttack1)
            {
                frameCounter++;
                if (frameCounter == 5)
                {
                    player.Texture = textureManager.RightPlayerAttack2;
                    frameCounter = 0;
                }
                return;
            }
            else if (player.Texture == textureManager.LeftPlayerAttack2)
            {
                frameCounter++;
                if (frameCounter == 5)
                {
                    player.Texture = textureManager.LeftStandingSprite;
                    frameCounter = 0;
                }
                else { return; }
            }
            else if (player.Texture == textureManager.RightPlayerAttack2)
            {
                frameCounter++;
                if (frameCounter == 5)
                {
                    player.Texture = textureManager.RightStandingSprite;
                    frameCounter = 0;
                }
                else { return; }
            }
            //checking keyboard state to make the player move
            if (kbState.IsKeyDown(Keys.A) || kbState.IsKeyDown(Keys.Left)) //move to the left
            {
                //first check to see if the player is crouching
                if (isCrouching)
                {
                    player.Texture = textureManager.LeftCrouchSprite;
                    player.X -= 8;
                    // moving camera with player
                    camera.LookAt(new Vector2(player.X, player.Y - 250));
                    return;
                }

                //if neither key was down previously reset keyCounter
                if (previouskbState.IsKeyUp(Keys.A) && previouskbState.IsKeyUp(Keys.Left))
                {
                    keyCounter = 0;
                }
                //add to the key counter if the key has continuously been down
                if (previouskbState.IsKeyDown(Keys.A) || previouskbState.IsKeyDown(Keys.Left))
                {
                    keyCounter++;
                }
                //if keyCounter is 0, change to the appropriate texture
                if (keyCounter == 0)
                {
                    player.Texture = textureManager.LeftStandingSprite;
                }

                // Has the player been pressing the key for long enough?
                if (keyCounter >= 5)
                {
                    keyCounter = 0;
                    // Update the frame and wrap
                    if (player.Texture == textureManager.LeftStandingSprite)
                    {
                        player.Texture = textureManager.LeftMiddleRunningSprite;
                    }
                    else if (player.Texture == textureManager.LeftMiddleRunningSprite)
                    {
                        player.Texture = textureManager.LeftRunningSprite;
                    }
                    else if (player.Texture == textureManager.LeftRunningSprite)
                    {
                        player.Texture = textureManager.LeftStandingSprite;
                    }
                }
                player.X -= 8;
                // moving camera with player
                camera.LookAt(new Vector2(player.X, player.Y - 250));
            }
            if (kbState.IsKeyDown(Keys.D) || kbState.IsKeyDown(Keys.Right)) //move to the right
            {
                //first check to see if player is crouching
                if (isCrouching)
                {
                    player.Texture = textureManager.RightCrouchSprite;
                    player.X += 8;
                    // moving camera with player
                    camera.LookAt(new Vector2(player.X, player.Y - 250));
                    return;
                }

                //neither key was down previously reset the counter
                if (previouskbState.IsKeyUp(Keys.D) && previouskbState.IsKeyUp(Keys.Right))
                {
                    keyCounter = 0;
                }
                //if either key was down continously add to the counter
                if (previouskbState.IsKeyDown(Keys.D) || previouskbState.IsKeyDown(Keys.Right))
                {
                    keyCounter++;
                }
                //if keyCounter is 0 change to the appropriate texture
                if (keyCounter == 0)
                {
                    player.Texture = textureManager.RightStandingSprite;
                }

                // Has the player been pressing the key for long enough
                if (keyCounter >= 5)
                {
                    keyCounter = 0;
                    // Update the frame and wrap
                    if (player.Texture == textureManager.RightStandingSprite)
                    {
                        player.Texture = textureManager.RightMiddleRunningSprite;
                    }
                    else if (player.Texture == textureManager.RightMiddleRunningSprite)
                    {
                        player.Texture = textureManager.RightRunningSprite;
                    }
                    else if (player.Texture == textureManager.RightRunningSprite)
                    {
                        player.Texture = textureManager.RightStandingSprite;
                    }
                }
                player.X += 8;
                // moving camera with player
                camera.LookAt(new Vector2(player.X, player.Y - 250));
            }
            if (kbState.IsKeyDown(Keys.Space) && !previouskbState.IsKeyDown(Keys.Space) && onPlatform && !isCrouching) //jump
            {
                jumpNum = 1;
            }
            if (kbState.IsKeyDown(Keys.Q) && !previouskbState.IsKeyDown(Keys.Q) && !kbState.IsKeyDown(Keys.Space)) //dash
            {
                if (player.UgManager.DashActive)
                {
                    if (player.Texture == textureManager.RightStandingSprite || player.Texture == textureManager.RightRunningSprite
                        || player.Texture == textureManager.RightCrouchSprite) //dash to the right
                    {
                        player.X += player.DashDistance;
                        // moving camera with player
                        camera.LookAt(new Vector2(player.X, player.Y - 250));
                    }
                    else if (player.Texture == textureManager.LeftStandingSprite || player.Texture == textureManager.LeftRunningSprite
                        || player.Texture == textureManager.LeftCrouchSprite) //dash to the left
                    {
                        player.X -= player.DashDistance;
                        // moving camera with player
                        camera.LookAt(new Vector2(player.X, player.Y - 250));
                    }
                    
                }              
            }
            if (kbState.IsKeyDown(Keys.S) && previouskbState.IsKeyUp(Keys.S) //crouch
                && !kbState.IsKeyDown(Keys.Space) && onPlatform)
            {
                isCrouching = player.Crouch(kbState); //sets the isCrouching bool based on the Crouch() method
            }
            // Player attack done here as well as enemy takeDamage
            if (ms.LeftButton == ButtonState.Pressed && previousMs.LeftButton == ButtonState.Released)
            {
                if (player.Texture == textureManager.LeftCrouchSprite || player.Texture == textureManager.LeftJumpSprite ||
                        player.Texture == textureManager.LeftRunningSprite || player.Texture == textureManager.LeftStandingSprite ||
                        player.Texture == textureManager.LeftMiddleRunningSprite)
                {
                    player.Texture = textureManager.LeftPlayerAttack1;
                }
                else if (player.Texture == textureManager.RightCrouchSprite || player.Texture == textureManager.RightJumpSprite ||
                        player.Texture == textureManager.RightRunningSprite || player.Texture == textureManager.RightStandingSprite ||
                        player.Texture == textureManager.RightMiddleRunningSprite)
                {
                    player.Texture = textureManager.RightPlayerAttack1;
                }
                for (int i = 0; i < enemies.Count; i++)
                {
                    enemies[i].TakeDamage(player.Attack(enemies[i].Position, gameTime));
                    if (enemies[i].IsDead)
                    {
                        enemies.RemoveAt(i);
                        player.Kills++;
                        if(player.Kills != 0 && player.Kills % 5 == 0)
                        {
                            player.UgManager.UpgradePoints++;
                        }
                    }
                }
            }


            //limiting player movement in both x directions and lower y direction
            //if (player.X <= 0)
            //{
            //    player.X = 0;
            //}
            //if (player.X >= graphicsDevice.Viewport.Width-200)
            //{
            //    player.X = graphicsDevice.Viewport.Width-200;
            //}
            //if (player.Y >= graphicsDevice.Viewport.Height)
            //{
            //    player.Y = graphicsDevice.Viewport.Height - 200;
            //}


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
                    Enemy enemy = new Enemy(new Rectangle(rng.Next(worldLeftEndWidth, 0), graphicsDevice.Viewport.Height - 450, 122, 250),
                        textureManager.RightEnemyWalk1, Level.One, false, gameTime);
                    enemies.Add(enemy);
                }

                else if (choice == 2)
                {
                    Enemy enemy = new Enemy(new Rectangle(rng.Next(0, worldRightEndWidth), graphicsDevice.Viewport.Height - 450, 122, 250),
                        textureManager.LeftEnemyWalk1, Level.One, false, gameTime);
                    enemies.Add(enemy);
                }

                else if (choice == 3)
                {
                    Enemy enemy = new Enemy(new Rectangle(rng.Next(worldLeftEndWidth, 0), graphicsDevice.Viewport.Height - 750, 122, 250),
                        textureManager.RightEnemyWalk1, Level.One, false, gameTime);
                    enemies.Add(enemy);
                }

                else if (choice == 4)
                {
                    Enemy enemy = new Enemy(new Rectangle(rng.Next(0, worldRightEndWidth), graphicsDevice.Viewport.Height - 750, 122, 250),
                        textureManager.LeftEnemyWalk1, Level.One, false, gameTime);
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
                    Enemy enemy = new Enemy(new Rectangle(rng.Next(worldLeftEndWidth, 0), graphicsDevice.Viewport.Height - 450, 147, 147),
                        rangeTexture, Level.One, true, gameTime);
                    enemies.Add(enemy);
                }

                else if (choice == 2)
                {
                    Enemy enemy = new Enemy(new Rectangle(rng.Next(0, worldRightEndWidth), graphicsDevice.Viewport.Height - 450, 147, 147),
                        rangeTexture, Level.One, true, gameTime);
                    enemies.Add(enemy);
                }

                else if (choice == 3)
                {
                    Enemy enemy = new Enemy(new Rectangle(rng.Next(worldLeftEndWidth, 0), graphicsDevice.Viewport.Height - 750, 147, 147),
                        rangeTexture, Level.One, true, gameTime);
                    enemies.Add(enemy);
                }

                else if (choice == 4)
                {
                    Enemy enemy = new Enemy(new Rectangle(rng.Next(0, worldRightEndWidth), graphicsDevice.Viewport.Height - 750, 147, 147),
                        rangeTexture, Level.One, true, gameTime);
                    enemies.Add(enemy);
                }
            }
        }


        /// <summary>
        /// Allows the enemy to move
        /// </summary>
        public void EnemyMove(GameTime gameTime)
        {
            // On platform and gravity stuff
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

            for (int i = 0; i < enemies.Count; i++)
            {
                //if (Math.Abs(enemies[i].X -player.X) < 100)
                //{
                //    return;
                //}

                // Limiting stuff for melee enemies
                if(enemies[i].X == player.X - 15 && enemies[i].Ranged == false)
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
                    if (enemies[i].Texture == textureManager.LeftEnemyWalk1 || enemies[i].Texture == textureManager.LeftEnemyWalk2 || enemies[i].Texture == textureManager.LeftEnemyWalk3)
                    {
                        enemies[i].Texture = textureManager.RightEnemyWalk1;
                        enemies[i].FrameCounter = 0;
                    }
                    enemies[i].FrameCounter++;
                    enemies[i].X += 5;
                    if (enemies[i].FrameCounter >= 5 )
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
                else if(enemies[i].X > player.X + 15 && enemies[i].Ranged == false)
                {
                    enemies[i].IsFacingLeft = true;
                    if (enemies[i].Texture == textureManager.RightEnemyWalk1 || enemies[i].Texture == textureManager.RightEnemyWalk2 || enemies[i].Texture == textureManager.RightEnemyWalk3)
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
                    if (enemies[i].Texture == textureManager.LeftEnemyWalk1 || enemies[i].Texture == textureManager.LeftEnemyWalk2 || enemies[i].Texture == textureManager.LeftEnemyWalk3)
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
                    if (enemies[i].Texture == textureManager.RightEnemyWalk1 || enemies[i].Texture == textureManager.RightEnemyWalk2 || enemies[i].Texture == textureManager.RightEnemyWalk3)
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
            for(int i = 0; i < enemies.Count; i++)
            {
                if(enemies[i].Y >= 745)
                {
                    enemies.Remove(enemies[i]);
                }
            }

            foreach(Enemy e in enemies)
            {
                // Call attack methods based on type of enemy and position
                int damage = 0;
                if (e.Ranged && e.IsFacingLeft)
                {
                    damage = e.Attack(new Rectangle(player.Position.X - 555, player.Position.Y, player.Position.Width, player.Position.Height), gameTime);
                }

                else if(e.Ranged && e.IsFacingLeft == false)
                {
                    damage = e.Attack(new Rectangle(player.Position.X + 555, player.Position.Y, player.Position.Width, player.Position.Height), gameTime);
                }

                else if(e.Ranged == false && e.IsFacingLeft)
                {
                    damage = e.Attack(new Rectangle(player.Position.X - 15, player.Position.Y, player.Position.Width, player.Position.Height), gameTime);
                }

                else if (e.Ranged == false && e.IsFacingLeft == false)
                {
                    damage = e.Attack(new Rectangle(player.Position.X + 15, player.Position.Y, player.Position.Width, player.Position.Height), gameTime);
                }
                player.TakeDamage(damage);

                // Moving the bullets along
                if(e.HasBullet && e.IsFacingLeft)
                {
                    e.BulletX -= 25;
                }

                if (e.HasBullet && e.IsFacingLeft == false)
                {
                    e.BulletX += 25;
                }
            }
        }

        /// <summary>
        /// Resets game to beginning
        /// </summary>
        public void ResetGame(Camera2D camera, Random rng, int worldLeftEndWidth, int worldRightEndWidth, GameTime gameTime, Texture2D tempTexture, int i)
        {
            player.Health = 100;
            waveNumber = WaveNumber.One;
            isCrouching = false;
            enemies.Clear();
            FillEnemyList(rng, waves[i].NumberOfMelee, waves[i].Difficulty, worldLeftEndWidth, worldRightEndWidth, gameTime);
            FillRangedList(rng, waves[i].NumberOfRanged, waves[i].Difficulty, worldLeftEndWidth, worldRightEndWidth, tempTexture, gameTime);
            camera.Zoom = 1.0f;
            player.UgManager.UpgradePoints = 0;
        }
    }
}
