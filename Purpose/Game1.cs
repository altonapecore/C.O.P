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
        private Texture2D leftStandingSprite;
        private Texture2D leftRunningSprite;
        private Texture2D rightCrouchSprite;
        private Texture2D leftCrouchSprite;

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
            leftStandingSprite = Content.Load<Texture2D>("LeftStandingSprite");
            leftRunningSprite = Content.Load<Texture2D>("LeftRunningSprite");
            rightCrouchSprite = Content.Load<Texture2D>("RightCrouchingSprite");
            leftCrouchSprite = Content.Load<Texture2D>("LeftCrouchingSprite");

            background = Content.Load<Texture2D>("background");
            platform = Content.Load<Texture2D>("PlatformTest");

            // Makes platforms
            bottomPlatforms = new List<Platform>();
            for (int i = 0; i < GraphicsDevice.Viewport.Width/100; i++)
            {
                bottomPlatforms.Add(new Platform(new Rectangle(i * 100, GraphicsDevice.Viewport.Height - 100, 100, 100), platform));
            }
            // Makes player, gameManager object and fills enemy list
            //the pineapple's dimensions were 445x355
            //those dimensions may be needed for logic for collisions
            player = new Player("Dude", new Rectangle(225, 225, 139, 352), leftCrouchSprite, rightCrouchSprite, leftStandingSprite, rightStandingSprite, leftRunningSprite, rightRunningSprite);
            gameManager = new GameManager(player, bottomPlatforms, GraphicsDevice);
            
            arenaWindow = new ArenaWindow(gameManager);
            gameManager.GameState = GameState.Menu;
            arenaWindow.ShowDialog(); //Loads arenaWindow here to allow User to change settings of level, enemies, and background

            gameManager.FillEnemyList(rng, gameManager.NumberOfEnemies, GraphicsDevice, trent);
            gameManager.FillRangedList(rng, gameManager.NumberOfRanged, GraphicsDevice, tempTexture);
           
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
                    // Stuff for auto scrolling screen
                    // Not fully working yet so I commented it out
                    //if(player.X != GraphicsDevice.Viewport.Width / 2 || player.Y != GraphicsDevice.Viewport.Height / 2)
                    //{
                    //    int x = background.Bounds.X;
                    //    int y = background.Bounds.Y;
                    //
                    //    x -= player.X - GraphicsDevice.Viewport.Width;
                    //    y -= player.Y - GraphicsDevice.Viewport.Height;
                    //
                    //    GraphicsDevice.Viewport = new Viewport(x, y, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
                    //}

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
                    spriteBatch.Draw(gameManager.Player.Texture, new Rectangle(gameManager.Player.X, gameManager.Player.Y, player.Position.Width, player.Position.Height), 
                        Color.White);
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

        //Basic animation stuff that is not done yet
        //Example in the Finite State Machine Dropbox on MyCourses
        public void UpdateAnimation()
        {
            //currentFrame = 1;
            //fps = 100.0;
            //secondsPerFrame = 1.0f / fps;
            //timeCounter = 0;
            //this.gameTime = gameTime;

            /// <summary>
            /// Updates the animation time
            /// </summary>
            /// <param name="gameTime">Game time information</param>
            //private void UpdateAnimation(GameTime gameTime)
            //{
            //    // Add to the time counter (need TOTALSECONDS here)
            //    timeCounter += gameTime.ElapsedGameTime.TotalSeconds;

            //    // Has enough time gone by to actually flip frames?
            //    if (timeCounter >= secondsPerFrame)
            //    {
            //        // Update the frame and wrap
            //        currentFrame++;
            //        if (currentFrame >= 4) currentFrame = 1;

            //        // Remove one "frame" worth of time
            //        timeCounter -= secondsPerFrame;
            //    }
            //}

            //protected override void Draw(GameTime gameTime)
            //{
            //    GraphicsDevice.Clear(Color.Black);

            //    spriteBatch.Begin();

            //    // *** Put code to check FINITE STATE MACHINE
            //    // *** and properly draw mario here
            //    switch (marioState)
            //    {
            //        case (MarioState.FaceLeft):
            //            DrawMarioStanding(SpriteEffects.FlipHorizontally);
            //            break;
            //        case (MarioState.WalkLeft):
            //            DrawMarioWalking(SpriteEffects.FlipHorizontally);
            //            break;
            //        case (MarioState.FaceRight):
            //            DrawMarioStanding(SpriteEffects.None);
            //            break;
            //        case (MarioState.WalkRight):
            //            DrawMarioWalking(SpriteEffects.None);
            //            break;
            //        default:
            //            break;
            //    }

            //    // Example call to draw mario walking (replace or adjust this line!)
            //    //DrawMarioWalking(SpriteEffects.FlipHorizontally);



            //    spriteBatch.End();

            //    base.Draw(gameTime);
            //}

            ///// <summary>
            ///// Draws mario with a walking animation
            ///// </summary>
            ///// <param name="flip">Should he be flipped horizontally?</param>
            //private void DrawMarioWalking(SpriteEffects flip)
            //{
            //    spriteBatch.Draw(
            //        marioTexture,
            //        marioPosition,
            //        new Rectangle(widthOfSingleSprite * currentFrame, 0, widthOfSingleSprite, marioTexture.Height),
            //        Color.White,
            //        0.0f,
            //        Vector2.Zero,
            //        1.0f,
            //        flip,
            //        0.0f);
            //}

            ///// <summary>
            ///// Draws mario standing still
            ///// </summary>
            ///// <param name="flip">Should he be flipped horizontally?</param>
            //private void DrawMarioStanding(SpriteEffects flip)
            //{
            //    spriteBatch.Draw(
            //        marioTexture,
            //        marioPosition,
            //        new Rectangle(0, 0, widthOfSingleSprite, marioTexture.Height),
            //        Color.White,
            //        0.0f,
            //        Vector2.Zero,
            //        1.0f,
            //        flip,
            //        0.0f);
            //}
    }
    }
}
