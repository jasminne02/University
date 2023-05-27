using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Draw
{
    /// <summary>
    /// Класът правоъгълник е основен примитив, който е наследник на базовия Shape.
    /// правоъгълник, който е запълнен със снимка
    /// </summary>

    [Serializable]

    public class ImageShape : Shape
	{

        private Image image;

		public Image Image { 
			get { return image; }
			set { }
		}

        #region Constructor

        public ImageShape(Image image, RectangleF rect) : base(rect)
		{
			this.image = image;
		}
		
		public ImageShape(RectangleShape rectangle) : base(rectangle)
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

			grfx.DrawImage(image, base.Rectangle);

        }
    }
}
