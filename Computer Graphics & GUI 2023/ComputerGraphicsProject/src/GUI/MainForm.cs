using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Draw
{
	/// <summary>
	/// Върху главната форма е поставен потребителски контрол,
	/// в който се осъществява визуализацията
	/// </summary>
	public partial class MainForm : Form
	{
		/// <summary>
		/// Агрегирания диалогов процесор във формата улеснява манипулацията на модела.
		/// </summary>
		private DialogProcessor dialogProcessor = new DialogProcessor();
       
        public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}

        private void MainForm_Load(object sender, EventArgs e)
        {
            transparencyTrackBar.Value = transparencyTrackBar.Maximum;
            speedMenu.Height= 50;
        }

        /// <summary>
        /// Изход от програмата. Затваря главната форма, а с това и програмата.
        /// </summary>
        void ExitToolStripMenuItemClick(object sender, EventArgs e)
		{
			Close();
		}
		
		/// <summary>
		/// Събитието, което се прихваща, за да се превизуализира при изменение на модела.
		/// </summary>
		void ViewPortPaint(object sender, PaintEventArgs e)
		{
			dialogProcessor.ReDraw(sender, e);
		}
		
		/// <summary>
		/// Бутон, който поставя на произволно място правоъгълник със зададените размери.
		/// Променя се лентата със състоянието и се инвалидира контрола, в който визуализираме.
		/// </summary>
		void DrawRectangleSpeedButtonClick(object sender, EventArgs e)
		{
			dialogProcessor.AddRandomRectangle();
			
			statusBar.Items[0].Text = "Последно действие: Рисуване на правоъгълник";
			
			viewPort.Invalidate();
		}

        /// <summary>
        /// Бутон, който поставя на произволно място квадрат със зададените размери.
        /// Променя се лентата със състоянието и се инвалидира контрола, в който визуализираме.
        /// </summary>
        void DrawSquareSpeedButtonClick(object sender, EventArgs e)
        {
            dialogProcessor.AddRandomSquare();

            statusBar.Items[0].Text = "Последно действие: Рисуване на квадрат";

            viewPort.Invalidate();
        }

        /// <summary>
        /// Бутон, който поставя на произволно място елипса със зададените размери.
        /// Променя се лентата със състоянието и се инвалидира контрола, в който визуализираме.
        /// </summary>
        void DrawEllipseSpeedButtonClick(object sender, EventArgs e)
        {
            dialogProcessor.AddRandomEllipse();

            statusBar.Items[0].Text = "Последно действие: Рисуване на елипса";

            viewPort.Invalidate();
        }

        /// <summary>
        /// Бутон, който поставя на произволно място кръг със зададените размери.
        /// Променя се лентата със състоянието и се инвалидира контрола, в който визуализираме.
        /// </summary>
        void DrawCircleSpeedButtonClick(object sender, EventArgs e)
        {
            dialogProcessor.AddRandomCircle();

            statusBar.Items[0].Text = "Последно действие: Рисуване на кръг";

            viewPort.Invalidate();
        }

        /// <summary>
        /// Бутон, който поставя на произволно място триъгълник със зададените размери.
        /// Променя се лентата със състоянието и се инвалидира контрола, в който визуализираме.
        /// </summary>
        void DrawTriangleSpeedButtonClick(object sender, EventArgs e)
        {
            dialogProcessor.AddRandomTriangle();

            statusBar.Items[0].Text = "Последно действие: Рисуване на триъгълник";

            viewPort.Invalidate();
        }

        /// <summary>
        /// Бутон, който поставя на произволно място отсечка със зададените размери.
        /// Променя се лентата със състоянието и се инвалидира контрола, в който визуализираме.
        /// </summary>
        void DrawLineSpeedButtonClick(object sender, EventArgs e)
        {
            dialogProcessor.AddRandomLine();

            statusBar.Items[0].Text = "Последно действие: Рисуване на отсечка";

            viewPort.Invalidate();
        }

        /// <summary>
        /// Бутон, който поставя на произволно място точка със зададените размери.
        /// Променя се лентата със състоянието и се инвалидира контрола, в който визуализираме.
        /// </summary>
        void DrawDotSpeedButtonClick(object sender, EventArgs e)
        {
            dialogProcessor.AddRandomDot();

            statusBar.Items[0].Text = "Последно действие: Рисуване на точка";

            viewPort.Invalidate();
        }

        /// <summary>
        /// Бутон, който поставя на произволно място петоъгълник със зададените размери.
        /// Променя се лентата със състоянието и се инвалидира контрола, в който визуализираме.
        /// </summary>
        void DrawPentagonSpeedButtonClick(object sender, EventArgs e)
        {
            dialogProcessor.AddRandomPentagon();

            statusBar.Items[0].Text = "Последно действие: Рисуване на петоъгълник";

            viewPort.Invalidate();
        }

        /// <summary>
        /// Бутон, който поставя на произволно място шестоъгълник със зададените размери.
        /// Променя се лентата със състоянието и се инвалидира контрола, в който визуализираме.
        /// </summary>
        void DrawHexagonSpeedButtonClick(object sender, EventArgs e)
        {
            dialogProcessor.AddRandomHexagon();

            statusBar.Items[0].Text = "Последно действие: Рисуване на шестоъгълник";

            viewPort.Invalidate();
        }

        /// <summary>
        /// Бутон, който поставя на произволно място звезда със зададените размери.
        /// Променя се лентата със състоянието и се инвалидира контрола, в който визуализираме.
        /// </summary>
        void DrawStarSpeedButtonClick(object sender, EventArgs e)
        {
            dialogProcessor.AddRandomStar();

            statusBar.Items[0].Text = "Последно действие: Рисуване на звезда";

            viewPort.Invalidate();
        }
        /// <summary>
        /// Бутон, който поставя на произволно място ТЕКСТ .
        /// Променя се лентата със състоянието и се инвалидира контрола, в който визуализираме.
        /// </summary>
        private void btnAddString_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxString.Text))
            {
                dialogProcessor.AddRandomString(textBoxString.Text);
                statusBar.Items[0].Text = "Последно действие: Рисуване на тектс";
                viewPort.Invalidate();
            }
        }
        /// <summary>
        /// Бутон, който поставя на произволно място сърце със зададените размери.
        /// Променя се лентата със състоянието и се инвалидира контрола, в който визуализираме.
        /// </summary>
        private void heartShapeButton_Click(object sender, EventArgs e)
        {
            dialogProcessor.AddRandomHeart();
            statusBar.Items[0].Text = "Последно действие: Рисуване на сърце";
            viewPort.Invalidate();
        }

        /// <summary>
        /// Прихващане на координатите при натискането на бутон на мишката и проверка (в обратен ред) дали не е
        /// щракнато върху елемент. Ако е така то той се отбелязва като селектиран и започва процес на "влачене".
        /// Промяна на статуса и инвалидиране на контрола, в който визуализираме.
        /// Реализацията се диалогът с потребителя, при който се избира "най-горния" елемент от екрана.
        /// </summary>
        void ViewPortMouseDown(object sender, MouseEventArgs e)
        {
            if (pickUpSpeedButton.Checked)
            {
                Shape selectedShape = dialogProcessor.ContainsPoint(e.Location);

                if (selectedShape != null)
                {
                    if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
                    {
                        // Селекткиране
                        if (dialogProcessor.Selection.Contains(selectedShape))
                        {
                            dialogProcessor.Selection.Remove(selectedShape);
                        }
                        else
                        {
                            dialogProcessor.Selection.Add(selectedShape);
                        }
                        selectedShape.BorderSize *= 2; // Увеличава размера
                    }
                    else
                    {
                        
                        dialogProcessor.Selection.Clear();
                        dialogProcessor.Selection.Add(selectedShape);
                        selectedShape.BorderSize *= 2; 
                    }

                    statusBar.Items[0].Text = "Последно действие: Селекция на примитив";
                    dialogProcessor.IsDragging = true;
                    dialogProcessor.LastLocation = e.Location;
                    viewPort.Invalidate();
                }
            }
        }


        void ViewPortMouseMove(object sender, MouseEventArgs e)
        {
            if (dialogProcessor.IsDragging && dialogProcessor.Selection.Count == 1)
            {
                Shape selectedShape = dialogProcessor.Selection[0];

                if (selectedShape != null)
                {
                    statusBar.Items[0].Text = "Последно действие: Влачене";

                    int offsetX = (int)(e.Location.X - dialogProcessor.LastLocation.X);
                    int offsetY = (int)(e.Location.Y - dialogProcessor.LastLocation.Y);

                    selectedShape.Move(offsetX, offsetY);

                    dialogProcessor.LastLocation = e.Location;
                    viewPort.Invalidate();
                }
            }
        }

        void ViewPortMouseUp(object sender, MouseEventArgs e)
        {
            if (pickUpSpeedButton.Checked)
            {
                Shape selectedShape = dialogProcessor.ContainsPoint(e.Location);

                if (selectedShape != null && (Control.ModifierKeys & Keys.Control) != Keys.Control)
                {
                    selectedShape.BorderSize /= 2; // Ресетва size до default
                    viewPort.Invalidate();
                }
            }
            dialogProcessor.IsDragging = false;
            
        }


        /// <summary>
        /// Групиране, отгрупиране
        /// </summary>
        private void goupShapesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dialogProcessor.GroupShapes();
            statusBar.Items[0].Text = "Последно действие: Групиране";
            viewPort.Invalidate();
        }

        private void ungroupShapesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dialogProcessor.UngroupShapes();
            statusBar.Items[0].Text = "Последно действие: Отгрупиране";
            viewPort.Invalidate();
        }

        /// <summary>
        /// Бутон, който отваря прозорец за избор на цвят на очертанията на примитивите
        /// </summary>
        void PickBorderColorButtonClick(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.ShowDialog();

            dialogProcessor.setBorderColor(colorDialog.Color);

            statusBar.Items[0].Text = "Последно действие: избор на цвят на очертанията на избрания примитив";

            viewPort.Invalidate();
        }

        /// <summary>
        /// Бутон, който отваря прозорец за избор на цвят на примитивите
        /// </summary>
        void PickFillColorButtonClick(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.ShowDialog();

            dialogProcessor.setFillColor(colorDialog.Color);

            statusBar.Items[0].Text = "Последно действие: избор на цвят запълващ избрания примитив";

            viewPort.Invalidate();
        }

        /// <summary>
        /// Тракбар, който Променя прозрачността на примитивите
        /// </summary>
        /// 
        private void transparencyTrackBar_Scroll(object sender, EventArgs e)
        {
            int trackBarMax = transparencyTrackBar.Maximum;
            int transparencyMax = 255;

            int transparency = (int)(((double)transparencyTrackBar.Value / trackBarMax) * transparencyMax);
            dialogProcessor.setTransparencyLevel(transparency);

            statusBar.Items[0].Text = "Последно действие: Промяна на прозрачност";
            viewPort.Invalidate();

        }
        
        /// <summary>
        /// Бутон, който избира дебелина на очертанията на примитивите
        /// избор - thin, medium, thick
        /// </summary>
        private void BorderSizeButtonClick(object sender, EventArgs e)
        {

        }

        private void selectBorderSizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // неактивен бутон, описва функцияра на dropdown бутона
        }

        private void thinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int border = 1;
            dialogProcessor.setBorderSizeLevel(border);

            statusBar.Items[0].Text = "Последно действие: избор на дебелина на очертанието на избрания примитив";

            viewPort.Invalidate();
        }

        private void mediumToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int border = 4;
            dialogProcessor.setBorderSizeLevel(border);

            statusBar.Items[0].Text = "Последно действие: избор на дебелина на очертанието на избрания примитив";

            viewPort.Invalidate();
        }

        private void thickToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int border = 8;
            dialogProcessor.setBorderSizeLevel(border);

            statusBar.Items[0].Text = "Последно действие: избор на дебелина на очертанието на избрания примитив";

            viewPort.Invalidate();
        }

        /// <summary>
        /// Бутон, който избира градуси за завъртане на примитивите
        /// </summary>
        private void rotateTrackBar_Scroll(object sender, EventArgs e)
        {
            int trackBarMax = rotateTrackBar.Maximum;
            float rotationMax = 360f;

            float rotation = ((float)rotateTrackBar.Value / trackBarMax) * rotationMax;
            dialogProcessor.RotatePrimitive(rotation);

            statusBar.Items[0].Text = "Последно действие: Завъртане";
            viewPort.Invalidate();
        }


        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }
        private void selectResizingValueToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void ResizePrimitive(float scaleFactor, string actionText)
        {
            statusBar.Items[0].Text = $"Последно действие: {actionText}";
            dialogProcessor.ResizePrimitive(scaleFactor);
            viewPort.Invalidate();
        }

        private void quarterSizeSmallerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResizePrimitive(0.75f, "намаляване на избрания примитив");
        }

        private void doubleSizeBiggerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResizePrimitive(2f, "уголемяване на избрания примитив");
        }

        private void quarterSizeBiggerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResizePrimitive(1.25f, "уголемяване на избрания примитив");
        }

        private void halfSizeBiggerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResizePrimitive(1.5f, "намаляване на избрания примитив");
        }

        private void halfSizeSmallerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResizePrimitive(0.5f, "намаляване на избрания примитив");
        }


        private void changeBackgroundColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.ShowDialog();

            dialogProcessor.ChangeBackgroundColor(colorDialog.Color);

            statusBar.Items[0].Text = "Последно действие: избор на цвят за фон";

            viewPort.Invalidate();
        }

        private void clearAllToolStripMenuItem_Click(object sender, EventArgs e)
        {

            dialogProcessor.ClearAll();

            statusBar.Items[0].Text = "Последно действие: изтриване на всичко от платното за рисуване";

            viewPort.Invalidate();
        }

        private void insertImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusBar.Items[0].Text = "Последно действие: избор на изображение";
            dialogProcessor.SetImage();
            viewPort.Invalidate();
        }

        private void setImageAsBackgroundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusBar.Items[0].Text = "Последно действие: избор на изображение за фон";
            dialogProcessor.SetBackground();
            viewPort.Invalidate();
        }

        private void removeBackgroundImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusBar.Items[0].Text = "Последно действие: премахване на изображение за фон";
            dialogProcessor.RemoveBackgroundImage();
            viewPort.Invalidate();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Drawing program", "About info", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                dialogProcessor.MySerialize(dialogProcessor.ShapeList, saveFileDialog.FileName);
                statusBar.Items[0].Text = "Последно действие: Запазване";
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                dialogProcessor.ShapeList = (List<Shape>)dialogProcessor.MyDeSerialize(openFileDialog.FileName);
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
                    SaveFileDialog saveFileDialog = new SaveFileDialog();

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        dialogProcessor.MySerialize(dialogProcessor.ShapeList, saveFileDialog.FileName);
                        statusBar.Items[0].Text = "Последно действие: Изчистване на работното място";
                    }
                }
                dialogProcessor.ClearAll();
                viewPort.Invalidate();
            }
        }

        private void imageToolStripMenuItem1_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            statusBar.Items[0].Text = "Последно действие: изтриване на примитив";
            dialogProcessor.DeleteSelected();
            viewPort.Invalidate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            statusBar.Items[0].Text = "Последно действие: копиране на примитив";
            dialogProcessor.CopySelected();
            viewPort.Invalidate();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            statusBar.Items[0].Text = "Последно действие: именуване на примитив";
            dialogProcessor.NameSelectedShape(nameTextBox.Text);
            nameTextBox.Clear();
            viewPort.Invalidate();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            string name = toolStripTextBox1.Text;
            toolStripTextBox1.Clear();  

            if (name != null)
            {
                ColorDialog colorDialog = new ColorDialog();
                colorDialog.ShowDialog();

                statusBar.Items[0].Text = "Последно действие: оцветяване на примитив";
                dialogProcessor.ColorObjectName(name, colorDialog.Color);
                viewPort.Invalidate();
            } else
            {
                MessageBox.Show("Please enter name of an element!", "Text issue", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
         
        private void setColorByObjectNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void viewPort_Load(object sender, EventArgs e)
        {

        }

        
    }
}
