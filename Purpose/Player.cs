using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace Purpose
{
    class Player : Character
    {
        //fields
        private int kills;
        private int upgradePoints;
        private int passiveTier;
        private int stealthTier;
        private int damageTier;

        //properties
        public int Kills
        {
            get { return kills; }
            set { kills = value; }
        }

        //constructor
        public Player(string name, Rectangle position, Texture2D texture) : base(name, position, texture)
        {
            kills = 0;
            upgradePoints = 0;
            damage = 10;
            health = 100;
            passiveTier = 1;
            stealthTier = 1;
            damageTier = 1;
        }

        //methods
        public void Move(KeyboardState kbState)
        {
            if (kbState.IsKeyDown(Keys.A))
            {
                position.X -= 5;
            }
            if (kbState.IsKeyDown(Keys.D))
            {
                position.X += 5;
            }
            if (kbState.IsKeyDown(Keys.Space))
            {
                Jump();
            }
        }

        public override int Attack()
        {
            return damage;
        }

        public override void TakeDamage(int damage)
        {
            
        }

        public void Jump()
        {

        }
    }
}
