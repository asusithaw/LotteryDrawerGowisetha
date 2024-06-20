using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LottaryResultsGowisetha
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
            

        private int GetNumberCount()
        {
            var winningNumberArray = new string[4];
            var checkingNumberArray = new string[4];

            winningNumberArray[0] = txtWinningNoOne.Text.Trim();
            winningNumberArray[1] = txtWinningNoTwo.Text.Trim();
            winningNumberArray[2] = txtWinningNoThree.Text.Trim();
            winningNumberArray[3] = txtWinningNoFour.Text.Trim();

            checkingNumberArray[0] = txtCheckingNoOne.Text.Trim();
            checkingNumberArray[1] = txtCheckingNoTwo.Text.Trim();
            checkingNumberArray[2] = txtCheckingNoThree.Text.Trim();
            checkingNumberArray[3] = txtCheckingNoFour.Text.Trim();

            int count = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (checkingNumberArray[i] == winningNumberArray[j])
                    {
                        winningNumberArray[j] = "";
                        count++;
                        break;
                    }
                }
            }

            return count;        
        }

        private bool IsLetterCorrect()
        {
            if (txtWinningLetter.Text.ToLower().Trim() == txtCheckingLetter.Text.ToLower().Trim())
                return true;

            return false;
        }

        private bool IsSecondWinningAvailable() 
        {
            if (txtSecondChanceCheckingNoOne.Text.Trim() == txtSecondChanceWinningNoOne.Text.Trim() &&
               txtSecondChanceCheckingNoTwo.Text.Trim() == txtSecondChanceWinningNoTwo.Text.Trim() &&
               txtSecondChanceCheckingNoThree.Text.Trim() == txtSecondChanceWinningNoThree.Text.Trim() &&
                txtSecondChanceCheckingNoFour.Text.Trim() == txtSecondChanceWinningNoFour.Text.Trim() &&
                txtSecondChanceCheckingNoFive.Text.Trim() == txtSecondChanceWinningNoFive.Text.Trim())
                return true;

            return false;
        }



        private void btnCheck_Click(object sender, EventArgs e)
        {
            
            if (IsLetterCorrect() && GetNumberCount() == 4)
            {
                txtOutput.Text = "Super Prize ";
            }
            else if (GetNumberCount() == 4)
            {
                txtOutput.Text = "Rs. 2,000,000 ";
            }
            else if (IsLetterCorrect() && GetNumberCount() == 3)
            {
                txtOutput.Text = "You Won Rs. 250,000 ";
            }
            else if (GetNumberCount() == 3)
            {
                txtOutput.Text = "You Won Rs. 5,000 ";
            }
            else if (IsLetterCorrect() && GetNumberCount() == 2)
            {
                txtOutput.Text = "You Won Rs. 2,000 ";
            }
            else if (GetNumberCount() == 2)
            {
                txtOutput.Text = "You Won Rs. 200 ";
            }
            else if (IsLetterCorrect() && GetNumberCount() == 1)
            {
                txtOutput.Text = "You Won Rs. 200 ";
            }
            else if (GetNumberCount() == 1)
            {
                txtOutput.Text = "You Won Rs. 40 ";
            }
            else if (IsLetterCorrect())
            {
                txtOutput.Text = "You Won Rs. 40 ";
            }
            else
            {
                txtOutput.Text = "No Win";
            }

            if (IsSecondWinningAvailable())
            {
                if (txtOutput.Text == "No Win")
                {
                    txtOutput.Text = "You Won Rs.100,000 By Lakshapathi";
                }
                else
                {
                    txtOutput.Text += " & Rs.100,000 By Lakshapathi";
                }
            }       
            
        }

        
    }
}
