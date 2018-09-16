using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AIBot.Game.Logic;

namespace AIBot.Game.UC
{
    public partial class StressLevelTwo : UserControl
    {
        List<PictureBox> pictureBoxList = new List<PictureBox>();
        private string pick;
        private List<string> images = null;
        private int success = 0, failed = 0;
        private int countDown = 50;
        public StressLevelTwo()
        {
            images = new List<string>()
            {
                "baloonblue.gif",
                "baloonred.gif",
                "baloonyellow.gif"
            };
            InitializeComponent();
            Init();
            GenBaloons();
            tmrCountDown.Start();
        }

        void Init()
        {
            picBucketBlue.SetImage("bucketblue.png");
            picBucketRed.SetImage("bucketred.png");
            picBucketYello.SetImage("bucketyello.png");
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
                pic.Click += (s, e) => { pick = pic.Text; };
                pic.SetImage(images[rd.Next(0, 3)]);
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

        private void picBucketYello_Click(object sender, EventArgs e)
        {
            Drop(picBucketYello);
        }

        private void tmrCountDown_Tick(object sender, EventArgs e)
        {
            if (countDown<0)
            {
                MessageBox.Show("game Over");
            }
            countDown--;
            lblTime.Text = $"{countDown}s";
        }

        void Drop(PictureBox pb)
        {
            if (pb.Name.ToLower().Contains(pick))
            {
                success++;
                lblSuccess.Text = $"{success}";
            }
            else
            {
                failed++;
                lblSuccess.Text = $"{failed}";
            }
        }

        
    }
}
