namespace Purpose
{
    partial class ArenaWindow
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
            this.MeleeIncrement = new System.Windows.Forms.NumericUpDown();
            this.EditorLabel = new System.Windows.Forms.Label();
            this.MeleeLabel = new System.Windows.Forms.Label();
            this.RangedLabel = new System.Windows.Forms.Label();
            this.RangedIncrement = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.DifficultyIncrement = new System.Windows.Forms.NumericUpDown();
            this.WhiteBackground = new System.Windows.Forms.RadioButton();
            this.BackgroundLabel = new System.Windows.Forms.Label();
            this.MetalBackground = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.EnemyLabel = new System.Windows.Forms.Label();
            this.StartButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.MeleeIncrement)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RangedIncrement)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DifficultyIncrement)).BeginInit();
            this.SuspendLayout();
            // 
            // MeleeIncrement
            // 
            this.MeleeIncrement.Location = new System.Drawing.Point(106, 115);
            this.MeleeIncrement.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.MeleeIncrement.Name = "MeleeIncrement";
            this.MeleeIncrement.Size = new System.Drawing.Size(43, 20);
            this.MeleeIncrement.TabIndex = 0;
            // 
            // EditorLabel
            // 
            this.EditorLabel.AutoSize = true;
            this.EditorLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.EditorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 30.25F);
            this.EditorLabel.Location = new System.Drawing.Point(12, 9);
            this.EditorLabel.Name = "EditorLabel";
            this.EditorLabel.Size = new System.Drawing.Size(325, 49);
            this.EditorLabel.TabIndex = 1;
            this.EditorLabel.Text = "Level Editor GUI";
            // 
            // MeleeLabel
            // 
            this.MeleeLabel.AutoSize = true;
            this.MeleeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.25F);
            this.MeleeLabel.Location = new System.Drawing.Point(12, 109);
            this.MeleeLabel.Name = "MeleeLabel";
            this.MeleeLabel.Size = new System.Drawing.Size(71, 26);
            this.MeleeLabel.TabIndex = 2;
            this.MeleeLabel.Text = "Melee";
            // 
            // RangedLabel
            // 
            this.RangedLabel.AutoSize = true;
            this.RangedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.25F);
            this.RangedLabel.Location = new System.Drawing.Point(12, 137);
            this.RangedLabel.Name = "RangedLabel";
            this.RangedLabel.Size = new System.Drawing.Size(88, 26);
            this.RangedLabel.TabIndex = 3;
            this.RangedLabel.Text = "Ranged";
            // 
            // RangedIncrement
            // 
            this.RangedIncrement.Location = new System.Drawing.Point(106, 143);
            this.RangedIncrement.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.RangedIncrement.Name = "RangedIncrement";
            this.RangedIncrement.Size = new System.Drawing.Size(43, 20);
            this.RangedIncrement.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.25F);
            this.label1.Location = new System.Drawing.Point(12, 166);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 26);
            this.label1.TabIndex = 5;
            this.label1.Text = "Difficulty";
            // 
            // DifficultyIncrement
            // 
            this.DifficultyIncrement.Location = new System.Drawing.Point(106, 172);
            this.DifficultyIncrement.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.DifficultyIncrement.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.DifficultyIncrement.Name = "DifficultyIncrement";
            this.DifficultyIncrement.Size = new System.Drawing.Size(43, 20);
            this.DifficultyIncrement.TabIndex = 6;
            this.DifficultyIncrement.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // WhiteBackground
            // 
            this.WhiteBackground.AutoSize = true;
            this.WhiteBackground.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.WhiteBackground.Location = new System.Drawing.Point(17, 249);
            this.WhiteBackground.Name = "WhiteBackground";
            this.WhiteBackground.Size = new System.Drawing.Size(76, 28);
            this.WhiteBackground.TabIndex = 7;
            this.WhiteBackground.TabStop = true;
            this.WhiteBackground.Text = "White";
            this.WhiteBackground.UseVisualStyleBackColor = true;
            // 
            // BackgroundLabel
            // 
            this.BackgroundLabel.AutoSize = true;
            this.BackgroundLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.25F);
            this.BackgroundLabel.Location = new System.Drawing.Point(12, 220);
            this.BackgroundLabel.Name = "BackgroundLabel";
            this.BackgroundLabel.Size = new System.Drawing.Size(128, 26);
            this.BackgroundLabel.TabIndex = 8;
            this.BackgroundLabel.Text = "Background";
            // 
            // MetalBackground
            // 
            this.MetalBackground.AutoSize = true;
            this.MetalBackground.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.MetalBackground.Location = new System.Drawing.Point(17, 283);
            this.MetalBackground.Name = "MetalBackground";
            this.MetalBackground.Size = new System.Drawing.Size(73, 28);
            this.MetalBackground.TabIndex = 9;
            this.MetalBackground.TabStop = true;
            this.MetalBackground.Text = "Metal";
            this.MetalBackground.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.radioButton1.Location = new System.Drawing.Point(17, 317);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(75, 28);
            this.radioButton1.TabIndex = 10;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "\"S***\"";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // EnemyLabel
            // 
            this.EnemyLabel.AutoSize = true;
            this.EnemyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 17.25F);
            this.EnemyLabel.Location = new System.Drawing.Point(12, 80);
            this.EnemyLabel.Name = "EnemyLabel";
            this.EnemyLabel.Size = new System.Drawing.Size(108, 29);
            this.EnemyLabel.TabIndex = 11;
            this.EnemyLabel.Text = "Enemies";
            // 
            // StartButton
            // 
            this.StartButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.StartButton.Location = new System.Drawing.Point(12, 442);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(123, 60);
            this.StartButton.TabIndex = 12;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = true;
            // 
            // ArenaWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.EnemyLabel);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.MetalBackground);
            this.Controls.Add(this.BackgroundLabel);
            this.Controls.Add(this.WhiteBackground);
            this.Controls.Add(this.DifficultyIncrement);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.RangedIncrement);
            this.Controls.Add(this.RangedLabel);
            this.Controls.Add(this.MeleeLabel);
            this.Controls.Add(this.EditorLabel);
            this.Controls.Add(this.MeleeIncrement);
            this.Name = "ArenaWindow";
            this.Text = "Arena";
            ((System.ComponentModel.ISupportInitialize)(this.MeleeIncrement)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RangedIncrement)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DifficultyIncrement)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown MeleeIncrement;
        private System.Windows.Forms.Label EditorLabel;
        private System.Windows.Forms.Label MeleeLabel;
        private System.Windows.Forms.Label RangedLabel;
        private System.Windows.Forms.NumericUpDown RangedIncrement;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown DifficultyIncrement;
        private System.Windows.Forms.RadioButton WhiteBackground;
        private System.Windows.Forms.Label BackgroundLabel;
        private System.Windows.Forms.RadioButton MetalBackground;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Label EnemyLabel;
        private System.Windows.Forms.Button StartButton;
    }
}