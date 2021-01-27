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
            GameReset();
        }

        private void GameReset()
        {
            force = 12;
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
                    int position = this.ClientSize.Width + rand.Next(100, 200) + (x.Width * 10);
                    x.Left = position;
                }



            }
            gameTimer.Start();

        }

        private void keyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space && Jumping == false)
                Jumping = true;


        }

        private void keyIsUp(object sender, KeyEventArgs e)
        {
            if (Jumping == true)
                Jumping = false;
            if (e.KeyCode == Keys.R && isGameOver == true)
                GameReset();
        }

        private void mainGameTimerEvent(object sender, EventArgs e)
        {
            Trex.Top += jumpSpeed;
            txtScore.Text = $"Score : " + score;
            if (Jumping == true && force < 0)
            {
                Jumping = false;
            }
            if (Jumping == true)
            {
                jumpSpeed = -12;
                force -= 1;
            }
            else
            {
                jumpSpeed = 12;
            }
            if(Trex.Top>275&&Jumping==false)
            {
                force = 12;
                Trex.Top = 278;
                jumpSpeed = 1;
            }

            foreach(Control x in this.Controls)
            {
                if(x is PictureBox&&(string)x.Tag=="Obstacle")
                {
                    x.Left -= obstacleSpeed;
                    if (x.Left < -100)
                    {
                        x.Left = this.ClientSize.Width + rand.Next(100, 200) + (x.Width * 10);
                        score++;
                    }
                 
                    if(x.Bounds.IntersectsWith(Trex.Bounds))
                    {
                        isGameOver = true;
                        txtScore.Text = $"Score" + score + "Press R to restart game";
                        GameReset();
                    }
                   

                }
                
               
                

            }
            
            




        }
    }
}
