using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Purpose
{
    class UnlockablesReadWrite
    {
        //fields
        private StreamWriter output;
        private StreamReader input;
        private string line;
        private string filename;
        private int unlockPoints;

        //properties
        public int UnlockPoints
        {
            get { return unlockPoints; }
            set { unlockPoints = value; }
        }

        public UnlockablesReadWrite()
        {
            filename = "Unlockables.txt";
            line = null;
        }

        public List<bool[]> Load()
        {
            int count = 1;
            List<bool[]> unlockedEquipped = new List<bool[]>();

            bool unlocked = false;
            bool equipped = false;

            try
            {
                input = new StreamReader(filename);
                while ((line = input.ReadLine()) != null)
                {
                    if (count != 1)
                    {
                        //creating an array of strings length 2
                        //first value whether it is unlocked
                        //second value whether it is equipped
                        string[] splitLine = new string[2];
                        splitLine = line.Split(';');

                        if (splitLine[0] == "Y")
                        {
                            unlocked = true;
                        }
                        if (splitLine[1] == "Y")
                        {
                            equipped = true;
                        }

                        bool[] values = new bool[2];
                        values[0] = unlocked;
                        values[1] = equipped;
                        unlockedEquipped.Add(values);
                    }
                    else
                    {
                        unlockPoints = int.Parse(line);
                    }
                    count++;
                    unlocked = false;
                    equipped = false;
                }
            }
            catch(NullReferenceException e)
            {
                Console.WriteLine("That file does not exist yet.");
            }
            catch(Exception e)
            {
                Console.WriteLine("There was an error reading the file");
            }

            if (input != null)
            {
                input.Close();
            }

            return unlockedEquipped;
        }

        public void Save(int unlockPoints, List<Unlockables> unlockables)
        {
            output = new StreamWriter(filename);
            
            output.WriteLine(unlockPoints);
            foreach (Unlockables u in unlockables)
            {
                if (u.Unlocked)
                {
                    output.Write("Y;");
                }
                else
                {
                    output.Write("N;");
                }
                
                if (u.Equipped)
                {
                    output.WriteLine("Y");
                }
                else
                {
                    output.WriteLine("N");
                }
            }

            output.Close();
        }
    }
}
