﻿using Microsoft.Xna.Framework;
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

            // TRY TO FIND A BETTER WAY TO DO THIS
            player = new Player("Dude", tempTexture);
            player.X = 225;
            player.Y = 225;
            gameManager = new GameManager(player);

            arenaWindow.ShowDialog();
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
            float time = (float)gameTime.ElapsedGameTime.TotalSeconds;
            KeyboardState previouskbState = kbState;
            kbState = Keyboard.GetState();

            // GameState finite state machine
            switch (gameState)
            {
                case GameState.Menu:
                    // Temp code stuffs
                    MouseState ms = Mouse.GetState();
                    gameManager.Move(kbState, previouskbState, time, ms, enemies);
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

            // GameState drawing stuffs
            switch (gameState)
            {
                case GameState.Menu:
                    spriteBatch.Draw(background, new Vector2(0, 0), Color.White);
                    // Temp drawing stuffs
                    spriteBatch.Draw(player.Texture, new Rectangle(player.X, player.Y, 445, 355), Color.White);
                    break;

                    while (count <= gameManager.jumpRectangles.Count)
                    {
                        spriteBatch.Draw(player.Texture, gameManager.jumpRectangles[count], Color.White);
                        count++;
                        InactiveSleepTime = new TimeSpan(0, 0, 1);
                    }

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
