using System;
using System.Windows.Forms;
using AIBot.Game.Logic;
using Image = System.Drawing.Image;

namespace AIBot.Game.UC
{
    public partial class GameStart : UserControl
    {
        private Enums.StressLevel _gemeLevel;
        private MainForm _mainForm;
        public GameStart(MainForm mainForm, Enums.StressLevel gameLevel)
        {
            InitializeComponent();
            _gemeLevel = gameLevel;
            _mainForm = mainForm;
            Initial();
        }

        void Initial()
        {
            switch (_gemeLevel) 
            {
                case Enums.StressLevel.STRESS_LEVEL_1:
                    lblName.Text = "SUPERMAN IN JUNGLE";
                    picHero.SetImage("supermanwin.gif");
                    break;
                case Enums.StressLevel.STRESS_LEVEL_2:
                    lblName.Text = "BALOON_B";
                    picHero.SetImage("baloonbuckert.gif");
                    break;
                case Enums.StressLevel.STRESS_LEVEL_3:
                    lblName.Text = "BALOON BUCKET";
                    picHero.SetImage("baloonbuckert.gif");
                    break;
                case Enums.StressLevel.ANXIETY:
                    lblName.Text = "DELIVERY BOY";
                    picHero.SetImage("deleveryboy.png");
                    break;
                case Enums.StressLevel.DEPRESSION:
                    lblName.Text = "HUNGER";
                    picHero.SetImage("hunger.png");
                    break;
                default:
                    throw new ArgumentException();
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Console.Beep(700, 200);
            _mainForm.ChangeTabUserController(_gemeLevel,this);
        }
    }
}
