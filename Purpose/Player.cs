﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Purpose
{
    public class Player : Character
    {
        //fields
        private int kills;
        private UpgradeManager ugManager;
        private TextureManager textureManager;
        private int stamina;
        private int dashDistance;
        private bool onBasePlatform;
        private int healthMax;
        private int staminaMax;
        private int velocity;
        private int gameTime;
        private int healthRegen;
        private int staminaRegen;
        private int previousX;
        private int horizontalVelocity;
        private int groundPoundStaminaCost;
        private int dashStaminaCost;
        private int groundPoundDamage;
        private bool combatStatus;

        //properties
        public int Kills
        {
            get { return kills; }
            set { kills = value; }
        }

        public int Stamina
        {
            get { return stamina; }
            set { stamina = value; }
        }

        public int DashDistance
        {
            get { return dashDistance; }
            set { dashDistance = value; }
        }

        public bool IsOnBasePlatform
        {
            get { return onBasePlatform; }
            set { onBasePlatform = value; }
        }

        public int HealthMax
        {
            get { return healthMax; }
            set { healthMax = value; }
        }

        public int StaminaMax
        {
            get { return staminaMax; }
            set { staminaMax = value; }
        }

        public int Velocity
        {
            get { return velocity; }
            set { velocity = value; }
        }

        public int HealthRegen
        {
            get { return healthRegen; }
            set { healthRegen = value; }
        }

        public int StaminaRegen
        {
            get { return staminaRegen; }
            set { staminaRegen = value; }
        }

        public UpgradeManager UgManager { get { return ugManager; } }

        public int GameTime { get { return gameTime; } }

        public int PreviousX { get { return previousX; } }
        
        public int HorizontalVelocity
        {
            get { return horizontalVelocity; }
            set { horizontalVelocity = value; }
        }

        public int GroundPoundStaminaCost { get { return groundPoundStaminaCost; } }
        
        public int DashStaminaCost { get { return dashStaminaCost; } }

        public int GroundPoundDamage { get { return groundPoundDamage; } }

        public bool CombatStatus
        {
            get { return combatStatus; }
            set { combatStatus = value; }
        }

        //secondary temporary constructor for debug purposes
        public Player(String name, Rectangle position, TextureManager textureManager, GameTime gameTime) : base(textureManager.RightStandingSprite)
        {
            this.textureManager = textureManager;
            ugManager = new UpgradeManager();

            this.position = position;
            health = 100;
            healthMax = health;
            stamina = 100;
            staminaMax = stamina;
            dashDistance = 200;
            damage = 10;
            texture = textureManager.RightStandingSprite;
            kills = 0;
            healthRegen = 2;
            staminaRegen = 1;
            this.gameTime = gameTime.TotalGameTime.Milliseconds;
            horizontalVelocity = 8;
            groundPoundStaminaCost = 40;
            dashStaminaCost = 20;
            groundPoundDamage = 20;
            combatStatus = false;
        }

        //methods
        /// <summary>
        /// Allows the player to attack by checking if the player is intersecting with another character's position
        /// </summary>
        /// <param name="enemyPosition">The position of the enemy</param>
        /// <returns>Returns an integer value for the damage done</returns>
        public override int Attack(Character enemy, GameTime gameTime)
        {
            if (this.gameTime + 200 <= gameTime.TotalGameTime.TotalMilliseconds)
            {
                if (position.Intersects(enemy.Position))
                {
                    this.gameTime = gameTime.TotalGameTime.Milliseconds;
                    combatStatus = true;
                    return damage;
                }
                return 0;
            }
            return 0;
        }

        /// <summary>
        /// Allows the player to take damage
        /// </summary>
        /// <param name="damage">The damage done to the player</param>
        public override void TakeDamage(int damage)
        {
            health -= damage;
            if(health <= 0)
            {
                isDead = true;
            }
        }

        /// <summary>
        /// Allows the player to jump
        /// </summary>
        public void Jump()
        {
            velocity = -30;
            Y += velocity;
        }

        /// <summary>
        /// Allows the player to execute their ground pound attack
        /// </summary>
        /// <param name="enemies">The list of enemies in the game</param>
        public void GroundPound(List<Enemy> enemies)
        {
            Rectangle groundPoundArea = new Rectangle(position.X-200, (position.Y + position.Height-20), 500, 20);
            if (ugManager.GroundPoundActive && stamina >= 40)
            {
                for (int i = 0; i < enemies.Count; i++)
                {
                    if (Math.Abs(enemies[i].X - X) < 500 && Math.Abs(enemies[i].Y - Y) < 200)
                    {
                        enemies[i].TakeDamage(groundPoundDamage);
                        enemies[i].Y -= 50;
                    }

                    if (enemies[i].IsDead)
                    {
                        enemies.RemoveAt(i);
                        kills++;
                        if (kills != 0 && kills % 3 == 0)
                        {
                            ugManager.UpgradePoints++;
                        }
                    }
                }
                stamina -= groundPoundStaminaCost;
            }
        }

        /// <summary>
        /// Increases the player speed for a short time
        /// </summary>
        public void Dash()
        {
            previousX = X;

            if (ugManager.DashActive && stamina >= 20)
            {
                //if (texture == textureManager.RightStandingSprite || texture == textureManager.RightRunningSprite
                //    || texture == textureManager.RightMiddleRunningSprite) //dash to the right
                //{
                //    X += dashDistance;
                //}
                //else if (texture == textureManager.LeftStandingSprite || texture == textureManager.LeftRunningSprite
                //    || texture == textureManager.LeftMiddleRunningSprite) //dash to the left
                //{
                //    X -= dashDistance;
                //}
                horizontalVelocity = 16;
                stamina -= dashStaminaCost;
            }
        }
    }
}
