using System.Windows.Forms;

namespace Draw
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.групиранеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.разгрупиранеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.смянаНаЦветаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.смянаНаЦветаНаГраницатаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавиТриъгълникToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавиЕлипсаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавиПравоъгълникToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.заНасToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.currentStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.speedMenu = new System.Windows.Forms.ToolStrip();
            this.pickUpSpeedButton = new System.Windows.Forms.ToolStripButton();
            this.drawRectangleSpeedButton = new System.Windows.Forms.ToolStripButton();
            this.DrawElipseSpeedButton = new System.Windows.Forms.ToolStripButton();
            this.AddTriangleSpeedButton = new System.Windows.Forms.ToolStripButton();
            this.GroupShapesButton = new System.Windows.Forms.ToolStripButton();
            this.UnGroupShapesButton = new System.Windows.Forms.ToolStripButton();
            this.PickBackgroundColor = new System.Windows.Forms.ToolStripButton();
            this.PickBorderColor = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.textBoxString = new System.Windows.Forms.TextBox();
            this.btnAddString = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.trackBar2 = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.viewPort = new Draw.DoubleBufferedPanel();
            this.mainMenu.SuspendLayout();
            this.statusBar.SuspendLayout();
            this.speedMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.imageToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(1464, 28);
            this.mainMenu.TabIndex = 1;
            this.mainMenu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(59, 24);
            this.fileToolStripMenuItem.Text = "&Файл";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.newToolStripMenuItem.Text = "&New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.openToolStripMenuItem.Text = "&Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.saveToolStripMenuItem.Text = "&Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.exitToolStripMenuItem.Text = "&Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItemClick);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.групиранеToolStripMenuItem,
            this.разгрупиранеToolStripMenuItem,
            this.смянаНаЦветаToolStripMenuItem,
            this.смянаНаЦветаНаГраницатаToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(111, 24);
            this.editToolStripMenuItem.Text = "&Редактиране";
            // 
            // групиранеToolStripMenuItem
            // 
            this.групиранеToolStripMenuItem.Name = "групиранеToolStripMenuItem";
            this.групиранеToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.G)));
            this.групиранеToolStripMenuItem.Size = new System.Drawing.Size(349, 26);
            this.групиранеToolStripMenuItem.Text = "&Групиране";
            this.групиранеToolStripMenuItem.Click += new System.EventHandler(this.GroupShapesButton_Click);
            // 
            // разгрупиранеToolStripMenuItem
            // 
            this.разгрупиранеToolStripMenuItem.Name = "разгрупиранеToolStripMenuItem";
            this.разгрупиранеToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.U)));
            this.разгрупиранеToolStripMenuItem.Size = new System.Drawing.Size(349, 26);
            this.разгрупиранеToolStripMenuItem.Text = "&Разгрупиране";
            this.разгрупиранеToolStripMenuItem.Click += new System.EventHandler(this.UnGroupShapesButton_Click);
            // 
            // смянаНаЦветаToolStripMenuItem
            // 
            this.смянаНаЦветаToolStripMenuItem.Name = "смянаНаЦветаToolStripMenuItem";
            this.смянаНаЦветаToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.смянаНаЦветаToolStripMenuItem.Size = new System.Drawing.Size(349, 26);
            this.смянаНаЦветаToolStripMenuItem.Text = "&Смяна на цвета";
            this.смянаНаЦветаToolStripMenuItem.Click += new System.EventHandler(this.PickBackgroundColor_Click);
            // 
            // смянаНаЦветаНаГраницатаToolStripMenuItem
            // 
            this.смянаНаЦветаНаГраницатаToolStripMenuItem.Name = "смянаНаЦветаНаГраницатаToolStripMenuItem";
            this.смянаНаЦветаНаГраницатаToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.B)));
            this.смянаНаЦветаНаГраницатаToolStripMenuItem.Size = new System.Drawing.Size(349, 26);
            this.смянаНаЦветаНаГраницатаToolStripMenuItem.Text = "С&мяна на цвета на границата";
            this.смянаНаЦветаНаГраницатаToolStripMenuItem.Click += new System.EventHandler(this.PickBorderColor_Click);
            // 
            // imageToolStripMenuItem
            // 
            this.imageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавиТриъгълникToolStripMenuItem,
            this.добавиЕлипсаToolStripMenuItem,
            this.добавиПравоъгълникToolStripMenuItem});
            this.imageToolStripMenuItem.Name = "imageToolStripMenuItem";
            this.imageToolStripMenuItem.Size = new System.Drawing.Size(121, 24);
            this.imageToolStripMenuItem.Text = "&Изображение";
            // 
            // добавиТриъгълникToolStripMenuItem
            // 
            this.добавиТриъгълникToolStripMenuItem.Name = "добавиТриъгълникToolStripMenuItem";
            this.добавиТриъгълникToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.добавиТриъгълникToolStripMenuItem.Size = new System.Drawing.Size(300, 26);
            this.добавиТриъгълникToolStripMenuItem.Text = "Добави &триъгълник";
            this.добавиТриъгълникToolStripMenuItem.Click += new System.EventHandler(this.AddTriangleSpeedButton_Click);
            // 
            // добавиЕлипсаToolStripMenuItem
            // 
            this.добавиЕлипсаToolStripMenuItem.Name = "добавиЕлипсаToolStripMenuItem";
            this.добавиЕлипсаToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.добавиЕлипсаToolStripMenuItem.Size = new System.Drawing.Size(300, 26);
            this.добавиЕлипсаToolStripMenuItem.Text = "Добави &елипса";
            this.добавиЕлипсаToolStripMenuItem.Click += new System.EventHandler(this.DrawElipseSpeedButton_Click);
            // 
            // добавиПравоъгълникToolStripMenuItem
            // 
            this.добавиПравоъгълникToolStripMenuItem.Name = "добавиПравоъгълникToolStripMenuItem";
            this.добавиПравоъгълникToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.добавиПравоъгълникToolStripMenuItem.Size = new System.Drawing.Size(300, 26);
            this.добавиПравоъгълникToolStripMenuItem.Text = "Добави &правоъгълник";
            this.добавиПравоъгълникToolStripMenuItem.Click += new System.EventHandler(this.DrawRectangleSpeedButtonClick);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.заНасToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(75, 24);
            this.helpToolStripMenuItem.Text = "&Помощ";
            // 
            // заНасToolStripMenuItem
            // 
            this.заНасToolStripMenuItem.Name = "заНасToolStripMenuItem";
            this.заНасToolStripMenuItem.Size = new System.Drawing.Size(136, 26);
            this.заНасToolStripMenuItem.Text = "&За нас";
            this.заНасToolStripMenuItem.Click += new System.EventHandler(this.заНасToolStripMenuItem_Click);
            // 
            // statusBar
            // 
            this.statusBar.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.currentStatusLabel});
            this.statusBar.Location = new System.Drawing.Point(0, 507);
            this.statusBar.Name = "statusBar";
            this.statusBar.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusBar.Size = new System.Drawing.Size(1464, 22);
            this.statusBar.TabIndex = 2;
            this.statusBar.Text = "statusStrip1";
            // 
            // currentStatusLabel
            // 
            this.currentStatusLabel.Name = "currentStatusLabel";
            this.currentStatusLabel.Size = new System.Drawing.Size(0, 16);
            // 
            // speedMenu
            // 
            this.speedMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.speedMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pickUpSpeedButton,
            this.drawRectangleSpeedButton,
            this.DrawElipseSpeedButton,
            this.AddTriangleSpeedButton,
            this.GroupShapesButton,
            this.UnGroupShapesButton,
            this.PickBackgroundColor,
            this.PickBorderColor,
            this.toolStripButton1});
            this.speedMenu.Location = new System.Drawing.Point(0, 28);
            this.speedMenu.Name = "speedMenu";
            this.speedMenu.Size = new System.Drawing.Size(1464, 27);
            this.speedMenu.TabIndex = 3;
            this.speedMenu.Text = "toolStrip1";
            // 
            // pickUpSpeedButton
            // 
            this.pickUpSpeedButton.Checked = true;
            this.pickUpSpeedButton.CheckOnClick = true;
            this.pickUpSpeedButton.CheckState = System.Windows.Forms.CheckState.Checked;
            this.pickUpSpeedButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.pickUpSpeedButton.Image = ((System.Drawing.Image)(resources.GetObject("pickUpSpeedButton.Image")));
            this.pickUpSpeedButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pickUpSpeedButton.Name = "pickUpSpeedButton";
            this.pickUpSpeedButton.Size = new System.Drawing.Size(29, 24);
            this.pickUpSpeedButton.Text = "toolStripButton1";
            // 
            // drawRectangleSpeedButton
            // 
            this.drawRectangleSpeedButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.drawRectangleSpeedButton.Image = ((System.Drawing.Image)(resources.GetObject("drawRectangleSpeedButton.Image")));
            this.drawRectangleSpeedButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.drawRectangleSpeedButton.Name = "drawRectangleSpeedButton";
            this.drawRectangleSpeedButton.Size = new System.Drawing.Size(29, 24);
            this.drawRectangleSpeedButton.Text = "DrawRectangleButton";
            this.drawRectangleSpeedButton.Click += new System.EventHandler(this.DrawRectangleSpeedButtonClick);
            // 
            // DrawElipseSpeedButton
            // 
            this.DrawElipseSpeedButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.DrawElipseSpeedButton.Image = ((System.Drawing.Image)(resources.GetObject("DrawElipseSpeedButton.Image")));
            this.DrawElipseSpeedButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DrawElipseSpeedButton.Name = "DrawElipseSpeedButton";
            this.DrawElipseSpeedButton.Size = new System.Drawing.Size(29, 24);
            this.DrawElipseSpeedButton.Text = "DrawElipseButton";
            this.DrawElipseSpeedButton.Click += new System.EventHandler(this.DrawElipseSpeedButton_Click);
            // 
            // AddTriangleSpeedButton
            // 
            this.AddTriangleSpeedButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.AddTriangleSpeedButton.Image = ((System.Drawing.Image)(resources.GetObject("AddTriangleSpeedButton.Image")));
            this.AddTriangleSpeedButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AddTriangleSpeedButton.Name = "AddTriangleSpeedButton";
            this.AddTriangleSpeedButton.Size = new System.Drawing.Size(29, 24);
            this.AddTriangleSpeedButton.Text = "AddTriangleButton";
            this.AddTriangleSpeedButton.Click += new System.EventHandler(this.AddTriangleSpeedButton_Click);
            // 
            // GroupShapesButton
            // 
            this.GroupShapesButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.GroupShapesButton.Image = ((System.Drawing.Image)(resources.GetObject("GroupShapesButton.Image")));
            this.GroupShapesButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.GroupShapesButton.Name = "GroupShapesButton";
            this.GroupShapesButton.Size = new System.Drawing.Size(29, 24);
            this.GroupShapesButton.Text = "GroupShapesButton";
            this.GroupShapesButton.Click += new System.EventHandler(this.GroupShapesButton_Click);
            // 
            // UnGroupShapesButton
            // 
            this.UnGroupShapesButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.UnGroupShapesButton.Image = ((System.Drawing.Image)(resources.GetObject("UnGroupShapesButton.Image")));
            this.UnGroupShapesButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.UnGroupShapesButton.Name = "UnGroupShapesButton";
            this.UnGroupShapesButton.Size = new System.Drawing.Size(29, 24);
            this.UnGroupShapesButton.Text = "UnGroupShapesButton";
            this.UnGroupShapesButton.Click += new System.EventHandler(this.UnGroupShapesButton_Click);
            // 
            // PickBackgroundColor
            // 
            this.PickBackgroundColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.PickBackgroundColor.Image = ((System.Drawing.Image)(resources.GetObject("PickBackgroundColor.Image")));
            this.PickBackgroundColor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.PickBackgroundColor.Name = "PickBackgroundColor";
            this.PickBackgroundColor.Size = new System.Drawing.Size(29, 24);
            this.PickBackgroundColor.Text = "toolStripButton1";
            this.PickBackgroundColor.ToolTipText = "PickBackgroundColor";
            this.PickBackgroundColor.Click += new System.EventHandler(this.PickBackgroundColor_Click);
            // 
            // PickBorderColor
            // 
            this.PickBorderColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.PickBorderColor.Image = ((System.Drawing.Image)(resources.GetObject("PickBorderColor.Image")));
            this.PickBorderColor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.PickBorderColor.Name = "PickBorderColor";
            this.PickBorderColor.Size = new System.Drawing.Size(29, 24);
            this.PickBorderColor.Text = "PickBorderColor";
            this.PickBorderColor.Click += new System.EventHandler(this.PickBorderColor_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(29, 24);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(424, 5);
            this.trackBar1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.trackBar1.Maximum = 255;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(143, 56);
            this.trackBar1.TabIndex = 5;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar1.Value = 255;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // textBoxString
            // 
            this.textBoxString.Location = new System.Drawing.Point(788, 18);
            this.textBoxString.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxString.Name = "textBoxString";
            this.textBoxString.Size = new System.Drawing.Size(176, 22);
            this.textBoxString.TabIndex = 6;
            // 
            // btnAddString
            // 
            this.btnAddString.Location = new System.Drawing.Point(987, 16);
            this.btnAddString.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAddString.Name = "btnAddString";
            this.btnAddString.Size = new System.Drawing.Size(100, 28);
            this.btnAddString.TabIndex = 7;
            this.btnAddString.Text = "Добави";
            this.btnAddString.UseVisualStyleBackColor = true;
            this.btnAddString.Click += new System.EventHandler(this.btnAddString_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(1219, 20);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 28);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text = "Изтрий";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(444, 34);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "Прозрачност";
            // 
            // trackBar2
            // 
            this.trackBar2.Location = new System.Drawing.Point(575, 5);
            this.trackBar2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.trackBar2.Maximum = 360;
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Size = new System.Drawing.Size(139, 56);
            this.trackBar2.TabIndex = 10;
            this.trackBar2.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar2.Scroll += new System.EventHandler(this.trackBar2_Scroll);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(599, 33);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 16);
            this.label2.TabIndex = 11;
            this.label2.Text = "Завъртане";
            // 
            // viewPort
            // 
            this.viewPort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewPort.Location = new System.Drawing.Point(0, 55);
            this.viewPort.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.viewPort.Name = "viewPort";
            this.viewPort.Size = new System.Drawing.Size(1464, 452);
            this.viewPort.TabIndex = 4;
            this.viewPort.Paint += new System.Windows.Forms.PaintEventHandler(this.ViewPortPaint);
            this.viewPort.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ViewPortMouseDown);
            this.viewPort.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ViewPortMouseMove);
            this.viewPort.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ViewPortMouseUp);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1464, 529);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.trackBar2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAddString);
            this.Controls.Add(this.textBoxString);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.viewPort);
            this.Controls.Add(this.speedMenu);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.mainMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mainMenu;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "MainForm";
            this.Text = "Draw";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.speedMenu.ResumeLayout(false);
            this.speedMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		
		private System.Windows.Forms.ToolStripStatusLabel currentStatusLabel;
		private Draw.DoubleBufferedPanel viewPort;
		private System.Windows.Forms.ToolStripButton pickUpSpeedButton;
		private System.Windows.Forms.ToolStripButton drawRectangleSpeedButton;
		private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem imageToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStrip speedMenu;
		private System.Windows.Forms.StatusStrip statusBar;
		private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripButton DrawElipseSpeedButton;
        private System.Windows.Forms.ToolStripButton AddTriangleSpeedButton;
        private System.Windows.Forms.ToolStripButton GroupShapesButton;
        private System.Windows.Forms.ToolStripButton UnGroupShapesButton;
        private System.Windows.Forms.ToolStripButton PickBackgroundColor;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ToolStripButton PickBorderColor;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.TextBox textBoxString;
        private System.Windows.Forms.Button btnAddString;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar trackBar2;
        private System.Windows.Forms.Label label2;
        private ToolStripMenuItem групиранеToolStripMenuItem;
        private ToolStripMenuItem разгрупиранеToolStripMenuItem;
        private ToolStripMenuItem смянаНаЦветаToolStripMenuItem;
        private ToolStripMenuItem смянаНаЦветаНаГраницатаToolStripMenuItem;
        private ToolStripMenuItem добавиТриъгълникToolStripMenuItem;
        private ToolStripMenuItem добавиЕлипсаToolStripMenuItem;
        private ToolStripMenuItem добавиПравоъгълникToolStripMenuItem;
        private ToolStripMenuItem заНасToolStripMenuItem;
        private ToolStripButton toolStripButton1;
    }
}
