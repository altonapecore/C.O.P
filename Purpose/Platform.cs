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
    }
}
