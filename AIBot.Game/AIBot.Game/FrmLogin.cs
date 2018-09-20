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
<<<<<<< HEAD
            var response = HttpRequester.Get($"http://localhost:5500/api/sessions/game/{txtSession.Text}");
           var gameType = (Enums.StressLevel) Convert.ToInt32(response);
=======
            var response = HttpRequester.Get($"{Globalconfig.ApiEndPoint}/api/sessions/game/{txtSession.Text}");
            var gameType = (Enums.StressLevel)Convert.ToInt32(response);
>>>>>>> 48322bc5f92d8da22be2e3b7ac6b151aa0766728
            this.Hide();
            new MainForm((Enums.StressLevel)gameType).Show();
        }
    }
}
