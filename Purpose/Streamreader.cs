using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Purpose
{
    //Class takes in txt file created from the editor to make prepare the waves
    class Streamreader
    {
        //Fields for the Streamreader
        private Streamreader input;
        private String file;
        private string line;

        //Field for the wave
        private Wave wave;

        //Constructor for the Reader
        public Streamreader(String file)
        {
            input = new Streamreader("waveEditor.txt");
            line = null;
        }

        //Method that runs through the text file to read it
        //As well as creates the new waves and stores them in their proper list.
        public void ReadEditor(StreamReader input)
        {
            //Put into try/catch to prevent crashes, etc.
            try
            {
                //Goes through and reads the text file
                while((line = input.ReadLine()) != null)
                {
                    //Using a split seperates the numbers and stores them into an array
                    String[] data = line.Split(',');

                    //Loops through the data array to deal with each number individually.
                    for(int i = 0; i < data.Length;)
                    {
                        //Parses the data array to ints to allow storage into the wave
                        wave.NumberOfMelee = int.Parse(data[i]);
                        wave.NumberOfRanged = int.Parse(data[i+1]);
                        wave.Difficulty = int.Parse(data[i + 2]);

                        //Using info gathered above creates a new Wave
                        wave = new Wave(wave.NumberOfMelee, wave.NumberOfRanged, wave.Difficulty);
                        wave.Waves.Add(wave); //Adds that new wave to the list.

                        i += 3; //Raises i by 3 to continue to the next group of numbers
                    }
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
