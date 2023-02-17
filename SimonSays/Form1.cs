using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Media;
using System.Drawing.Drawing2D;
using System.IO;

namespace SimonSays
{
    //// System.Windows.Media.MediaPlayer blipSound = new System.Windows.Media.MediaPlayer();
    //InitializeComponent();
    //background_music.Open(new Uri(Application.StartupPath + "/Resources/backgorund_music.wav"));
    //        background_music.MediaEnded += new EventHandler(backMedia_music_MediaEnded);
    //private void backMedia_MediaEnded(object sender, EventArgs e)
    //{
    //    backMedia.Stop();
    //    backMedia.Play();
    //}
    public partial class Form1 : Form
    {
        public static List <int> patterns = new List <int>();

        
      

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
  
            Form1.ChangeScreen(this, new MenuScreen());
  
        }

        public static void ChangeScreen(object sender, UserControl next)
        {
            Form f; 

            if (sender is Form)
            {
                f = (Form)sender;
            }
            else
            {
                UserControl current = (UserControl)sender;
                f = current.FindForm();
                f.Controls.Remove(current);
            }

            next.Location = new Point((f.ClientSize.Width - next.Width) / 2,
                (f.ClientSize.Height - next.Height) / 2);

            f.Controls.Add(next);
            next.Focus();
        }
    }
}
