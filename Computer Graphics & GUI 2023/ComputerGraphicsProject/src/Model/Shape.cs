using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Draw
{
    /// <summary>
    /// Базовия клас на примитивите, който съдържа общите характеристики на примитивите.
    /// </summary>

    [Serializable]
    public abstract class Shape
	{
		#region Constructors
		
		public Shape()
		{
		}
		
		public Shape(RectangleF rect)
		{
			rectangle = rect;
		}
		
		public Shape(Shape shape)
		{
			this.Height = shape.Height;
			this.Width = shape.Width;
			this.Location = shape.Location;
			this.rectangle = shape.rectangle;
			
			this.FillColor =  shape.FillColor;
			this.BorderColor = shape.BorderColor;
			this.transparency = shape.transparency;
			this.borderSize = shape.borderSize;
			this.angle = shape.angle;
			this.size = shape.size;
		}
		#endregion
		
		#region Properties
		
		/// <summary>
		/// Обхващащ правоъгълник на елемента.
		/// </summary>
		private RectangleF rectangle;		
		public virtual RectangleF Rectangle {
			get { return rectangle; }
			set { rectangle = value; }
		}
		
		/// <summary>
		/// Широчина на елемента.
		/// </summary>
		public virtual float Width {
			get { return Rectangle.Width; }
			set { rectangle.Width = value; }
		}
		
		/// <summary>
		/// Височина на елемента.
		/// </summary>
		public virtual float Height {
			get { return Rectangle.Height; }
			set { rectangle.Height = value; }
		}
		
		/// <summary>
		/// Горен ляв ъгъл на елемента.
		/// </summary>
		public virtual PointF Location {
			get { return Rectangle.Location; }
			set { rectangle.Location = value; }
		}
		
		/// <summary>
		/// Цвят на елемента.
		/// </summary>
		private Color fillColor;		
		public virtual Color FillColor {
			get { return fillColor; }
			set { fillColor = value; }
		}

		private Color borderColor = Color.Black; // borderColor е черен по подразбиране
		public virtual Color BorderColor
		{
			get { return borderColor; }
			set { borderColor = value; }
		}

		private int transparency = 255; // няма никаква прозрачност по подразбиране
		public int Transparency
        {
			get { return transparency; }
			set { transparency = value; }
		}
        private string text;
        public virtual string Text
        {
            get { return text; }
            set { text = value; }
        }

        private int borderSize = 1;
		public int BorderSize
		{
			get { return borderSize; }
			set { borderSize = value; }
		}

		private float angle = 0;
        public virtual float Angle
        {
            get { return angle; }
            set { angle = value; }
        }

        private float size = 0;
        public virtual float Size
        {
            get { return size; }
            set { size = value; }
        }

        private string name;
        public virtual string Name
        {
            get { return name; }
            set { name = value; }
        }

        #endregion


        /// <summary>
        /// Проверка дали точка point принадлежи на елемента.
        /// </summary>
        /// <param name="point">Точка</param>
        /// <returns>Връща true, ако точката принадлежи на елемента и
        /// false, ако не пренадлежи</returns>
        public virtual bool Contains(PointF point)
		{
			return Rectangle.Contains(point.X, point.Y);
		}
		
		/// <summary>
		/// Визуализира елемента.
		/// </summary>
		/// <param name="grfx">Къде да бъде визуализиран елемента.</param>
		public virtual void DrawSelf(Graphics grfx)
		{
			// shape.Rectangle.Inflate(shape.BorderWidth, shape.BorderWidth);
		}

        public virtual void RotateShape(Graphics grfx)
        {
			grfx.ResetTransform();
            grfx.TranslateTransform(Rectangle.X + Rectangle.Width / 2, Rectangle.Y + Rectangle.Height / 2);
            grfx.RotateTransform(Angle);
            grfx.TranslateTransform(-(Rectangle.X + Rectangle.Width / 2), -(Rectangle.Y + Rectangle.Height / 2));
        }

        public static bool isOnLine(PointF a, PointF b, PointF point)
        {
            if (point.X <= Math.Max(a.X, b.X)
                 && point.X <= Math.Min(a.X, b.X)
                 && (point.Y <= Math.Max(a.Y, b.Y)
                 && point.Y <= Math.Min(a.Y, b.Y)))
                return true;

            return false;
        }

        public static int direction(PointF a, PointF b, PointF c)
        {
            int val = (int)((b.Y - a.Y) * (c.X - b.X) - (b.X - a.X) * (c.Y - b.Y));

            if (val == 0)
                return 0;

            else if (val < 0)
                return 2;

            return 1;
        }

        public static bool isIntersect(PointF x1, PointF y1, PointF x2, PointF y2)
        {
            int dir1 = direction(x1, y1, x2);
            int dir2 = direction(x1, y1, y2);
            int dir3 = direction(x2, y2, x1);
            int dir4 = direction(x2, y2, y1);

            if (dir1 != dir2 && dir3 != dir4)
                return true;

            if (dir1 == 0 && isOnLine(x1, y1, x2))
                return true;

            if (dir2 == 0 && isOnLine(x1, y1, y2))
                return true;

            if (dir3 == 0 && isOnLine(x2, y2, x1))
                return true;

            if (dir4 == 0 && isOnLine(x2, y2, y1))
                return true;

            return false;
        }
        public virtual void Move(float dx, float dy)
        {
            Location = new PointF(Location.X + dx, Location.Y + dy);

        }

        public virtual void GroupTransparency(int transparency)
        {
            this.transparency = transparency;
        }

        public virtual void GroupRotate(float angle)
        {
            this.Angle = angle;
        }
        public virtual void GroupBorderSize(int borderSize) 
        {
            this.borderSize = borderSize;
        }
        public virtual void GroupSize(float size)
        {
            this.Size = size;
        }


    }

    class line
    {
        public PointF p1, p2;
        public line(PointF p1, PointF p2)
        {
            this.p1 = p1;
            this.p2 = p2;
        }
    }

}
