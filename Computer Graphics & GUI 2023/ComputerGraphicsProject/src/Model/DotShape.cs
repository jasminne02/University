using System;
using System.Drawing;

namespace Draw
{
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
            if (base.Contains(point))
                return true;
            else
                return false;
        }

        public override void DrawSelf(Graphics grfx)
        {
            base.DrawSelf(grfx);

            grfx.FillEllipse(new SolidBrush(Color.FromArgb(Transparency, BorderColor)), 
                              Rectangle.X, Rectangle.Y, Rectangle.Width, Rectangle.Height);
            grfx.DrawEllipse(new Pen(Color.FromArgb(Transparency, BorderColor), BorderSize), 
                              Rectangle.X, Rectangle.Y, Rectangle.Width, Rectangle.Height);

        }
    }
}
