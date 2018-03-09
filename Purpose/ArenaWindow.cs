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
        private GameManager gameManager;
        private RadioButton radioButton;

        public ArenaWindow(GameManager gameManager)
        {
            InitializeComponent();
            this.gameManager = gameManager;
        }

        //When User presses Start the window closes and goes to the Game
        //Also checks the background selected by the user
        private void StartButton_Click(object sender, EventArgs e)
        {
            gameManager.GameState = GameState.Game;

            //Goes through to check which radio button was checked and which background to use
            if (radioButton == WhiteBackground)
            {
                gameManager.BackgroundSelection = Background.WhiteBackground;
            }
            else if (radioButton == MetalBackground)
            {
                gameManager.BackgroundSelection = Background.MetalBackground;
            }
            else if (radioButton == RustyBackground)
            {
                gameManager.BackgroundSelection = Background.RustBackground;
            }
            Close();
        }

        //If radiobutton is clicked, changes the background to White
        private void WhiteBackground_CheckedChanged(object sender, EventArgs e)
        {
            radioButton = WhiteBackground;
        }

        //If radiobutton is clicked, changes the background to Metal
        private void MetalBackground_CheckedChanged(object sender, EventArgs e)
        {
            radioButton = MetalBackground;
        }

        //If radiobuuton is clicked, background is changed to Rusty
        private void RustyBackground_CheckedChanged(object sender, EventArgs e)
        {
            radioButton = RustyBackground;
        }

        //When number is changed, number of Melee Enemies are spawned
        private void MeleeIncrement_ValueChanged(object sender, EventArgs e)
        {

        }

        //When number is changed, number of Ranged Enemies are spawned
        private void RangedIncrement_ValueChanged(object sender, EventArgs e)
        {

        }

        //When number is changed, chnages the difficulty or level of the Enemies
        private void DifficultyIncrement_ValueChanged(object sender, EventArgs e)
        {

        }

    }
}
