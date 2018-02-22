using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Purpose
{
    class GameObject
    {
        //fields
        protected Rectangle position;
        protected Texture2D texture;

        //properties
        public Rectangle Position { get { return position; } }
        public int X
        {
            get { return position.X; }
            set { position.X = value; }
        }
        public int Y
        {
            get { return position.Y; }
            set { position.Y = value; }
        }
        public Texture2D Texture { get { return texture; } }

        //constructor
        public GameObject(Rectangle position, Texture2D texture)
        {
            this.position = position;
            this.texture = texture;
        }

        //methods
        
    }
}
