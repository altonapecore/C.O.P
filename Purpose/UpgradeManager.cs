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
        private int dashUpCost;
        private int groundPoundCost;
        private int damageUpCost;
        private int dashCost;
        private int healthUpCost;
        private int staminaUpCost;

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

        public int DashUpCost { get { return dashUpCost; } }
        public int GroundPoundCost { get { return groundPoundCost; } }
        public int DamageUpCost { get { return damageUpCost; } }
        public int DashCost { get { return dashCost; } }
        public int HealthUpCost { get { return healthUpCost; } }
        public int StaminaUpCost { get { return staminaUpCost; } }
        
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

            damageUpCost = 1;
            dashCost = 3;
            dashUpCost = 1;
            groundPoundCost = 5;
            healthUpCost = 1;
            staminaUpCost = 1;
        }

        // Methods
        public void StaminaUpgrade(Player player)
        {
            if (upgradePoints > 0)
            {
                staminaTier++;
                if (staminaTier < 3 && upgradePoints > staminaUpCost - 1)
                {
                    player.StaminaMax += 2;
                    upgradePoints -= staminaUpCost;
                    if (staminaTier == 2)
                    {
                        staminaUpCost = 2;
                    }
                }
                else if (staminaTier > 6 && upgradePoints > staminaUpCost - 1)
                {
                    player.StaminaMax += 6;
                    player.StaminaRegen += 2;
                    upgradePoints -= staminaUpCost;
                }
                else if (staminaTier > 3 && upgradePoints > staminaUpCost - 1)
                {
                    player.StaminaMax += 4;
                    player.StaminaRegen += 1;
                    upgradePoints -= staminaUpCost;
                    if (staminaTier == 5)
                    {
                        staminaUpCost = 3;
                    }
                }
            }
        }

        public void HealthUpgrade(Player player)
        {
            if (upgradePoints > 0)
            {
                healthTier++;
                if (healthTier < 3 && upgradePoints > healthUpCost - 1)
                {
                    player.HealthMax += 2;
                    upgradePoints -= healthUpCost;
                    if (healthTier == 2)
                    {
                        healthUpCost = 2;
                    }
                }
                else if (healthTier > 6 && upgradePoints > healthUpCost - 1)
                {
                    player.HealthMax += 6;
                    player.HealthRegen += 2;
                    upgradePoints -= healthUpCost;
                }
                else if (healthTier >= 3 && upgradePoints > healthUpCost - 1)
                {
                    player.HealthMax += 4;
                    player.HealthRegen += 1;
                    upgradePoints -= healthUpCost;
                    if (healthTier == 5)
                    {
                        healthUpCost = 3;
                    }
                }
            }
        }

        public int AttackUpgrade(int damage)
        {
            if (upgradePoints > 0)
            {
                damageTier++;
                if (damageTier < 3 && upgradePoints > damageUpCost - 1)
                {
                    damage += 3;
                    upgradePoints -= damageUpCost;
                    if (damageTier == 2)
                    {
                        damageUpCost = 2;
                    }
                }
                else if (damageTier >= 12 && upgradePoints > damageUpCost - 1)
                {
                    damage += 0;
                    damageTier = 12;
                }
                else if (damageTier >= 9 && upgradePoints > damageUpCost - 1)
                {
                    damage += 3;
                    upgradePoints -= damageUpCost;
                    if (damageTier == 11)
                    {
                        damageUpCost = 0;
                    }
                }
                else if (damageTier >= 6 && upgradePoints > damageUpCost - 1)
                {
                    damage += 3;
                    upgradePoints -= damageUpCost;
                    if (damageTier == 8)
                    {
                        damageUpCost = 5;
                    }
                }
                else if (damageTier >= 3 && upgradePoints > damageUpCost - 1)
                {
                    damage += 3;
                    upgradePoints -= damageUpCost;
                    if (damageTier == 5)
                    {
                        damageUpCost = 3;
                    }
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
                upgradePoints -= dashUpCost;
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
                    upgradePoints -= dashCost;
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
                    upgradePoints -= groundPoundCost;
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

            damageUpCost = 1;
            dashCost = 3;
            dashUpCost = 1;
            healthUpCost = 1;
            staminaUpCost = 1;
        }
    }
}
