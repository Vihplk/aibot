using System;
using System.Windows.Forms;
using AIBot.Game.Logic;
using AIBot.Game.UC;

namespace AIBot.Game
{
    public partial class MainForm : Form
    {
        private Enums.StressLevel _stressLevel;
        private FrmLogin _login;
        public MainForm(Enums.StressLevel stressLevel, FrmLogin login)
        {
            InitializeComponent();
            _login = login;
            lblSession.Text = Globalconfig.SessionId;
            _stressLevel = stressLevel;
            tabPage1.Controls.Add(new GameNotAuthorized());
            tabPage2.Controls.Add(new GameNotAuthorized());
            tabPage3.Controls.Add(new GameNotAuthorized());
            tabPage4.Controls.Add(new GameNotAuthorized());
            tabPage5.Controls.Add(new GameNotAuthorized());

            tabPage1.Enabled = false;
            tabPage2.Enabled = false;
            tabPage3.Enabled = false;
            tabPage4.Enabled = false;
            tabPage5.Enabled = false;
            switch (stressLevel)
            {
                case Enums.StressLevel.STRESS_LEVEL_1:
                    tabPage1.Controls.RemoveAt(0);
                    tabPage1.Controls.Add(new GameStart(this, Enums.StressLevel.STRESS_LEVEL_1));
                    tabPage1.Enabled = true;
                    break;
                case Enums.StressLevel.STRESS_LEVEL_2:
                    tabPage1.Controls.RemoveAt(0);
                    tabPage2.Controls.RemoveAt(0);
                    tabPage1.Controls.Add(new GameStart(this, Enums.StressLevel.STRESS_LEVEL_1));
                    tabPage2.Controls.Add(new GameStart(this, Enums.StressLevel.STRESS_LEVEL_2));
                    tabPage1.Enabled = true;
                    tabPage2.Enabled = true;
                    break;
                case Enums.StressLevel.STRESS_LEVEL_3:
                    tabPage1.Controls.RemoveAt(0);
                    tabPage2.Controls.RemoveAt(0);
                    tabPage3.Controls.RemoveAt(0);
                    tabPage1.Controls.Add(new GameStart(this, Enums.StressLevel.STRESS_LEVEL_1));
                    tabPage2.Controls.Add(new GameStart(this, Enums.StressLevel.STRESS_LEVEL_2));
                    tabPage3.Controls.Add(new GameStart(this, Enums.StressLevel.STRESS_LEVEL_3));
                    tabPage1.Enabled = true;
                    tabPage2.Enabled = true;
                    tabPage3.Enabled = true;
                    break;
                case Enums.StressLevel.ANXIETY:
                    tabPage4.Controls.RemoveAt(0);
                    tabPage4.Controls.Add(new GameStart(this, Enums.StressLevel.ANXIETY)); 
                    tabPage4.Enabled = true;
                    break;
                case Enums.StressLevel.DEPRESSION:
                    tabPage5.Controls.RemoveAt(0);
                    tabPage5.Controls.Add(new GameStart(this, Enums.StressLevel.DEPRESSION)); 
                    tabPage5.Enabled = true; 
                    break;
            }
        }

        public void BackToHome(Enums.StressLevel stresslevel)
        {
            tabPage1.Controls.RemoveAt(0);
            tabPage1.Controls.Add(new GameStart(this, Enums.StressLevel.STRESS_LEVEL_1));

            switch (stresslevel)
            {
                case Enums.StressLevel.STRESS_LEVEL_1:
                    tabPage1.Controls.RemoveAt(0);
                    tabPage1.Controls.Add(new GameStart(this, Enums.StressLevel.STRESS_LEVEL_1));
                    break;
                case Enums.StressLevel.STRESS_LEVEL_2:
                    tabPage2.Controls.RemoveAt(0);
                    tabPage2.Controls.Add(new GameStart(this, Enums.StressLevel.STRESS_LEVEL_2));
                    break;
                case Enums.StressLevel.STRESS_LEVEL_3:
                    tabPage3.Controls.RemoveAt(0);
                    tabPage3.Controls.Add(new StressLevelThree());
                    break;
                case Enums.StressLevel.ANXIETY:
                    tabPage4.Controls.RemoveAt(0);
                    tabPage4.Controls.Add(new Anxiety());
                    break;
                case Enums.StressLevel.DEPRESSION:
                    tabPage5.Controls.RemoveAt(0);
                    tabPage5.Controls.Add(new Depression());
                    break;
                default:
                    throw new ArgumentException();
            }
        }

        public void ChangeTabUserController(Enums.StressLevel gameLevel, GameStart gameStart)
        {
            switch (gameLevel)
            {
                case Enums.StressLevel.STRESS_LEVEL_1:
                    tabPage1.Controls.Remove(gameStart);
                    tabPage1.Controls.Add(new StressLevelOne(this));
                    break;
                case Enums.StressLevel.STRESS_LEVEL_2:
                    tabPage2.Controls.Remove(gameStart);
                    tabPage2.Controls.Add(new StressLevelTwo(this));
                    break;
                case Enums.StressLevel.STRESS_LEVEL_3:
                    tabPage3.Controls.Remove(gameStart);
                    tabPage3.Controls.Add(new StressLevelThree());
                    break;
                case Enums.StressLevel.ANXIETY:
                    tabPage4.Controls.Remove(gameStart);
                    tabPage4.Controls.Add(new Anxiety());
                    break;
                case Enums.StressLevel.DEPRESSION:
                    tabPage5.Controls.Remove(gameStart);
                    tabPage5.Controls.Add(new Depression());
                    break;
                default:
                    throw new ArgumentException();
            }
        }
 
        private void logoutToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            _login.Show();
            this.Close();
        }
    }
}
