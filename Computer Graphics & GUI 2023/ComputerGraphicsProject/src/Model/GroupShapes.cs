using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Draw.src.Model
{
    [Serializable]
    public class GroupShape : Shape
    {
        public List<Shape> Shapes { get; set; }
        public GroupShape(RectangleF bounds) : base(bounds)
        {
            Shapes = new List<Shape>();
        }
        public GroupShape(GroupShape rectangle)
           : base(rectangle)
        {
            Shapes = new List<Shape>();
        }

        
        public override bool Contains(PointF point)
        {
            if (base.Contains(point))
            {

                foreach (Shape item in Shapes)
                {
                    if (item.Contains(point)) return true;
                }
                return true;
            }
            else

                return false;
        }
        public override void DrawSelf(Graphics grfx)
        {
            base.DrawSelf(grfx);

            foreach (Shape item in Shapes)
            {
                item.DrawSelf(grfx);
            }

        }
        public override void Move(float dx, float dy)
        {
            base.Move(dx, dy);

            foreach (Shape item in Shapes)
            {
                item.Move(dx, dy);
            }
        }

        public override Color FillColor
        {
            set
            {
                foreach (Shape item in Shapes)
                {
                    item.FillColor = value;
                }
            }
        }

        public override Color BorderColor
        {
            set
            {
                foreach (Shape item in Shapes)
                {
                    item.BorderColor = value;
                }
            }
        }

        public override void GroupTransparency(int transparency)
        {
            base.GroupTransparency(transparency);

            foreach (Shape item in Shapes)
            {
                item.Transparency = transparency;
            }
        }
        public override void GroupBorderSize(int borderSize)
        {
            base.GroupBorderSize(borderSize);

            foreach (Shape item in Shapes)
            {
                item.BorderSize = borderSize;
            }
        }
        public override void GroupRotate(float angle)
        {
            base.GroupRotate(angle);
            foreach (Shape item in Shapes)
            {
                item.Angle = angle;
            }
        }
        public override void GroupSize(float size)
        {
            base.GroupSize(size);
            foreach (Shape item in Shapes)
            {
                item.Size = size;
            }
        }
    }


}
