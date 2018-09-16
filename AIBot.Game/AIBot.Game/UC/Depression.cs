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
        public Depression()
        {
            InitializeComponent();
            images = new List<string>()
            {
                "rice.png","water.png","book.png",
                "chocolat.png","fruit.png","newspaper.png",
                "coke.png","coke.png"
            };
            Init();
        }

        void Init()
        {
            picHero.SetImage("boy.gif");

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
                rdBound--;
                images.RemoveAt(index);
            }
        }
    }
}
