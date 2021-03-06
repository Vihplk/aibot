﻿using System;
using System.Drawing;
using System.Windows.Forms;
using AIBot.Game.Logic;
using AIBot.Game.Models;
using AIBot.Game.Utility;

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
        private int time = 50;
        private int success = 0, failed = 0;
        private MainForm _mainForm;
        public StressLevelOne(MainForm mainForm)
        {
            InitializeComponent();
            _mainForm = mainForm;
            picHero.SetImage("superman.gif");
            picAction.SetImage("pause.png").Text = "pause";
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
                    lblFaild.Text = $"{failed}";
                    activeBlock.RemovePicture(this.Width);
                    isActiveBlock = false;
                    Console.Beep(226,500);
                }
                if (activeBlock.IsWent())
                {
                    Console.Beep(512, 1);
                    success++;
                    lblSuccess.Text = $"{success}";
                    isActiveBlock = false;
                }
            }

            heroY += 3;
            if (heroY >= this.Height)
            {
                heroY = this.Height;
            }
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

        private void StressLevelOne_KeyDown(object sender, KeyEventArgs e)
         {
            if (e.KeyData == Keys.Space)
            {
                heroY -= 15;
            }
             if (heroY < 0)
             {
                 heroY = 0;
             }
             Console.Beep(700, 100);
         }

        private void picAction_Click(object sender, EventArgs e)
        {
            if (picAction.Text.StartsWith("pause"))
            {
                tmrCount.Stop();
                tmrBackgroundImage.Stop();
                picAction.SetImage("play.png").Text = "play";
            }
            else
            {
                tmrCount.Start();
                tmrBackgroundImage.Start();
                picAction.SetImage("pause.png").Text = "pause";
            }
        }

        private void picQuit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"sure?", ""
                    , MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                _mainForm.BackToHome(Enums.StressLevel.STRESS_LEVEL_1);
            }
        }

        private void StressLevelOne_MouseClick(object sender, MouseEventArgs e)
        {
            heroY -= 15;
        }

        private void tmrCount_Tick(object sender, EventArgs e)
        {
            time--;
            lblTime.Text = $"{time}s";

            if (time > 0 && time <= 20)
            {
                speed = 20;
            }
            else if (time <= 0)
            {
                tmrCount.Stop();
                tmrBackgroundImage.Stop();
                if (MessageBox.Show(
                        $"Your result summary success:{success},failed:{failed}. \n Click ok to save game result",
                        "Game finised"
                        , MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    SubmitResult();
                }
                else
                {
                    _mainForm.BackToHome(Enums.StressLevel.STRESS_LEVEL_1);
                }
            }
        }

        private void SubmitResult()
        {

            var response =
                HttpRequester.Get(
                    $"{Globalconfig.ApiEndPoint}/api/sessions/game/{Globalconfig.SessionId}/{(int) Enums.StressLevel.STRESS_LEVEL_1}/{success}/{failed}");
            _mainForm.BackToHome(Enums.StressLevel.STRESS_LEVEL_1);
        }

    }
}
