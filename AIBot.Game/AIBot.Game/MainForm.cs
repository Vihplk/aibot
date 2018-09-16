using System;
using System.Windows.Forms;
using AIBot.Game.Logic;
using AIBot.Game.UC;

namespace AIBot.Game
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            tabPage1.Controls.Add(new GameStart(this,Enums.StressLevel.STRESS_LEVEL_1));
            tabPage2.Controls.Add(new GameStart(this,Enums.StressLevel.STRESS_LEVEL_2));
            tabPage3.Controls.Add(new GameStart(this,Enums.StressLevel.STRESS_LEVEL_3));
            tabPage4.Controls.Add(new GameStart(this,Enums.StressLevel.ANXIETY));
            tabPage5.Controls.Add(new GameStart(this,Enums.StressLevel.DEPRESSION));
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
