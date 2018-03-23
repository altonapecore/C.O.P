using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Purpose
{
    //Using the StreamReader gets infor needed to run the waves
    class Wave
    {
        //Fields for the number of enemies to spawn
        private int numberOfMelee;
        private int numberOfRanged;

        //Holds level of difficulty for enemies
        private int difficulty;

        //List for Waves and info for wave is stored
        private List<Wave> waves;

        //Properties for enemies
        public int NumberOfMelee
        {
            get { return numberOfMelee; }
            set { numberOfMelee = value; }
        }

        public int NumberOfRanged
        {
            get { return numberOfRanged; }
            set { numberOfRanged = value; }
        }

        //Property for Difficulty
        public int Difficulty
        {
            get { return difficulty; }
            set { difficulty = value; }
        }

        public List<Wave> Waves
        {
            get { return waves; }
            set { waves = value; }
        }

        //Default Constructor
        public Wave()
        {
            numberOfMelee = 0;
            numberOfRanged = 0;
            difficulty = 1;
            waves = new List<Wave>();
        }

        //Parameterized Constructor
        public Wave(int numberOfMelee, int numberOfRanged, int difficulty)
        {
            this.numberOfMelee = numberOfMelee;
            this.numberOfRanged = numberOfRanged;
            this.difficulty = difficulty;
        }
    }
}
