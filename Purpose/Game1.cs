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

    enum Level
    {
        One,
        Two,
        Three,
        Four
    }

    enum GameState
    {
        Menu,
        Game,
        Pause,
        GameOver
    }
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        GameState gameState;
        KeyboardState kbState;
        Player player;
        Texture2D tempTexture;
        Texture2D background;
        GameManager gameManager;
        List<Enemy> enemies;
        List<Platform> bottomPlatforms;
        Texture2D platform;
        ArenaWindow arenaWindow;
        int count = 0;

        // Temp stuffs
        Texture2D trent;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            // Set screen size
            graphics.IsFullScreen = false;
            graphics.PreferredBackBufferHeight = 845;
            graphics.PreferredBackBufferWidth = 1350;

            // Temp coding stuffs
            for(int i = 0; i < 3; i++)
            {
                int x = 50;
                int y = 50;
                Rectangle rectangle = new Rectangle(x, y, 147, 147);
                Enemy enemy = new Enemy(rectangle, trent, Level.One);
                x += 87;
                y += 87;
            }
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {

            // Initialize GameState
            gameState = GameState.Menu;
            //Initialize the Window Form
            arenaWindow = new ArenaWindow();
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
            tempTexture = Content.Load<Texture2D>("pineapple");
            background = Content.Load<Texture2D>("background");
            trent = Content.Load<Texture2D>("trent");
            platform = Content.Load<Texture2D>("PlatformTest");
            bottomPlatforms = new List<Platform>();
            for (int i = 0; i < GraphicsDevice.Viewport.Width/100; i++)
            {
                bottomPlatforms.Add(new Platform(new Rectangle(i * 100, GraphicsDevice.Viewport.Height - 100, 100, 100), platform));
            }

            // TRY TO FIND A BETTER WAY TO DO THIS
            player = new Player("Dude", tempTexture, new Rectangle(225, 225, tempTexture.Width, tempTexture.Height));
            player.X = 225;
            player.Y = 225;
            gameManager = new GameManager(player);
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
            switch (gameState)
            {
                case GameState.Menu:
                    // Temp code stuffs
                    MouseState ms = Mouse.GetState();
                    gameManager.Move(kbState, previouskbState, ms, enemies);
                    if (kbState.IsKeyDown(Keys.Enter))
                    {
                        gameState = GameState.Game;
                    }
                    break;

                case GameState.Game:

                    if (kbState.IsKeyDown(Keys.P))
                    {
                        gameState = GameState.Pause;
                    }

                    if(player.Health <= 0)
                    {
                        gameState = GameState.GameOver;
                    }
                    break;

                case GameState.Pause:

                    if (kbState.IsKeyDown(Keys.P))
                    {
                        gameState = GameState.Game;
                    }
                    break;

                case GameState.GameOver:

                    if (kbState.IsKeyDown(Keys.Enter))
                    {
                        gameState = GameState.Menu;
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

            spriteBatch.Draw(background, new Vector2(0, 0), Color.White);

            foreach (Platform p in bottomPlatforms)
            {
                spriteBatch.Draw(p.Texture, p.Position, Color.White);
            }

            // GameState drawing stuffs
            switch (gameState)
            {
                case GameState.Menu:

                    // Temp drawing stuffs

                    spriteBatch.Draw(player.Texture, new Rectangle(player.X, player.Y, 445, 355), Color.White);

                    break;

                case GameState.Game:
                    break;

                case GameState.Pause:
                    break;

                case GameState.GameOver:
                    break;
            }

            spriteBatch.End();
            base.Draw(gameTime);
        }


    }
}
