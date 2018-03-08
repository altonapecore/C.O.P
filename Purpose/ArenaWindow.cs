using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Purpose
{
    public partial class ArenaWindow : Form
    {
        private GameState gameState;
        public ArenaWindow(GameState gameState)
        {
            InitializeComponent();
            this.gameState = gameState;
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            gameState = GameState.Game;
        }
    }
}
