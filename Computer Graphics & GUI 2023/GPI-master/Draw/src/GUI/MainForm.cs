using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Draw
{
	public partial class MainForm : Form
	{
		private DialogProcessor dialogProcessor = new DialogProcessor();
		
		public MainForm()
		{
			InitializeComponent();
		}
        
		void ExitToolStripMenuItemClick(object sender, EventArgs e)
		{
			Close();
		}
		
		void ViewPortPaint(object sender, PaintEventArgs e)
		{
			dialogProcessor.ReDraw(sender, e);
		}

		void DrawRectangleSpeedButtonClick(object sender, EventArgs e)
		{
			dialogProcessor.AddRandomRectangle();
			
			statusBar.Items[0].Text = "Последно действие: Рисуване на правоъгълник";
			
			viewPort.Invalidate();
		}
        
        private void DrawElipseSpeedButton_Click(object sender, EventArgs e)
        {
            dialogProcessor.AddRandomEllipse();

            statusBar.Items[0].Text = "Последно действие: Рисуване на елипса";

            viewPort.Invalidate();
        }

        private void AddTriangleSpeedButton_Click(object sender, EventArgs e)
        {
            dialogProcessor.AddRandomTriangle();

            statusBar.Items[0].Text = "Последно действие: Рисуване на триъгълник";

            viewPort.Invalidate();
        }

        void ViewPortMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (pickUpSpeedButton.Checked)
                {
                    var sel = dialogProcessor.ContainsPoint(e.Location);

                    if (sel != null)
                    {
                        if (dialogProcessor.Selection.Contains(sel))
                        {
                            dialogProcessor.Selection.Remove(sel);
                        }
                        else
                        {
                            dialogProcessor.Selection.Add(sel);
                        }

                        statusBar.Items[0].Text = "Последно действие: Селекция на примитив";
                        dialogProcessor.IsDragging = true;
                        dialogProcessor.LastLocation = e.Location;
                        viewPort.Invalidate();
                    }
                }
            }
		}
        
		void ViewPortMouseMove(object sender, MouseEventArgs e)
		{
			if (dialogProcessor.IsDragging) {
				if (dialogProcessor.Selection != null) statusBar.Items[0].Text = "Последно действие: Влачене";
				dialogProcessor.TranslateTo(e.Location);
				viewPort.Invalidate();
			}
		}

		void ViewPortMouseUp(object sender, MouseEventArgs e)
		{
			dialogProcessor.IsDragging = false;
		}

        private void GroupShapesButton_Click(object sender, EventArgs e)
        {
            dialogProcessor.GroupSelected();
            statusBar.Items[0].Text = "Последно действие: Групиране";
            viewPort.Invalidate();
        }

        private void UnGroupShapesButton_Click(object sender, EventArgs e)
        {
            dialogProcessor.UnGroup();
            statusBar.Items[0].Text = "Последно действие: Разгрупиране";
            viewPort.Invalidate();
        }

        private void PickBackgroundColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                dialogProcessor.SetFillColor(colorDialog1.Color);
                statusBar.Items[0].Text = "Последно действие: Смяна на цвета";
                viewPort.Invalidate();
            }
        }

        private void PickBorderColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                dialogProcessor.SetBorderColor(colorDialog1.Color);
                statusBar.Items[0].Text = "Последно действие: Смяна на цвета на границата";
                viewPort.Invalidate();
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            dialogProcessor.SetOpacity(trackBar1.Value);
            statusBar.Items[0].Text = "Последно действие: Добавяне на прозрачност";
            viewPort.Invalidate();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                dialogProcessor.MySerialize(dialogProcessor.ShapeList, saveFileDialog1.FileName);
                statusBar.Items[0].Text = "Последно действие: Запазване";
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                dialogProcessor.ShapeList = (List<Shape>)dialogProcessor.MyDeSerialize(openFileDialog1.FileName);
                statusBar.Items[0].Text = "Последно действие: Отваряне";
                viewPort.Invalidate();
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dialogProcessor.ShapeList.Count > 0)
            {
                if (MessageBox.Show("Искате ли да запаметите промените?", "Запаметяване", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        dialogProcessor.MySerialize(dialogProcessor.ShapeList, saveFileDialog1.FileName);
                        statusBar.Items[0].Text = "Последно действие: Изчистване на работното място";
                    }
                }
                dialogProcessor.ShapeList.Clear();
                viewPort.Invalidate();
            }
        }

        private void btnAddString_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxString.Text))
            {
                dialogProcessor.AddRandomString(textBoxString.Text);
                statusBar.Items[0].Text = "Последно действие: Рисуване на тектс";
                viewPort.Invalidate();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            dialogProcessor.DeleteSelected();
            statusBar.Items[0].Text = "Последно действие: Изтриване на селектираните примитиви";
            viewPort.Invalidate();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            dialogProcessor.Rotate((float)trackBar2.Value);
            statusBar.Items[0].Text = "Последно действие: Завъртане";
            viewPort.Invalidate();
        }

        private void заНасToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Draw Inc.", "За нас", MessageBoxButtons.OK);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            dialogProcessor.AddRandomX();

            statusBar.Items[0].Text = "Последно действие: Рисуване на X";

            viewPort.Invalidate();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}