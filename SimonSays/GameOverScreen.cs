using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;

namespace SimonSays
{
    public partial class GameOverScreen : UserControl
    {
        public static List<int> highscore = new List<int>();
        SoundPlayer failed = new SoundPlayer(Properties.Resources.mission);

        public GameOverScreen()
        {
            InitializeComponent();
        }
        private void GameOverScreen_Load(object sender, EventArgs e)
        {
            highscore.Add(Form1.patterns.Count());
            highscore.Sort();
            highscore.Reverse();
            scoreLabel.Text = highscore[0].ToString();

            failed.Play();
            lengthLabel.Text = Form1.patterns.Count.ToString();
        }
        private void closeButton_Click(object sender, EventArgs e)
        {
            Form1.ChangeScreen(this, new MenuScreen());
        }
    }
}
