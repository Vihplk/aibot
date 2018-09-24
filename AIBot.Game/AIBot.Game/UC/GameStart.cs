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
        private string _info;
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
                    _info = @"Spider-Man is a fictional superhero created by writer-editor Stan Lee and writer-artist Steve Ditko. He first appeared in the anthology comic book Amazing Fantasy #15 in the Silver Age of Comic Books";
                    break;
                case Enums.StressLevel.STRESS_LEVEL_2:
                    lblName.Text = "BALOON_B";
                    picHero.SetImage("baloonbuckert.gif");
                    _info = @"Spider-Man is a fictional superhero created by writer-editor Stan Lee and writer-artist Steve Ditko. He first appeared in the anthology comic book Amazing Fantasy #15 in the Silver Age of Comic Books";
                    break;
                case Enums.StressLevel.STRESS_LEVEL_3:
                    lblName.Text = "BALOON BUCKET";
                    picHero.SetImage("baloonbuckert.gif");
                    _info = @"Spider-Man is a fictional superhero created by writer-editor Stan Lee and writer-artist Steve Ditko. He first appeared in the anthology comic book Amazing Fantasy #15 in the Silver Age of Comic Books";
                    break;
                case Enums.StressLevel.ANXIETY:
                    lblName.Text = "DELIVERY BOY";
                    picHero.SetImage("deleveryboy.png");
                    _info = @"Spider-Man is a fictional superhero created by writer-editor Stan Lee and writer-artist Steve Ditko. He first appeared in the anthology comic book Amazing Fantasy #15 in the Silver Age of Comic Books";
                    break;
                case Enums.StressLevel.DEPRESSION:
                    lblName.Text = "HUNGER";
                    picHero.SetImage("hunger.png");
                    _info = @"Spider-Man is a fictional superhero created by writer-editor Stan Lee and writer-artist Steve Ditko. He first appeared in the anthology comic book Amazing Fantasy #15 in the Silver Age of Comic Books";
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

        private void btnInfo_Click(object sender, EventArgs e)
        {
            MessageBox.Show(_info,"Instraction");
        }
    }
}
