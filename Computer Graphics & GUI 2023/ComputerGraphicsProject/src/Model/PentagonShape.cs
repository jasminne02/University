using System;
using System.Drawing;

namespace Draw
{
    [Serializable]
    public class PentagonShape : Shape
    {
        private PointF[] points = new PointF[5];

        public PentagonShape(RectangleF rect) : base(rect)
        {
        }

        public PentagonShape(PentagonShape pentagon) : base(pentagon)
        {
        }

        public override bool Contains(PointF point)
        {
            PointF pt = new PointF(9999, point.Y);
            int count = 0;

            for (int i = 0; i < 5; i++)
            {
                line side = new line(points[i], points[(i + 1) % 5]);
                if (isIntersect(side.p1, side.p2, point, pt))
                {
                    if (direction(side.p1, point, side.p2) == 0)
                        return isOnLine(side.p1, side.p2, point);
                    count++;
                }
            }

            return count % 2 != 0;
        }

        public override void DrawSelf(Graphics grfx)
        {
            base.DrawSelf(grfx);
            base.RotateShape(grfx);

            float halfWidth = Rectangle.Width / 2;
            float halfHeight = Rectangle.Height / 2;
            float quarterWidth = Rectangle.Width / 4;

            points[0] = new PointF(Rectangle.X, Rectangle.Y);
            points[1] = new PointF(Rectangle.X + halfWidth, Rectangle.Y - halfHeight);
            points[2] = new PointF(Rectangle.X + Rectangle.Width, Rectangle.Y);
            points[3] = new PointF(Rectangle.X + (quarterWidth * 3), Rectangle.Y + halfHeight);
            points[4] = new PointF(Rectangle.X + quarterWidth, Rectangle.Y + halfHeight);

            grfx.FillPolygon(new SolidBrush(Color.FromArgb(Transparency, FillColor)), points);
            grfx.DrawPolygon(new Pen(Color.FromArgb(Transparency, BorderColor), BorderSize), points);
        }
    }
}
