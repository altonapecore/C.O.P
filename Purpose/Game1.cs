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
        private ArenaWindow arenaWindow;
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
        private GameObject returnToPauseButton;
        private GameObject groundPoundButton;
        private GameObject attackUpButton;
        private GameObject staminaUpButton;
        private GameObject healthUpButton;
        private GameObject dashButton;
        private GameObject dashDistanceUpButton;

        private Texture2D pauseScreen;
        private GameObject returnToGameButton;
        private GameObject upgradesButton;

        public Texture2D gameOver;
        //Field for the Reader
        private Reader reader;

        //textureManager object
        private TextureManager textureManager;

        //temporary stuff
        private Texture2D tempTexture;
        //private Texture2D tempCrouchTexture;
        private Texture2D trent;
        private SpriteFont comicSans24;
        private SpriteFont agency30;
        private Random rng;

        //Temporary BackGround
        private Texture2D whiteBack;
        private Texture2D rustyBack;
        private Texture2D metalBack;

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
            //temporary textures
            tempTexture = Content.Load<Texture2D>("pineapple");
            //tempCrouchTexture = Content.Load<Texture2D>("smallerPineapple(1)");
            trent = Content.Load<Texture2D>("trent");
            comicSans24 = Content.Load<SpriteFont>("ComicSans24");
            agency30 = Content.Load<SpriteFont>("Agency30");
            startScreen = Content.Load<Texture2D>("metalBackground2");
            buttonFrame = Content.Load<Texture2D>("buttonFrame2");
            roundedFrame = Content.Load<Texture2D>("roundedFrame");
            upgradeScreen = Content.Load<Texture2D>("UpgradeUI");
            pauseScreen = Content.Load<Texture2D>("pauseMenu");
            gameOver = Content.Load<Texture2D>("gameOver");

            //temporary background
            whiteBack = Content.Load<Texture2D>("whiteback");
            metalBack = Content.Load<Texture2D>("metalback");
            rustyBack = Content.Load<Texture2D>("rustyback");

            background = Content.Load<Texture2D>("background");
            basePlatform = Content.Load<Texture2D>("PlatformTest");
            notBasePlatform = Content.Load<Texture2D>("PlatformTest2");

            startButton = new GameObject(buttonFrame, new Rectangle(500, 365, 300, 100));
            returnToPauseButton = new GameObject(buttonFrame, new Rectangle(25,340,170,110));
            returnToGameButton = new GameObject(buttonFrame, new Rectangle(530, 280, 280, 160));
            upgradesButton = new GameObject(buttonFrame, new Rectangle(530, 495, 280, 100));

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
                Content.Load<Texture2D>("LeftEnemyWalk1"), Content.Load<Texture2D>("LeftEnemyWalk2"), Content.Load<Texture2D>("LeftEnemyWalk3"));

            player = new Player("Dude", new Rectangle(225, 225, 139, 352), textureManager, gameTime);

            gameManager = new GameManager(player, bottomPlatforms, GraphicsDevice, textureManager);

            arenaWindow = new ArenaWindow(gameManager);
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

            // GameState finite state machine
            switch (gameManager.GameState)
            {

                case GameState.Menu:
                    // Reset game
                    gameManager.ResetGame(camera, rng, worldLeftEndWidth, worldRightEndWidth, gameTime, tempTexture, 0);

                    //Using the selection from the ArenaWindow pciks the background to use in the Game
                    if (gameManager.BackgroundSelection == Background.WhiteBackground)
                    {
                        background = whiteBack; //Changes the background to White
                    }
                    else if (gameManager.BackgroundSelection == Background.MetalBackground)
                    {
                        background = metalBack; // Background is Metal
                    }
                    else if (gameManager.BackgroundSelection == Background.RustBackground)
                    {
                        background = rustyBack; //Background is Rusty
                    }

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

                    // Stuff for moving player and enemy, as well as player attack
                    ms = Mouse.GetState();
                    gameManager.PlayerMove(kbState, previouskbState, ms, previousMs, camera, totalPlatforms, gameTime);
                    // Jump logic
                    if(gameManager.JumpNum >= 1 && gameManager.JumpNum <= 10)
                    {
                        player.Jump();
                        gameManager.JumpNum++;
                    }
                    if(gameManager.JumpNum == 10)
                    {
                        gameManager.JumpNum = 0;
                    }

                    gameManager.EnemyMove(gameTime);
                    if (kbState.IsKeyDown(Keys.P))
                    {
                        gameManager.GameState = GameState.Pause;
                    }

                    if (player.IsDead || player.Y >= GraphicsDevice.Viewport.Height )
                    {
                        gameManager.GameState = GameState.GameOver;
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
                    if (returnToPauseButton.Intersects(ms.Position) && ms.LeftButton == ButtonState.Pressed)
                    {
                        gameManager.GameState = GameState.Pause;
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

                case GameState.GameOver:
                    camera.Zoom = 1.0f;
                    camera.Position = new Vector2(0, 0);
                    // Press enter to go back to menu
                    if (kbState.IsKeyDown(Keys.Enter))
                    {
                        gameManager.GameState = GameState.Menu;
                    }
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
                    // Enemies
                    //for (int i = 0; i < gameManager.Enemies.Count; i++)
                    //{

                    //    spriteBatch.Draw(gameManager.Enemies[i].Texture, new Rectangle(gameManager.Enemies[i].X, gameManager.Enemies[i].Y, 147, 147), Color.White);
                    //}

                    foreach (Enemy e in gameManager.Enemies)
                    {
                        if (e.IsAttacking)
                        {
                            spriteBatch.Draw(e.Texture, e.Position, Color.Red);
                        }
                        
                        else
                        {
                            spriteBatch.Draw(e.Texture, e.Position, Color.White);
                        }

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

                    if (upgradesButton.Intersects(ms.Position))
                    {
                        spriteBatch.Draw(upgradesButton.Texture, upgradesButton.Position, Color.Black);
                    }
                    else
                    {
                        spriteBatch.Draw(upgradesButton.Texture, upgradesButton.Position, Color.White);
                    }
                    break;

                case GameState.UpgradeMenu:
                    spriteBatch.Draw(upgradeScreen, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);
                    spriteBatch.DrawString(agency30, "Upgrade Points: " + gameManager.Player.UgManager.UpgradePoints.ToString(), new Vector2(1090,730), Color.White);
                    //spriteBatch.Draw(buttonFrame, new Rectangle(1192, 722, 54, 60), Color.Black);

                    if (returnToPauseButton.Intersects(ms.Position))
                    {
                        spriteBatch.Draw(returnToPauseButton.Texture, returnToPauseButton.Position, Color.Black);
                    }
                    else
                    {
                        spriteBatch.Draw(returnToPauseButton.Texture, returnToPauseButton.Position, Color.White);
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

                case GameState.GameOver:
                    // Temp drawing stuffs
                    //spriteBatch.Draw(background, new Vector2(0, 0), Color.White);
                    //spriteBatch.DrawString(comicSans24, "Press ENTER to go back to menu", new Vector2(GraphicsDevice.Viewport.X / 2, GraphicsDevice.Viewport.Y / 2),
                    //    Color.Yellow);

                    spriteBatch.Draw(gameOver, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);

                    break;
            }

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
