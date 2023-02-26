using System;
using System.Drawing;

namespace Draw
{
    public class HexagonShape : Shape
    {
        #region Constructor

        public HexagonShape(RectangleF rect) : base(rect)
        {
        }

        public HexagonShape(HexagonShape hex) : base(hex)
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

            PointF[] points = { new PointF(Rectangle.X, Rectangle.Y), 
                                new PointF(Rectangle.X + Rectangle.Width/4, Rectangle.Y-Rectangle.Height/2),
                                new PointF(Rectangle.X + (Rectangle.Width/4)*3, Rectangle.Y-Rectangle.Height/2),
                                new PointF(Rectangle.X + Rectangle.Width, Rectangle.Y),
                                new PointF(Rectangle.X + (Rectangle.Width/4)*3, Rectangle.Y+Rectangle.Height/2),
                                new PointF(Rectangle.X + Rectangle.Width/4, Rectangle.Y+Rectangle.Height/2) };

            grfx.FillPolygon(new SolidBrush(Color.FromArgb(Transparency, FillColor)), points);
            grfx.DrawPolygon(new Pen(Color.FromArgb(Transparency, BorderColor)), points);

        }
    }
}
