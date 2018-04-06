using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Purpose
{
    class PresetWaves
    {
        private GameManager gameManager;

        //Default Constructor
        public PresetWaves(GameManager gameManager)
        {
            this.gameManager = gameManager;
        }

        //Method to create
        //All the waves for the game
        public void CreateWaves()
        {
            //Creating the First Wave
            Wave newWave = new Wave(1, 0, 1);
            //Adding wave to the list of Waves
            gameManager.PresetWaves.Add(newWave);

            //Creating the Second Wave
            newWave = new Wave(2, 0, 1);
            //Adding wave to the list of Waves
            gameManager.PresetWaves.Add(newWave);

            //Creating the Third Wave
            newWave = new Wave(1, 0, 1);
            //Adding wave to the list of Waves
            gameManager.PresetWaves.Add(newWave);

            //Creating the Fourth Wave
            newWave = new Wave(2, 5, 1);
            //Adding wave to the list of Waves
            gameManager.PresetWaves.Add(newWave);

            //First Introduction of Ranged Enemies
            //Creating the Fifth Wave
            newWave = new Wave(10, 1, 2);
            //Adding wave to the list of Waves
            gameManager.PresetWaves.Add(newWave);

            //Creating the Sixth Wave
            newWave = new Wave(2, 1, 2);
            //Adding wave to the list of Waves
            gameManager.PresetWaves.Add(newWave);

            //Creating the Seventh Wave
            newWave = new Wave(3, 8, 2);
            //Adding wave to the list of Waves
            gameManager.PresetWaves.Add(newWave);

            //Creating the Eighth Wave
            newWave = new Wave(8, 2, 2);
            //Adding wave to the list of Waves
            gameManager.PresetWaves.Add(newWave);

            //Creating the Nineth Wave
            newWave = new Wave(4, 3, 2);
            //Adding wave to the list of Waves
            gameManager.PresetWaves.Add(newWave);

            //Creating the Tenth Wave
            newWave = new Wave(5, 4, 2);
            //Adding wave to the list of Waves
            gameManager.PresetWaves.Add(newWave);

            //Creating the Eleventh Wave
            newWave = new Wave(35, 0, 3);
            //Adding wave to the list of Waves
            gameManager.PresetWaves.Add(newWave);

            //Creating the Twelveth Wave
            newWave = new Wave(0, 40, 3);
            //Adding wave to the list of Waves
            gameManager.PresetWaves.Add(newWave);

            //Creating the Thirteenth Wave
            newWave = new Wave(17, 14, 3);
            //Adding wave to the list of Waves
            gameManager.PresetWaves.Add(newWave);

            //Creating the Fourteenth Wave
            newWave = new Wave(18, 15, 3);
            //Adding wave to the list of Waves
            gameManager.PresetWaves.Add(newWave);

            //Creating the Fifteenth Wave
            newWave = new Wave(20, 17, 3);
            //Adding wave to the list of Waves
            gameManager.PresetWaves.Add(newWave);
        }
    }
}
