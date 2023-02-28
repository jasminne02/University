using System;
using System.Drawing;

namespace Draw
{
    public class StarShape : Shape
    {
        private PointF[] points = new PointF[10];

        #region Constructor

        public StarShape(RectangleF rect) : base(rect) 
        {
        }

        public StarShape(StarShape star) : base(star)
        {
        }

        #endregion

        public override bool Contains(PointF point)
        {
            PointF pt = new PointF(9999, point.Y);
            int count = 0;
            int i = 0;

            do
            {
                line side = new line(points[i], points[(i + 1) % 10]);
                if (isIntersect(side.p1, side.p2, point, pt))
                {
                    if (direction(side.p1, point, side.p2) == 0)
                        return isOnLine(side.p1, side.p2, point);
                    count++;
                }
                i = (i + 1) % 10;
            } while (i != 0);

            if (count % 2 != 0)
                return true;
            else
                return false;
        }

        public override void DrawSelf(Graphics grfx)
        {
            base.DrawSelf(grfx);

            points[0] = new PointF(Rectangle.X, Rectangle.Y);
            points[1] = new PointF(Rectangle.X + Rectangle.Width / 3, Rectangle.Y);
            points[2] = new PointF(Rectangle.X + Rectangle.Width / 2, Rectangle.Y - (Rectangle.Height / 3) * 2);
            points[3] = new PointF(Rectangle.X + (Rectangle.Width / 3) * 2, Rectangle.Y);
            points[4] = new PointF(Rectangle.X + Rectangle.Width, Rectangle.Y);
            points[5] = new PointF(Rectangle.X + (Rectangle.Width / 4) * 3, Rectangle.Y + (Rectangle.Height / 9) * 4);
            points[6] = new PointF(Rectangle.X + (Rectangle.Width / 6) * 5, Rectangle.Y + Rectangle.Height);
            points[7] = new PointF(Rectangle.X + Rectangle.Width / 2, Rectangle.Y + (Rectangle.Height / 3) * 2);
            points[8] = new PointF(Rectangle.X + Rectangle.Width / 6, Rectangle.Y + Rectangle.Height);
            points[9] = new PointF(Rectangle.X + Rectangle.Width / 4, Rectangle.Y + (Rectangle.Height / 9) * 4);

            grfx.FillPolygon(new SolidBrush(Color.FromArgb(Transparency, FillColor)), points);
            grfx.DrawPolygon(new Pen(Color.FromArgb(Transparency, BorderColor), BorderSize), points);

        }
    }
}
