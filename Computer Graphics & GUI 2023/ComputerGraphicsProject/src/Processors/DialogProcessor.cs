using System;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Windows.Forms;
using System.Collections.Generic;
using Draw.src.Model;

namespace Draw
{
	/// <summary>
	/// Класът, който ще бъде използван при управляване на диалога.
	/// </summary>
	public class DialogProcessor : DisplayProcessor
	{
		#region Constructor
		
		public DialogProcessor()
		{
            Selection = new List<Shape>();
        }
		
		#endregion
		
		#region Properties
		
		/// <summary>
		/// Избран елемент.
		/// </summary>
		
        private List<Shape> selection;
        public List<Shape> Selection { get { return selection; } set { selection = value; } }
        


        /// <summary>
        /// Дали в момента диалога е в състояние на "влачене" на избрания елемент.
        /// </summary>
        private bool isDragging;
		public bool IsDragging {
			get { return isDragging; }
			set { isDragging = value; }
		}
		
		/// <summary>
		/// Последна позиция на мишката при "влачене".
		/// Използва се за определяне на вектора на транслация.
		/// </summary>
		private PointF lastLocation;
		public PointF LastLocation {
			get { return lastLocation; }
			set { lastLocation = value; }
		}
		
		#endregion
		
		/// <summary>
		/// Добавя примитив - правоъгълник на произволно място върху клиентската област.
		/// </summary>
		public void AddRandomRectangle()
		{
			Random rnd = new Random();
			int x = rnd.Next(100,1000);
			int y = rnd.Next(100,600);
			
			RectangleShape rect = new RectangleShape(new Rectangle(x,y,100,200));
			rect.FillColor = Color.White;

			ShapeList.Add(rect);
		}

        public void AddRandomSquare()
        {
            Random rnd = new Random();
            int x = rnd.Next(100, 1000);
            int y = rnd.Next(100, 600);

            SquareShape square = new SquareShape(new Rectangle(x, y, 100, 100));
			square.FillColor = Color.White;

            ShapeList.Add(square);
        }

        public void AddRandomEllipse()
        {
            Random rnd = new Random();
            int x = rnd.Next(100, 1000);
            int y = rnd.Next(100, 600);

            EllipseShape ellipse = new EllipseShape(new Rectangle(x, y, 200, 100));
            ellipse.FillColor = Color.White;

            ShapeList.Add(ellipse);
        }

        public void AddRandomCircle()
        {
            Random rnd = new Random();
            int x = rnd.Next(100, 1000);
            int y = rnd.Next(100, 500);

            CircleShape circle = new CircleShape(new Rectangle(x, y, 100, 100));
            circle.FillColor = Color.White;

            ShapeList.Add(circle);
        }

        public void AddRandomTriangle()
        {
            Random rnd = new Random();
            int x = rnd.Next(100, 1000);
            int y = rnd.Next(100, 600);

            TriangleShape triangle = new TriangleShape(new Rectangle(x, y, 100, 100));
            triangle.FillColor = Color.White;

            ShapeList.Add(triangle);
        }

        public void AddRandomLine()
        {
            Random rnd = new Random();
            int x = rnd.Next(100, 1000);
            int y = rnd.Next(100, 600);

            LineShape line = new LineShape(new Rectangle(x, y, x, y));
            line.FillColor = Color.White;

            ShapeList.Add(line);
        }

        public void AddRandomDot()
        {
            Random rnd = new Random();
            int x = rnd.Next(100, 1000);
            int y = rnd.Next(100, 600);

            DotShape dot = new DotShape(new Rectangle(x, y, 10, 10));

            ShapeList.Add(dot);
        }

        public void AddRandomPentagon()
        {
            Random rnd = new Random();
            int x = rnd.Next(100, 1000);
            int y = rnd.Next(100, 600);

            PentagonShape pentagon = new PentagonShape(new Rectangle(x, y, 100, 90));
            pentagon.FillColor = Color.White;

            ShapeList.Add(pentagon);
        }
  
