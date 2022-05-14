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
    public partial class ColorGameForm : Form
    {
        List<int> numbers = new List<int> { 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8 };
        string firstChoice;
        string secondChoice;
        List<PictureBox> pictures = new List<PictureBox>();
        PictureBox picA;
        PictureBox picB;

        public ColorGameForm()
        {
            InitializeComponent();
            LoadPictures();
        }

        private void ColorGameForm_Load(object sender, EventArgs e)
        {

        }

        private void RestartGameEvent(object sender, EventArgs e)
        {
            RestartGame();
        }

        private void LoadPictures()
        {
            int leftPos = 20;
            int topPos = 20;
            int rows = 0;

            for (int i = 0; i < 16; i++)
            {
                PictureBox newPic = new PictureBox();
                newPic.Height = 55;
                newPic.Width = 55;
                newPic.BackColor = Color.White;
                newPic.SizeMode = PictureBoxSizeMode.StretchImage;
                newPic.Click += NewPic_Click;
                pictures.Add(newPic);


                if(rows < 4)
                {
                    rows++;
                    newPic.Left = leftPos;
                    newPic.Top = topPos;
                    this.Controls.Add(newPic);
                    leftPos = leftPos + 60;
                }

                if(rows == 4)
                {
                    leftPos = 20;
                    topPos += 60;
                    rows = 0;
                }
            }

            RestartGame();
        }

        private void NewPic_Click(object sender, EventArgs e)
        {

            if(firstChoice == null)
            {
                picA = sender as PictureBox;
                if (picA.Tag != null && picA.Image == null)
                {
                    picA.Image = Image.FromFile("colors/"+"clr"+(string)picA.Tag + ".jpg");
                    firstChoice = (string)picA.Tag;
                }
            }
            else if (secondChoice == null)
            {
                picB = sender as PictureBox;

                if(picB.Tag != null && picB.Image == null)
                {
                    picB.Image = Image.FromFile("colors/"+"clr"+(string)picB.Tag +".jpg");
                    secondChoice = (string)picB.Tag;
                }
            }
            else
            {
                CheckPictures(picA, picB);
            }


        }

        private void RestartGame()
        {
            //randomise the original list
            var randomList = numbers.OrderBy(x => Guid.NewGuid()).ToList();
            //assihn the random list to the original
            numbers = randomList;

            for (int i = 0; i < pictures.Count; i++)
            {
                pictures[i].Image = null;
                pictures[i].Tag = numbers[i].ToString();
            }
        }

        private void CheckPictures(PictureBox A, PictureBox B)
        {
            if(firstChoice == secondChoice)
            {
                A.Tag = null;
                B.Tag = null;
            }

            firstChoice = null;
            secondChoice = null;

            foreach (PictureBox pics in pictures.ToList())
            {
                if(pics.Tag != null)
                {
                    pics.Image = null;
                }
            }
        }
    }
}
