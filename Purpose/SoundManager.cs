using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Audio;

namespace Purpose
{
    public class SoundManager
    {
        private SoundEffect punch;
        private SoundEffect grunt;

        public SoundEffect Grunt
        {
            get { return grunt; }
            set { grunt = value; }
        }

        public SoundEffect Punch
        {
            get { return punch; }
            set { punch = value; }
        }


        public SoundManager(SoundEffect grunt, SoundEffect punch)
        {
            this.grunt = grunt;
            this.punch = punch;
        }
    }
}
