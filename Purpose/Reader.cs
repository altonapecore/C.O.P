using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Purpose
{
    //Class takes in txt file created from the editor to make prepare the waves
    class Reader
    {
        //Fields for the Streamreader
        private StreamReader input;
        private string line;

        //Field for the wave and manager to create it
        //private Wave wave;
        private GameManager gameManager;
        //private Game1 game1;

        //Constructor for the Reader
        public Reader(GameManager gameManager)
        {
            input = new StreamReader("../../../../Content/waveEditor.txt");
            line = null;
            //wave = new Wave(gameManager, game1);
            this.gameManager = gameManager;
            //this.game1 = game1;
        }

        //Method that runs through the text file to read it
        //As well as creates the new waves and stores them in their proper list.
        public void ReadEditor()
        {
            //Put into try/catch to prevent crashes, etc.
            try
            {
                //Goes through and reads the text file
                while((line = input.ReadLine()) != null)
                {
                    //Using a split seperates the numbers and stores them into an array
                    String[] data = line.Split(',');

                    //Parses the data array to ints to allow storage into the wave
                    int numberOfMelee = int.Parse(data[0]);
                    int numberOfRanged = int.Parse(data[1]);
                    int difficulty = int.Parse(data[2]);
                    Wave newWave = new Wave(numberOfMelee, numberOfRanged, difficulty);
                    //Using info gathered above creates a new Wave
                    //Wave wave = new Wave(wave.NumberOfMelee, wave.NumberOfRanged, wave.Difficulty);
                    gameManager.EditedWaves.Add(newWave); //Adds that new wave to the list.
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Error while trying to read file" + e.Message);
            }

            if(input != null)
            {
                input.Close();
            }
        }

    }
}
