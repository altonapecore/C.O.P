using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Purpose
{
    /// <summary>
    /// It's ya boy, Alex
    /// Nicholas needs a medic
    /// Overlord Trent has arrived.
    /// Vansh is here
    /// </summary>

    public enum Level
    {
        One,
        Two,
        Three,
        Four
    }

    public enum GameState
    {
        Menu,
        Game,
        Pause,
        GameOver
    }
    public class Game1 : Game
    {
        //Fields 
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        public GameState gameState;
        private Level currentLevel;
        private KeyboardState kbState;
        private MouseState ms;
        private Player player;
        private Texture2D background;
        private GameManager gameManager;
        private List<Enemy> enemies;
        private List<Platform> bottomPlatforms;
        private Texture2D platform;
        private ArenaWindow arenaWindow;
        

        //Actual Player Textures
        private Texture2D rightStandingSprite;
        private Texture2D rightRunningSprite;

        //temporary stuff
        private Texture2D tempTexture;
        private Texture2D tempCrouchTexture;
        private Texture2D trent;
        private SpriteFont comicSans24;
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
            // Initialize GameState and level
            currentLevel = Level.One;
            //Initialize the Window Form
            base.Initialize();
            //bottomPlatforms = new List<Platform>();
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
            tempCrouchTexture = Content.Load<Texture2D>("smallerPineapple(1)");
            trent = Content.Load<Texture2D>("trent");
            comicSans24 = Content.Load<SpriteFont>("ComicSans24");

            //temporary background
            whiteBack = Content.Load<Texture2D>("whiteback");
            metalBack = Content.Load<Texture2D>("metalback");
            rustyBack = Content.Load<Texture2D>("rustyback");

            // Right facing sprite
            rightStandingSprite = Content.Load<Texture2D>("RightStandingSprite");
            rightRunningSprite = Content.Load<Texture2D>("RightRunningSprite");

            background = Content.Load<Texture2D>("background");
            platform = Content.Load<Texture2D>("PlatformTest");

            // Makes platforms
            bottomPlatforms = new List<Platform>();
            for (int i = 0; i < GraphicsDevice.Viewport.Width/100; i++)
            {
                bottomPlatforms.Add(new Platform(new Rectangle(i * 100, GraphicsDevice.Viewport.Height - 100, 100, 100), platform));
            }
            // Makes player, gameManager object and fills enemy list
            player = new Player("Dude", tempTexture, tempCrouchTexture, new Rectangle(225, 225, 445, 355));
            gameManager = new GameManager(player, bottomPlatforms, GraphicsDevice);
            gameManager.FillEnemyList(rng, 3, GraphicsDevice, trent);
            gameManager.GameState = GameState.Menu;
            arenaWindow = new ArenaWindow(gameManager);
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

            // GameState finite state machine
            switch (gameManager.GameState)
            {

                case GameState.Menu:

                    //Loads up the Arena Window
                    arenaWindow.ShowDialog();

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
                    break;

                case GameState.Game:
                    // Stuff for moving player and enemy, as well as player attack
                    MouseState previousMs = ms;
                    ms = Mouse.GetState();
                    gameManager.PlayerMove(kbState, previouskbState, ms, previousMs);
                    gameManager.EnemyMove();
                    if (kbState.IsKeyDown(Keys.P))
                    {
                        gameManager.GameState = GameState.Pause;
                    }

                    if(player.Health <= 0)
                    {
                        gameManager.GameState = GameState.GameOver;
                    }
                    break;

                case GameState.Pause:
                    // Make a pauseMenu form and shows it
                    PauseMenu pauseMenu = new PauseMenu();
                    pauseMenu.ShowDialog();
                    gameManager.GameState = GameState.Game;
                    break;

                case GameState.GameOver:
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
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();           

            

            // GameState drawing stuffs
            switch (gameManager.GameState)
            {
                case GameState.Menu:
                   
                    // Temp drawing stuffs
                    //spriteBatch.Draw(background, new Vector2(0, 0), Color.White);
                    //spriteBatch.DrawString(comicSans24, "Press ENTER to play", new Vector2(GraphicsDevice.Viewport.X / 2, GraphicsDevice.Viewport.Y / 2), Color.Yellow);

                    break;

                case GameState.Game:
                    // Background
                    spriteBatch.Draw(background, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);
                    // Platforms
                    foreach (Platform p in bottomPlatforms)
                    {
                        spriteBatch.Draw(p.Texture, p.Position, Color.White);
                    }
                    // Player
                    spriteBatch.Draw(gameManager.Player.Texture, new Rectangle(gameManager.Player.X, gameManager.Player.Y, player.Position.Width, player.Position.Height), Color.White);
                    // Enemies
                    for(int i = 0; i < gameManager.Enemies.Count; i++)
                    {

                        spriteBatch.Draw(gameManager.Enemies[i].Texture, new Rectangle(gameManager.Enemies[i].X, gameManager.Enemies[i].Y, 147, 147), Color.White);
                    }
                    break;

                case GameState.GameOver:
                    // Temp drawing stuffs
                    spriteBatch.Draw(background, new Vector2(0, 0), Color.White);
                    spriteBatch.DrawString(comicSans24, "Press ENTER to go back to menu", new Vector2(GraphicsDevice.Viewport.X / 2, GraphicsDevice.Viewport.Y / 2),
                        Color.Yellow);
                    break;
            }

            spriteBatch.End();
            base.Draw(gameTime);
        }


    }
}
