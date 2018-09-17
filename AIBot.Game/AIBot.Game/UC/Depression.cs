using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AIBot.Game.Logic;

namespace AIBot.Game.UC
{
    public partial class Depression : UserControl
    {
        private List<string> images;
        private List<PictureBox> picList = null;
        private List<PictureBox> picSelectedBoxs = null;
        private List<KeyValuePair<string,string[]>> time;
        private int selectedIndex = 0;
        private int success = 0;
        private int failed = 0;
        private int timer = 0;
        private int eatTime = 0;
        public Depression()
        {
            InitializeComponent();
            Init();
        }

        void Init()
        {
            images = new List<string>()
            {
                "rice.png","water.png","book.png",
                "chocolat.png","fruit.png","newspaper.png",
                "coke.png","tv.png"
            };

            picHero.SetImage("boy.gif");
            time = new List<KeyValuePair<string, string[]>>()
            {
                new KeyValuePair<string, string[]>("7.00AM",new []{"rice","water","newspaper"}),
                new KeyValuePair<string, string[]>("1.00PM",new []{"rice","water","fruit"}),
                new KeyValuePair<string, string[]>("7.30PM",new []{"rice","water","book"})
            };
            lblTime.Text = time[0].Key;
            picList = new List<PictureBox>()
            {
                pic1,
                pic2,
                pic3,
                pic4,
                pic5,
                pic6,
                pic7,
                pic8
            };
            var rd = new Random();
            var rdBound = 8;
            foreach (var item in picList)
            {
                var index = rd.Next(0, rdBound);
                item.SetImage(images[index]);
                item.Text = images[index];
                rdBound--;
                images.RemoveAt(index);
            }

            picSelectedBoxs = new List<PictureBox>()
            {
                picSel1,
                picSel2,
                picSel3
            };
            foreach (var item in picSelectedBoxs)
            {
                item.SetImage("no.png");
            }
        }

        private void pic1_Click(object sender, EventArgs e)
        {
            Pick(pic1);
        }

        private void pic2_Click(object sender, EventArgs e)
        {
            Pick(pic2);
        }

        private void pic3_Click(object sender, EventArgs e)
        {
            Pick(pic3);
        }

        private void pic4_Click(object sender, EventArgs e)
        {
            Pick(pic4);
        }

        private void pic5_Click(object sender, EventArgs e)
        {
            Pick(pic5);
        }

        private void pic6_Click(object sender, EventArgs e)
        {
            Pick(pic6);
        }

        private void pic7_Click(object sender, EventArgs e)
        {
            Pick(pic7);
        }

        private void pic8_Click(object sender, EventArgs e)
        {
            Pick(pic8);
        }

        void Pick(PictureBox pb)
        {
            try
            {
                picSelectedBoxs[selectedIndex].SetImage(pb.Text);
                picSelectedBoxs[selectedIndex].Text = pb.Text;
                selectedIndex++;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }          
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            try
            {
                var vals = time[eatTime].Value;
                if (picSelectedBoxs[0].Text.Contains(vals[0]) && picSelectedBoxs[1].Text.Contains(vals[1]) &&
                    picSelectedBoxs[2].Text.Contains(vals[2]))
                {
                    success++;
                }
                else
                {
                    failed++;
                }
                lblSuccess.Text = success.ToString();
                lblFaild.Text = failed.ToString();
                selectedIndex++;
                eatTime++;
                selectedIndex = 0;
                lblTime.Text = time[eatTime].Key;
                foreach (var item in picSelectedBoxs)
                {
                    item.SetImage("no.png");
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show($"game is finished.you have {success} success and {failed} failier");
            }
           
        }
    }
}
