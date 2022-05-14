namespace MemoryGame
{
    partial class ColorGameForm
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
            this.btnRestartColorGame = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnRestartColorGame
            // 
            this.btnRestartColorGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRestartColorGame.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnRestartColorGame.Location = new System.Drawing.Point(94, 363);
            this.btnRestartColorGame.Name = "btnRestartColorGame";
            this.btnRestartColorGame.Size = new System.Drawing.Size(178, 58);
            this.btnRestartColorGame.TabIndex = 1;
            this.btnRestartColorGame.Text = "Restart";
            this.btnRestartColorGame.UseVisualStyleBackColor = true;
            this.btnRestartColorGame.Click += new System.EventHandler(this.RestartGameEvent);
            // 
            // ColorGameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(374, 449);
            this.Controls.Add(this.btnRestartColorGame);
            this.Name = "ColorGameForm";
            this.Text = "ColorGameForm";
            this.Load += new System.EventHandler(this.ColorGameForm_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnRestartColorGame;
    }
}