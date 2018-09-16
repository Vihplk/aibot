using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            //var response = HttpRequester.Get("http://localhost:5500/api/sessions/game/4FBFF349-7623-44D1-BE22-F866B48489B2");
            //var gameType = (Enums.StressLevel) Convert.ToInt32(response);
            //this.Hide();
            new MainForm((Enums.StressLevel) 2).Show();
        }
    }
}
