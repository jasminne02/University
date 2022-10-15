namespace MemoryGame
{
    partial class MainForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.colorGameBtn = new System.Windows.Forms.Button();
            this.picGameBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(338, 123);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 48);
            this.label1.TabIndex = 0;
            this.label1.Text = "PLAY";
            // 
            // colorGameBtn
            // 
            this.colorGameBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colorGameBtn.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.colorGameBtn.Location = new System.Drawing.Point(92, 250);
            this.colorGameBtn.Name = "colorGameBtn";
            this.colorGameBtn.Size = new System.Drawing.Size(240, 79);
            this.colorGameBtn.TabIndex = 1;
            this.colorGameBtn.Text = "Color Memory Game";
            this.colorGameBtn.UseVisualStyleBackColor = true;
            this.colorGameBtn.Click += new System.EventHandler(this.colorGameBtn_Click);
            // 
            // picGameBtn
            // 
            this.picGameBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.picGameBtn.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.picGameBtn.Location = new System.Drawing.Point(466, 250);
            this.picGameBtn.Name = "picGameBtn";
            this.picGameBtn.Size = new System.Drawing.Size(240, 79);
            this.picGameBtn.TabIndex = 2;
            this.picGameBtn.Text = "Picture Memory Game";
            this.picGameBtn.UseVisualStyleBackColor = true;
            this.picGameBtn.Click += new System.EventHandler(this.picGameBtn_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.picGameBtn);
            this.Controls.Add(this.colorGameBtn);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Name = "MainForm";
            this.Text = "Memory Game";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button colorGameBtn;
        private System.Windows.Forms.Button picGameBtn;
    }
}

