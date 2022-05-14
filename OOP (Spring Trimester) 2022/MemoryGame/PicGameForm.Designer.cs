namespace MemoryGame
{
    partial class PicGameForm
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
            this.btnRestartPicGame = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnRestartPicGame
            // 
            this.btnRestartPicGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRestartPicGame.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnRestartPicGame.Location = new System.Drawing.Point(90, 356);
            this.btnRestartPicGame.Name = "btnRestartPicGame";
            this.btnRestartPicGame.Size = new System.Drawing.Size(184, 52);
            this.btnRestartPicGame.TabIndex = 0;
            this.btnRestartPicGame.Text = "Restart";
            this.btnRestartPicGame.UseVisualStyleBackColor = true;
            this.btnRestartPicGame.Click += new System.EventHandler(this.RestartGameEvent);
            // 
            // PicGameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(374, 450);
            this.Controls.Add(this.btnRestartPicGame);
            this.Name = "PicGameForm";
            this.Text = "PicGameForm";
            this.Load += new System.EventHandler(this.PicGameForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnRestartPicGame;
    }
}