using System.Drawing;
using System.Windows.Forms;

namespace AIBot.Game.Models
{
    public class BackgroundImage
    {
        public int  InitialX { get; protected set; }
        public int BoundaryX { get; protected set; }
        public int X { get; protected set; }
        public int Y { get; protected set; }
        public int WindowWidth { get; protected set; }
        public int InitialY { get; protected set; }
        private int TempBoundaryX { get; set; }

        public BackgroundImage(int initialX,int initialY,PictureBox picture,UserControl uc)
        {
            BoundaryX = picture.Width;
            InitialX = initialX;
            WindowWidth = uc.Width;
            TempBoundaryX = BoundaryX;
            InitialY = initialY;
        }

        public Point MoveX(int speed)
        {
            X -= speed;
            if (WindowWidth >= TempBoundaryX)
            {
                X = 0;
                TempBoundaryX = BoundaryX;
            }

            TempBoundaryX -= speed;
            return new Point(X, Y);
        }
    }
}
