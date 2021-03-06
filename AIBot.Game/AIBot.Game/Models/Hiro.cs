﻿using System.Drawing;
using System.Windows.Forms;

namespace AIBot.Game.Models
{
    public class Hiro
    {
        public PictureBox PictureWin { get; protected set; }
        public PictureBox PictureMove { get; protected set; }
        public int InitialX { get; protected set; }
        public int BoundaryX { get; protected set; }
        public int X { get; protected set; }
        public int Y { get; protected set; }
        public int InitialY { get; protected set; }
        public PictureBox PictureBox { get; protected set; }
        public int Width { get; protected set; }
        public int Height { get; protected set; }

        public Hiro(PictureBox pictureBox, int initialX, int initialY, int boundaryX)
        {
            X = InitialX = initialX;
            Y = InitialY = initialY;
            PictureBox = pictureBox;
            BoundaryX = boundaryX;
        }

        public Hiro SetSize(int height, int width)
        {
            this.Width = width;
            this.Height = height;
            return this;
        }

        public PictureBox MoveX(int speed)
        {
            X -= speed;
            PictureBox.Location = new Point(X, Y);
            return PictureBox;
        }

        public bool IsWent()
        {
            return BoundaryX > X;
        }
    }
}
