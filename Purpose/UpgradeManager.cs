using System;
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
            upgradePoints = 0;
            dashActive = false;
            groundPoundActive = false;
            staminaTier = 0;
            healthTier = 0;
            stealthTier = 0;
            damageTier = 0;
        }

        // Methods
        public void StaminaUpgrade(Player player)
        {
            if (upgradePoints > 0)
            {
                staminaTier++;
                if (staminaTier < 3)
                {
                    player.StaminaMax += 2;
                    upgradePoints--;
                }
                else if (staminaTier > 6 && upgradePoints > 2)
                {
                    player.StaminaMax += 6;
                    player.StaminaRegen += 2;
                    upgradePoints -= 3;
                }
                else if (staminaTier > 3 && upgradePoints > 1)
                {
                    player.StaminaMax += 4;
                    player.StaminaRegen += 1;
                    upgradePoints -= 2;
                }
            }
        }

        public void HealthUpgrade(Player player)
        {
            if (upgradePoints > 0)
            {
                healthTier++;
                if (healthTier < 3)
                {
                    player.HealthMax += 2;
                    upgradePoints--;
                }
                else if (healthTier > 6 && upgradePoints > 2)
                {
                    player.HealthMax += 6;
                    player.HealthRegen += 2;
                    upgradePoints -= 3;
                }
                else if (healthTier >= 3 && upgradePoints > 1)
                {
                    player.HealthMax += 4;
                    player.HealthRegen += 1;
                    upgradePoints -= 2;
                }
            }
        }

        public int AttackUpgrade(int damage)
        {
            if (upgradePoints > 0)
            {
                damageTier++;
                if (damageTier < 3)
                {
                    damage += 1;
                    upgradePoints--;
                }
                else if (damageTier >= 12)
                {
                    damage += 0;
                    damageTier = 12;
                }
                else if (damageTier >= 9 && upgradePoints > 5)
                {
                    damage += 8;
                    upgradePoints -= 5;
                }
                else if (damageTier >= 6 && upgradePoints > 2)
                {
                    damage += 6;
                    upgradePoints -= 3;
                }
                else if (damageTier >= 3 && upgradePoints > 1)
                {
                    damage += 3;
                    upgradePoints -= 2;
                }
            }
            return damage;
        }

        public int DashDistanceUpgrade(int dashDistance)
        {
            if (upgradePoints > 0 && dashActive)
            {
                stealthTier++;
                if (stealthTier < 3)
                {
                    dashDistance += 20;
                }
                else if (stealthTier >= 3)
                {
                    dashDistance += 40;
                }
                upgradePoints--;
                return dashDistance;
            }
            return dashDistance;
        }

        public void ActivateDash()
        {
            if (upgradePoints > 2)
            {
                if (!dashActive)
                {
                    dashActive = true;
                    upgradePoints -= 3;
                }
            }
        }

        public void ActivateGroundPound()
        {
            if (upgradePoints > 4)
            {
                if (!groundPoundActive)
                {
                    groundPoundActive = true;
                    upgradePoints  -= 5;
                }
            }
        }

        public void ResetUpgrades()
        {
            upgradePoints = 0;
            groundPoundActive = false;
            dashActive = false;
            damageTier = 0;
            stealthTier = 0;
            staminaTier = 0;
            healthTier = 0;
        }
    }
}
