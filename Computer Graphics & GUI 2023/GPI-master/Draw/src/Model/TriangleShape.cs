using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draw.src.Model
{
    [Serializable]
    class TriangleShape : Shape
    {
        #region Constructor

        public TriangleShape(RectangleF tri) : base(tri)
        {
        }

        public TriangleShape(TriangleShape triangle) : base(triangle)
        {
        }

        #endregion

        /// <summary>
        /// Проверка за принадлежност на точка point към правоъгълника.
        /// В случая на правоъгълник този метод може да не бъде пренаписван, защото
        /// Реализацията съвпада с тази на абстрактния клас Shape, който проверява
        /// дали точката е в обхващащия правоъгълник на елемента (а той съвпада с
        /// елемента в този случай).
        /// </summary>
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

            Point[] p = { new Point((int)Rectangle.X + ((int)Rectangle.Width / 2), (int)Rectangle.Y), new Point((int)Rectangle.X, (int)(Rectangle.Y + Rectangle.Height)), new Point((int)(Rectangle.X + Rectangle.Width), (int)(Rectangle.Y + Rectangle.Height)) };
            grfx.FillPolygon(new SolidBrush(Color.FromArgb(Opacity, FillColor)), p);
            grfx.DrawPolygon(new Pen(BorderColor), p);

            grfx.ResetTransform();
        }
    }
}
