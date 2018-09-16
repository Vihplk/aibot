using System;
using System.Windows.Forms;

namespace AIBot.Game.Logic
{
    public static class Image
    {
        public static PictureBox SetImage(this PictureBox pb,string imageName)
        {
            pb.ImageLocation = $"{Globalconfig.ImageLocation}{imageName}";
            return pb;
        }

        public static bool ImagesAreOverlap(this PictureBox pb1,PictureBox pb2)
        {
            var xrange = new int[2];
            var yrange = new int [2];

            xrange[0] = pb1.Location.X - pb2.Width;
            xrange[1] = pb1.Location.X + pb1.Width;

            yrange[0] = pb1.Location.Y + pb2.Height;
            yrange[1] = pb1.Location.Y + pb1.Height;

            var tx = pb2.Location.X;
            var ty = pb2.Location.Y;

            if (tx>xrange[0] && tx<xrange[1] && ty> yrange[0] && ty < yrange[1])
            {
                return true;
            }
            return false;
        }
    }
}
