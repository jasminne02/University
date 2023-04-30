using System;
using System.Collections.Generic;
using System.Drawing;

namespace Draw
{
    /// <summary>
    /// Класът правоъгълник е основен примитив, който е наследник на базовия Shape.
    /// </summary>
    [Serializable]
    public class GroupShape : Shape
    {
        #region Constructor

        public GroupShape(RectangleF rect)
            : base(rect)
        {
            SubItems = new List<Shape>();
        }

        public GroupShape(GroupShape rectangle)
            : base(rectangle)
        {
            SubItems = new List<Shape>();
        }

        #endregion

        public List<Shape> SubItems { get; set; }

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
            {
                // Проверка дали е в обекта само, ако точката е в обхващащия правоъгълник.
                // В случая на правоъгълник - директно връщаме true
                foreach (var item in SubItems)
                {
                    if (item.Contains(point)) return true;
                }
                return true;
            }
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

            foreach (var item in SubItems)
            {
                item.DrawSelf(grfx);
            }

        }

        public override void Move(float dx, float dy)
        {
            base.Move(dx, dy);

            foreach (var item in SubItems)
            {
                item.Move(dx, dy);
            }
        }

        public override Color FillColor
        {
            set
            {
                foreach (var item in SubItems)
                {
                    item.FillColor = value;
                }
            }
        }

        public override Color BorderColor
        {
            set
            {
                foreach (var item in SubItems)
                {
                    item.BorderColor = value;
                }
            }
        }

        public override void GroupOpacity(int opacity)
        {
            base.GroupOpacity(opacity);
            foreach (var item in SubItems)
            {
                item.Opacity = opacity;
            }
        }

        public override void GroupRotate(float angle)
        {
            base.GroupRotate(angle);
            foreach (var item in SubItems)
            {
                item.Angle = angle;
            }
        }
    }
}
