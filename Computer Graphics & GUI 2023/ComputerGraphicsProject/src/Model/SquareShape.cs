using System;
using System.Drawing;

namespace Draw
{

    public class SquareShape : Shape
    {
        #region Constructor

        public SquareShape(RectangleF rect) : base(rect)
        {
        }

        public SquareShape(SquareShape square) : base(square)
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

            grfx.FillRectangle(new SolidBrush(Color.FromArgb(Transparency, FillColor)), 
                                Rectangle.X, Rectangle.Y, Rectangle.Width, Rectangle.Height);
            grfx.DrawRectangle(new Pen(Color.FromArgb(Transparency, BorderColor), BorderSize), 
                                Rectangle.X, Rectangle.Y, Rectangle.Width, Rectangle.Height);

        }
    }
}
