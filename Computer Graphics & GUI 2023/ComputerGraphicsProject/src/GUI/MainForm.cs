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
        /// Прихващане на координатите при натискането на бутон на мишката и проверка (в обратен ред) дали не е
        /// щракнато върху елемент. Ако е така то той се отбелязва като селектиран и започва процес на "влачене".
        /// Промяна на статуса и инвалидиране на контрола, в който визуализираме.
        /// Реализацията се диалогът с потребителя, при който се избира "най-горния" елемент от екрана.
        /// </summary>
        void ViewPortMouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (pickUpSpeedButton.Checked) {
				dialogProcessor.Selection = dialogProcessor.ContainsPoint(e.Location);
				if (dialogProcessor.Selection != null) {
					statusBar.Items[0].Text = "Последно действие: Селекция на примитив";
					dialogProcessor.IsDragging = true;
					dialogProcessor.LastLocation = e.Location;
					viewPort.Invalidate();
				}
			}
		}

		/// <summary>
		/// Прихващане на преместването на мишката.
		/// Ако сме в режм на "влачене", то избрания елемент се транслира.
		/// </summary>
		void ViewPortMouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (dialogProcessor.IsDragging) {
				if (dialogProcessor.Selection != null) statusBar.Items[0].Text = "Последно действие: Влачене";
				dialogProcessor.TranslateTo(e.Location);
				viewPort.Invalidate();
			}
		}

		/// <summary>
		/// Прихващане на отпускането на бутона на мишката.
		/// Излизаме от режим "влачене".
		/// </summary>
		void ViewPortMouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			dialogProcessor.IsDragging = false;
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
        /// Бутон, който избира прозрачността на примитивите
        /// избор - low, medium, high
        /// </summary>
        void TransparencyButtonClick(object sender, EventArgs e)
        {
           
        }

        private void selectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // неактивен бутон, описва функцияра на dropdown бутона
        }

        private void lowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int transparency = 255;
            dialogProcessor.setTransparencyLeveL(transparency);

            statusBar.Items[0].Text = "Последно действие: избор на прозрачност на избрания примитив";

            viewPort.Invalidate();
        }

        private void mediumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int transparency = 125;
            dialogProcessor.setTransparencyLeveL(transparency);

            statusBar.Items[0].Text = "Последно действие: избор на прозрачност на избрания примитив";

            viewPort.Invalidate();
        }

        private void highToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int transparency = 30;
            dialogProcessor.setTransparencyLeveL(transparency);

            statusBar.Items[0].Text = "Последно действие: избор на прозрачност на избрания примитив";

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
    }
}
