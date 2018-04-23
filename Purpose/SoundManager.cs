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
        #region Fields
        private SoundEffect punch;
        private SoundEffect grunt;
        private SoundEffect playerDeath;
        #endregion

        public SoundEffect Grunt { get { return grunt; } }

        public SoundEffect Punch { get { return punch; } }

        public SoundEffect PlayerDeath { get { return playerDeath; } }


        public SoundManager(SoundEffect grunt, SoundEffect punch, SoundEffect playerDeath)
        {
            this.grunt = grunt;
            this.punch = punch;
            this.playerDeath = playerDeath;
        }
    }
}
