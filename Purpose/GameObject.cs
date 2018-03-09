using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Purpose
{
    public class GameObject
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
        public virtual Texture2D Texture
        {
            get { return texture; }
            set { texture = value; }
        }

        //constructor
        public GameObject(Texture2D texture)
        {
            this.texture = texture;
        }
        
    }
}