        public void AddRandomHexagon()
        {
            Random rnd = new Random();
            int x = rnd.Next(100, 1000);
            int y = rnd.Next(100, 600);

            HexagonShape hex = new HexagonShape(new Rectangle(x, y, 100, 90));
            hex.FillColor = Color.White;

            ShapeList.Add(hex);
        }

        public void AddRandomStar()
        {
            Random rnd = new Random();
            int x = rnd.Next(100, 1000);
            int y = rnd.Next(100, 600);

            StarShape star = new StarShape(new Rectangle(x, y, 150, 90));
            star.FillColor = Color.White;

            ShapeList.Add(star);
        }
        public void AddRandomString(string text)
        {
            Random rnd = new Random();
            int x = rnd.Next(100, 1000);
            int y = rnd.Next(100, 600);

            SizeF stringSize = new SizeF();
            stringSize = TextRenderer.MeasureText(text, new Font("Arial", 16));

            StringShape stringShape = new StringShape(new Rectangle(x, y, (int)stringSize.Width, (int)stringSize.Height));
            stringShape.Text = text;
            stringShape.FillColor = Color.Black;
            stringShape.Transparency = 255;

            ShapeList.Add(stringShape);
        }
        public void AddRandomHeart()
        {
          
            Random rnd = new Random();
            int x = rnd.Next(100, 1000);
            int y = rnd.Next(100, 600);
            HeartShape heartShape = new HeartShape(new Rectangle(x, y, 200, 150));
            heartShape.FillColor = Color.White;

            ShapeList.Add(heartShape);
        }
            public void GroupShapes()
        {
            if (selection.Count > 1)
            {
                double minX = selection[0].Rectangle.Left;
                double minY = selection[0].Rectangle.Top;
                double maxX = selection[0].Rectangle.Right;
                double maxY = selection[0].Rectangle.Bottom;

                for (int i = 1; i < selection.Count; i++)
                {
                    RectangleF bounds = selection[i].Rectangle;

                    if (bounds.Left < minX)
                        minX = bounds.Left;
                    if (bounds.Top < minY)
                        minY = bounds.Top;
                    if (bounds.Right > maxX)
                        maxX = bounds.Right;
                    if (bounds.Bottom > maxY)
                        maxY = bounds.Bottom;
                }

                RectangleF groupBounds = new RectangleF((float)minX, (float)minY, (float)(maxX - minX), (float)(maxY - minY));

                GroupShape groupShape = new GroupShape(groupBounds);
                groupShape.Shapes.AddRange(selection);

                // Изчиства ShapeList RemoveAll()
                ShapeList.RemoveAll(shape => selection.Contains(shape));

                // Адва нова група groupShape
                ShapeList.Add(groupShape);

                
                selection.Clear();
                selection.Add(groupShape);
            }
        }

        public void UngroupShapes()
        {
            List<Shape> ungroupedShapes = new List<Shape>();

            foreach (Shape shape in selection)
            {
                if (shape is GroupShape groupShape)
                {
                    // Изчиства елементите от списъка
                    ShapeList.Remove(groupShape);

                    // Добавя всеки инвидуален елемент към листа
                    foreach (Shape individualShape in groupShape.Shapes)
                    {
                        ShapeList.Add(individualShape);
                        ungroupedShapes.Add(individualShape);
                    }
                }
            }

            // Изчиства селекцията и адва елементите към selection
            selection.Clear();
            selection.AddRange(ungroupedShapes);
        }

        // <summary>
        // променя цвета на очертанията на избрания примтив
        // </summary>
        public void setBorderColor(Color color)
        {
            foreach (Shape item in Selection)
            {
                item.BorderColor = color;
            }
        }

        // <summary>
        // променя цвета заплъващ избрания примтив
        // </summary>
        public void setFillColor(Color color)
        {
            foreach (Shape item in Selection)
            {
                item.FillColor = color;
            }
        }

