using System;
using System.Drawing;


namespace Draw
{
    [Serializable]

    public class BackgroundSerializable : Shape
	{
        private Color color = Color.White;

        public Color Color
        {
            get { return color; }
            set { color = value; }
        }

        private System.Drawing.Image image;

        public System.Drawing.Image Image
        {
            get { return image; }
            set { image = value; }
        }

        public BackgroundSerializable(Color color)
        {
            this.color = color;
        }

        public BackgroundSerializable(Image image)
        {
            this.image = image;
        }


        public override void DrawSelf(Graphics grfx)
		{
            grfx.Clear(color); 

            if (image != null )
            {
                grfx.DrawImage(image, 0, 0, 1550, 750);
            }

        }
    }
}
