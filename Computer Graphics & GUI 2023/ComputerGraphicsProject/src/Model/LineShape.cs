using System;
using System.Drawing;

namespace Draw
{

    public class LineShape : Shape
    {
        #region Constructor

        public LineShape(RectangleF rect) : base(rect)
        {
        }

        public LineShape(LineShape line) : base(line)
        {
        }

        #endregion

        public override bool Contains(PointF point)
        {
            if (point.X >= Rectangle.X && point.Y == Rectangle.Y && point.X <= Rectangle.X + Rectangle.Width)
                return true;
            else
                return false;
        }

        public override void DrawSelf(Graphics grfx)
        {
            base.DrawSelf(grfx);

            PointF[] points = { new PointF(Rectangle.X, Rectangle.Y), new PointF(Rectangle.X+Rectangle.Width, Rectangle.Y) };

            grfx.FillPolygon(new SolidBrush(Color.FromArgb(Transparency, BorderColor)), points);
            grfx.DrawPolygon(new Pen(Color.FromArgb(Transparency, BorderColor), BorderSize), points);

        }
    }
}
