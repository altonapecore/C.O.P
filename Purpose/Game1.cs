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
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Eleven,
        Twelve,
        Thirteen,
        Fourteen,
        Fifteen
    }

    public enum GameState
    {
        Menu,
        Game,
        EditorGame,
        Pause,
        UpgradeMenu,
        NextWave,
        GameOver
    }
    public class Game1 : Game
    {
        //Fields for MonoGame
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private Camera2D camera;

        //Fields for Key,Mouse States, etc.
        private KeyboardState kbState;
        private MouseState ms;

        //Fields for Platforms and Walls
        private List<Platform> bottomPlatforms;
        private List<Platform> firstLevelPlatforms;
        private List<Platform> totalPlatforms;
        private List<Platform> leftWalls;
        private List<Platform> rightWalls;

        //Fields for World Size
        private int worldLeftEndWidth;
        private int worldRightEndWidth;
        private int worldTopHeight;
        private int worldBottomHeight;

        //Fields for Buttons/GameObjects
        private GameObject startButton;
        private GameObject returnToNewWaveButton;
        private GameObject groundPoundButton;
        private GameObject attackUpButton;
        private GameObject staminaUpButton;
        private GameObject healthUpButton;
        private GameObject dashButton;
        private GameObject dashDistanceUpButton;
        private GameObject returnToGameButton;
        private GameObject goOnButton;
        private GameObject upgradesButton;
        private GameObject returnToMenuButton;

        //Field for other Classes
        private Reader reader;
        private Player player;
        private GameManager gameManager;
        private GameTime gameTime;
        private PresetWaves presetWaves;
        private TextureManager textureManager;

        //temporary stuff
        private Texture2D background;
        private Texture2D tempTexture;
        private Vector2 healthBar;
        private Vector2 staminaBar;
        private SpriteFont comicSans24;
        private SpriteFont agency30;
        private Random rng;

        //properties
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
            worldLeftEndWidth = -3000;
            worldRightEndWidth = 3000;
            worldTopHeight = -1500;
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

            textureManager = new TextureManager(Content.Load<Texture2D>("LeftCrouchingSprite"), Content.Load<Texture2D>("RightCrouchingSprite"),
                Content.Load<Texture2D>("LeftStandingSprite"), Content.Load<Texture2D>("RightStandingSprite"), Content.Load<Texture2D>("LeftMiddleRunningSprite"),
                Content.Load<Texture2D>("RightMiddleRunningSprite"), Content.Load<Texture2D>("LeftRunningSprite"), Content.Load<Texture2D>("RightRunningSprite"),
                Content.Load<Texture2D>("RightPlayerAttackSprite1"), Content.Load<Texture2D>("LeftPlayerAttackSprite1"), Content.Load<Texture2D>("RightPlayerAttackSprite2"), Content.Load<Texture2D>("LeftPlayerAttackSprite2"),
                Content.Load<Texture2D>("RightEnemyWalk1"), Content.Load<Texture2D>("RightEnemyWalk2"), Content.Load<Texture2D>("RightEnemyWalk3"),
                Content.Load<Texture2D>("LeftEnemyWalk1"), Content.Load<Texture2D>("LeftEnemyWalk2"), Content.Load<Texture2D>("LeftEnemyWalk3"), tempTexture,
                Content.Load<Texture2D>("whiteback"), Content.Load<Texture2D>("rustyback"), Content.Load<Texture2D>("metalback"), Content.Load<Texture2D>("StartMenu"), Content.Load<Texture2D>("buttonFrame2"), Content.Load<Texture2D>("roundedFrame"),
                Content.Load<Texture2D>("UpgradeUI"), Content.Load<Texture2D>("PauseMenu"), Content.Load<Texture2D>("NextWaveMenu"), Content.Load<Texture2D>("GameOver"), Content.Load<Texture2D>("PlatformTest"), Content.Load<Texture2D>("PlatformTest2"));


            startButton = new GameObject(textureManager.ButtonFrame, new Rectangle(500, 335, 349, 155));
            returnToNewWaveButton = new GameObject(textureManager.ButtonFrame, new Rectangle(10,340,242,109));
            returnToGameButton = new GameObject(textureManager.ButtonFrame, new Rectangle(500, 280, 349, 160));
            goOnButton = new GameObject(textureManager.ButtonFrame, new Rectangle(500, 272, 349, 160));
            upgradesButton = new GameObject(textureManager.ButtonFrame, new Rectangle(500, 512, 349, 160));
            returnToMenuButton = new GameObject(textureManager.ButtonFrame, new Rectangle(500, 343, 349, 160));

            groundPoundButton = new GameObject(textureManager.RoundedFrame, new Rectangle(337,200,118,118));
            attackUpButton = new GameObject(textureManager.RoundedFrame, new Rectangle(510, 292, 118, 118));
            staminaUpButton = new GameObject(textureManager.RoundedFrame, new Rectangle(725, 292, 118, 118));
            healthUpButton = new GameObject(textureManager.RoundedFrame, new Rectangle(889, 200, 118, 118));
            dashButton = new GameObject(textureManager.RoundedFrame, new Rectangle(620, 490, 118, 118));
            dashDistanceUpButton = new GameObject(textureManager.RoundedFrame, new Rectangle(620, 680, 118, 118));

            // Makes platforms & walls
            bottomPlatforms = new List<Platform>();
            totalPlatforms = new List<Platform>();
            firstLevelPlatforms = new List<Platform>();
            leftWalls = new List<Platform>();
            rightWalls = new List<Platform>();

            // Base platforms
            for (int i = 0; i > worldLeftEndWidth; i -= 100)
            {
                bottomPlatforms.Add(new Platform(new Rectangle(i, GraphicsDevice.Viewport.Height - 100, 100, 100), textureManager.BasePlatform));
                totalPlatforms.Add(new Platform(new Rectangle(i, GraphicsDevice.Viewport.Height - 100, 100, 100), textureManager.BasePlatform));
            }
            for (int i = 0; i < worldRightEndWidth; i += 100)
            {
                bottomPlatforms.Add(new Platform(new Rectangle(i, GraphicsDevice.Viewport.Height - 100, 100, 100), textureManager.BasePlatform));
                totalPlatforms.Add(new Platform(new Rectangle(i, GraphicsDevice.Viewport.Height - 100, 100, 100), textureManager.BasePlatform));
            }
            // First level platforms
            for (int i = -1250; i > worldLeftEndWidth; i -= 100)
            {
                firstLevelPlatforms.Add(new Platform(new Rectangle(i, GraphicsDevice.Viewport.Height - 250, 100, 50), textureManager.NotBasePlatform));
                totalPlatforms.Add(new Platform(new Rectangle(i, GraphicsDevice.Viewport.Height - 250, 100, 50), textureManager.NotBasePlatform));
            }
            for (int i = 1250; i < worldRightEndWidth; i += 100)
            {
                firstLevelPlatforms.Add(new Platform(new Rectangle(i, GraphicsDevice.Viewport.Height - 250, 100, 50), textureManager.NotBasePlatform));
                totalPlatforms.Add(new Platform(new Rectangle(i, GraphicsDevice.Viewport.Height - 250, 100, 50), textureManager.NotBasePlatform));
            }
            
            // Walls
            for(int i = -1500;i <= GraphicsDevice.Viewport.Height; i += 100)
            {
                leftWalls.Add(new Platform(new Rectangle(worldLeftEndWidth, i, 100, 100), textureManager.BasePlatform));
            }
            for (int i = -1500; i <= GraphicsDevice.Viewport.Height; i+= 100)
            {
                rightWalls.Add(new Platform(new Rectangle(worldRightEndWidth, i, 100, 100), textureManager.BasePlatform));
            }

            // Makes player, gameManager object and fills enemy list
            background = textureManager.MetalBack;
            player = new Player("Dude", new Rectangle(0, 490, 139, 352), textureManager, gameTime);
            gameManager = new GameManager(player, totalPlatforms, leftWalls, rightWalls, GraphicsDevice, textureManager);
            //wave = new Wave(gameManager, game1 = new Game1());

            gameManager.GameState = GameState.Menu;
            //arenaWindow.ShowDialog(); //Loads arenaWindow here to allow User to change settings of level, enemies, and background


            //Initializing Reader
            //reader = new Reader(gameManager);
            //Runs the Reader method to vcreate enemies needed
            //reader.ReadEditor();

            //Intializing the PresetWaves
            presetWaves = new PresetWaves(gameManager);
            //Creates all the waves
            presetWaves.CreateWaves();
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

            // Checks for the GameState which is determined by user
            // If they want to use editor tool they get game based of input from text file
            // If they pick regular start they get preset waves
            //if (gameManager.GameState == GameState.Game)
            //{
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
                    case WaveNumber.Six:
                        UpdateHelper(kbState, previouskbState, ms, previousMs, 5, gameTime);
                        break;
                    case WaveNumber.Seven:
                        UpdateHelper(kbState, previouskbState, ms, previousMs, 6, gameTime);
                        break;
                    case WaveNumber.Eight:
                        UpdateHelper(kbState, previouskbState, ms, previousMs, 7, gameTime);
                        break;
                    case WaveNumber.Nine:
                        UpdateHelper(kbState, previouskbState, ms, previousMs, 8, gameTime);
                        break;
                    case WaveNumber.Ten:
                        UpdateHelper(kbState, previouskbState, ms, previousMs, 9, gameTime);
                        break;
                    case WaveNumber.Eleven:
                        UpdateHelper(kbState, previouskbState, ms, previousMs, 10, gameTime);
                        break;
                    case WaveNumber.Twelve:
                        UpdateHelper(kbState, previouskbState, ms, previousMs, 11, gameTime);
                        break;
                    case WaveNumber.Thirteen:
                        UpdateHelper(kbState, previouskbState, ms, previousMs, 12, gameTime);
                        break;
                    case WaveNumber.Fourteen:
                        UpdateHelper(kbState, previouskbState, ms, previousMs, 13, gameTime);
                        break;
                    case WaveNumber.Fifteen:
                        UpdateHelper(kbState, previouskbState, ms, previousMs, 14, gameTime);
                        break;
                    default:
                        break;
                }
            //}
            //else if(gameManager.GameState == GameState.EditorGame)
            //{
            //    switch(gameManager.WaveNumber)
            //    {
            //        case WaveNumber.One:
            //            UpdateHelper(kbState, previouskbState, ms, previousMs, 0, gameTime);
            //            break;
            //        case WaveNumber.Two:
            //            UpdateHelper(kbState, previouskbState, ms, previousMs, 1, gameTime);
            //            break;
            //        case WaveNumber.Three:
            //            UpdateHelper(kbState, previouskbState, ms, previousMs, 2, gameTime);
            //            break;
            //        case WaveNumber.Four:
            //            UpdateHelper(kbState, previouskbState, ms, previousMs, 3, gameTime);
            //            break;
            //        case WaveNumber.Five:
            //            UpdateHelper(kbState, previouskbState, ms, previousMs, 4, gameTime);
            //            break;
            //    }
            //}

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            var transformMatrix = camera.GetViewMatrix();
            spriteBatch.Begin(transformMatrix: transformMatrix);

            

            // GameState drawing stuffs
            switch (gameManager.GameState)
            {
                case GameState.Menu:

                    spriteBatch.Draw(textureManager.StartScreen, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);
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

                    // Walls
                    foreach (Platform w in leftWalls)
                    {
                        spriteBatch.Draw(w.Texture, w.Position, Color.White);
                    }
                    foreach (Platform w in rightWalls)
                    {
                        spriteBatch.Draw(w.Texture, w.Position, Color.White);
                    }

                    // Player
                    spriteBatch.Draw(gameManager.Player.Texture, new Rectangle(gameManager.Player.X, gameManager.Player.Y, player.Position.Width, player.Position.Height),
                        Color.White);
                    spriteBatch.DrawString(agency30,gameManager.Player.Health.ToString(),healthBar,Color.Red);
                    spriteBatch.DrawString(agency30, gameManager.Player.Stamina.ToString(), staminaBar, Color.Green);

                    foreach (Enemy e in gameManager.Enemies)
                    {
                            spriteBatch.Draw(e.Texture, e.Position, e.Color);
                        
                        // Drawing bullet bois
                        if(e.HasBullet)
                        {
                            spriteBatch.Draw(e.Texture, e.Bullet, Color.White);
                        }
                    }
                    break;

                case GameState.EditorGame:
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

                    // Walls
                    foreach (Platform w in leftWalls)
                    {
                        spriteBatch.Draw(w.Texture, w.Position, Color.White);
                    }
                    foreach (Platform w in rightWalls)
                    {
                        spriteBatch.Draw(w.Texture, w.Position, Color.White);
                    }

                    // Player
                    spriteBatch.Draw(gameManager.Player.Texture, new Rectangle(gameManager.Player.X, gameManager.Player.Y, player.Position.Width, player.Position.Height),
                        Color.White);
                    spriteBatch.DrawString(agency30,gameManager.Player.Health.ToString(),healthBar,Color.Red);
                    spriteBatch.DrawString(agency30, gameManager.Player.Stamina.ToString(), staminaBar, Color.Green);

                    foreach (Enemy e in gameManager.Enemies)
                    {
                            spriteBatch.Draw(e.Texture, e.Position, e.Color);
                        
                        // Drawing bullet bois
                        if(e.HasBullet)
                        {
                            spriteBatch.Draw(e.Texture, e.Bullet, Color.White);
                        }
                    }
                    break;

                case GameState.Pause:
                    spriteBatch.Draw(textureManager.PauseScreen, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);

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
                    spriteBatch.Draw(textureManager.UpgradeScreen, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);
                    spriteBatch.DrawString(agency30, "Upgrade Points: " + gameManager.Player.UgManager.UpgradePoints.ToString(), new Vector2(1090,730), Color.White);

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
                    spriteBatch.Draw(textureManager.NextWaveScreen, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);

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
                    spriteBatch.Draw(textureManager.GameOver, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);

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
                    gameManager.ResetOnPlayerDeath(camera, rng, worldLeftEndWidth, worldRightEndWidth, gameTime, tempTexture);

                    if (startButton.Intersects(ms.Position) && ms.LeftButton == ButtonState.Pressed && previousMs.LeftButton == ButtonState.Released)
                    {
                        gameManager.GameState = GameState.Game;
                    }
                    break;

                case GameState.Game:
                    //arenaManagerCounter = 0;
                    camera.MinimumZoom = 0.1f;
                    camera.MaximumZoom = 1.0f;
                    camera.Zoom = 0.5f;

                    healthBar = new Vector2(player.Position.X, player.Position.Y + 30);
                    staminaBar = new Vector2(player.Position.X + player.Position.Width, player.Position.Y + 30);
                    // Stuff for moving player and enemy, as well as player attack
                    ms = Mouse.GetState();
                    gameManager.PlayerMove(kbState, previouskbState, ms, previousMs, camera, gameTime);

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
                            gameManager.WaveNumber = WaveNumber.Six;
                            gameManager.GameState = GameState.NextWave;
                        }
                        else if (gameManager.WaveNumber == WaveNumber.Six)
                        {
                            gameManager.WaveNumber = WaveNumber.Seven;
                            gameManager.GameState = GameState.NextWave;
                        }
                        else if (gameManager.WaveNumber == WaveNumber.Seven)
                        {
                            gameManager.WaveNumber = WaveNumber.Eight;
                            gameManager.GameState = GameState.NextWave;
                        }
                        else if (gameManager.WaveNumber == WaveNumber.Eight)
                        {
                            gameManager.WaveNumber = WaveNumber.Nine;
                            gameManager.GameState = GameState.NextWave;
                        }
                        else if (gameManager.WaveNumber == WaveNumber.Nine)
                        {
                            gameManager.WaveNumber = WaveNumber.Ten;
                            gameManager.GameState = GameState.NextWave;
                        }
                        else if (gameManager.WaveNumber == WaveNumber.Ten)
                        {
                            gameManager.WaveNumber = WaveNumber.Eleven;
                            gameManager.GameState = GameState.NextWave;
                        }
                        else if (gameManager.WaveNumber == WaveNumber.Eleven)
                        {
                            gameManager.WaveNumber = WaveNumber.Twelve;
                            gameManager.GameState = GameState.NextWave;
                        }
                        else if (gameManager.WaveNumber == WaveNumber.Twelve)
                        {
                            gameManager.WaveNumber = WaveNumber.Thirteen;
                            gameManager.GameState = GameState.NextWave;
                        }
                        else if (gameManager.WaveNumber == WaveNumber.Thirteen)
                        {
                            gameManager.WaveNumber = WaveNumber.Fourteen;
                            gameManager.GameState = GameState.NextWave;
                        }
                        else if (gameManager.WaveNumber == WaveNumber.Fourteen)
                        {
                            gameManager.WaveNumber = WaveNumber.Fifteen;
                            gameManager.GameState = GameState.NextWave;
                        }
                        else if (gameManager.WaveNumber == WaveNumber.Fifteen)
                        {
                            gameManager.GameState = GameState.GameOver;
                            break;
                        }
                    }
                    break;

                case GameState.EditorGame:

                    camera.MinimumZoom = 0.5f;
                    camera.MaximumZoom = 1.0f;
                    camera.Zoom = 0.5f;

                    healthBar = new Vector2(player.Position.X, player.Position.Y + 30);
                    staminaBar = new Vector2(player.Position.X + player.Position.Width, player.Position.Y + 30);
                    // Stuff for moving player and enemy, as well as player attack
                    ms = Mouse.GetState();
                    gameManager.PlayerMove(kbState, previouskbState, ms, previousMs, camera, gameTime);

                    gameManager.EnemyMove(gameTime);
                    if (kbState.IsKeyDown(Keys.P))
                    {
                        gameManager.GameState = GameState.Pause;
                    }

                    if (player.IsDead || player.Y >= GraphicsDevice.Viewport.Height)
                    {
                        gameManager.GameState = GameState.GameOver;
                    }

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
                        }
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
                        gameManager.Player.StaminaMax = gameManager.Player.UgManager.StaminaUpgrade(gameManager.Player.StaminaMax);
                    }
                    else if (healthUpButton.Intersects(ms.Position) && ms.LeftButton == ButtonState.Pressed && previousMs.LeftButton == ButtonState.Released)
                    {
                        gameManager.Player.HealthMax = gameManager.Player.UgManager.HealthUpgrade(gameManager.Player.HealthMax);
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

                    gameManager.ResetForNextWave(camera, rng, worldLeftEndWidth, worldRightEndWidth, gameTime, tempTexture, waveNumber);

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
