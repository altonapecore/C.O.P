﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Purpose
{
    public class UpgradeManager
    {
        //fields
        private bool dashActive;
        private bool groundPoundActive;
        private int staminaTier;
        private int healthTier;
        private int stealthTier;
        private int damageTier;
        private int upgradePoints;

        //properties
        public bool DashActive
        {
            get { return dashActive; }
            set { dashActive = value; }
        }

        public bool GroundPoundActive
        {
            get { return groundPoundActive; }
            set { groundPoundActive = value; }
        }

        public int UpgradePoints
        {
            get { return upgradePoints; }
            set { upgradePoints = value; }
        }
        
        //constructor
        public UpgradeManager()
        {
            upgradePoints = 10;
            dashActive = false;
            groundPoundActive = false;
            staminaTier = 0;
            healthTier = 0;
            stealthTier = 0;
            damageTier = 0;
        }

        // Methods
        public int StaminaUpgrade(int staminaMax)
        {
            if (upgradePoints > 0)
            {
                staminaTier++;
                if (staminaTier < 3)
                {
                    staminaMax += 5;
                }
                else if (staminaTier > 3)
                {
                    staminaMax += 10;
                }
                upgradePoints--;
                return staminaMax;
            }
            return 0;
        }

        public int HealthUpgrade(int healthMax)
        {
            if (upgradePoints > 0)
            {
                healthTier++;
                if (healthTier < 3)
                {
                    healthMax += 5;
                }
                else if (healthTier >= 3)
                {
                    healthMax += 10;
                }
                upgradePoints--;
                return healthMax;
            }
            return 0;
        }

        public int AttackUpgrade(int damage)
        {
            if (upgradePoints > 0)
            {
                damageTier++;
                if (damageTier < 3)
                {
                    damage += 5;
                }
                else if (damageTier >= 3)
                {
                    damage += 10;
                }
                upgradePoints--;
                return damage;
            }
            return 0;
        }

        public int DashDistanceUpgrade(int dashDistance)
        {
            if (upgradePoints > 0 && dashActive)
            {
                stealthTier++;
                if (stealthTier < 3)
                {
                    dashDistance += 10;
                }
                else if (stealthTier >= 3)
                {
                    dashDistance += 20;
                }
                upgradePoints--;
                return dashDistance;
            }
            return 0;
        }

        public void ActivateDash()
        {
            if (upgradePoints > 0)
            {
                if (!dashActive)
                {
                    dashActive = true;
                    upgradePoints--;
                }
            }
        }

        public void ActivateGroundPound()
        {
            if (upgradePoints > 1)
            {
                if (!groundPoundActive)
                {
                    groundPoundActive = true;
                    upgradePoints-=2;
                }
            }
        }
    }
}
