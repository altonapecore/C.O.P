using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Purpose
{
    class UpgradeManager
    {
        //fields
        private bool dashActive;
        private bool groundPoundActive;
        private int passiveTier;
        private int stealthTier;
        private int damageTier;

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
        
        //constructor
        public UpgradeManager()
        {
            dashActive = false;
            groundPoundActive = false;
            passiveTier = 1;
            stealthTier = 1;
            damageTier = 1;
        }

        // Methods
        public void PassiveUpgrade(int stamina, int staminaRegen, int health)
        {
            ++passiveTier;
            if(passiveTier==1)
            {
                staminaRegen += 1;
            }
            else if(passiveTier==2 || passiveTier==3 || passiveTier==4 || passiveTier==5 || passiveTier==6)
            {
                health += 10;
            }
            else if(passiveTier==7)
            {
                stamina += 100;
            }
            passiveTier++;
        }
        public void DamageUpgrade(int damage)
        {
            ++damageTier;
            if (damageTier == 1 || damageTier == 2 || damageTier == 3 || damageTier == 4 || damageTier == 5)
            {
                damage += 10;
            }
            else if(damageTier==6)
            {
                groundPoundActive = true;
            }
        }
        public void StealthUpgrade(int dashDistance)
        {
            ++stealthTier;
            if(stealthTier == 1)
            {
                dashActive = true;
            }
            else if(stealthTier == 2 || stealthTier == 3 || stealthTier == 4 || stealthTier == 5)
            {
                dashDistance += 10;
            }
        }
    }
}
