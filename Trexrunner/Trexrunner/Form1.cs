using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trexrunner
{
    public partial class Form1 : Form
    {
        bool Jumping = false;
        int force = 12;
        int jumpSpeed;
        int score = 0;
        int obstacleSpeed = 12;
        Random rand = new Random();
        int position;
        bool isGameOver = false;
      
     

        public Form1()
        {
            InitializeComponent();
        }

        private void GameReset()
        {
            obstacleSpeed = 12;
            jumpSpeed = 0;
            Jumping = false;
            score = 0;
            isGameOver = false;
            Trex.Top = 278;

            foreach(Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "Obstacle")
                {
                    int position = this.ClientSize.Width + rand.Next(500, 800) + (x.Width * 10);
                    x.Left = position;
                }



            }
            gameTimer.Start();

        }

        private void keyIsDown(object sender, KeyEventArgs e)
        {

        }

        private void keyIsUp(object sender, KeyEventArgs e)
        {

        }

        private void mainGameTimerEvent(object sender, EventArgs e)
        {

        }
    }
}