        // <summary>
        // променя прозрачността на избрания примтив
        // </summary>
        public void setTransparencyLevel(int transparency)
        {
            foreach (Shape item in Selection)
            {
                if (item.GetType() == typeof(ImageShape))
                {
                    MessageBox.Show("Image's transparency cannot be changed", "Image info",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    item.GroupTransparency(transparency);
                    item.Transparency = transparency;
                }
            }
        }


        //<summary>
        //променя дебелината на очертанието на избрания примитив
        //</summary>
        public void setBorderSizeLevel(int borderSize)
        {
            foreach (Shape item in Selection)
            {
                if (item.GetType() == typeof(ImageShape))
                {
                    MessageBox.Show("Image's border cannot be changed", "Image info",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    item.GroupBorderSize(borderSize);
                    item.BorderSize = borderSize;
                }
            }
        }


        public void RotatePrimitive(float angle)
        {
            foreach (Shape item in Selection)
            {
                if (item.GetType() == typeof(ImageShape))
                {
                    MessageBox.Show("Image cannot be rotated", "Image info",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    item.Angle = angle;
                    item.GroupRotate(angle);
                }
            }
        }

        public void ResizePrimitive(float size)
        {
            foreach (Shape item in Selection)
            {
                if (item.Size > 0 && size == 1)
                {
                    
                    item.Height /= item.Size;
                    item.Width /= item.Size;
                    item.Size = 0;
                    item.GroupSize(size);
                }
                else
                {
                    float newSize = size;

                    item.Height *= newSize;
                    item.Width *= newSize;
                    item.Size += newSize;
                    item.GroupSize(size);
                }
            }
        }



        public void SetBackground()
        {
            Bitmap image = chooseImage();
            if (image != null)
            {
                Background.Image = image;
            }
        }

        public void SetImage()
        {
            Bitmap image = chooseImage();
            if (image != null)
            {
                Random rnd = new Random();
                int x = rnd.Next(100, 1000);
                int y = rnd.Next(100, 600);

                ImageShape rect = new ImageShape(image, new Rectangle(x, y, image.Width/2, image.Height/2));

                ShapeList.Add(rect);
            }
        }

        public void ChangeBackgroundColor(Color color)
        {
            if(Background.Image != null)
            {
                MessageBox.Show("Remove background image to set color", "Background info", MessageBoxButtons.OK, 
                    MessageBoxIcon.Information);
            }

            Background.Color = color;

        }

        public void RemoveBackgroundImage()
        {
            Background.Image = null;
        }

        public void ClearAll()
        {
            Background.Color = Color.White;
            Background.Image = null;
            ShapeList.Clear();
        }

        public void DeleteSelected()
        {
            foreach (Shape item in Selection)
            {
                ShapeList.Remove(item);
            }
        }

        public void NameSelectedShape(string name)
        {
            foreach (Shape item in Selection)
            {
                if (isSelected())
                {
                    item.Name = name;
                }
            }
        }
        public void ColorObjectName(string name, Color color)
        {
            Shape shape = getShapeByName(name);

            if (shape != null)
            {
                shape.FillColor = color;
            } else
            {
                MessageBox.Show("Object with such a name does not exist!", "Object issue", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void CopySelected()
        {
            Shape copy;

            Random rnd = new Random();
            int x = rnd.Next(100, 1000);
            int y = rnd.Next(100, 600);
            foreach (Shape item in Selection)
            {
                if (item.GetType() == typeof(CircleShape))
                {
                    copy = new CircleShape(new Rectangle(x, y, 100, 100));
                }
                else if (item.GetType() == typeof(DotShape))
                {
                    copy = new DotShape(new Rectangle(x, y, 100, 100));
                }
                else if (item.GetType() == typeof(EllipseShape))
                {
                    copy = new EllipseShape(new Rectangle(x, y, 100, 100));
                }
                else if (item.GetType() == typeof(HexagonShape))
                {
                    copy = new HexagonShape(new Rectangle(x, y, 100, 100));
                }
                else if (item.GetType() == typeof(ImageShape))
                {
                    copy = new ImageShape(((ImageShape)item).Image, new Rectangle(x, y, 100, 100));
                }
                else if (item.GetType() == typeof(LineShape))
                {
                    copy = new LineShape(new Rectangle(x, y, 100, 100));
                }
                else if (item.GetType() == typeof(PentagonShape))
                {
                    copy = new PentagonShape(new Rectangle(x, y, 100, 100));
                }
                else if (item.GetType() == typeof(RectangleShape))
                {
                    copy = new RectangleShape(new Rectangle(x, y, 100, 100));
                }
                else if (item.GetType() == typeof(StarShape))
                {
                    copy = new StarShape(new Rectangle(x, y, 100, 100));
                }
                else
                {
                    copy = new TriangleShape(new Rectangle(x, y, 100, 100));
                }

                copy.Height = item.Height;
                copy.Width = item.Width;
                copy.Rectangle = item.Rectangle;
                copy.FillColor = item.FillColor;
                copy.BorderColor = item.BorderColor;
                copy.Transparency = item.Transparency;
                copy.BorderSize = item.BorderSize;
                copy.Angle = item.Angle;
                copy.Size = item.Size;

                ShapeList.Add(copy);
            }
        }
        public void MySerialize(object obj, string filePath = null)
        {
            if (Background.Image != null)
            {
                ShapeList.Insert(0, new BackgroundSerializable(Background.Image));
            } else
            {
                ShapeList.Insert(0, new BackgroundSerializable((Background.Color)));
            }

            IFormatter formatter = new BinaryFormatter();
            Stream stream;
            if (filePath != null)
            {
                stream = new FileStream(filePath + ".drw", FileMode.Create);
            }
            else
            {
                stream = new FileStream("MyFile.drw", FileMode.Create, FileAccess.Write, FileShare.None);
            }
            formatter.Serialize(stream, obj);
            stream.Close();
        }

        public object MyDeSerialize(string filePath = null)
        {
            object obj;
            IFormatter formatter = new BinaryFormatter();
            Stream stream;
            if (filePath != null)
            {
                stream = new FileStream(filePath,
                                     FileMode.Open,
                                     FileAccess.Read, FileShare.None);
            }
            else
            {
                stream = new FileStream("MyFile.drw",
                                    FileMode.Open);
            }
            obj = formatter.Deserialize(stream);
            stream.Close();
            return obj;
        }

        /// <summary>
        /// Проверява дали дадена точка е в елемента.
        /// Обхожда в ред обратен на визуализацията с цел намиране на
        /// "най-горния" елемент т.е. този който виждаме под мишката.
        /// </summary>
        /// <param name="point">Указана точка</param>
        /// <returns>Елемента на изображението, на който принадлежи дадената точка.</returns>
        public Shape ContainsPoint(PointF point)
		{
			for(int i = ShapeList.Count - 1; i >= 0; i--){
				if (ShapeList[i].Contains(point)){						
					return ShapeList[i];
				}	
			}
			return null;
		}

        /// <summary>
        /// Транслация на избраният елемент на вектор определен от <paramref name="p>p</paramref>
        /// </summary>
        /// <param name="p">Вектор на транслация.</param>
        public void TranslateTo(PointF p)
        {
            if (Selection != null)
            {
                float diffX = p.X - lastLocation.X;
                float diffY = p.Y - lastLocation.Y;

                foreach (Shape item in Selection)
                {
                    item.Location = new PointF(item.Location.X + diffX, item.Location.Y + diffY);
                }

                lastLocation = p;
            }
        }

        private bool isSelected()
        {
            // checks if a shape is selected
            if (selection != null)
                return true;

            MessageBox.Show("Please select an element!", "Selection issue", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        private Shape getShapeByName(string name)
        {
            foreach (Shape shape in ShapeList)
            {
                if(shape.Name == name) return shape;
            }
            return null;
        }

        private Bitmap chooseImage()
        {
            // open file dialog   
            OpenFileDialog open = new OpenFileDialog();
            // image filters  
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png";

            if (open.ShowDialog() == DialogResult.OK)
            {
                return new Bitmap(open.FileName);
            }

            return null;
        }
	}
}
 