using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Purpose
{
    public enum PlatformVersion
    {
        Easy,
        Medium,
        Hard,
        Mean,
        Life
    }
    public class PlatformManager
    {
        #region Fields, Properties, and Constructor
        // Fields
        private List<Platform> totalPlatforms;
        private List<Platform> leftWalls;
        private List<Platform> rightWalls;
        private GraphicsDevice graphicsDevice;

        // Properties
        public List<Platform> TotalPlatforms
        {
            get { return totalPlatforms; }
            set { totalPlatforms = value; }
        }

        public List<Platform> LeftWalls
        {
            get { return leftWalls; }
            set { leftWalls = value; }
        }

        public List<Platform> RightWalls
        {
            get { return rightWalls; }
            set { rightWalls = value; }
        }
        // Constructor
        public PlatformManager(GraphicsDevice graphicsDevice)
        {
            totalPlatforms = new List<Platform>();
            leftWalls = new List<Platform>();
            rightWalls = new List<Platform>();
            this.graphicsDevice = graphicsDevice;
        }
        #endregion

        #region MakePlatforms
        // Methods
        public void MakePlatforms(PlatformVersion platformVersion, GraphicsDevice graphicsDevice, TextureManager textureManager)
        {
            switch (platformVersion)
            {
                case PlatformVersion.Easy:
                    // Base platforms
                    for (int i = 0; i > -3000; i -= 100)
                    {
                        totalPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 100, 100, 100), textureManager.BasePlatform));
                    }
                    for (int i = 0; i < 3000; i += 100)
                    {
                        totalPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 100, 100, 100), textureManager.BasePlatform));
                    }
                    // First level platforms
                    for (int i = -1250; i > -3000; i -= 100)
                    {
                        totalPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 300, 100, 50), textureManager.NotBasePlatform));
                    }
                    for (int i = 1250; i < 3000; i += 100)
                    {
                        totalPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 300, 100, 50), textureManager.NotBasePlatform));
                    }

                    // Second level platforms
                    for (int i = -175; i > -1100; i -= 100)
                    {
                        totalPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 500, 100, 50), textureManager.NotBasePlatform));
                    }
                    for (int i = 175; i < 1100; i += 100)
                    {
                        totalPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 500, 100, 50), textureManager.NotBasePlatform));
                    }

                    // Walls
                    for (int i = -1500; i <= graphicsDevice.Viewport.Height; i += 100)
                    {
                        leftWalls.Add(new Platform(new Rectangle(-3000, i, 100, 100), textureManager.BasePlatform));
                    }
                    for (int i = -1500; i <= graphicsDevice.Viewport.Height; i += 100)
                    {
                        rightWalls.Add(new Platform(new Rectangle(3000, i, 100, 100), textureManager.BasePlatform));
                    }
                    break;

                case PlatformVersion.Medium:
                    // Base platforms
                    for (int i = 0; i > -3000; i -= 100)
                    {
                        totalPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 100, 100, 100), textureManager.BasePlatform));
                    }
                    for (int i = 0; i < 3000; i += 100)
                    {
                        totalPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 100, 100, 100), textureManager.BasePlatform));
                    }
                    // First level platforms
                    for (int i = -1250; i > -3000; i -= 100)
                    {
                        totalPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 300, 100, 50), textureManager.NotBasePlatform));
                    }
                    for (int i = 1250; i < 3000; i += 100)
                    {
                        totalPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 300, 100, 50), textureManager.NotBasePlatform));
                    }

                    // Second level platforms
                    for (int i = -175; i > -1100; i -= 100)
                    {
                        totalPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 500, 100, 50), textureManager.NotBasePlatform));
                    }
                    for (int i = 175; i < 1100; i += 100)
                    {
                        totalPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 500, 100, 50), textureManager.NotBasePlatform));
                    }

                    // Third level platforms
                    for (int i = -500; i > -2500; i -= 100)
                    {
                        totalPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 900, 100, 50), textureManager.NotBasePlatform));
                    }
                    for (int i = 500; i < 2500; i += 100)
                    {
                        totalPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 900, 100, 50), textureManager.NotBasePlatform));
                    }

                    // Misc platforms
                    for (int i = 0; i > -300; i -= 100)
                    {
                        totalPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 300, 100, 50), textureManager.NotBasePlatform));
                    }
                    for (int i = 0; i < 300; i += 100)
                    {
                        totalPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 300, 100, 50), textureManager.NotBasePlatform));
                    }

                    for (int i = 0; i > -300; i -= 100)
                    {
                        totalPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 700, 100, 50), textureManager.NotBasePlatform));
                    }
                    for (int i = 0; i < 300; i += 100)
                    {
                        totalPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 700, 100, 50), textureManager.NotBasePlatform));
                    }

                    // Walls
                    for (int i = -1500; i <= graphicsDevice.Viewport.Height; i += 100)
                    {
                        leftWalls.Add(new Platform(new Rectangle(-3000, i, 100, 100), textureManager.BasePlatform));
                    }
                    for (int i = -1500; i <= graphicsDevice.Viewport.Height; i += 100)
                    {
                        rightWalls.Add(new Platform(new Rectangle(3000, i, 100, 100), textureManager.BasePlatform));
                    }
                    break;

                case PlatformVersion.Hard:
                    // Base platforms
                    for (int i = 0; i > -2000; i -= 100)
                    {
                        totalPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 100, 100, 100), textureManager.BasePlatform));
                    }
                    for (int i = 0; i < 2000; i += 100)
                    {
                        totalPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 100, 100, 100), textureManager.BasePlatform));
                    }
                    // First level platforms
                    for (int i = 0; i > -2000; i -= 100)
                    {
                        totalPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 500, 100, 50), textureManager.NotBasePlatform));
                    }
                    for (int i = 0; i < 1300; i += 100)
                    {
                        totalPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 500, 100, 50), textureManager.NotBasePlatform));
                    }

                    // Second level platforms
                    for (int i = 0; i > -1300; i -= 100)
                    {
                        totalPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 900, 100, 50), textureManager.NotBasePlatform));
                    }
                    for (int i = 0; i < 2000; i += 100)
                    {
                        totalPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 900, 100, 50), textureManager.NotBasePlatform));
                    }

                    // Third level platforms
                    for (int i = 0; i > -2000; i -= 100)
                    {
                        totalPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 1300, 100, 50), textureManager.NotBasePlatform));
                    }
                    for (int i = 0; i < 1300; i += 100)
                    {
                        totalPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 1300, 100, 50), textureManager.NotBasePlatform));
                    }

                    // Fourth level platforms
                    for (int i = 0; i > -1300; i -= 100)
                    {
                        totalPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 1700, 100, 50), textureManager.NotBasePlatform));
                    }
                    for (int i = 0; i < 2000; i += 100)
                    {
                        totalPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 1700, 100, 50), textureManager.NotBasePlatform));
                    }

                    // Fifth level platforms
                    for (int i = 0; i > -2000; i -= 100)
                    {
                        totalPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 2100, 100, 50), textureManager.NotBasePlatform));
                    }
                    for (int i = 0; i < 1300; i += 100)
                    {
                        totalPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 2100, 100, 50), textureManager.NotBasePlatform));
                    }

                    // Misc platforms
                    for (int i = 1500; i < 2000; i += 100)
                    {
                        totalPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 300, 100, 50), textureManager.NotBasePlatform));
                    }
                    for (int i = -1500; i > -2000; i -= 100)
                    {
                        totalPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 700, 100, 50), textureManager.NotBasePlatform));
                    }
                    for (int i = 1500; i < 2000; i += 100)
                    {
                        totalPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 1100, 100, 50), textureManager.NotBasePlatform));
                    }
                    for (int i = -1500; i > -2000; i -= 100)
                    {
                        totalPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 1500, 100, 50), textureManager.NotBasePlatform));
                    }
                    for (int i = 1500; i < 2000; i += 100)
                    {
                        totalPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 1900, 100, 50), textureManager.NotBasePlatform));
                    }

                    // Walls
                    for (int i = -2200; i <= graphicsDevice.Viewport.Height; i += 100)
                    {
                        leftWalls.Add(new Platform(new Rectangle(-2000, i, 100, 100), textureManager.BasePlatform));
                    }
                    for (int i = -2200; i <= graphicsDevice.Viewport.Height; i += 100)
                    {
                        rightWalls.Add(new Platform(new Rectangle(2000, i, 100, 100), textureManager.BasePlatform));
                    }
                    break;

                case PlatformVersion.Mean:
                    // Base platforms
                    for (int i = 0; i > -3000; i -= 100)
                    {
                        totalPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 100, 100, 100), textureManager.BasePlatform));
                    }
                    for (int i = 0; i < 3000; i += 100)
                    {
                        totalPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 100, 100, 100), textureManager.BasePlatform));
                    }
                    // First level platforms
                    for (int i = 0; i > -250; i -= 100)
                    {
                        totalPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 500, 100, 50), textureManager.NotBasePlatform));
                    }
                    for (int i = 0; i < 250; i += 100)
                    {
                        totalPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 500, 100, 50), textureManager.NotBasePlatform));
                    }

                    // Second level platforms
                    for (int i = -1750; i > -3000; i -= 100)
                    {
                        totalPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 900, 100, 50), textureManager.NotBasePlatform));
                    }
                    for (int i = 1750; i < 3000; i += 100)
                    {
                        totalPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 900, 100, 50), textureManager.NotBasePlatform));
                    }
                    for (int i = 0; i > -200; i -= 100)
                    {
                        totalPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 900, 100, 50), textureManager.NotBasePlatform));
                    }
                    for (int i = 0; i < 200; i += 100)
                    {
                        totalPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 900, 100, 50), textureManager.NotBasePlatform));
                    }

                    // Third level platforms
                    for (int i = -500; i > -1800; i -= 100)
                    {
                        totalPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 1100, 100, 50), textureManager.NotBasePlatform));
                    }
                    for (int i = 500; i < 1800; i += 100)
                    {
                        totalPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 1100, 100, 50), textureManager.NotBasePlatform));
                    }

                    // Fourth level platforms
                    for (int i = 0; i > -250; i -= 100)
                    {
                        totalPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 1500, 100, 50), textureManager.NotBasePlatform));
                    }
                    for (int i = 0; i < 250; i += 100)
                    {
                        totalPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 1500, 100, 50), textureManager.NotBasePlatform));
                    }

                    // Misc platforms
                    for (int i = -2500; i > -3000; i -= 100)
                    {
                        totalPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 300, 100, 50), textureManager.NotBasePlatform));
                    }
                    for (int i = 2500; i < 3000; i += 100)
                    {
                        totalPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 300, 100, 50), textureManager.NotBasePlatform));
                    }

                    for (int i = -1750; i > -2250; i -= 100)
                    {
                        totalPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 500, 100, 50), textureManager.NotBasePlatform));
                    }
                    for (int i = 1750; i < 2250; i += 100)
                    {
                        totalPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 500, 100, 50), textureManager.NotBasePlatform));
                    }

                    for (int i = -1300; i > -1500; i -= 100)
                    {
                        totalPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 700, 100, 50), textureManager.NotBasePlatform));
                    }
                    for (int i = 1300; i < 1500; i += 100)
                    {
                        totalPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 700, 100, 50), textureManager.NotBasePlatform));
                    }

                    for (int i = -500; i > -1800; i -= 100)
                    {
                        totalPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 1100, 100, 50), textureManager.NotBasePlatform));
                    }
                    for (int i = 500; i < 1800; i += 100)
                    {
                        totalPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 1100, 100, 50), textureManager.NotBasePlatform));
                    }

                    for (int i = 0; i > -200; i -= 100)
                    {
                        totalPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 1100, 100, 50), textureManager.NotBasePlatform));
                    }
                    for (int i = 0; i < 200; i += 100)
                    {
                        totalPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 1100, 100, 50), textureManager.NotBasePlatform));
                    }

                    for (int i = -1750; i > -2000; i -= 100)
                    {
                        totalPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 1300, 100, 50), textureManager.NotBasePlatform));
                    }
                    for (int i = 1750; i < 2000; i += 100)
                    {
                        totalPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 1300, 100, 50), textureManager.NotBasePlatform));
                    }

                    for (int i = -1000; i > -1300; i -= 100)
                    {
                        totalPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 1300, 100, 50), textureManager.NotBasePlatform));
                    }
                    for (int i = 1000; i < 1300; i += 100)
                    {
                        totalPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 1300, 100, 50), textureManager.NotBasePlatform));
                    }

                    for (int i = -250; i > -600; i -= 100)
                    {
                        totalPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 1300, 100, 50), textureManager.NotBasePlatform));
                    }
                    for (int i = 250; i < 600; i += 100)
                    {
                        totalPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 1300, 100, 50), textureManager.NotBasePlatform));
                    }

                    for (int i = -1400; i > -1550; i -= 100)
                    {
                        totalPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 1500, 100, 50), textureManager.NotBasePlatform));
                    }
                    for (int i = 1400; i < 1550; i += 100)
                    {
                        totalPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 1500, 100, 50), textureManager.NotBasePlatform));
                    }

                    for (int i = -700; i > -850; i -= 100)
                    {
                        totalPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 1500, 100, 50), textureManager.NotBasePlatform));
                    }
                    for (int i = 700; i < 850; i += 100)
                    {
                        totalPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 1500, 100, 50), textureManager.NotBasePlatform));
                    }

                    // Walls
                    for (int i = -1500; i <= graphicsDevice.Viewport.Height; i += 100)
                    {
                        leftWalls.Add(new Platform(new Rectangle(-3000, i, 100, 100), textureManager.BasePlatform));
                    }
                    for (int i = -1500; i <= graphicsDevice.Viewport.Height; i += 100)
                    {
                        rightWalls.Add(new Platform(new Rectangle(3000, i, 100, 100), textureManager.BasePlatform));
                    }
                    break;
                
                case PlatformVersion.Life:
                    // Base platforms
                    for (int i = 0; i > -1500; i -= 100)
                    {
                        totalPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 100, 100, 100), textureManager.BasePlatform));
                    }
                    for (int i = 0; i < 500; i += 100)
                    {
                        totalPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 100, 100, 100), textureManager.BasePlatform));
                    }
                    for (int i = -1500; i > -2500; i -= 100)
                    {
                        totalPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 1300, 100, 100), textureManager.BasePlatform));
                    }

                    // First level platforms
                    for (int i = 0; i > -1000; i -= 100)
                    {
                        totalPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 500, 100, 50), textureManager.NotBasePlatform));
                    }

                    // Second level platforms
                    for (int i = 0; i > -500; i -= 100)
                    {
                        totalPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 1500, 100, 50), textureManager.NotBasePlatform));
                    }
                    for (int i = 0; i < 400; i += 100)
                    {
                        totalPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 1500, 100, 50), textureManager.NotBasePlatform));
                    }

                    // Third level platforms
                    for (int i = 0; i > -1200; i -= 100)
                    {
                        totalPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 2100, 100, 50), textureManager.NotBasePlatform));
                    }
                    for (int i = 0; i < 1100; i += 100)
                    {
                        totalPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 2100, 100, 50), textureManager.NotBasePlatform));
                    }

                    // Fourth level platforms
                    for (int i = 600; i < 1100; i += 100)
                    {
                        totalPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 1100, 100, 50), textureManager.NotBasePlatform));
                    }

                    // Fifth level platforms
                    for (int i = 600; i < 1100; i += 100)
                    {
                        totalPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 600, 100, 50), textureManager.NotBasePlatform));
                    }

                    // Misc platforms
                    for (int i = -900; i > -1500; i -= 100)
                    {
                        totalPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 300, 100, 50), textureManager.NotBasePlatform));
                    }
                    
                    for (int i = 150; i < 450; i += 100)
                    {
                        totalPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 700, 100, 50), textureManager.NotBasePlatform));
                    }

                    for (int i = 0; i > -800; i -= 100)
                    {
                        totalPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 900, 100, 50), textureManager.NotBasePlatform));
                    }

                    for (int i = -900; i > -1300; i -= 100)
                    {
                        totalPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 1100, 100, 50), textureManager.NotBasePlatform));
                    }

                    for (int i = -700; i > -800; i -= 100)
                    {
                        totalPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 1300, 100, 50), textureManager.NotBasePlatform));
                    }

                    for (int i = -1900; i > -2200; i -= 100)
                    {
                        totalPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 1500, 100, 50), textureManager.NotBasePlatform));
                    }

                    for (int i = -1300; i > -1800; i -= 100)
                    {
                        totalPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 1700, 100, 50), textureManager.NotBasePlatform));
                    }

                    for (int i = -1950; i > -2550; i -= 100)
                    {
                        totalPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 1900, 100, 50), textureManager.NotBasePlatform));
                    }

                    for (int i = -1650; i > -1950; i -= 100)
                    {
                        totalPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 2100, 100, 50), textureManager.NotBasePlatform));
                    }

                    for (int i = -1400; i > -1500; i -= 100)
                    {
                        totalPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 2300, 100, 50), textureManager.NotBasePlatform));
                    }

                    totalPlatforms.Add(new Platform(new Rectangle(500, 1250, 100, 50), textureManager.NotBasePlatform));
                    totalPlatforms.Add(new Platform(new Rectangle(500, 1300, 100, 50), textureManager.NotBasePlatform));

                    // Walls
                    for (int i = -400; i <= graphicsDevice.Viewport.Height; i += 100)
                    {
                        leftWalls.Add(new Platform(new Rectangle(-1500, i, 100, 100), textureManager.BasePlatform));
                    }
                    for (int i = -2900; i <= graphicsDevice.Viewport.Height; i += 100)
                    {
                        rightWalls.Add(new Platform(new Rectangle(1500, i, 100, 100), textureManager.BasePlatform));
                    }
                    for (int i = -2900; i <= graphicsDevice.Viewport.Height - 1250; i += 100)
                    {
                        leftWalls.Add(new Platform(new Rectangle(-2500, i, 100, 100), textureManager.BasePlatform));
                    }
                    for (int i = -1200; i <= graphicsDevice.Viewport.Height; i += 100)
                    {
                        rightWalls.Add(new Platform(new Rectangle(500, i, 100, 100), textureManager.BasePlatform));
                        leftWalls.Add(new Platform(new Rectangle(500, i, 100, 100), textureManager.BasePlatform));
                    }
                    for (int i = -1400; i <= graphicsDevice.Viewport.Height - 2100; i += 100)
                    {
                        rightWalls.Add(new Platform(new Rectangle(-1200, i, 100, 100), textureManager.BasePlatform));
                        leftWalls.Add(new Platform(new Rectangle(-1200, i, 100, 100), textureManager.BasePlatform));
                    }
                    break;
            }
        }
        #endregion

        #region ClearPlatformLists
        public void ClearPlatformLists()
        {
            totalPlatforms.Clear();
            leftWalls.Clear();
            rightWalls.Clear();
        }
        #endregion

    }
}
