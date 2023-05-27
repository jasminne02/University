using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Draw
{
    [Serializable]
    public class HeartShape : Shape
    {
        #region Constructor

        public HeartShape(RectangleF rect) : base(rect)
        {
        }

        public HeartShape(HeartShape heart) : base(heart)
        {
        }

        #endregion

        public bool Contains(PointF point)
        {
            RectangleF bounds = new RectangleF(Location.X, Location.Y, Width, Height);
            return bounds.Contains(point);
        }


        public override void DrawSelf(Graphics grfx)
        {
            base.RotateShape(grfx);
            base.DrawSelf(grfx);

            // Изчисляване на разстоянието на контролните точки
            float controlPointOffset = Width * 0.4f;
            PointF bottomCenter = new PointF(Location.X + Width / 2, Location.Y + Height / 2 + controlPointOffset);
            PointF topLeft = new PointF(Location.X + Width / 2 - controlPointOffset, Location.Y + controlPointOffset);
            PointF topRight = new PointF(Location.X + Width / 2 + controlPointOffset, Location.Y + controlPointOffset);

            using (GraphicsPath path = new GraphicsPath())
            {
                // Дефиниране формата на сърцето
                path.StartFigure();
                path.AddArc(Location.X + Width / 2 - controlPointOffset, Location.Y + controlPointOffset / 2, controlPointOffset, controlPointOffset, -180, 180);
                path.AddArc(Location.X + Width / 2, Location.Y + controlPointOffset / 2, controlPointOffset, controlPointOffset, -180, 180);
                path.AddLine(topRight, bottomCenter);
                path.AddLine(bottomCenter, topLeft);
                path.CloseFigure();



                using (SolidBrush brush = new SolidBrush(Color.FromArgb(Transparency, FillColor)))
                {
                    grfx.FillPath(brush, path);
                }

                using (Pen pen = new Pen(Color.FromArgb(Transparency, BorderColor), BorderSize))
                {
                    grfx.DrawPath(pen, path);
                }
                
            }
        }
    }
}
