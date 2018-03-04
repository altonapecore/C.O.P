using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Purpose
{
    class Platform : Item
    {
        public Platform(Rectangle position, Texture2D texture) : base(position, texture)
        {
            this.position = position;
            this.texture = texture;
        }
    }
}
