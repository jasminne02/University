using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace Draw.src.Model
{
    [Serializable]
    public class StringShape : Shape
    {
        public StringShape(RectangleF line) : base(line)
        {
        }

        public StringShape(StringShape line) : base(line)
        {
        }

        public override bool Contains(PointF point)
        {
            if (base.Contains(point))
                // Проверка дали е в обекта само, ако точката е в обхващащия правоъгълник.
                // В случая на правоъгълник - директно връщаме true


                return true;
            else
                // Ако не е в обхващащия правоъгълник, то неможе да е в обекта и => false
                return false;
        }

        public override void DrawSelf(Graphics grfx)
        {
            base.DrawSelf(grfx);
            base.RotateShape(grfx);

            Font drawFont = new Font("Arial", 16);
            grfx.DrawString(Text, drawFont, new SolidBrush(Color.FromArgb(Transparency, FillColor)), Rectangle.X, Rectangle.Y);

            grfx.ResetTransform();
        }
    }
}