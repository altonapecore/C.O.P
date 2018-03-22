using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Purpose
{
    public class Platform : GameObject
    {
        // Constructor
        public Platform(Rectangle position, Texture2D texture) : base(texture)
        {
            this.position = position;
            this.texture = texture;
        }

        /// <summary>
        /// Checks to see if the platform is above another platform
        /// If it is, return true. If not, return false
        /// </summary>
        public bool AbovePlatform(List<Platform> platforms)
        {
            foreach(Platform platformToBeChecked in platforms)
            {
                foreach(Platform platformToBeCheckedAgainst in platforms)
                {
                    if(platformToBeChecked.Y > platformToBeCheckedAgainst.Y)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return false;
        }
    }
}
