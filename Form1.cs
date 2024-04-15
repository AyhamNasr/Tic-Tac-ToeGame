using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tic_Tac_ToeGame.Properties;

namespace Tic_Tac_ToeGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        byte Player1 = 0 , Player2 = 0 , Counter = 0;

        void ScoorBord()
        {
            lblPlayer1Scoore.Text = Convert.ToString(Player1);
            lblPlayer2Scoor.Text = Convert.ToString(Player2);

        }
        bool CheckBtnWin(Button btn1 , Button btn2 , Button btn3)
        {
            if (btn1.Tag.ToString() != "?" & btn2.Tag.ToString() != "?" & btn3.Tag.ToString() != "?"
                & (btn1.Tag == btn2.Tag) & (btn2.Tag == btn3.Tag))
            {
                btn1.BackColor = Color.YellowGreen;
                btn2.BackColor = Color.YellowGreen;
                btn3.BackColor = Color.YellowGreen;

                lblWinner.Text = lblPlayer.Text;

                if (lblWinner.Text.ToString() == "Player1")
                {
                    Player1++;
                    ScoorBord();
                }

                if (lblWinner.Text.ToString() == "Player2")
                {
                    Player2++;
                    ScoorBord();
                }
                MessageBox.Show("Game Over", "Confagulation", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return true;

            }
            else
            {
                return false;
            }
        }

        void CheckWin()
        {
            if (CheckBtnWin(button2, button3, button4))
                return;
            if (CheckBtnWin(button5, button6, button7))
                return;
            if (CheckBtnWin(button8, button9, button10))
                return;
            if (CheckBtnWin(button2, button5, button8))
                return;
            if (CheckBtnWin(button3, button6, button9))
                return;
            if (CheckBtnWin(button4, button7, button10))
                return;
            if (CheckBtnWin(button2, button6, button10))
                return;
            if (CheckBtnWin(button4, button6, button8))
                return;
            else
            {
                if(Counter == 9)
                lblWinner.Text = "No Winner";
                else
                    lblWinner.Text = "In Progress";

            }
        }
        void PlaceChoose(Button btn)
        {
            if(btn.Tag.ToString() == "?" )
            {
                if(lblPlayer.Text == "Player1")
                {
                    btn.Image = Resources.X;
                    btn.Tag = "X";
                    Counter++;
                    CheckWin();
                    lblPlayer.Text = "Player2";
                }
                else
                {
                    btn.Image = Resources.O;
                    btn.Tag = "O";
                    Counter++;
                    CheckWin();
                    lblPlayer.Text = "Player1";
                }
            }
            else
            MessageBox.Show("You Cant Choose Here", "Invalid Choose", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        
        void ResetButton(Button btn)
        {
            btn.Image = Resources.question_mark_96;
            btn.BackColor = Color.Black;
            btn.Tag = "?";

        }
        void Restart()
        {
            ResetButton(button2);
            ResetButton(button3);
            ResetButton(button4);
            ResetButton(button5);
            ResetButton(button6);
            ResetButton(button7);
            ResetButton(button8);
            ResetButton(button9);
            ResetButton(button10);

            lblPlayer.Text = "Player1";
            lblWinner.Text = "In Progress";
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Color White = Color.FromArgb(255, 255, 255, 255);

            Pen Pen = new Pen(White);

            Pen.Width = 10;

            Pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            Pen.EndCap   = System.Drawing.Drawing2D.LineCap.Round;

            e.Graphics.DrawLine(Pen, 550, 200, 550, 500);
            e.Graphics.DrawLine(Pen, 700, 200, 700, 500);
            e.Graphics.DrawLine(Pen, 400, 300, 850, 300);
            e.Graphics.DrawLine(Pen, 400, 400, 850, 400);
            

        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            Restart();
        }

        private void button_Click(object sender, EventArgs e)
        {
            PlaceChoose((Button)sender);
        }

        
    }
}
