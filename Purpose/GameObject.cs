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
        public Rectangle Position
        {
            get { return position; }
            set { position = value; }
        }
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
        public Texture2D Texture
        {
            get { return texture; }
            set { texture = value; }
        }

        //constructor
        public GameObject(Texture2D texture)
        {
            this.texture = texture;
        }

        public GameObject(Texture2D texture, Rectangle position)
        {
            this.texture = texture;
            this.position = position;
        }
        
        public bool Intersects(Point mousePosition)
        {
            Rectangle mouseRectangle = new Rectangle(mousePosition.X, mousePosition.Y, 5, 5);

            if (position.Intersects(mouseRectangle))
            {
                return true;
            }
            return false;
        }
    }
}
