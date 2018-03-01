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

        public void DashUpgrade()
        {
            dashActive = true;
        }
        public void GroundUpgrade()
        {
            groundPoundActive = true;
        }
        public void PassiveUpgrade(int passiveTier,int stamina, int staminaRegen, int health)
        {
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
        public void DamageUpgrade(int damageTier, int damage)
        {
            if (damageTier == 1 || damageTier == 2 || damageTier == 3 || damageTier == 4 || damageTier == 5)
            {
                damage += 10;
            }
            else if(damageTier==6)
            {
                GroundUpgrade();
            }
        }
        //methods
    }
}
