using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draw.src.Model
{
    [Serializable]
    public class XShape : Shape
    {
        public XShape(RectangleF xShape) : base(xShape)
        {
        }

        public XShape(XShape xShape) : base(xShape)
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

        /// <summary>
        /// Частта, визуализираща конкретния примитив.
        /// </summary>
        public override void DrawSelf(Graphics grfx)
        {
            base.DrawSelf(grfx);
            base.RotateShape(grfx);
            
            grfx.DrawLine(new Pen(BorderColor, 1),
                     Rectangle.X,
                     Rectangle.Y,
                     Rectangle.X + Rectangle.Width,
                     Rectangle.Y + Rectangle.Height);
            
            grfx.DrawLine(new Pen(BorderColor, 1),
                     Rectangle.X,
                     Rectangle.Y + Rectangle.Height,
                     Rectangle.X + Rectangle.Width,
                     Rectangle.Y);

            grfx.ResetTransform();
        }
    }
}
