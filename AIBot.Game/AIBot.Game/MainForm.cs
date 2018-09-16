using System;
using System.Windows.Forms;
using AIBot.Game.Logic;
using AIBot.Game.UC;

namespace AIBot.Game
{
    public partial class MainForm : Form
    {
        private Enums.StressLevel _stressLevel;
        public MainForm(Enums.StressLevel stressLevel)
        {
            InitializeComponent();
            _stressLevel = stressLevel;
            tabPage1.Enabled = false;
            tabPage2.Enabled = false;
            tabPage3.Enabled = false;
            tabPage4.Enabled = false;
            tabPage5.Enabled = false;
            switch (stressLevel)
            {
                case Enums.StressLevel.STRESS_LEVEL_1:
                    tabPage1.Controls.Add(new GameStart(this, Enums.StressLevel.STRESS_LEVEL_1));
                    tabPage1.Enabled = true;
                    break;
                case Enums.StressLevel.STRESS_LEVEL_2:
                    tabPage1.Controls.Add(new GameStart(this, Enums.StressLevel.STRESS_LEVEL_1));
                    tabPage2.Controls.Add(new GameStart(this, Enums.StressLevel.STRESS_LEVEL_2));
                    tabPage1.Enabled = true;
                    tabPage2.Enabled = true;
                    break;
                case Enums.StressLevel.STRESS_LEVEL_3:
                    tabPage1.Controls.Add(new GameStart(this, Enums.StressLevel.STRESS_LEVEL_1));
                    tabPage2.Controls.Add(new GameStart(this, Enums.StressLevel.STRESS_LEVEL_2));
                    tabPage3.Controls.Add(new GameStart(this, Enums.StressLevel.STRESS_LEVEL_3));
                    tabPage1.Enabled = true;
                    tabPage2.Enabled = true;
                    tabPage3.Enabled = true;
                    break;
                case Enums.StressLevel.ANXIETY:
                    tabPage4.Controls.Add(new GameStart(this, Enums.StressLevel.ANXIETY)); 
                    tabPage4.Enabled = true;
                    break;
                case Enums.StressLevel.DEPRESSION:
                    tabPage5.Controls.Add(new GameStart(this, Enums.StressLevel.DEPRESSION)); 
                    tabPage5.Enabled = true; 
                    break;
            }
        }

        public void ChangeTabUserController(Enums.StressLevel gameLevel, GameStart gameStart)
        {
            switch (gameLevel)
            {
                case Enums.StressLevel.STRESS_LEVEL_1:
                    tabPage1.Controls.Remove(gameStart);
                    tabPage1.Controls.Add(new StressLevelOne());
                    break;
                case Enums.StressLevel.STRESS_LEVEL_2:
                    tabPage2.Controls.Remove(gameStart);
                    tabPage2.Controls.Add(new StressLevelTwo());
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
    }
}
