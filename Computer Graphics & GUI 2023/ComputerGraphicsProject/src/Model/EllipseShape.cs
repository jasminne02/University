using System;
using System.Drawing;

namespace Draw
{
    public class EllipseShape : Shape
    {
        #region Constructor

        public EllipseShape(RectangleF rect) : base(rect)
        {
        }

        public EllipseShape(EllipseShape ellipse) : base(ellipse)
        {
        }

        #endregion

        public override bool Contains(PointF point)
        {
            if (base.Contains(point))
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
