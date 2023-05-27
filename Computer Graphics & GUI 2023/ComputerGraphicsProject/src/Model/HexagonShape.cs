using System;
using System.Drawing;

namespace Draw
{
    [Serializable]

    public class HexagonShape : Shape
    {
        private PointF[] points = new PointF[6];

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
            int count = 0;
            int i = 0;

            do
            {
                PointF p1 = points[i];
                PointF p2 = points[(i + 1) % 6];

                if (isIntersect(p1, p2, point, new PointF(9999, point.Y)))
                {
                    if (direction(p1, point, p2) == 0)
                        return isOnLine(p1, p2, point);
                    count++;
                }

                i = (i + 1) % 6;
            } while (i != 0);

            return count % 2 != 0;
        }


        public override void DrawSelf(Graphics grfx)
        {
            base.DrawSelf(grfx);
            base.RotateShape(grfx);

            points[0] = new PointF(Rectangle.X, Rectangle.Y);
            points[1] = new PointF(Rectangle.X + Rectangle.Width / 4, Rectangle.Y - Rectangle.Height / 2);
            points[2] = new PointF(Rectangle.X + (Rectangle.Width / 4) * 3, Rectangle.Y - Rectangle.Height / 2);
            points[3] = new PointF(Rectangle.X + Rectangle.Width, Rectangle.Y);
            points[4] = new PointF(Rectangle.X + (Rectangle.Width / 4) * 3, Rectangle.Y + Rectangle.Height / 2);
            points[5] = new PointF(Rectangle.X + Rectangle.Width / 4, Rectangle.Y + Rectangle.Height / 2);

            grfx.FillPolygon(new SolidBrush(Color.FromArgb(Transparency, FillColor)), points);
            grfx.DrawPolygon(new Pen(Color.FromArgb(Transparency, BorderColor), BorderSize), points);

        }

    }
}
