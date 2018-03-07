namespace Purpose
{
    partial class PauseMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PauseMenu));
            this.ReturnToGame = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ReturnToGame
            // 
            this.ReturnToGame.BackColor = System.Drawing.Color.Transparent;
            this.ReturnToGame.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ReturnToGame.BackgroundImage")));
            this.ReturnToGame.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReturnToGame.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ReturnToGame.Location = new System.Drawing.Point(36, 49);
            this.ReturnToGame.Name = "ReturnToGame";
            this.ReturnToGame.Size = new System.Drawing.Size(273, 106);
            this.ReturnToGame.TabIndex = 0;
            this.ReturnToGame.Text = "Return to game";
            this.ReturnToGame.UseVisualStyleBackColor = false;
            this.ReturnToGame.Click += new System.EventHandler(this.ReturnToGame_Click);
            // 
            // PauseMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(838, 538);
            this.Controls.Add(this.ReturnToGame);
            this.Name = "PauseMenu";
            this.ShowInTaskbar = false;
            this.Text = "PauseMenu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ReturnToGame;
    }
}