using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;
using System.Drawing.Drawing2D;
using System.Threading;
using System.Timers;

namespace SimonSays
{
    public partial class GameScreen : UserControl
    {
        SoundPlayer greenSound = new SoundPlayer(Properties.Resources.regular); // Reciving all sound files for use
        SoundPlayer redSound = new SoundPlayer(Properties.Resources.Lead);
        SoundPlayer yellowSound = new SoundPlayer(Properties.Resources.ceramic);
        SoundPlayer blueSound = new SoundPlayer(Properties.Resources.boost);
        SoundPlayer mistakeSound = new SoundPlayer(Properties.Resources.mistake);
        
        int guess = 0; // used to confirm if player has gone
        int counter = 1; // To show pattern length one screen
        Random randGen = new Random();

        public GameScreen()
        {
            InitializeComponent();
        }
        private void GameScreen_Load(object sender, EventArgs e)
        {
            GraphicsPath circlePath = new GraphicsPath();
            circlePath.AddEllipse(5, 5, 100, 100);    
            Region buttonRegion = new Region(circlePath);

            greenButton.Region = buttonRegion;
            blueButton.Region = buttonRegion;   
            yellowButton.Region = buttonRegion;
            redButton.Region = buttonRegion;

            Form1.patterns.Clear();
            this.Refresh();
            Thread.Sleep(500);
            ComputerTurn();

        }
        private void ComputerTurn()
        {
            Form1.patterns.Add(randGen.Next(0, 4));
            centerLabel.Text = counter.ToString();
            counter++;
            
            for (int i = 0; i < Form1.patterns.Count(); i++) // displaying the colour of buttons in the pattern order
                                                             // using a number between 0-3 to assign a value that corresponds with a colour
            {
                if (Form1.patterns[i] == 0) // green
                {
                    greenButton.BackColor = Color.LightGreen;
                    Refresh();
                    greenSound.Play();
                    Thread.Sleep(500);
                    greenButton.BackColor = Color.ForestGreen;
                    Refresh();
                    Thread.Sleep(250);
                }
                else if (Form1.patterns[i] == 1) // red
                {
                    redButton.BackColor = Color.Pink;
                    Refresh();
                    redSound.Play();
                    Thread.Sleep(500);
                    redButton.BackColor = Color.DarkRed;
                    Refresh();
                    Thread.Sleep(250);
                }
                else if (Form1.patterns[i] == 2) //yellow
                {
                    yellowButton.BackColor = Color.LightYellow;
                    Refresh();
                    yellowSound.Play();
                    Thread.Sleep(500);
                    yellowButton.BackColor = Color.Goldenrod;
                    Refresh();
                    Thread.Sleep(250);

                }
                else if (Form1.patterns[i] == 3) //blue
                {
                    blueButton.BackColor = Color.LightBlue;
                    Refresh();
                    blueSound.Play();
                    Thread.Sleep(500);
                    blueButton.BackColor = Color.DarkBlue;
                    Refresh();
                    Thread.Sleep(250);
                }
            }
           
            guess = 0; 
        }
        private void greenButton_Click(object sender, EventArgs e) 
        {
            int green = 0;
            if (Form1.patterns[guess] == 0) // if the element at guess = 0, the button is green and you must click green
            {
                greenButton.BackColor = Color.LightGreen;
                Refresh();
                greenSound.Play();
                Thread.Sleep(200);
                greenButton.BackColor = Color.ForestGreen;
                Refresh();
                guess++;
              
                if (guess == Form1.patterns.Count()) // if this was the full pattern, jump back to computer turn
                {
                    Refresh();
                    Thread.Sleep(1000);
                    ComputerTurn();
                }
            }
            else // if wrong colour guessed, the game ends
            {
                GameOver();
            }
        }
        private void redButton_Click(object sender, EventArgs e)
        {
            int red = 1;
            if (Form1.patterns[guess] == 1) // if the element at guess = 1, the button is red and you must click red
            {
                redButton.BackColor = Color.Pink;
                Refresh();
                redSound.Play();
                Thread.Sleep(200);
                redButton.BackColor = Color.DarkRed;
                Refresh();
                guess++;
                if (guess == Form1.patterns.Count()) // if this was the full pattern, jump back to computer turn
                {
                    Refresh();
                    Thread.Sleep(1000);
                    ComputerTurn();
                }
            }
            else // if wrong colour guessed, the game ends
            {
                GameOver();
            }
        }
        private void blueButton_Click(object sender, EventArgs e)
        {
            int blue = 3;
            if (Form1.patterns[guess] == 3) // if the element at guess = 3, the button is blue and you must click blue
            {
                blueButton.BackColor = Color.LightBlue;
                Refresh();
                blueSound.Play();
                Thread.Sleep(200);
                blueButton.BackColor = Color.DarkBlue;
                Refresh();
                guess++;
                if (guess == Form1.patterns.Count()) // if this was the full pattern, jump back to computer turn
                {
                    Refresh();
                    Thread.Sleep(1000);
                    ComputerTurn();
                }

            }
            else // if wrong colour guessed, the game ends
            {
                GameOver(); 
            }
        }
        private void yellowButton_Click(object sender, EventArgs e)
        {
            int yellow = 2;
            if (Form1.patterns[guess] == 2) // if the element at guess = 2, the button is yellow and you must click yellow
            {
                yellowButton.BackColor = Color.LightYellow;
                Refresh();
                yellowSound.Play();
                Thread.Sleep(200); ;
                yellowButton.BackColor = Color.Goldenrod;
                Refresh();
                guess++;
                if (guess == Form1.patterns.Count()) // if this was the full pattern, jump back to computer turn
                {
                    Refresh();
                    Thread.Sleep(1000);
                    ComputerTurn();
                }
            }
            else // if wrong colour guessed, the game ends
            {
                GameOver();
            }
        }
        public void GameOver()
        {
            mistakeSound.Play();
            Form1.ChangeScreen(this, new GameOverScreen());
        }
    }
}
