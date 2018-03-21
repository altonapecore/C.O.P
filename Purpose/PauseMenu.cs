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
        GameManager gameManager;

        public PauseMenu(GameManager gameManager)
        {
            InitializeComponent();
            this.gameManager = gameManager;
        }

        private void ReturnToGame_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void UpgradeMenu_Click(object sender, EventArgs e)
        {
            gameManager.GameState = GameState.UpgradeMenu;
            Close();
        }
    }
}
