using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

namespace Purpose
{
    public class SoundManager
    {
        #region Fields
        private SoundEffect punch;
        private SoundEffect grunt;
        private SoundEffect playerDeath;
        private Song song;
        #endregion

        public SoundEffect Grunt { get { return grunt; } }

        public SoundEffect Punch { get { return punch; } }

        public SoundEffect PlayerDeath { get { return playerDeath; } }
        
        public Song Song { get { return song; } }

        public SoundManager(SoundEffect grunt, SoundEffect punch, SoundEffect playerDeath, Song song)
        {
            this.grunt = grunt;
            this.punch = punch;
            this.playerDeath = playerDeath;
            this.song = song;
        }
    }
}
