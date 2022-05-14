using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemoryGame
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void colorGameBtn_Click(object sender, EventArgs e)
        {
            ColorGameForm colorGameForm = new ColorGameForm();
            colorGameForm.Show();
        }

        private void picGameBtn_Click(object sender, EventArgs e)
        {
            PicGameForm picGameForm = new PicGameForm();
            picGameForm.Show();
        }
    }
}
