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
        private List<Platform> bottomPlatforms;
        private List<Platform> firstLevelPlatforms;
        private List<Platform> secondLevelPlatforms;
        private List<Platform> thirdLevelPlatforms;
        private List<Platform> fourthLevelPlatforms;
        private List<Platform> fifthLevelPlatforms;
        private List<Platform> leftWalls;
        private List<Platform> rightWalls;
        private GraphicsDevice graphicsDevice;

        // Properties
        public List<Platform> TotalPlatforms
        {
            get { return totalPlatforms; }
            set { totalPlatforms = value; }
        }
        public List<Platform> BottomPlatforms
        {
            get { return bottomPlatforms; }
            set { bottomPlatforms = value; }
        }
        public List<Platform> FirstLevelPlatforms
        {
            get { return firstLevelPlatforms; }
            set { firstLevelPlatforms = value; }
        }
        public List<Platform> SecondLevelPlatforms
        {
            get { return secondLevelPlatforms; }
            set { secondLevelPlatforms = value; }
        }
        public List<Platform> ThirdLevelPlatforms
        {
            get { return thirdLevelPlatforms; }
            set { thirdLevelPlatforms = value; }
        }
        public List<Platform> FourthLevelPlatforms
        {
            get { return fourthLevelPlatforms; }
            set { fourthLevelPlatforms = value; }
        }
        public List<Platform> FifthLevelPlatforms
        {
            get { return fifthLevelPlatforms; }
            set { fifthLevelPlatforms = value; }
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
            bottomPlatforms = new List<Platform>();
            firstLevelPlatforms = new List<Platform>();
            secondLevelPlatforms = new List<Platform>();
            thirdLevelPlatforms = new List<Platform>();
            fourthLevelPlatforms = new List<Platform>();
            fifthLevelPlatforms = new List<Platform>();
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
                        bottomPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 100, 100, 100), textureManager.BasePlatform));
                        totalPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 100, 100, 100), textureManager.BasePlatform));
                    }
                    for (int i = 0; i < 3000; i += 100)
                    {
                        bottomPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 100, 100, 100), textureManager.BasePlatform));
                        totalPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 100, 100, 100), textureManager.BasePlatform));
                    }
                    // First level platforms
                    for (int i = -1250; i > -3000; i -= 100)
                    {
                        firstLevelPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 300, 100, 50), textureManager.NotBasePlatform));
                        totalPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 300, 100, 50), textureManager.NotBasePlatform));
                    }
                    for (int i = 1250; i < 3000; i += 100)
                    {
                        firstLevelPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 300, 100, 50), textureManager.NotBasePlatform));
                        totalPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 300, 100, 50), textureManager.NotBasePlatform));
                    }

                    // Second level platforms
                    for (int i = -175; i > -1100; i -= 100)
                    {
                        secondLevelPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 500, 100, 50), textureManager.NotBasePlatform));
                        totalPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 500, 100, 50), textureManager.NotBasePlatform));
                    }
                    for (int i = 175; i < 1100; i += 100)
                    {
                        secondLevelPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 500, 100, 50), textureManager.NotBasePlatform));
                        totalPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 500, 100, 50), textureManager.NotBasePlatform));
                    }

                    // Third level platforms
                    for (int i = -500; i > -2500; i -= 100)
                    {
                        thirdLevelPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 900, 100, 50), textureManager.NotBasePlatform));
                        totalPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 900, 100, 50), textureManager.NotBasePlatform));
                    }
                    for (int i = 500; i < 2500; i += 100)
                    {
                        thirdLevelPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 900, 100, 50), textureManager.NotBasePlatform));
                        totalPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 900, 100, 50), textureManager.NotBasePlatform));
                    }

                    // Misc platforms
                    for (int i = 0; i > -300; i -= 100)
                    {
                        totalPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 700, 100, 50), textureManager.NotBasePlatform));
                        totalPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 300, 100, 50), textureManager.NotBasePlatform));
                    }
                    for (int i = 0; i < 300; i += 100)
                    {
                        totalPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 700, 100, 50), textureManager.NotBasePlatform));
                        totalPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 300, 100, 50), textureManager.NotBasePlatform));
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
                    for (int i = 0; i > -2000; i -= 100)
                    {
                        bottomPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 100, 100, 100), textureManager.BasePlatform));
                        totalPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 100, 100, 100), textureManager.BasePlatform));
                    }
                    for (int i = 0; i < 2000; i += 100)
                    {
                        bottomPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 100, 100, 100), textureManager.BasePlatform));
                        totalPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 100, 100, 100), textureManager.BasePlatform));
                    }
                    // First level platforms
                    for (int i = 0; i > -2000; i -= 100)
                    {
                        firstLevelPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 500, 100, 50), textureManager.NotBasePlatform));
                        totalPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 500, 100, 50), textureManager.NotBasePlatform));
                    }
                    for (int i = 0; i < 1300; i += 100)
                    {
                        firstLevelPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 500, 100, 50), textureManager.NotBasePlatform));
                        totalPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 500, 100, 50), textureManager.NotBasePlatform));
                    }

                    // Second level platforms
                    for (int i = 0; i > -1300; i -= 100)
                    {
                        secondLevelPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 900, 100, 50), textureManager.NotBasePlatform));
                        totalPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 900, 100, 50), textureManager.NotBasePlatform));
                    }
                    for (int i = 0; i < 2000; i += 100)
                    {
                        secondLevelPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 900, 100, 50), textureManager.NotBasePlatform));
                        totalPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 900, 100, 50), textureManager.NotBasePlatform));
                    }

                    // Third level platforms
                    for (int i = 0; i > -2000; i -= 100)
                    {
                        thirdLevelPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 1300, 100, 50), textureManager.NotBasePlatform));
                        totalPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 1300, 100, 50), textureManager.NotBasePlatform));
                    }
                    for (int i = 0; i < 1300; i += 100)
                    {
                        thirdLevelPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 1300, 100, 50), textureManager.NotBasePlatform));
                        totalPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 1300, 100, 50), textureManager.NotBasePlatform));
                    }

                    // Fourth level platforms
                    for (int i = 0; i > -1300; i -= 100)
                    {
                        fourthLevelPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 1700, 100, 50), textureManager.NotBasePlatform));
                        totalPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 1700, 100, 50), textureManager.NotBasePlatform));
                    }
                    for (int i = 0; i < 2000; i += 100)
                    {
                        fourthLevelPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 1700, 100, 50), textureManager.NotBasePlatform));
                        totalPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 1700, 100, 50), textureManager.NotBasePlatform));
                    }

                    // Fifth level platforms
                    for (int i = 0; i > -2000; i -= 100)
                    {
                        fifthLevelPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 2100, 100, 50), textureManager.NotBasePlatform));
                        totalPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 2100, 100, 50), textureManager.NotBasePlatform));
                    }
                    for (int i = 0; i < 1300; i += 100)
                    {
                        fifthLevelPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 2100, 100, 50), textureManager.NotBasePlatform));
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
                    for (int i = -1500; i <= graphicsDevice.Viewport.Height; i += 100)
                    {
                        leftWalls.Add(new Platform(new Rectangle(-2000, i, 100, 100), textureManager.BasePlatform));
                    }
                    for (int i = -1500; i <= graphicsDevice.Viewport.Height; i += 100)
                    {
                        rightWalls.Add(new Platform(new Rectangle(2000, i, 100, 100), textureManager.BasePlatform));
                    }
                    break;

                case PlatformVersion.Hard:
                    // Base platforms
                    for (int i = 0; i > -3000; i -= 100)
                    {
                        bottomPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 100, 100, 100), textureManager.BasePlatform));
                        totalPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 100, 100, 100), textureManager.BasePlatform));
                    }
                    for (int i = 0; i < 3000; i += 100)
                    {
                        bottomPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 100, 100, 100), textureManager.BasePlatform));
                        totalPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 100, 100, 100), textureManager.BasePlatform));
                    }
                    // First level platforms
                    for (int i = 0; i > -250; i -= 100)
                    {
                        firstLevelPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 500, 100, 50), textureManager.NotBasePlatform));
                        totalPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 500, 100, 50), textureManager.NotBasePlatform));
                    }
                    for (int i = 0; i < 250; i += 100)
                    {
                        firstLevelPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 500, 100, 50), textureManager.NotBasePlatform));
                        totalPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 500, 100, 50), textureManager.NotBasePlatform));
                    }

                    // Second level platforms
                    for (int i = -1750; i > -3000; i -= 100)
                    {
                        secondLevelPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 900, 100, 50), textureManager.NotBasePlatform));
                        totalPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 900, 100, 50), textureManager.NotBasePlatform));
                    }
                    for (int i = 1750; i < 3000; i += 100)
                    {
                        secondLevelPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 900, 100, 50), textureManager.NotBasePlatform));
                        totalPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 900, 100, 50), textureManager.NotBasePlatform));
                    }
                    for (int i = 0; i > -200; i -= 100)
                    {
                        secondLevelPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 900, 100, 50), textureManager.NotBasePlatform));
                        totalPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 900, 100, 50), textureManager.NotBasePlatform));
                    }
                    for (int i = 0; i < 200; i += 100)
                    {
                        secondLevelPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 900, 100, 50), textureManager.NotBasePlatform));
                        totalPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 900, 100, 50), textureManager.NotBasePlatform));
                    }

                    // Third level platforms
                    for (int i = -500; i > -1800; i -= 100)
                    {
                        thirdLevelPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 1100, 100, 50), textureManager.NotBasePlatform));
                        totalPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 1100, 100, 50), textureManager.NotBasePlatform));
                    }
                    for (int i = 500; i < 1800; i += 100)
                    {
                        thirdLevelPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 1100, 100, 50), textureManager.NotBasePlatform));
                        totalPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 1100, 100, 50), textureManager.NotBasePlatform));
                    }

                    // Fourth level platforms
                    for (int i = 0; i > -250; i -= 100)
                    {
                        fourthLevelPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 1500, 100, 50), textureManager.NotBasePlatform));
                        totalPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 1500, 100, 50), textureManager.NotBasePlatform));
                    }
                    for (int i = 0; i < 250; i += 100)
                    {
                        fourthLevelPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 1500, 100, 50), textureManager.NotBasePlatform));
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

                case PlatformVersion.Mean:
                    // Base platforms
                    for (int i = 0; i > -3000; i -= 100)
                    {
                        bottomPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 100, 100, 100), textureManager.BasePlatform));
                        totalPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 100, 100, 100), textureManager.BasePlatform));
                    }
                    for (int i = 0; i < 3000; i += 100)
                    {
                        bottomPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 100, 100, 100), textureManager.BasePlatform));
                        totalPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 100, 100, 100), textureManager.BasePlatform));
                    }
                    // First level platforms
                    for (int i = -1250; i > -3000; i -= 100)
                    {
                        firstLevelPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 300, 100, 50), textureManager.NotBasePlatform));
                        totalPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 300, 100, 50), textureManager.NotBasePlatform));
                    }
                    for (int i = 1250; i < 3000; i += 100)
                    {
                        firstLevelPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 300, 100, 50), textureManager.NotBasePlatform));
                        totalPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 300, 100, 50), textureManager.NotBasePlatform));
                    }

                    // Second level platforms
                    for (int i = -175; i > -1100; i -= 100)
                    {
                        secondLevelPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 500, 100, 50), textureManager.NotBasePlatform));
                        totalPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 500, 100, 50), textureManager.NotBasePlatform));
                    }
                    for (int i = 175; i < 1100; i += 100)
                    {
                        secondLevelPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 500, 100, 50), textureManager.NotBasePlatform));
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

                case PlatformVersion.Life:
                    // Base platforms
                    for (int i = 0; i > -3000; i -= 100)
                    {
                        bottomPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 100, 100, 100), textureManager.BasePlatform));
                        totalPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 100, 100, 100), textureManager.BasePlatform));
                    }
                    for (int i = 0; i < 3000; i += 100)
                    {
                        bottomPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 100, 100, 100), textureManager.BasePlatform));
                        totalPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 100, 100, 100), textureManager.BasePlatform));
                    }
                    // First level platforms
                    for (int i = -1250; i > -3000; i -= 100)
                    {
                        firstLevelPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 300, 100, 50), textureManager.NotBasePlatform));
                        totalPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 300, 100, 50), textureManager.NotBasePlatform));
                    }
                    for (int i = 1250; i < 3000; i += 100)
                    {
                        firstLevelPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 300, 100, 50), textureManager.NotBasePlatform));
                        totalPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 300, 100, 50), textureManager.NotBasePlatform));
                    }

                    // Second level platforms
                    for (int i = -175; i > -1100; i -= 100)
                    {
                        secondLevelPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 500, 100, 50), textureManager.NotBasePlatform));
                        totalPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 500, 100, 50), textureManager.NotBasePlatform));
                    }
                    for (int i = 175; i < 1100; i += 100)
                    {
                        secondLevelPlatforms.Add(new Platform(new Rectangle(i, graphicsDevice.Viewport.Height - 500, 100, 50), textureManager.NotBasePlatform));
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

            }
        }
        #endregion

        #region ClearPlatformLists
        public void ClearPlatformLists()
        {
            totalPlatforms.Clear();
            firstLevelPlatforms.Clear();
            secondLevelPlatforms.Clear();
            thirdLevelPlatforms.Clear();
            fourthLevelPlatforms.Clear();
            fifthLevelPlatforms.Clear();
            leftWalls.Clear();
            rightWalls.Clear();
        }
        #endregion

    }
}
