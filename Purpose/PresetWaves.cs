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
            Wave newWave = new Wave(2, 1, 1);
            //Adding wave to the list of Waves
            gameManager.PresetWaves.Add(newWave);

            //Creating the Second Wave
            newWave = new Wave(1, 3, 1);
            //Adding wave to the list of Waves
            gameManager.PresetWaves.Add(newWave);

            //Creating the Third Wave
            newWave = new Wave(5, 0, 1);
            //Adding wave to the list of Waves
            gameManager.PresetWaves.Add(newWave);

            //Creating the Fourth Wave
            newWave = new Wave(2, 5, 1);
            //Adding wave to the list of Waves
            gameManager.PresetWaves.Add(newWave);

            //First Introduction of Ranged Enemies
            //Creating the Fifth Wave
            newWave = new Wave(4, 4, 2);
            //Adding wave to the list of Waves
            gameManager.PresetWaves.Add(newWave);

            //Creating the Sixth Wave
            newWave = new Wave(2, 3, 2);
            //Adding wave to the list of Waves
            gameManager.PresetWaves.Add(newWave);

            //Creating the Seventh Wave
            newWave = new Wave(5, 2, 2);
            //Adding wave to the list of Waves
            gameManager.PresetWaves.Add(newWave);

            //Creating the Eighth Wave
            newWave = new Wave(8, 3, 2);
            //Adding wave to the list of Waves
            gameManager.PresetWaves.Add(newWave);

            //Creating the Nineth Wave
            newWave = new Wave(4, 7, 2);
            //Adding wave to the list of Waves
            gameManager.PresetWaves.Add(newWave);

            //Creating the Tenth Wave
            newWave = new Wave(6, 6, 2);
            //Adding wave to the list of Waves
            gameManager.PresetWaves.Add(newWave);

            //Creating the Eleventh Wave
            newWave = new Wave(7, 9, 3);
            //Adding wave to the list of Waves
            gameManager.PresetWaves.Add(newWave);

            //Creating the Twelveth Wave
            newWave = new Wave(9, 5, 3);
            //Adding wave to the list of Waves
            gameManager.PresetWaves.Add(newWave);

            //Creating the Thirteenth Wave
            newWave = new Wave(10, 6, 3);
            //Adding wave to the list of Waves
            gameManager.PresetWaves.Add(newWave);

            //Creating the Fourteenth Wave
            newWave = new Wave(12, 8, 3);
            //Adding wave to the list of Waves
            gameManager.PresetWaves.Add(newWave);

            //Creating the Fifteenth Wave
            newWave = new Wave(15, 10, 3);
            //Adding wave to the list of Waves
            gameManager.PresetWaves.Add(newWave);
        }
    }
}
