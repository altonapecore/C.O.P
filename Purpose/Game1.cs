using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using MonoGame.Extended;
using MonoGame.Extended.ViewportAdapters;

namespace Purpose
{
    /// <summary>
    /// It's ya boy, Alex
    /// Nicholas needs a medic
    /// Overlord Trent has arrived.
    /// Vansh is here
    /// </summary>

    //Enums
    public enum Level
    {
        One,
        Two,
        Three,
    }

    public enum WaveNumber
    {
        One,
        Two, 
        Three, 
        Four, 
        Five
    }

    public enum GameState
    {
        Menu,
        Game,
        Pause,
        UpgradeMenu,
        NextWave,
        GameOver
    }
    public class Game1 : Game
    {
        //Fields 
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private KeyboardState kbState;
        private MouseState ms;
        private Player player;
        private Texture2D background;
        private GameManager gameManager;
        private List<Platform> bottomPlatforms;
        private List<Platform> firstLevelPlatforms;
        private List<Platform> totalPlatforms;
        private Texture2D basePlatform;
        private Texture2D notBasePlatform;
        private Camera2D camera;
        private int worldLeftEndWidth;
        private int worldRightEndWidth;
        private int worldTopHeight;
        private int worldBottomHeight;
        private GameTime gameTime;

        private Texture2D startScreen;
        private GameObject startButton;

        private Texture2D buttonFrame;
        private Texture2D roundedFrame;

        private Texture2D upgradeScreen;
        private GameObject returnToNewWaveButton;
        private GameObject groundPoundButton;
        private GameObject attackUpButton;
        private GameObject staminaUpButton;
        private GameObject healthUpButton;
        private GameObject dashButton;
        private GameObject dashDistanceUpButton;

        private Texture2D pauseScreen;
        private GameObject returnToGameButton;

        private Texture2D nextWaveScreen;
        private GameObject goOnButton;
        private GameObject upgradesButton;

        public Texture2D gameOver;
        public GameObject returnToMenuButton;

        //Field for the Reader
        private Reader reader;

        //textureManager object
        private TextureManager textureManager;

        //Field for the Wave
        private Wave wave;
        //private Game1 game1;

        //temporary stuff
        private Texture2D tempTexture;
        private Vector2 healthBar = new Vector2(10, 10);
        //private Texture2D tempCrouchTexture;
        private Texture2D trent;
        private SpriteFont comicSans24;
        private SpriteFont agency30;
        private Random rng;

        //Temporary BackGround
        private Texture2D whiteBack;
        private Texture2D rustyBack;
        private Texture2D metalBack;

        public Random Rng
        {
            get { return rng; }
            set { rng = value; }
        }

        public int WorldLeftEndWidth
        {
            get { return worldLeftEndWidth; }
            set { worldLeftEndWidth = value; }
        }

        public int WorldRightEndWidth
        {
            get { return worldRightEndWidth; }
            set { worldRightEndWidth = value; }
        }

        public GameTime GameTime
        {
            get { return gameTime; }
            set { gameTime = value; }
        }

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            // Set screen size
            graphics.IsFullScreen = false;
            graphics.PreferredBackBufferHeight = 845;
            graphics.PreferredBackBufferWidth = 1350;

            // Temp coding stuffs
            rng = new Random();

            // Set size of world width and height
            worldLeftEndWidth = -5000;
            worldRightEndWidth = 5000;
            worldTopHeight = -2000;
            worldBottomHeight = 1000;

