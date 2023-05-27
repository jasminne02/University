using System;
using System.Drawing;

namespace Draw
{
    [Serializable]
    public class CircleShape : Shape
    {
        #region Constructor

        public CircleShape(RectangleF rect) : base(rect)
        {
        }

        public CircleShape(CircleShape circle) : base(circle)
        {
        }

        #endregion

        public override bool Contains(PointF point)
        {
            // (x-h)^2/a^2 + (y-k)^2/b^2 <= 1
            float a = Rectangle.Width / 2;
            float b = Rectangle.Height / 2;
            float h = Location.X + a;
            float k = Location.Y + b;

            if (Math.Pow((point.X - h), 2) / Math.Pow(a, 2) + Math.Pow((point.Y - k), 2) / Math.Pow(b, 2) <= 1)
                return true;
            else
                return false;
        }

        public override void DrawSelf(Graphics grfx)
        {
            base.DrawSelf(grfx);

            grfx.FillEllipse(new SolidBrush(Color.FromArgb(Transparency, FillColor)), 
                              Rectangle.X, Rectangle.Y, Rectangle.Width, Rectangle.Height);
            grfx.DrawEllipse(new Pen(Color.FromArgb(Transparency, BorderColor), BorderSize), 
                              Rectangle.X, Rectangle.Y, Rectangle.Width, Rectangle.Height);

        }
    }
}
