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
        private int dashDistance;
        private GameState gameState;
        private Texture2D background;
        private Background backgroundSelection;
        private int numberOfEnemies;
        private int numberOfRanged;

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
        public int DashDistance
        {
            get { return dashDistance; }
            set { dashDistance = value; }
        }
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
        
        //This is for the number of Melee Enemies
        public int NumberOfEnemies
        {
            get { return numberOfEnemies; }
            set { numberOfEnemies = value; }
        }

        //This is for number of Ranged Enemies
        public int NumberOfRanged
        {
            get { return numberOfRanged; }
            set { numberOfRanged = value; }
        }

        //constructor

        //temporary constructor
        public GameManager(Player player, List<Platform> platforms, GraphicsDevice graphicsDevice)
        {
            this.player = player;
            this.platforms = platforms;
            isCrouching = false;
            enemies = new List<Enemy>();
            this.graphicsDevice = graphicsDevice;
            dashDistance = 100;
            backgroundSelection = Purpose.Background.WhiteBackground;
        }

        //final constructor for when sprites are finished
        public GameManager(string playerName, Texture2D leftCrouchSprite, Texture2D rightCrouchSprite, Texture2D leftStandingSprite, 
            Texture2D rightStandingSprite, Texture2D rightJumpSprite, Texture2D leftJumpSprite, GraphicsDevice graphicsDevice, Random rng, int numberOfEnemies, int numberOfRanged, Texture2D enemyTexture)
        {
            enemies = new List<Enemy>();
            this.graphicsDevice = graphicsDevice;
            FillEnemyList(rng, numberOfEnemies, graphicsDevice, enemyTexture);
            //player = new Player(playerName, leftCrouchSprite, rightCrouchSprite, leftStandingSprite, rightStandingSprite, 
            //    rightJumpSprite, leftJumpSprite, graphicsDevice);
            dashDistance = 100;
        }

        //methods
        /// <summary>
        /// Allows the player to move and activate abilities
        /// </summary>
        /// <param name="kbState">The current state of teh keyboard</param>
        /// <param name="previouskbState">The previous state of the keyboard</param>
        /// <param name="ms">The current mouse state</param>
        /// <param name="previousMs">The previous mouse state</param>
        public void PlayerMove(KeyboardState kbState, KeyboardState previouskbState, MouseState ms, MouseState previousMs)
        {
            //a boolean representing if the player is on the platform
            bool onPlatform = false;

            //a loop to check if the player is on the platform
            foreach (Platform p in platforms)
            {
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
            }

            //checking keyboard state to make the player move
            if (kbState.IsKeyDown(Keys.A) || kbState.IsKeyDown(Keys.Left)) //move to the left
            {
                player.X -= 8;
                if (player.Texture == player.LeftStandingSprite || player.Texture == player.RightStandingSprite)
                {
                    player.Texture = player.LeftRunningSprite;
                }
                else if (player.Texture == player.LeftCrouchSprite || player.Texture == player.RightCrouchSprite)
                {
                    player.Texture = player.LeftCrouchSprite;
                }
                else
                {
                    player.Texture = player.LeftStandingSprite;
                }

            }
            if (kbState.IsKeyDown(Keys.D) || kbState.IsKeyDown(Keys.Right)) //move to the right
            {
                player.X += 8;
                if (player.Texture == player.LeftStandingSprite || player.Texture == player.RightStandingSprite)
                {
                    player.Texture = player.RightRunningSprite;
                }
                else if (player.Texture == player.LeftCrouchSprite || player.Texture == player.RightCrouchSprite)
                {
                    player.Texture = player.RightCrouchSprite;
                }
                else
                {
                    player.Texture = player.RightStandingSprite;
                }
            }
            if (kbState.IsKeyDown(Keys.Space) && !previouskbState.IsKeyDown(Keys.Space) && onPlatform && !isCrouching) //jump
            {
                player.Jump();
            }
            if (kbState.IsKeyDown(Keys.Q) && !previouskbState.IsKeyDown(Keys.Q) && !kbState.IsKeyDown(Keys.Space)) //dash
            {
                if (player.UgManager.DashActive)
                {
                    if (player.Texture == player.RightStandingSprite || player.Texture == player.RightCrouchSprite) //dash to the right
                    {
                        player.X += dashDistance;
                    }
                    else if (player.Texture == player.LeftStandingSprite || player.Texture == player.LeftCrouchSprite) //dash to the left
                    {
                        player.X -= dashDistance;
                    }
                }
            }
            if (kbState.IsKeyDown(Keys.S) && previouskbState.IsKeyUp(Keys.S) //crouch
                && !kbState.IsKeyDown(Keys.Space) && onPlatform)
            {
                isCrouching = player.Crouch(); //sets the isCrouching bool based on the Crouch() method
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

            //limiting player movement in both x directions and lower y direction
            if (player.X <= 0)
            {
                player.X = 0;
            }
            if (player.X >= graphicsDevice.Viewport.Width -200)
            {
                player.X = graphicsDevice.Viewport.Width-200;
            }
            if (player.Y >= graphicsDevice.Viewport.Height)
            {
                player.Y = graphicsDevice.Viewport.Height-200;
            }
        }

        /// <summary>
        /// Fills the List of enemies
        /// </summary>
        /// <param name="rng">A random variable to help set the enemies' positions</param>
        /// <param name="numberOfEnemies">The number of enemies to spawn in</param>
        /// <param name="graphicsDevice">The graphics device to help limit the enemies' spawn positions</param>
        /// <param name="enemyTexture">The texture of the enemies</param>
        public void FillEnemyList(Random rng, int numberOfEnemies, GraphicsDevice graphicsDevice, Texture2D enemyTexture)
        {
            for (int i = 0; i < NumberOfEnemies; i++)
            {
                Enemy enemy = new Enemy(new Rectangle(rng.Next(0, graphicsDevice.Viewport.Width), graphicsDevice.Viewport.Height - 450, 147, 147), enemyTexture, Level.One, false);
                enemies.Add(enemy);
            }
        }

        /// <summary>
        /// Fills enemy list with Ranged Enemies
        /// </summary>
        /// <param name="rng">Variable to set position</param>
        /// <param name="numberOfRanged">The number to spawn</param>
        /// <param name="graphicsDevice">Limits the enemies spawn point</param>
        /// <param name="rangeTexture">The texture for the Ranged Enemies</param>
        public void FillRangedList(Random rng, int numberOfRanged, GraphicsDevice graphicsDevice, Texture2D rangeTexture)
        {
            for (int i = 0; i < NumberOfRanged; i++)
            {
                Enemy enemy = new Enemy(new Rectangle(rng.Next(0, graphicsDevice.Viewport.Width), graphicsDevice.Viewport.Height - 450, 147, 147), rangeTexture, Level.One, true);
                enemies.Add(enemy);
            }
        }


        /// <summary>
        /// Allows the enemy to move
        /// </summary>
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
