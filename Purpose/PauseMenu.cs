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
    public partial class PauseMenu : Form
    {
        GameState gameState;

        public PauseMenu(GameState gameState)
        {
            InitializeComponent();
            this.gameState = gameState;
        }

        private void ReturnToGame_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void UpgradeMenu_Click(object sender, EventArgs e)
        {
            gameState = GameState.UpgradeMenu;
            Close();
        }
    }
}
