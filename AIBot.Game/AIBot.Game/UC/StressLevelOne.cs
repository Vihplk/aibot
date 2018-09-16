﻿using System;
using System.Drawing;
using System.Windows.Forms;
using AIBot.Game.Logic;
using AIBot.Game.Models;

namespace AIBot.Game.UC
{
    public partial class StressLevelOne : UserControl
    {
        bool isActiveBlock = false;
        Block activeBlock = null;
        private Hiro hiro = null;
        private Enums.GameState GameState = Enums.GameState.Start;
        private int speed=5;
        private int heroX = 0, heroY = 0;
        private int time = 0;
        private int success = 0, failed = 0;
        public StressLevelOne()
        {
            InitializeComponent();
            picHero.SetImage("superman.gif");
            tmrBackgroundImage.Start();
            tmrCount.Start();
        }

        private void tmrBackgroundImage_Tick(object sender, EventArgs e)
        {
            if (!isActiveBlock)
            {
                var rdIndex = SelectRandomTree();
                switch (rdIndex)
                {
                    case 0:
                        activeBlock = new Block(pictureBox1, this.Width, 240, 0 - pictureBox1.Width);
                        break;
                    case 1:
                        activeBlock = new Block(pictureBox2, this.Width, 152, 0 - pictureBox2.Width);
                        break;
                    case 2:
                        activeBlock = new Block(pictureBox3, this.Width, 367, 0 - pictureBox3.Width);
                        break;
                }
                speed = GetRandomSpeed();
                isActiveBlock = true;
            }
            if (isActiveBlock)
            {
                activeBlock.MoveX(speed);
                if (activeBlock.PictureBox.ImagesAreOverlap(picHero))
                {
                    failed++;
                    lblFaild.Text = $"{failed}s";
                    activeBlock.RemovePicture(this.Width);
                    isActiveBlock = false;
                }
                if (activeBlock.IsWent())
                {
                    success++;
                    lblSuccess.Text = $"{success}s";
                    isActiveBlock = false;
                }
            }

            heroY += 3;
            picHero.Location = new Point(heroX, heroY);
        }

        private int SelectRandomTree()
        {
            Random rd = new Random();
            return rd.Next(0, 3);
        }

        private int GetRandomSpeed()
        {
            Random rd = new Random();
            return rd.Next(10, 20);
        }

        private void StressLevelOne_MouseClick(object sender, MouseEventArgs e)
        {
            heroY -= 15;
        }

        private void tmrCount_Tick(object sender, EventArgs e)
        {
            time++;
            lblTime.Text = $"{time}s";
            if (time>=50)
            {
                MessageBox.Show("Game finised");
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            tmrBackgroundImage.Start();
            GameState = Enums.GameState.Prosess;
        }
    }
}