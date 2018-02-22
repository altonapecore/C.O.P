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
        }

        //methods
    }
}
