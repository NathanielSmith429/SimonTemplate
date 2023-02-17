using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrayNotify;
using System.Media;
using System.Threading;

namespace SimonSays
{
    public partial class MenuScreen : UserControl
    {
        SoundPlayer background = new SoundPlayer(Properties.Resources.theme);
     
        public MenuScreen()
        {
            background.Play();
            InitializeComponent();
        }
        private void newButton_Click(object sender, EventArgs e)
        {
            background.Stop();
    
            Form1.ChangeScreen(this, new GameScreen());
           
        }
        private void exitButton_Click(object sender, EventArgs e)
        {
           Application.Exit();  
        }
    }
}
