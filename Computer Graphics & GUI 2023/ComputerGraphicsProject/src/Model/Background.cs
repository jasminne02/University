using System;
using System.Drawing;


namespace Draw
{
    public static class Background
	{
        private static Color color = Color.White;

        public static Color Color
        {
            get { return color; }
            set { color = value; }
        }

        private static System.Drawing.Image image;

        public static System.Drawing.Image Image
        {
            get { return image; }
            set { image = value; }
        }


        public static void DrawSelf(Graphics grfx)
		{
            grfx.Clear(color); 

            if (image != null )
            {
                grfx.DrawImage(image, 0, 0, 1550, 750);
            }

        }
    }
}
