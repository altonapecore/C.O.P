using System;
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
        private List<Platform> basePlatforms;
        private List<Platform> firstLevelPlatforms;
        private List<Platform> leftWalls;
        private List<Platform> rightWalls;
        private bool isCrouching;
        private GraphicsDevice graphicsDevice;
        private GameState gameState;
        private Texture2D background;
        private Background backgroundSelection;
        private int playerJumpNum;
        private int enemyJumpNum;
        private WaveNumber waveNumber;
        private int gravity = -2;

        //private List<Wave> waves;
        private List<Wave> waves;

        private TextureManager textureManager;
        private Texture2D rangeTexture;

        int keyCounter;
        int frameCounter;

        int healthFrameCounter;
        int staminaFrameCounter;

        private bool onBasePlatform;
        //private bool onPlatform;

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
        public int PlayerJumpNum
        {
            get { return playerJumpNum; }
            set { playerJumpNum = value; }
        }

        public int EnemyJumpNum
        {
            get { return enemyJumpNum; }
            set { enemyJumpNum = value; }
        }

        public Texture2D RangeTexture
        {
            get { return rangeTexture; }
            set { rangeTexture = value; }
        }

        public WaveNumber WaveNumber { get { return waveNumber; } set { waveNumber = value; } }

        //constructor
        public GameManager(Player player, List<Platform> platforms, List<Platform> basePlatforms, List<Platform> firstLevelPlatforms, List<Platform> leftWalls, List<Platform> rightWalls, GraphicsDevice graphicsDevice,
            TextureManager textureManager)
        {
            this.player = player;
            this.platforms = platforms;
            this.basePlatforms = basePlatforms;
            this.firstLevelPlatforms = firstLevelPlatforms;
            this.leftWalls = leftWalls;
            this.rightWalls = rightWalls;
            isCrouching = false;
            enemies = new List<Enemy>();
            this.graphicsDevice = graphicsDevice;
            backgroundSelection = Purpose.Background.WhiteBackground;
            this.textureManager = textureManager;
            waves = new List<Wave>();
            rangeTexture = textureManager.RangedEnemyTexture;
            waveNumber = WaveNumber.One;

            onBasePlatform = false;
            //onPlatform = false;
        }

        //methods
        /// <summary>
        /// Allows the player to move and activate abilities
        /// </summary>
        /// <param name="kbState">The current state of teh keyboard</param>
        /// <param name="previouskbState">The previous state of the keyboard</param>
        /// <param name="ms">The current mouse state</param>
        /// <param name="previousMs">The previous mouse state</param>
        public void PlayerMove(KeyboardState kbState, KeyboardState previouskbState, MouseState ms, MouseState previousMs, Camera2D camera, GameTime gameTime)
        {
            if (player.Stamina < player.StaminaMax && staminaFrameCounter >= 20)
            {
                player.Stamina += 1;
                staminaFrameCounter = 0;
            }
            else
            {
                staminaFrameCounter++;
            }
            if (player.Health < player.HealthMax && healthFrameCounter >= 80)
            {
                player.Health += 1;
                healthFrameCounter = 0;
            }
            else
            {
                healthFrameCounter++;
            }

            //a boolean representing if the player is on the platform
            bool onPlatform = false;

            if (player.Velocity > 0)
            {
                foreach (Platform p in platforms)
                {
                    if (new Rectangle(player.X, player.Y + 300, player.Position.Width, 52).Intersects(p.Position))
                    {
                        player.Velocity = 0;
                        onPlatform = true;
                        break;
                    }
                }
            }

            //if not, make them fall
            if (!onPlatform)
            {
                player.Y += player.Velocity;
                player.Velocity -= gravity;
                //moving camera with player
                camera.LookAt(new Vector2(player.X, player.Y - 250));
            }

            // Wall collisions
            foreach (Platform w in leftWalls)
            {
                if (player.Position.Intersects(w.Position))
                {
                    player.X = w.Position.X + w.Position.Width;
                }
            }
            foreach (Platform w in rightWalls)
            {
                if (player.Position.Intersects(w.Position))
                {
                    player.X = w.Position.X - player.Position.Width;
                }
            }

            //attack animation
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
            if (kbState.IsKeyDown(Keys.Space) && !previouskbState.IsKeyDown(Keys.Space) && !isCrouching)//jump
            {
                player.Jump();
            }
            if (kbState.IsKeyDown(Keys.Q) && !previouskbState.IsKeyDown(Keys.Q) && !kbState.IsKeyDown(Keys.Space)) //dash
            {
                if (player.UgManager.DashActive)
                {
                    player.Dash();
                    camera.LookAt(new Vector2(player.X, player.Y - 250));
                }           
            }
            if (kbState.IsKeyDown(Keys.S) && previouskbState.IsKeyUp(Keys.S) //crouch
                && !kbState.IsKeyDown(Keys.Space) && onPlatform)
            {
                isCrouching = player.Crouch(kbState); //sets the isCrouching bool based on the Crouch() method
            }

            // Player attack done here as well as enemy takeDamage
            if (ms.LeftButton == ButtonState.Pressed && previousMs.LeftButton == ButtonState.Released && !isCrouching)
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
                    enemies[i].TakeDamage(player.Attack(enemies[i], gameTime));
                    if (enemies[i].IsDead)
                    {
                        enemies.RemoveAt(i);
                        player.Kills++;
                        if(player.Kills != 0 && player.Kills % 3 == 0)
                        {
                            player.UgManager.UpgradePoints++;
                        }
                    }
                }
            }
            if (kbState.IsKeyDown(Keys.E) && previouskbState.IsKeyUp(Keys.E) && player.UgManager.GroundPoundActive && ms.LeftButton == ButtonState.Released 
                && !isCrouching)
            {
                if (frameCounter == 3)
                {
                    player.GroundPound(enemies);
                    frameCounter = 0;
                }
                else if (frameCounter != 3)
                {
                    frameCounter++;
                }
            }
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
            GameTime gameTime )
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
        public void EnemyMove(GameTime gameTime)
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
                    if (enemies[i].Texture == textureManager.LeftEnemyWalk1 || enemies[i].Texture == textureManager.LeftEnemyWalk2 
                        || enemies[i].Texture == textureManager.LeftEnemyWalk3)
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
            for(int i = 0; i < enemies.Count; i++)
            {
                if(enemies[i].Y >= 745)
                {
                    enemies.Remove(enemies[i]);
                }
            }

            foreach(Enemy e in enemies)
            {
                //e.GameTime = (int)gameTime.TotalGameTime.TotalSeconds;
                // Call attack methods based on type of enemy and position
                int damage = 0;
                if (e.Ranged && e.IsFacingLeft)
                {
                    damage = e.Attack(player, gameTime);
                }

                else if(e.Ranged && !e.IsFacingLeft)
                {
                    damage = e.Attack(player, gameTime);
                }

                else if(!e.Ranged && e.IsFacingLeft)
                {
                    damage = e.Attack(player, gameTime);
                }

                else if (!e.Ranged && !e.IsFacingLeft)
                {
                    damage = e.Attack(player, gameTime);
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
        public void ResetOnPlayerDeath(Camera2D camera, Random rng, int worldLeftEndWidth, int worldRightEndWidth, GameTime gameTime, Texture2D tempTexture)
        {
            player.Health = 100;
            player.HealthMax = player.Health;
            camera.Zoom = 1.0f;
            player.IsDead = false;
            player.X = 225;
            player.Y = 225;
            isCrouching = false;
            player.UgManager.DashActive = false;
            player.UgManager.GroundPoundActive = false;
            enemies.Clear();
            FillEnemyList(rng, waves[0].NumberOfMelee, waves[0].Difficulty, worldLeftEndWidth, worldRightEndWidth, gameTime);
            FillRangedList(rng, waves[0].NumberOfRanged, waves[0].Difficulty, worldLeftEndWidth, worldRightEndWidth, tempTexture, gameTime);
            player.UgManager.UpgradePoints = 0;            
        }

        public void ResetForNextWave(Camera2D camera, Random rng, int worldLeftEndWidth, int worldRightEndWidth, GameTime gameTime, Texture2D tempTexture, int waveNumber)
        {
            camera.Zoom = 1.0f;
            player.X = 225;
            player.Y = 225;
            isCrouching = false;
            enemies.Clear();
            FillEnemyList(rng, waves[waveNumber].NumberOfMelee, waves[waveNumber].Difficulty, worldLeftEndWidth, worldRightEndWidth, gameTime);
            FillRangedList(rng, waves[waveNumber].NumberOfRanged, waves[waveNumber].Difficulty, worldLeftEndWidth, worldRightEndWidth,
                tempTexture, gameTime);
        }
    }
}
