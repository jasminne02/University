using System;
using System.Drawing;
using System.IO.Ports;

namespace Draw
{
    [Serializable]
    public class TriangleShape : Shape
    {
        #region Constructor

        public TriangleShape(RectangleF rect) : base(rect)
        {
        }

        public TriangleShape(TriangleShape triangle) : base(triangle)
        {
        }

        #endregion

        public override bool Contains(PointF point)
        {
            // проверява дали point е в триъгълника или не като смята лицето на вече съществуващия триъгълник
            // след това свързва point с всяка двойка страни за да образува 3 триъгълника
            // ако сбора от лицето им е равен на лицето на съществуващия триъгълник то point е в него
            // ако не е равен значи е извън него

            float x1 = Rectangle.X;
            float x2 = Rectangle.X + Rectangle.Width / 2;
            float x3 = Rectangle.X + Rectangle.Width;
            float y1 = Rectangle.Y;
            float y2 = Rectangle.Y - Rectangle.Height;
            float y3 = Rectangle.Y;

            float triangleArea = getArea(x1, y1, x2, y2, x3, y3);
            float area1 = getArea(point.X, point.Y, x2, y2, x3, y3);
            float area2 = getArea(x1, y1, point.X, point.Y, x3, y3);
            float area3 = getArea(x1, y1, x2, y2, point.X, point.Y);


            if (triangleArea == area1 + area2 + area3)
                return true;
            else
                return false;
        }

        public override void DrawSelf(Graphics grfx)
        {
            base.DrawSelf(grfx);
            base.RotateShape(grfx);

            PointF[] points = { new PointF(Rectangle.X, Rectangle.Y), 
                                new PointF(Rectangle.X + Rectangle.Width/2, Rectangle.Y - Rectangle.Height), 
                                new PointF(Rectangle.X + Rectangle.Width, Rectangle.Y) };

            grfx.FillPolygon(new SolidBrush(Color.FromArgb(Transparency, FillColor)), points);
            grfx.DrawPolygon(new Pen(Color.FromArgb(Transparency, BorderColor), BorderSize), points);

        }

        private float getArea(float x1, float y1, float x2, float y2, float x3, float y3)
        {
            return (float)Math.Abs((x1 * (y2 - y3) +
                         x2 * (y3 - y1) +
                         x3 * (y1 - y2)) / 2.0);
        }
    }
}
 