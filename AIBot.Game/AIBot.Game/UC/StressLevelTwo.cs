﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AIBot.Game.Logic;
using AIBot.Game.Utility;

namespace AIBot.Game.UC
{
    public partial class StressLevelTwo : UserControl
    {
        List<PictureBox> pictureBoxList = new List<PictureBox>();
        private List<string> images = null;
        private int success = 0, failed = 0;
        private int countDown = 50;
        public List<string> pair = new List<string>();
        private PictureBox selectedPictureBox = new PictureBox();
        private MainForm _mainForm;
        public StressLevelTwo(MainForm mainForm)
        {
            images = new List<string>()
            {
                "baloonblue.gif",
                "baloonred.gif",
                "baloonyellow.gif"
            };
            InitializeComponent();
            _mainForm = mainForm;
            Init();
            GenBaloons();
            tmrCountDown.Start();
        }

        void Init()
        {
            picBucketBlue.SetImage("bucketblue.png");
            picBucketRed.SetImage("bucketred.png");
            picBucketYellow.SetImage("bucketyellow.png");
            picAction.SetImage("pause.png").Text = "pause";
        }

        void GenBaloons()
        {
            int x = 25;
            var rd = new Random();
            for (int i = 0; i < 7; i++)
            {
                var pic = new PictureBox();
                var name = images[rd.Next(0, 3)];
                pic.Text = name.Contains("red") ? "red" :
                    name.Contains("blue") ? "blue" : "yellow";
                pic.Location = new Point(x, 20);
                pic.SizeMode = PictureBoxSizeMode.StretchImage;
                pic.Cursor = System.Windows.Forms.Cursors.Hand;
                pic.Click += (s, e) =>
                {
                    if (pair.Count == 0)
                    {
                        pair.Add(pic.Text);
                        lblYouSelect.Text = pic.Text.ToUpper();
                        lblYouDrop.Text = string.Empty;
                        selectedPictureBox = pic;
                        Console.Beep(700, 100);
                    }
                    else
                    {
                        MessageBox.Show("invalied oparation");
                    }
                };
                pic.SetImage(name);
                pictureBoxList.Add(pic);
                x += 150;
            }

            foreach (var item in pictureBoxList)
            {
                pnlBaloon.Controls.Add(item);
            }
        }

        private void picBucketBlue_Click(object sender, EventArgs e)
        {
            Drop(picBucketBlue);
        }

        private void picBucketRed_Click(object sender, EventArgs e)
        {
            Drop(picBucketRed);
        }
        private void picBucketYellow_Click(object sender, EventArgs e)
        {
            Drop(picBucketYellow);
        }
        private void tmrCountDown_Tick(object sender, EventArgs e)
        {
            if (countDown<0)
            {
                tmrCountDown.Stop();
                if (MessageBox.Show($"Your result summary success:{success},failed:{failed}. \n Click ok to save game result", "Game finised"
                        , MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    SubmitResult();
                }
                else
                {
                    _mainForm.BackToHome(Enums.StressLevel.STRESS_LEVEL_2);
                } 
            }
            countDown--;
            lblTime.Text = $"{countDown}s";
        }

        void Drop(PictureBox pb)
        {
            if (pair.Count!=1)
            {
                MessageBox.Show("please select a baloon first");
                return;
            }
            Console.Beep(700, 100);
            pair.Add(pb.Name.ToLower());
            lblYouDrop.Text = GetColor(pb.Name).ToUpper();
            if (pb.Name.ToLower().Contains(pair[0]))
            {
                success++;
                lblSuccess.Text = $"{success}";
                Random rd = new Random();
                var name = images[rd.Next(0, 3)];
                selectedPictureBox.Text = name.Contains("red") ? "red" :
                    name.Contains("blue") ? "blue" : "yellow";
                selectedPictureBox.SetImage(name);
            }
            else
            {
                failed++;
                lblFaild.Text = $"{failed}";
            }
            pair = new List<string>();
        }

        private void pnlBaloon_Paint(object sender, PaintEventArgs e)
        {

        }

        private void picAction_Click(object sender, EventArgs e)
        {
            if (picAction.Text.StartsWith("pause"))
            {
                tmrCountDown.Stop(); 
                picAction.SetImage("play.png").Text = "play";
            }
            else
            {
                tmrCountDown.Start(); 
                picAction.SetImage("pause.png").Text = "pause";
            }
        }

        private void picQuit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"sure?", ""
                    , MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                _mainForm.BackToHome(Enums.StressLevel.STRESS_LEVEL_2);
            }
        }

        string GetColor(string name)
        {
            if (name.Contains("Red"))
            {
                return "red";
            }
            else if (name.Contains("Blue"))
            {
                return "blue";
            }
            else if (name.Contains("Yello"))
            {
                return "yellow";
            }

            return "";
        }
        private void SubmitResult()
        {

            var response =
                HttpRequester.Get(
                    $"{Globalconfig.ApiEndPoint}/api/sessions/game/{Globalconfig.SessionId}/{(int)Enums.StressLevel.STRESS_LEVEL_2}/{success}/{failed}");
            _mainForm.BackToHome(Enums.StressLevel.STRESS_LEVEL_2);
        }
    }
}
