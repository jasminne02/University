using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Matching_Game
{
    public partial class Form1 : Form
    {
        List<Bitmap> pictures = new List<Bitmap>()
        {
            Properties.Resources.Card1,Properties.Resources.Card1,Properties.Resources.Card2,Properties.Resources.Card2,
            Properties.Resources.Card3,Properties.Resources.Card3,Properties.Resources.Card4,Properties.Resources.Card4,
            Properties.Resources.Card5,Properties.Resources.Card5,Properties.Resources.Card6,Properties.Resources.Card6,
            Properties.Resources.Card7,Properties.Resources.Card7,Properties.Resources.Card8,Properties.Resources.Card8
        };
        PictureBox first, second;
        bool done = false;
        public Form1()
        {
            InitializeComponent();
        }
        private void AssignImages()
        {
            Random r = new Random();

            for (int i = 0; i < pictures.Count; i++) 
            {
                Tags(i);
            }

            foreach (Control c in this.Controls)
            {
                int j = r.Next(pictures.Count);
                PictureBox p = (PictureBox) c;
                p.InitialImage = pictures[j];
                p.Tag = pictures[j].Tag;
                pictures.RemoveAt(j);
            }
        }

        private void Tags(int index)
        {          
           if(index == 0 || index == 1)
            {
                pictures[index].Tag = "Card1";
            }
            else if (index == 2 || index == 3)
            {
                pictures[index].Tag = "Card2";
            }
            else if (index == 4 || index == 5)
            {
                pictures[index].Tag = "Card3";
            }
            else if (index == 6 || index == 7)
            {
                pictures[index].Tag = "Card4";
            }
            else if (index == 8 || index == 9)
            {
                pictures[index].Tag = "Card5";
            }
            else if (index == 10 || index == 11)
            {
                pictures[index].Tag = "Card6";
            }
            else if (index == 12 || index == 13)
            {
                pictures[index].Tag = "Card7";
            }
            else if (index == 14 || index == 15)
            {
                pictures[index].Tag = "Card8";
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            AssignImages();
        }

        private void Timer(object sender, EventArgs e)
        {
            timer1.Stop();

            if (first.Tag.ToString() == second.Tag.ToString())
            {
                CheckForWinner();
            }
            else if (first.Tag.ToString() != second.Tag.ToString())
            {
                first.BackgroundImage = null;
                second.BackgroundImage = null;
            }
            first = null;
            second = null;
            done = false;
        }

        private void picture_Click(object sender, EventArgs e)
        {
            PictureBox cast = (PictureBox)sender;
            
            if (cast.BackgroundImage == null && done == false)
            {
                if (first == null)
                {
                    first = cast;
                    first.BackgroundImage = first.InitialImage;
                    return; 
                }
                second = cast;
                second.BackgroundImage = second.InitialImage;
                done = true;
                timer1.Start();
            }
        }

        

        private void CheckForWinner()
        {
            foreach(Control c in this.Controls)
            {
                    PictureBox pb = (PictureBox)c;
                    if (pb.BackgroundImage == null) return; 
            }
            MessageBox.Show("Congrats!!");
        }
    }
}
