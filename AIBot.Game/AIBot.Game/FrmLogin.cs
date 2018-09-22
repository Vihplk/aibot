using System;
using System.Windows.Forms;
using AIBot.Game.Logic;
using AIBot.Game.Utility;

namespace AIBot.Game
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

   
        private void btnEnter_Click(object sender, EventArgs e)
        {
            //var response = HttpRequester.Get($"{Globalconfig.ApiEndPoint}/api/sessions/game/{txtSession.Text}");
            //var gameType = (Enums.StressLevel)Convert.ToInt32(response);
            //this.Hide();    
            Console.Beep(700, 1000);
            new MainForm((Enums.StressLevel)5).Show();
        }
    }
}
