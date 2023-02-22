using System;
using System.Drawing;

namespace Draw
{
    /// <summary>
    /// Класът правоъгълник е основен примитив, който е наследник на базовия Shape.
    /// </summary>
    public class PentagonShape : Shape
    {
        #region Constructor

        public PentagonShape(RectangleF rect) : base(rect)
        {
        }

        public PentagonShape(PentagonShape pentagon) : base(pentagon)
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

        /// <summary>
        /// Частта, визуализираща конкретния примитив.
        /// </summary>
        public override void DrawSelf(Graphics grfx)
        {
            base.DrawSelf(grfx);

            /*PointF[] points = { new PointF(Rectangle.X, Rectangle.Y), new PointF(Rectangle.X + Rectangle.Width/2, Rectangle.Y-Rectangle.Height/2),
                                new PointF(Rectangle.X + Rectangle.Width, Rectangle.Y), new PointF(Rectangle.X + (Rectangle.Width/4)*3, Rectangle.Y+Rectangle.Height/2),
                                new PointF(Rectangle.X + Rectangle.Width/4, Rectangle.Y+Rectangle.Height/2) };

            grfx.FillPolygon(new SolidBrush(FillColor), points);
            grfx.DrawPolygon(Pens.Black, points);
            */

            base.DrawSelf(grfx);

            grfx.FillEllipse(new SolidBrush(FillColor), Rectangle.X, Rectangle.Y, Rectangle.Width, 50);
            grfx.DrawEllipse(Pens.Black, Rectangle.X, Rectangle.Y, Rectangle.Width, 50);

            grfx.FillEllipse(new SolidBrush(FillColor), Rectangle.X, Rectangle.Y+100, Rectangle.Width, 50);
            grfx.DrawEllipse(Pens.Black, Rectangle.X, Rectangle.Y+100, Rectangle.Width, Rectangle.Height);

            grfx.DrawLine(Pens.Brown, new PointF(Rectangle.X, Rectangle.Y), new PointF(Rectangle.X, Rectangle.Y + 100));
            grfx.DrawLine(Pens.Brown, new PointF(Rectangle.X+Rectangle.Width, Rectangle.Y), new PointF(Rectangle.X+Rectangle.Width, Rectangle.Y + 100));

        }
    }
}
