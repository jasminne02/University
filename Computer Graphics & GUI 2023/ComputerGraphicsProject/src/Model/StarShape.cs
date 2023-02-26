using System;
using System.Drawing;

namespace Draw
{
    public class StarShape : Shape
    {
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
            if (base.Contains(point))
                return true;
            else
                return false;
        }

        public override void DrawSelf(Graphics grfx)
        {
            base.DrawSelf(grfx);

            PointF[] points = { new PointF(Rectangle.X, Rectangle.Y),
                                new PointF(Rectangle.X + Rectangle.Width/3, Rectangle.Y),
                                new PointF(Rectangle.X + Rectangle.Width/2, Rectangle.Y - (Rectangle.Height/3)*2),
                                new PointF(Rectangle.X + (Rectangle.Width/3)*2, Rectangle.Y),
                                new PointF(Rectangle.X + Rectangle.Width, Rectangle.Y), 
                                new PointF(Rectangle.X + (Rectangle.Width/4)*3, Rectangle.Y + (Rectangle.Height/9)*4),
                                new PointF(Rectangle.X + (Rectangle.Width/6)*5, Rectangle.Y + Rectangle.Height), 
                                new PointF(Rectangle.X + Rectangle.Width/2, Rectangle.Y + (Rectangle.Height/3)*2),
                                new PointF(Rectangle.X + Rectangle.Width/6, Rectangle.Y + Rectangle.Height),
                                new PointF(Rectangle.X + Rectangle.Width/4, Rectangle.Y + (Rectangle.Height/9)*4)};

            grfx.FillPolygon(new SolidBrush(Color.FromArgb(Transparency, FillColor)), points);
            grfx.DrawPolygon(new Pen(Color.FromArgb(Transparency, BorderColor)), points);

        }
    }
}
