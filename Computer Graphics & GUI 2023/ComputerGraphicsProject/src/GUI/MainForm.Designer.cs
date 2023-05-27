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
            this.changeBackgroundColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setColorByObjectNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.clearAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.goupShapesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ungroupShapesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.insertImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setImageAsBackgroundToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeBackgroundImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.currentStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.speedMenu = new System.Windows.Forms.ToolStrip();
            this.pickUpSpeedButton = new System.Windows.Forms.ToolStripButton();
            this.drawLineSpeedButton = new System.Windows.Forms.ToolStripButton();
            this.drawDotSpeedButton = new System.Windows.Forms.ToolStripButton();
            this.drawCircleSpeedButton = new System.Windows.Forms.ToolStripButton();
            this.drawEllipseSpeedButton = new System.Windows.Forms.ToolStripButton();
            this.drawTriangleSpeedButton = new System.Windows.Forms.ToolStripButton();
            this.drawSquareSpeedButton = new System.Windows.Forms.ToolStripButton();
            this.drawRectangleSpeedButton = new System.Windows.Forms.ToolStripButton();
            this.drawPentagonSpeedButton = new System.Windows.Forms.ToolStripButton();
            this.drawHexagonShape = new System.Windows.Forms.ToolStripButton();
            this.drawStarSpeedButton = new System.Windows.Forms.ToolStripButton();
            this.heartShapeButton = new System.Windows.Forms.ToolStripButton();
            this.ickBorderColorButton = new System.Windows.Forms.ToolStripButton();
            this.pickFillColorButton = new System.Windows.Forms.ToolStripButton();
            this.borderSizeButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.selectBorderSizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mediumToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.thickToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.halfSizeSmallerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quarterSizeSmallerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quarterSizeBiggerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.halfSizeBiggerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.doubleSizeBiggerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectRotationValueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.textBoxString = new System.Windows.Forms.TextBox();
            this.btnAddString = new System.Windows.Forms.Button();
            this.transparencyTrackBar = new System.Windows.Forms.TrackBar();
            this.rotateTrackBar = new System.Windows.Forms.TrackBar();
            this.viewPort = new Draw.DoubleBufferedPanel();
            this.mainMenu.SuspendLayout();
            this.statusBar.SuspendLayout();
            this.speedMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.transparencyTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rotateTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.imageToolStripMenuItem1,
            this.helpToolStripMenuItem});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.mainMenu.Size = new System.Drawing.Size(1385, 24);
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
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            this.fileToolStripMenuItem.Click += new System.EventHandler(this.fileToolStripMenuItem_Click);
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItemClick);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeBackgroundColorToolStripMenuItem,
            this.setColorByObjectNameToolStripMenuItem,
            this.clearAllToolStripMenuItem,
            this.goupShapesToolStripMenuItem,
            this.ungroupShapesToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // changeBackgroundColorToolStripMenuItem
            // 
            this.changeBackgroundColorToolStripMenuItem.Name = "changeBackgroundColorToolStripMenuItem";
            this.changeBackgroundColorToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.changeBackgroundColorToolStripMenuItem.Text = "Change background color";
            this.changeBackgroundColorToolStripMenuItem.Click += new System.EventHandler(this.changeBackgroundColorToolStripMenuItem_Click);
            // 
            // setColorByObjectNameToolStripMenuItem
            // 
            this.setColorByObjectNameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBox1,
            this.toolStripMenuItem2});
            this.setColorByObjectNameToolStripMenuItem.Name = "setColorByObjectNameToolStripMenuItem";
            this.setColorByObjectNameToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.setColorByObjectNameToolStripMenuItem.Text = "Set color by object name";
            this.setColorByObjectNameToolStripMenuItem.Click += new System.EventHandler(this.setColorByObjectNameToolStripMenuItem_Click);
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(100, 23);
            this.toolStripTextBox1.Tag = "";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(160, 22);
            this.toolStripMenuItem2.Text = "Submit";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // clearAllToolStripMenuItem
            // 
            this.clearAllToolStripMenuItem.Name = "clearAllToolStripMenuItem";
            this.clearAllToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.clearAllToolStripMenuItem.Text = "Clear all";
            this.clearAllToolStripMenuItem.Click += new System.EventHandler(this.clearAllToolStripMenuItem_Click);
            // 
            // goupShapesToolStripMenuItem
            // 
            this.goupShapesToolStripMenuItem.Name = "goupShapesToolStripMenuItem";
            this.goupShapesToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.goupShapesToolStripMenuItem.Text = "GoupShapes";
            this.goupShapesToolStripMenuItem.Click += new System.EventHandler(this.goupShapesToolStripMenuItem_Click);
            // 
            // ungroupShapesToolStripMenuItem
            // 
            this.ungroupShapesToolStripMenuItem.Name = "ungroupShapesToolStripMenuItem";
            this.ungroupShapesToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.ungroupShapesToolStripMenuItem.Text = "Ungroup Shapes";
            this.ungroupShapesToolStripMenuItem.Click += new System.EventHandler(this.ungroupShapesToolStripMenuItem_Click);
            // 
            // imageToolStripMenuItem1
            // 
            this.imageToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.insertImageToolStripMenuItem,
            this.setImageAsBackgroundToolStripMenuItem,
            this.removeBackgroundImageToolStripMenuItem});
            this.imageToolStripMenuItem1.Name = "imageToolStripMenuItem1";
            this.imageToolStripMenuItem1.Size = new System.Drawing.Size(52, 20);
            this.imageToolStripMenuItem1.Text = "Image";
            this.imageToolStripMenuItem1.Click += new System.EventHandler(this.imageToolStripMenuItem1_Click);
            // 
            // insertImageToolStripMenuItem
            // 
            this.insertImageToolStripMenuItem.Name = "insertImageToolStripMenuItem";
            this.insertImageToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.insertImageToolStripMenuItem.Text = "Insert image";
            this.insertImageToolStripMenuItem.Click += new System.EventHandler(this.insertImageToolStripMenuItem_Click);
            // 
            // setImageAsBackgroundToolStripMenuItem
            // 
            this.setImageAsBackgroundToolStripMenuItem.Name = "setImageAsBackgroundToolStripMenuItem";
            this.setImageAsBackgroundToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.setImageAsBackgroundToolStripMenuItem.Text = "Set image as background";
            this.setImageAsBackgroundToolStripMenuItem.Click += new System.EventHandler(this.setImageAsBackgroundToolStripMenuItem_Click);
            // 
            // removeBackgroundImageToolStripMenuItem
            // 
            this.removeBackgroundImageToolStripMenuItem.Name = "removeBackgroundImageToolStripMenuItem";
            this.removeBackgroundImageToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.removeBackgroundImageToolStripMenuItem.Text = "Remove background image";
            this.removeBackgroundImageToolStripMenuItem.Click += new System.EventHandler(this.removeBackgroundImageToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.aboutToolStripMenuItem.Text = "About...";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // statusBar
            // 
            this.statusBar.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.currentStatusLabel});
            this.statusBar.Location = new System.Drawing.Point(0, 559);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(1385, 22);
            this.statusBar.TabIndex = 2;
            this.statusBar.Text = "statusStrip1";
            // 
            // currentStatusLabel
            // 
            this.currentStatusLabel.Name = "currentStatusLabel";
            this.currentStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // speedMenu
            // 
            this.speedMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.speedMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pickUpSpeedButton,
            this.drawLineSpeedButton,
            this.drawDotSpeedButton,
            this.drawCircleSpeedButton,
            this.drawEllipseSpeedButton,
            this.drawTriangleSpeedButton,
            this.drawSquareSpeedButton,
            this.drawRectangleSpeedButton,
            this.drawPentagonSpeedButton,
            this.drawHexagonShape,
            this.drawStarSpeedButton,
            this.heartShapeButton,
            this.ickBorderColorButton,
            this.pickFillColorButton,
            this.borderSizeButton,
            this.toolStripButton1});
            this.speedMenu.Location = new System.Drawing.Point(0, 24);
            this.speedMenu.Name = "speedMenu";
            this.speedMenu.Size = new System.Drawing.Size(1385, 27);
            this.speedMenu.Stretch = true;
            this.speedMenu.TabIndex = 3;
            this.speedMenu.Text = "toolStrip1";
            // 
            // pickUpSpeedButton
            // 
            this.pickUpSpeedButton.CheckOnClick = true;
            this.pickUpSpeedButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.pickUpSpeedButton.Image = ((System.Drawing.Image)(resources.GetObject("pickUpSpeedButton.Image")));
            this.pickUpSpeedButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pickUpSpeedButton.Name = "pickUpSpeedButton";
            this.pickUpSpeedButton.Size = new System.Drawing.Size(24, 24);
            this.pickUpSpeedButton.Text = "selectShape";
            // 
            // drawLineSpeedButton
            // 
            this.drawLineSpeedButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.drawLineSpeedButton.Image = ((System.Drawing.Image)(resources.GetObject("drawLineSpeedButton.Image")));
            this.drawLineSpeedButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.drawLineSpeedButton.Name = "drawLineSpeedButton";
            this.drawLineSpeedButton.Size = new System.Drawing.Size(24, 24);
            this.drawLineSpeedButton.Text = "drawLineButton";
            this.drawLineSpeedButton.Click += new System.EventHandler(this.DrawLineSpeedButtonClick);
            // 
            // drawDotSpeedButton
            // 
            this.drawDotSpeedButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.drawDotSpeedButton.Image = ((System.Drawing.Image)(resources.GetObject("drawDotSpeedButton.Image")));
            this.drawDotSpeedButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.drawDotSpeedButton.Name = "drawDotSpeedButton";
            this.drawDotSpeedButton.Size = new System.Drawing.Size(24, 24);
            this.drawDotSpeedButton.Text = "drawDotButton";
            this.drawDotSpeedButton.Click += new System.EventHandler(this.DrawDotSpeedButtonClick);
            // 
            // drawCircleSpeedButton
            // 
            this.drawCircleSpeedButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.drawCircleSpeedButton.Image = ((System.Drawing.Image)(resources.GetObject("drawCircleSpeedButton.Image")));
            this.drawCircleSpeedButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.drawCircleSpeedButton.Name = "drawCircleSpeedButton";
            this.drawCircleSpeedButton.Size = new System.Drawing.Size(24, 24);
            this.drawCircleSpeedButton.Text = "drawCircleButton";
            this.drawCircleSpeedButton.Click += new System.EventHandler(this.DrawCircleSpeedButtonClick);
            // 
            // drawEllipseSpeedButton
            // 
            this.drawEllipseSpeedButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.drawEllipseSpeedButton.Image = ((System.Drawing.Image)(resources.GetObject("drawEllipseSpeedButton.Image")));
            this.drawEllipseSpeedButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.drawEllipseSpeedButton.Name = "drawEllipseSpeedButton";
            this.drawEllipseSpeedButton.Size = new System.Drawing.Size(24, 24);
            this.drawEllipseSpeedButton.Text = "drawEllipseButton";
            this.drawEllipseSpeedButton.Click += new System.EventHandler(this.DrawEllipseSpeedButtonClick);
            // 
            // drawTriangleSpeedButton
            // 
            this.drawTriangleSpeedButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.drawTriangleSpeedButton.Image = ((System.Drawing.Image)(resources.GetObject("drawTriangleSpeedButton.Image")));
            this.drawTriangleSpeedButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.drawTriangleSpeedButton.Name = "drawTriangleSpeedButton";
            this.drawTriangleSpeedButton.Size = new System.Drawing.Size(24, 24);
            this.drawTriangleSpeedButton.Text = "drawTriangleButton";
            this.drawTriangleSpeedButton.Click += new System.EventHandler(this.DrawTriangleSpeedButtonClick);
            // 
            // drawSquareSpeedButton
            // 
            this.drawSquareSpeedButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.drawSquareSpeedButton.Image = ((System.Drawing.Image)(resources.GetObject("drawSquareSpeedButton.Image")));
            this.drawSquareSpeedButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.drawSquareSpeedButton.Name = "drawSquareSpeedButton";
            this.drawSquareSpeedButton.Size = new System.Drawing.Size(24, 24);
            this.drawSquareSpeedButton.Text = "drawSquareButton";
            this.drawSquareSpeedButton.Click += new System.EventHandler(this.DrawSquareSpeedButtonClick);
            // 
            // drawRectangleSpeedButton
            // 
            this.drawRectangleSpeedButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.drawRectangleSpeedButton.Image = ((System.Drawing.Image)(resources.GetObject("drawRectangleSpeedButton.Image")));
            this.drawRectangleSpeedButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.drawRectangleSpeedButton.Name = "drawRectangleSpeedButton";
            this.drawRectangleSpeedButton.Size = new System.Drawing.Size(24, 24);
            this.drawRectangleSpeedButton.Text = "DrawRectangleButton";
            this.drawRectangleSpeedButton.Click += new System.EventHandler(this.DrawRectangleSpeedButtonClick);
            // 
            // drawPentagonSpeedButton
            // 
            this.drawPentagonSpeedButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.drawPentagonSpeedButton.Image = ((System.Drawing.Image)(resources.GetObject("drawPentagonSpeedButton.Image")));
            this.drawPentagonSpeedButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.drawPentagonSpeedButton.Name = "drawPentagonSpeedButton";
            this.drawPentagonSpeedButton.Size = new System.Drawing.Size(24, 24);
            this.drawPentagonSpeedButton.Text = "drawPentagonButton";
            this.drawPentagonSpeedButton.Click += new System.EventHandler(this.DrawPentagonSpeedButtonClick);
            // 
            // drawHexagonShape
            // 
            this.drawHexagonShape.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.drawHexagonShape.Image = ((System.Drawing.Image)(resources.GetObject("drawHexagonShape.Image")));
            this.drawHexagonShape.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.drawHexagonShape.Name = "drawHexagonShape";
            this.drawHexagonShape.Size = new System.Drawing.Size(24, 24);
            this.drawHexagonShape.Text = "drawHexagonButton";
            this.drawHexagonShape.Click += new System.EventHandler(this.DrawHexagonSpeedButtonClick);
            // 
            // drawStarSpeedButton
            // 
            this.drawStarSpeedButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.drawStarSpeedButton.Image = ((System.Drawing.Image)(resources.GetObject("drawStarSpeedButton.Image")));
            this.drawStarSpeedButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.drawStarSpeedButton.Name = "drawStarSpeedButton";
            this.drawStarSpeedButton.Size = new System.Drawing.Size(24, 24);
            this.drawStarSpeedButton.Text = "drawStarButton";
            this.drawStarSpeedButton.Click += new System.EventHandler(this.DrawStarSpeedButtonClick);
            // 
            // heartShapeButton
            // 
            this.heartShapeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.heartShapeButton.Image = ((System.Drawing.Image)(resources.GetObject("heartShapeButton.Image")));
            this.heartShapeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.heartShapeButton.Name = "heartShapeButton";
            this.heartShapeButton.Size = new System.Drawing.Size(24, 24);
            this.heartShapeButton.Text = "toolStripButton2";
            this.heartShapeButton.Click += new System.EventHandler(this.heartShapeButton_Click);
            // 
            // ickBorderColorButton
            // 
            this.ickBorderColorButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ickBorderColorButton.Image = ((System.Drawing.Image)(resources.GetObject("ickBorderColorButton.Image")));
            this.ickBorderColorButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ickBorderColorButton.Name = "ickBorderColorButton";
            this.ickBorderColorButton.Size = new System.Drawing.Size(24, 24);
            this.ickBorderColorButton.Text = "pickBorderColorButton";
            this.ickBorderColorButton.Click += new System.EventHandler(this.PickBorderColorButtonClick);
            // 
            // pickFillColorButton
            // 
            this.pickFillColorButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.pickFillColorButton.Image = ((System.Drawing.Image)(resources.GetObject("pickFillColorButton.Image")));
            this.pickFillColorButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pickFillColorButton.Name = "pickFillColorButton";
            this.pickFillColorButton.Size = new System.Drawing.Size(24, 24);
            this.pickFillColorButton.Text = "pickFillColorButton";
            this.pickFillColorButton.Click += new System.EventHandler(this.PickFillColorButtonClick);
            // 
            // borderSizeButton
            // 
            this.borderSizeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.borderSizeButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectBorderSizeToolStripMenuItem,
            this.thinToolStripMenuItem,
            this.mediumToolStripMenuItem1,
            this.thickToolStripMenuItem});
            this.borderSizeButton.Image = ((System.Drawing.Image)(resources.GetObject("borderSizeButton.Image")));
            this.borderSizeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.borderSizeButton.Name = "borderSizeButton";
            this.borderSizeButton.Size = new System.Drawing.Size(33, 24);
            this.borderSizeButton.Text = "pickBorderSizeButton";
            this.borderSizeButton.Click += new System.EventHandler(this.BorderSizeButtonClick);
            // 
            // selectBorderSizeToolStripMenuItem
            // 
            this.selectBorderSizeToolStripMenuItem.Enabled = false;
            this.selectBorderSizeToolStripMenuItem.Name = "selectBorderSizeToolStripMenuItem";
            this.selectBorderSizeToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.selectBorderSizeToolStripMenuItem.Text = "Select Border Size";
            this.selectBorderSizeToolStripMenuItem.Click += new System.EventHandler(this.selectBorderSizeToolStripMenuItem_Click);
            // 
            // thinToolStripMenuItem
            // 
            this.thinToolStripMenuItem.Name = "thinToolStripMenuItem";
            this.thinToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.thinToolStripMenuItem.Text = "Thin";
            this.thinToolStripMenuItem.Click += new System.EventHandler(this.thinToolStripMenuItem_Click);
            // 
            // mediumToolStripMenuItem1
            // 
            this.mediumToolStripMenuItem1.Name = "mediumToolStripMenuItem1";
            this.mediumToolStripMenuItem1.Size = new System.Drawing.Size(166, 22);
            this.mediumToolStripMenuItem1.Text = "Medium";
            this.mediumToolStripMenuItem1.Click += new System.EventHandler(this.mediumToolStripMenuItem1_Click);
            // 
            // thickToolStripMenuItem
            // 
            this.thickToolStripMenuItem.Name = "thickToolStripMenuItem";
            this.thickToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.thickToolStripMenuItem.Text = "Thick";
            this.thickToolStripMenuItem.Click += new System.EventHandler(this.thickToolStripMenuItem_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.halfSizeSmallerToolStripMenuItem,
            this.quarterSizeSmallerToolStripMenuItem,
            this.quarterSizeBiggerToolStripMenuItem,
            this.halfSizeBiggerToolStripMenuItem,
            this.doubleSizeBiggerToolStripMenuItem});
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(33, 24);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // halfSizeSmallerToolStripMenuItem
            // 
            this.halfSizeSmallerToolStripMenuItem.Name = "halfSizeSmallerToolStripMenuItem";
            this.halfSizeSmallerToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.halfSizeSmallerToolStripMenuItem.Text = "half size smaller";
            this.halfSizeSmallerToolStripMenuItem.Click += new System.EventHandler(this.halfSizeSmallerToolStripMenuItem_Click);
            // 
            // quarterSizeSmallerToolStripMenuItem
            // 
            this.quarterSizeSmallerToolStripMenuItem.Name = "quarterSizeSmallerToolStripMenuItem";
            this.quarterSizeSmallerToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.quarterSizeSmallerToolStripMenuItem.Text = "quarter size smaller";
            this.quarterSizeSmallerToolStripMenuItem.Click += new System.EventHandler(this.quarterSizeSmallerToolStripMenuItem_Click);
            // 
            // quarterSizeBiggerToolStripMenuItem
            // 
            this.quarterSizeBiggerToolStripMenuItem.Name = "quarterSizeBiggerToolStripMenuItem";
            this.quarterSizeBiggerToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.quarterSizeBiggerToolStripMenuItem.Text = "quarter size bigger";
            this.quarterSizeBiggerToolStripMenuItem.Click += new System.EventHandler(this.quarterSizeBiggerToolStripMenuItem_Click);
            // 
            // halfSizeBiggerToolStripMenuItem
            // 
            this.halfSizeBiggerToolStripMenuItem.Name = "halfSizeBiggerToolStripMenuItem";
            this.halfSizeBiggerToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.halfSizeBiggerToolStripMenuItem.Text = "half size bigger";
            this.halfSizeBiggerToolStripMenuItem.Click += new System.EventHandler(this.halfSizeBiggerToolStripMenuItem_Click);
            // 
            // doubleSizeBiggerToolStripMenuItem
            // 
            this.doubleSizeBiggerToolStripMenuItem.Name = "doubleSizeBiggerToolStripMenuItem";
            this.doubleSizeBiggerToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.doubleSizeBiggerToolStripMenuItem.Text = "double size bigger";
            this.doubleSizeBiggerToolStripMenuItem.Click += new System.EventHandler(this.doubleSizeBiggerToolStripMenuItem_Click);
            // 
            // selectRotationValueToolStripMenuItem
            // 
            this.selectRotationValueToolStripMenuItem.Name = "selectRotationValueToolStripMenuItem";
            this.selectRotationValueToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(32, 19);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(32, 19);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(32, 19);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(32, 19);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(32, 19);
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(32, 19);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(744, 24);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(56, 24);
            this.button1.TabIndex = 5;
            this.button1.Text = "Delete";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(684, 24);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(56, 24);
            this.button2.TabIndex = 6;
            this.button2.Text = "Copy";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(908, 24);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(55, 25);
            this.button3.TabIndex = 7;
            this.button3.Text = "Name";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(804, 24);
            this.nameTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(100, 20);
            this.nameTextBox.TabIndex = 8;
            this.nameTextBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textBoxString
            // 
            this.textBoxString.Location = new System.Drawing.Point(968, 24);
            this.textBoxString.Name = "textBoxString";
            this.textBoxString.Size = new System.Drawing.Size(100, 20);
            this.textBoxString.TabIndex = 9;
            // 
            // btnAddString
            // 
            this.btnAddString.Location = new System.Drawing.Point(1074, 24);
            this.btnAddString.Name = "btnAddString";
            this.btnAddString.Size = new System.Drawing.Size(75, 23);
            this.btnAddString.TabIndex = 10;
            this.btnAddString.Text = "Add Text";
            this.btnAddString.UseVisualStyleBackColor = true;
            this.btnAddString.Click += new System.EventHandler(this.btnAddString_Click);
            // 
            // transparencyTrackBar
            // 
            this.transparencyTrackBar.Location = new System.Drawing.Point(422, 24);
            this.transparencyTrackBar.Name = "transparencyTrackBar";
            this.transparencyTrackBar.Size = new System.Drawing.Size(102, 45);
            this.transparencyTrackBar.TabIndex = 11;
            this.transparencyTrackBar.Tag = "";
            this.transparencyTrackBar.Scroll += new System.EventHandler(this.transparencyTrackBar_Scroll);
            // 
            // rotateTrackBar
            // 
            this.rotateTrackBar.AccessibleName = "";
            this.rotateTrackBar.Location = new System.Drawing.Point(530, 24);
            this.rotateTrackBar.Name = "rotateTrackBar";
            this.rotateTrackBar.Size = new System.Drawing.Size(104, 45);
            this.rotateTrackBar.TabIndex = 12;
            this.rotateTrackBar.Scroll += new System.EventHandler(this.rotateTrackBar_Scroll);
            // 
            // viewPort
            // 
            this.viewPort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewPort.Location = new System.Drawing.Point(0, 51);
            this.viewPort.Margin = new System.Windows.Forms.Padding(4);
            this.viewPort.Name = "viewPort";
            this.viewPort.Size = new System.Drawing.Size(1385, 508);
            this.viewPort.TabIndex = 4;
            this.viewPort.Load += new System.EventHandler(this.viewPort_Load);
            this.viewPort.Paint += new System.Windows.Forms.PaintEventHandler(this.ViewPortPaint);
            this.viewPort.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ViewPortMouseDown);
            this.viewPort.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ViewPortMouseMove);
            this.viewPort.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ViewPortMouseUp);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1385, 581);
            this.Controls.Add(this.rotateTrackBar);
            this.Controls.Add(this.transparencyTrackBar);
            this.Controls.Add(this.btnAddString);
            this.Controls.Add(this.textBoxString);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.viewPort);
            this.Controls.Add(this.speedMenu);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.mainMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mainMenu;
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
            ((System.ComponentModel.ISupportInitialize)(this.transparencyTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rotateTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		
		private System.Windows.Forms.ToolStripStatusLabel currentStatusLabel;
		private Draw.DoubleBufferedPanel viewPort;
		private System.Windows.Forms.ToolStripButton pickUpSpeedButton;
		private System.Windows.Forms.ToolStripButton drawRectangleSpeedButton;
		private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStrip speedMenu;
		private System.Windows.Forms.StatusStrip statusBar;
		private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripButton drawEllipseSpeedButton;
        private System.Windows.Forms.ToolStripButton drawCircleSpeedButton;
        private System.Windows.Forms.ToolStripButton drawTriangleSpeedButton;
        private System.Windows.Forms.ToolStripButton drawLineSpeedButton;
        private System.Windows.Forms.ToolStripButton drawDotSpeedButton;
        private System.Windows.Forms.ToolStripButton drawSquareSpeedButton;
        private System.Windows.Forms.ToolStripButton drawPentagonSpeedButton;
        private System.Windows.Forms.ToolStripButton drawHexagonShape;
        private System.Windows.Forms.ToolStripButton drawStarSpeedButton;
        private System.Windows.Forms.ToolStripButton ickBorderColorButton;
        private System.Windows.Forms.ToolStripButton pickFillColorButton;
        private System.Windows.Forms.ToolStripDropDownButton borderSizeButton;
        private System.Windows.Forms.ToolStripMenuItem selectBorderSizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thinToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mediumToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem thickToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectRotationValueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem8;
        private System.Windows.Forms.ToolStripDropDownButton toolStripButton1;
        private System.Windows.Forms.ToolStripMenuItem quarterSizeSmallerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem halfSizeSmallerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quarterSizeBiggerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem halfSizeBiggerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem doubleSizeBiggerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeBackgroundColorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imageToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem insertImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setImageAsBackgroundToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeBackgroundImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.ToolStripMenuItem setColorByObjectNameToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.TextBox textBoxString;
        private System.Windows.Forms.Button btnAddString;
        private System.Windows.Forms.ToolStripMenuItem goupShapesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ungroupShapesToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton heartShapeButton;
        private System.Windows.Forms.TrackBar transparencyTrackBar;
        private System.Windows.Forms.TrackBar rotateTrackBar;
    }
}