            // Initialize gameTime
            gameTime = new GameTime();
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // Make mouse visible
            this.IsMouseVisible = true;
            //Initialize the Window Form
            base.Initialize();
            //bottomPlatforms = new List<Platform>();
            ViewportAdapter viewportAdapter = new BoxingViewportAdapter(Window, GraphicsDevice, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
            camera = new Camera2D(viewportAdapter);
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // Load in textures
            tempTexture = Content.Load<Texture2D>("pineapple");
            comicSans24 = Content.Load<SpriteFont>("ComicSans24");
            agency30 = Content.Load<SpriteFont>("Agency30");
            startScreen = Content.Load<Texture2D>("StartMenu");
            buttonFrame = Content.Load<Texture2D>("buttonFrame2");
            roundedFrame = Content.Load<Texture2D>("roundedFrame");
            upgradeScreen = Content.Load<Texture2D>("UpgradeUI");
            pauseScreen = Content.Load<Texture2D>("PauseMenu");
            nextWaveScreen = Content.Load<Texture2D>("NextWaveMenu");
            gameOver = Content.Load<Texture2D>("GameOver");

            //temporary background
            whiteBack = Content.Load<Texture2D>("whiteback");
            metalBack = Content.Load<Texture2D>("metalback");
            rustyBack = Content.Load<Texture2D>("rustyback");

            background = metalBack;
            //background = Content.Load<Texture2D>("background");
            basePlatform = Content.Load<Texture2D>("PlatformTest");
            notBasePlatform = Content.Load<Texture2D>("PlatformTest2");

            startButton = new GameObject(buttonFrame, new Rectangle(500, 335, 349, 155));
            returnToNewWaveButton = new GameObject(buttonFrame, new Rectangle(10,340,242,109));
            returnToGameButton = new GameObject(buttonFrame, new Rectangle(500, 280, 349, 160));
            goOnButton = new GameObject(buttonFrame, new Rectangle(500, 272, 349, 160));
            upgradesButton = new GameObject(buttonFrame, new Rectangle(500, 512, 349, 160));
            returnToMenuButton = new GameObject(buttonFrame, new Rectangle(500, 343, 349, 160));

            groundPoundButton = new GameObject(roundedFrame, new Rectangle(337,200,118,118));
            attackUpButton = new GameObject(roundedFrame, new Rectangle(510, 292, 118, 118));
            staminaUpButton = new GameObject(roundedFrame, new Rectangle(725, 292, 118, 118));
            healthUpButton = new GameObject(roundedFrame, new Rectangle(889, 200, 118, 118));
            dashButton = new GameObject(roundedFrame, new Rectangle(620, 490, 118, 118));
            dashDistanceUpButton = new GameObject(roundedFrame, new Rectangle(620, 680, 118, 118));

            // Makes platforms
            bottomPlatforms = new List<Platform>();
            totalPlatforms = new List<Platform>();
            firstLevelPlatforms = new List<Platform>();
            // Base platforms
            for (int i = 0; i > worldLeftEndWidth / 100; i--)
            {
                bottomPlatforms.Add(new Platform(new Rectangle(i * 100, GraphicsDevice.Viewport.Height - 100, 100, 100), basePlatform));
                totalPlatforms.Add(new Platform(new Rectangle(i * 100, GraphicsDevice.Viewport.Height - 100, 100, 100), basePlatform));
            }
            for (int i = 0; i < worldRightEndWidth / 100; i++)
            {
                bottomPlatforms.Add(new Platform(new Rectangle(i * 100, GraphicsDevice.Viewport.Height - 100, 100, 100), basePlatform));
                totalPlatforms.Add(new Platform(new Rectangle(i * 100, GraphicsDevice.Viewport.Height - 100, 100, 100), basePlatform));
            }
            // First level platforms
            for (int i = 0; i > worldLeftEndWidth / 100; i -= 5)
            {
                firstLevelPlatforms.Add(new Platform(new Rectangle(i * 100, GraphicsDevice.Viewport.Height - 250, 100, 50), notBasePlatform));
                totalPlatforms.Add(new Platform(new Rectangle(i * 100, GraphicsDevice.Viewport.Height - 250, 100, 50), notBasePlatform));
            }
            for (int i = 0; i < worldRightEndWidth / 100; i += 5)
            {
                firstLevelPlatforms.Add(new Platform(new Rectangle(i * 100, GraphicsDevice.Viewport.Height - 250, 100, 50), notBasePlatform));
                totalPlatforms.Add(new Platform(new Rectangle(i * 100, GraphicsDevice.Viewport.Height - 250, 100, 50), notBasePlatform));
            }
            for (int i = 1; i > worldLeftEndWidth / 100; i -= 5)
            {
                firstLevelPlatforms.Add(new Platform(new Rectangle(i * 100, GraphicsDevice.Viewport.Height - 250, 100, 50), notBasePlatform));
                totalPlatforms.Add(new Platform(new Rectangle(i * 100, GraphicsDevice.Viewport.Height - 250, 100, 50), notBasePlatform));
            }
            for (int i = 1; i < worldRightEndWidth / 100; i += 5)
            {
                firstLevelPlatforms.Add(new Platform(new Rectangle(i * 100, GraphicsDevice.Viewport.Height - 250, 100, 50), notBasePlatform));
                totalPlatforms.Add(new Platform(new Rectangle(i * 100, GraphicsDevice.Viewport.Height - 250, 100, 50), notBasePlatform));
            }
            // Makes player, gameManager object and fills enemy list
            textureManager = new TextureManager(Content.Load<Texture2D>("LeftCrouchingSprite"), Content.Load<Texture2D>("RightCrouchingSprite"),
                Content.Load<Texture2D>("LeftStandingSprite"), Content.Load<Texture2D>("RightStandingSprite"), Content.Load<Texture2D>("LeftMiddleRunningSprite"),
                Content.Load<Texture2D>("RightMiddleRunningSprite"), Content.Load<Texture2D>("LeftRunningSprite"), Content.Load<Texture2D>("RightRunningSprite"),
                Content.Load<Texture2D>("RightPlayerAttackSprite1"), Content.Load<Texture2D>("LeftPlayerAttackSprite1"), Content.Load<Texture2D>("RightPlayerAttackSprite2"), Content.Load<Texture2D>("LeftPlayerAttackSprite2"),
                Content.Load<Texture2D>("RightEnemyWalk1"), Content.Load<Texture2D>("RightEnemyWalk2"), Content.Load<Texture2D>("RightEnemyWalk3"),
                Content.Load<Texture2D>("LeftEnemyWalk1"), Content.Load<Texture2D>("LeftEnemyWalk2"), Content.Load<Texture2D>("LeftEnemyWalk3"), tempTexture);

            player = new Player("Dude", new Rectangle(225, 225, 139, 352), textureManager, gameTime);

            gameManager = new GameManager(player, totalPlatforms, GraphicsDevice, textureManager);
            //wave = new Wave(gameManager, game1 = new Game1());

            gameManager.GameState = GameState.Menu;
            //arenaWindow.ShowDialog(); //Loads arenaWindow here to allow User to change settings of level, enemies, and background


            //Initializing Reader
            reader = new Reader(gameManager);
            //Runs the Reader method to vcreate enemies needed
            reader.ReadEditor();
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            KeyboardState previouskbState = kbState;
            kbState = Keyboard.GetState();

            MouseState previousMs = ms;
            ms = Mouse.GetState();

            switch (gameManager.WaveNumber)
            {
                case WaveNumber.One:
                    UpdateHelper(kbState, previouskbState, ms, previousMs, 0, gameTime);
                    break;
                case WaveNumber.Two:
                    UpdateHelper(kbState, previouskbState, ms, previousMs, 1, gameTime);
                    break;
                case WaveNumber.Three:
                    UpdateHelper(kbState, previouskbState, ms, previousMs, 2, gameTime);
                    break;
                case WaveNumber.Four:
                    UpdateHelper(kbState, previouskbState, ms, previousMs, 3, gameTime);
                    break;
                case WaveNumber.Five:
                    UpdateHelper(kbState, previouskbState, ms, previousMs, 4, gameTime);
                    break;
                default:
                    break;
            }


            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            var transformMatrix = camera.GetViewMatrix();
            spriteBatch.Begin(transformMatrix: transformMatrix);

            

            // GameState drawing stuffs
            switch (gameManager.GameState)
            {
                case GameState.Menu:

                    spriteBatch.Draw(startScreen, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);
                    if (startButton.Intersects(ms.Position))
                    {
                        spriteBatch.Draw(startButton.Texture, startButton.Position, Color.Black);
                    }
                    else
                    {
                        spriteBatch.Draw(startButton.Texture, startButton.Position, Color.White);
                    }


                    break;

                case GameState.Game:
                    // Background
                    for (int x = worldLeftEndWidth; x < worldRightEndWidth; x += background.Width)
                    {
                        for (int y = worldTopHeight; y < worldBottomHeight; y += background.Height)
                        {
                            spriteBatch.Draw(background, new Rectangle(x, y, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);
                        }
                    }

                    // Platforms
                    foreach (Platform p in totalPlatforms)
                    {
                        spriteBatch.Draw(p.Texture, p.Position, Color.White);
                    }
                    // Player
                    spriteBatch.Draw(gameManager.Player.Texture, new Rectangle(gameManager.Player.X, gameManager.Player.Y, player.Position.Width, player.Position.Height),
                        Color.White);
                    spriteBatch.DrawString(agency30,gameManager.Player.Health.ToString(),healthBar,Color.Red);
                    // Enemies
                    //for (int i = 0; i < gameManager.Enemies.Count; i++)
                    //{

                    //    spriteBatch.Draw(gameManager.Enemies[i].Texture, new Rectangle(gameManager.Enemies[i].X, gameManager.Enemies[i].Y, 147, 147), Color.White);
                    //}

                    foreach (Enemy e in gameManager.Enemies)
                    {
                        // If attacking, draw this
                        if (e.IsAttacking)
                        {
                            spriteBatch.Draw(e.Texture, e.Position, Color.Red);
                        }
                        
                        // If not, draw this
                        else
                        {
                            spriteBatch.Draw(e.Texture, e.Position, Color.White);
                        }

                        // Drawing bullet bois
                        if(e.HasBullet)
                        {
                            spriteBatch.Draw(e.Texture, e.Bullet, Color.White);
                        }
                        //spriteBatch.Draw(e.Texture, e.Position, Color.White);
                    }
                    break;

                case GameState.Pause:
                    spriteBatch.Draw(pauseScreen, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);

                    if (returnToGameButton.Intersects(ms.Position))
                    {
                        spriteBatch.Draw(returnToGameButton.Texture, returnToGameButton.Position, Color.Black);
                    }
                    else
                    {
                        spriteBatch.Draw(returnToGameButton.Texture, returnToGameButton.Position, Color.White);
                    }
                    break;

                case GameState.UpgradeMenu:
                    spriteBatch.Draw(upgradeScreen, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);
                    spriteBatch.DrawString(agency30, "Upgrade Points: " + gameManager.Player.UgManager.UpgradePoints.ToString(), new Vector2(1090,730), Color.White);
                    //spriteBatch.Draw(buttonFrame, new Rectangle(1192, 722, 54, 60), Color.Black);

                    if (returnToNewWaveButton.Intersects(ms.Position))
                    {
                        spriteBatch.Draw(returnToNewWaveButton.Texture, returnToNewWaveButton.Position, Color.Black);
                    }
                    else
                    {
                        spriteBatch.Draw(returnToNewWaveButton.Texture, returnToNewWaveButton.Position, Color.White);
                    }

                    if (groundPoundButton.Intersects(ms.Position))
                    {
                        spriteBatch.Draw(groundPoundButton.Texture, groundPoundButton.Position, Color.Black);
                    }
                    else
                    {
                        spriteBatch.Draw(groundPoundButton.Texture, groundPoundButton.Position, Color.White);
                    }

                    if (attackUpButton.Intersects(ms.Position))
                    {
                        spriteBatch.Draw(attackUpButton.Texture, attackUpButton.Position, Color.Black);
                    }
                    else
                    {
                        spriteBatch.Draw(attackUpButton.Texture, attackUpButton.Position, Color.White);
                    }

                    if (staminaUpButton.Intersects(ms.Position))
                    {
                        spriteBatch.Draw(staminaUpButton.Texture, staminaUpButton.Position, Color.Black);
                    }
                    else
                    {
                        spriteBatch.Draw(staminaUpButton.Texture, staminaUpButton.Position, Color.White);
                    }

                    if (healthUpButton.Intersects(ms.Position))
                    {
                        spriteBatch.Draw(healthUpButton.Texture, healthUpButton.Position, Color.Black);
                    }
                    else
                    {
                        spriteBatch.Draw(healthUpButton.Texture, healthUpButton.Position, Color.White);
                    }

                    if (dashButton.Intersects(ms.Position))
                    {
                        spriteBatch.Draw(dashButton.Texture, dashButton.Position, Color.Black);
                    }
                    else
                    {
                        spriteBatch.Draw(dashButton.Texture, dashButton.Position, Color.White);
                    }

                    if (dashDistanceUpButton.Intersects(ms.Position))
                    {
                        spriteBatch.Draw(dashDistanceUpButton.Texture, dashDistanceUpButton.Position, Color.Black);
                    }
                    else
                    {
                        spriteBatch.Draw(dashDistanceUpButton.Texture, dashDistanceUpButton.Position, Color.White);
                    }
                    break;

                case GameState.NextWave:
                    spriteBatch.Draw(nextWaveScreen, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);

                    if (goOnButton.Intersects(ms.Position))
                    {
                        spriteBatch.Draw(goOnButton.Texture, goOnButton.Position, Color.Black);
                    }
                    else
                    {
                        spriteBatch.Draw(goOnButton.Texture, goOnButton.Position, Color.White);
                    }


                    if (upgradesButton.Intersects(ms.Position))
                    {
                        spriteBatch.Draw(upgradesButton.Texture, upgradesButton.Position, Color.Black);
                    }
                    else
                    {
                        spriteBatch.Draw(upgradesButton.Texture, upgradesButton.Position, Color.White);
                    }
                    break;

                case GameState.GameOver:
                    // Temp drawing stuffs
                    //spriteBatch.Draw(background, new Vector2(0, 0), Color.White);
                    //spriteBatch.DrawString(comicSans24, "Press ENTER to go back to menu", new Vector2(GraphicsDevice.Viewport.X / 2, GraphicsDevice.Viewport.Y / 2),
                    //    Color.Yellow);

                    spriteBatch.Draw(gameOver, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);
                    if (returnToMenuButton.Intersects(ms.Position))
                    {
                        spriteBatch.Draw(returnToMenuButton.Texture, returnToMenuButton.Position, Color.Black);
                    }
                    else
                    {
                        spriteBatch.Draw(returnToMenuButton.Texture, returnToMenuButton.Position, Color.White);
                    }

                    break;
            }

            spriteBatch.End();
            base.Draw(gameTime);
        }

        private void UpdateHelper(KeyboardState kbState, KeyboardState previouskbState, MouseState msState, MouseState previousMs, int waveNumber, GameTime gameTime)
        {
            // GameState finite state machine
            switch (gameManager.GameState)
            {

                case GameState.Menu:
                    // Reset game
                    gameManager.ResetGame(camera, rng, worldLeftEndWidth, worldRightEndWidth, gameTime, tempTexture, waveNumber);

                    if (startButton.Intersects(ms.Position) && ms.LeftButton == ButtonState.Pressed)
                    {
                        gameManager.GameState = GameState.Game;
                    }

                    break;

                case GameState.Game:
                    //arenaManagerCounter = 0;
                    camera.MinimumZoom = 0.5f;
                    camera.MaximumZoom = 1.0f;
                    camera.Zoom = 0.5f;

                    healthBar = new Vector2(player.Position.X, player.Position.Y + 30);
                    // Stuff for moving player and enemy, as well as player attack
                    ms = Mouse.GetState();
                    gameManager.PlayerMove(kbState, previouskbState, ms, previousMs, camera, gameTime);
                    // Jump logic
                    if (gameManager.JumpNum >= 1 && gameManager.JumpNum <= 10)
                    {
                        player.Jump();
                        gameManager.JumpNum++;
                    }
                    if (gameManager.JumpNum == 10)
                    {
                        gameManager.JumpNum = 0;
                    }

                    gameManager.EnemyMove(gameTime);
                    if (kbState.IsKeyDown(Keys.P))
                    {
                        gameManager.GameState = GameState.Pause;
                    }

                    if (player.IsDead || player.Y >= GraphicsDevice.Viewport.Height)
                    {
                        gameManager.GameState = GameState.GameOver;
                    }

                    //When all enemies are dead calls in the next wave method
                    if (gameManager.Enemies.Count == 0)
                    {
                        if (gameManager.WaveNumber == WaveNumber.One)
                        {
                            gameManager.WaveNumber = WaveNumber.Two;
                            gameManager.GameState = GameState.NextWave;
                        }
                        else if (gameManager.WaveNumber == WaveNumber.Two)
                        {
                            gameManager.WaveNumber = WaveNumber.Three;
                            gameManager.GameState = GameState.NextWave;
                        }
                        else if (gameManager.WaveNumber == WaveNumber.Three)
                        {
                            gameManager.WaveNumber = WaveNumber.Four;
                            gameManager.GameState = GameState.NextWave;
                        }
                        else if (gameManager.WaveNumber == WaveNumber.Four)
                        {
                            gameManager.WaveNumber = WaveNumber.Five;
                            gameManager.GameState = GameState.NextWave;
                        }
                        else if (gameManager.WaveNumber == WaveNumber.Five)
                        {
                            gameManager.GameState = GameState.GameOver;
                            break;
                        }
                        camera.Zoom = 1.0f;
                        camera.Position = new Vector2(0, 0);
                    }
                    break;

                case GameState.Pause:
                    camera.Zoom = 1.0f;
                    camera.Position = new Vector2(0, 0);

                    if (returnToGameButton.Intersects(ms.Position) && ms.LeftButton == ButtonState.Pressed)
                    {
                        gameManager.GameState = GameState.Game;
                    }
                    else if (upgradesButton.Intersects(ms.Position) && ms.LeftButton == ButtonState.Pressed)
                    {
                        gameManager.GameState = GameState.UpgradeMenu;
                    }

                    break;

                case GameState.UpgradeMenu:
                    if (returnToNewWaveButton.Intersects(ms.Position) && ms.LeftButton == ButtonState.Pressed)
                    {
                        gameManager.GameState = GameState.NextWave;
                    }

                    if (groundPoundButton.Intersects(ms.Position) && ms.LeftButton == ButtonState.Pressed && previousMs.LeftButton == ButtonState.Released)
                    {
                        gameManager.Player.UgManager.ActivateGroundPound();
                    }
                    else if (attackUpButton.Intersects(ms.Position) && ms.LeftButton == ButtonState.Pressed && previousMs.LeftButton == ButtonState.Released)
                    {
                        gameManager.Player.Damage = gameManager.Player.UgManager.AttackUpgrade(gameManager.Player.Damage);
                    }
                    else if (staminaUpButton.Intersects(ms.Position) && ms.LeftButton == ButtonState.Pressed && previousMs.LeftButton == ButtonState.Released)
                    {
                        gameManager.Player.Stamina = gameManager.Player.UgManager.StaminaUpgrade(gameManager.Player.Stamina);
                    }
                    else if (healthUpButton.Intersects(ms.Position) && ms.LeftButton == ButtonState.Pressed && previousMs.LeftButton == ButtonState.Released)
                    {
                        gameManager.Player.Health = gameManager.Player.UgManager.HealthUpgrade(gameManager.Player.Health);
                    }
                    else if (dashButton.Intersects(ms.Position) && ms.LeftButton == ButtonState.Pressed && previousMs.LeftButton == ButtonState.Released)
                    {
                        gameManager.Player.UgManager.ActivateDash();
                    }
                    else if (dashDistanceUpButton.Intersects(ms.Position) && ms.LeftButton == ButtonState.Pressed && previousMs.LeftButton == ButtonState.Released)
                    {
                        gameManager.Player.DashDistance = gameManager.Player.UgManager.DashDistanceUpgrade(gameManager.Player.DashDistance);
                    }
                    break;

                case GameState.NextWave:
                    camera.Zoom = 1.0f;
                    camera.Position = new Vector2(0, 0);

                    gameManager.ResetGame(camera, rng, worldLeftEndWidth, worldRightEndWidth, gameTime, tempTexture, waveNumber);

                    if (goOnButton.Intersects(ms.Position) && ms.LeftButton == ButtonState.Pressed && previousMs.LeftButton == ButtonState.Released)
                    {
                        gameManager.GameState = GameState.Game;
                    }
                    else if (upgradesButton.Intersects(ms.Position) && ms.LeftButton == ButtonState.Pressed && previousMs.LeftButton == ButtonState.Released)
                    {
                        gameManager.GameState = GameState.UpgradeMenu;
                    }
                    break;

                case GameState.GameOver:
                    camera.Zoom = 1.0f;
                    camera.Position = new Vector2(0, 0);
                    gameManager.WaveNumber = WaveNumber.One;
                    // Press enter to go back to menu
                    if (returnToMenuButton.Intersects(ms.Position) && ms.LeftButton == ButtonState.Pressed && previousMs.LeftButton == ButtonState.Released)
                    {
                        gameManager.GameState = GameState.Menu;
                    }
                    break;
            }
        }
    }
}
