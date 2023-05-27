using System;
using System.Drawing;

namespace Draw
{
    [Serializable]

    public class DotShape : Shape
    {
        #region Constructor

        public DotShape(RectangleF rect) : base(rect)
        {
        }

        public DotShape(DotShape dot) : base(dot)
        {
        }

        #endregion

        public override bool Contains(PointF point)
        {
            float a = Rectangle.Width / 2;
            float b = Rectangle.Height / 2;
            float h = Location.X + a;
            float k = Location.Y + b;

            return ((point.X - h) * (point.X - h) / (a * a)) + ((point.Y - k) * (point.Y - k) / (b * b)) <= 1;
        }


        public override void DrawSelf(Graphics grfx)
        {
            base.DrawSelf(grfx);
            base.RotateShape(grfx);

            grfx.FillEllipse(new SolidBrush(Color.FromArgb(Transparency, BorderColor)), 
                              Rectangle.X, Rectangle.Y, Rectangle.Width, Rectangle.Height);
            grfx.DrawEllipse(new Pen(Color.FromArgb(Transparency, BorderColor), BorderSize), 
                              Rectangle.X, Rectangle.Y, Rectangle.Width, Rectangle.Height);

        }
    }
}
