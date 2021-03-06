﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tic_Tac_Toe
{
    public partial class MainForm : Form
    {
        #region Variables
        private readonly List<Button> ButtonList = new List<Button>();
        private int playerScore = 0;
        private int aIScore = 0;
        private int draw = 0;
        private bool playerWin;
        private bool aIWin;
        Random random = new Random();
        #endregion

        #region Constructor
        public MainForm()
        {
            InitializeComponent();

            playerLabel.Text = NameForm.SetPlayerName;

            fillButtonList(ButtonList);
        }
        #endregion

        #region Form events
        private void button_Click(object sender, EventArgs e)
        {
            try
            {
                var button = (Button)sender;
                button.Text = "X";
                button.Enabled = false;
                ButtonList.Remove(button);
                aIMove();
                checkWin();
            }
            catch (InvalidCastException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        #endregion

        #region Methods
        private void aIMove()
        {
            if (aIBlock() == null)
            {
                if (ButtonList.Count > 0)
                {
                    int index = random.Next(ButtonList.Count);
                    Button button = ButtonList[index];

                    if (button.Text == "" && button.Enabled)
                    {
                        button.Text = "O";
                        button.Enabled = false;
                        ButtonList.Remove(button);
                    }
                }
            }
        }

        private string aIBlock()
        {
            #region Horizontal rows
            // First row
            if ((button1.Text == "") && (button2.Text == "X") && (button3.Text == "X"))
            {
                button1.Enabled = false;
                ButtonList.Remove(button1);
                return button1.Text = "O";
            }
            if ((button1.Text == "X") && (button2.Text == "") && (button3.Text == "X"))
            {
                button2.Enabled = false;
                ButtonList.Remove(button2);
                return button2.Text = "O";
            }
            if ((button1.Text == "X") && (button2.Text == "X") && (button3.Text == ""))
            {
                button3.Enabled = false;
                ButtonList.Remove(button3);
                return button3.Text = "O";
            }

            // Second row
            if ((button4.Text == "") && (button5.Text == "X") && (button6.Text == "X"))
            {
                button4.Enabled = false;
                ButtonList.Remove(button4);
                return button4.Text = "O";
            }
            if ((button4.Text == "X") && (button5.Text == "") && (button6.Text == "X"))
            {
                button5.Enabled = false;
                ButtonList.Remove(button5);
                return button5.Text = "O";
            }
            if ((button4.Text == "X") && (button5.Text == "X") && (button6.Text == ""))
            {
                button6.Enabled = false;
                ButtonList.Remove(button6);
                return button6.Text = "O";
            }

            // Third row
            if ((button7.Text == "") && (button8.Text == "X") && (button9.Text == "X"))
            {
                button7.Enabled = false;
                ButtonList.Remove(button7);
                return button7.Text = "O";
            }
            if ((button7.Text == "X") && (button8.Text == "") && (button9.Text == "X"))
            {
                button8.Enabled = false;
                ButtonList.Remove(button8);
                return button8.Text = "O";
            }

            if ((button7.Text == "X") && (button8.Text == "X") && (button9.Text == ""))
            {
                button9.Enabled = false;
                ButtonList.Remove(button9);
                return button9.Text = "O";
            }
            #endregion

            #region Vertical rows
            // First row
            if ((button1.Text == "") && (button4.Text == "X") && (button7.Text == "X"))
            {
                button1.Enabled = false;
                ButtonList.Remove(button1);
                return button1.Text = "O";
            }
            if ((button1.Text == "X") && (button4.Text == "") && (button7.Text == "X"))
            {
                button4.Enabled = false;
                ButtonList.Remove(button4);
                return button4.Text = "O";
            }
            if ((button1.Text == "X") && (button4.Text == "X") && (button7.Text == ""))
            {
                button7.Enabled = false;
                ButtonList.Remove(button7);
                return button7.Text = "O";
            }

            // Second row
            if ((button2.Text == "") && (button5.Text == "X") && (button8.Text == "X"))
            {
                button2.Enabled = false;
                ButtonList.Remove(button2);
                return button2.Text = "O";
            }
            if ((button2.Text == "X") && (button5.Text == "") && (button8.Text == "X"))
            {
                button5.Enabled = false;
                ButtonList.Remove(button5);
                return button5.Text = "O";
            }
            if ((button2.Text == "X") && (button5.Text == "X") && (button8.Text == ""))
            {
                button8.Enabled = false;
                ButtonList.Remove(button8);
                return button8.Text = "O";
            }

            // Third row
            if ((button3.Text == "") && (button6.Text == "X") && (button9.Text == "X"))
            {
                button3.Enabled = false;
                ButtonList.Remove(button3);
                return button3.Text = "O";
            }
            if ((button3.Text == "X") && (button6.Text == "") && (button9.Text == "X"))
            {
                button6.Enabled = false;
                ButtonList.Remove(button6);
                return button6.Text = "O";
            }
            if ((button3.Text == "X") && (button6.Text == "X") && (button9.Text == ""))
            {
                button9.Enabled = false;
                ButtonList.Remove(button9);
                return button9.Text = "O";
            }
            #endregion

            #region Diagonals
            // First diagonal
            if ((button1.Text == "") && (button5.Text == "X") && (button9.Text == "X"))
            {
                button1.Enabled = false;
                ButtonList.Remove(button1);
                return button1.Text = "O";
            }
            if ((button1.Text == "X") && (button5.Text == "") && (button9.Text == "X"))
            {
                button5.Enabled = false;
                ButtonList.Remove(button5);
                return button5.Text = "O";
            }
            if ((button1.Text == "X") && (button5.Text == "X") && (button9.Text == ""))
            {
                button9.Enabled = false;
                ButtonList.Remove(button9);
                return button9.Text = "O";
            }

            // Second diagonal
            if ((button3.Text == "") && (button5.Text == "X") && (button7.Text == "X"))
            {
                button3.Enabled = false;
                ButtonList.Remove(button3);
                return button3.Text = "O";
            }
            if ((button3.Text == "X") && (button5.Text == "") && (button7.Text == "X"))
            {
                button5.Enabled = false;
                ButtonList.Remove(button5);
                return button5.Text = "O";
            }
            if ((button3.Text == "X") && (button5.Text == "X") && (button7.Text == ""))
            {
                button7.Enabled = false;
                ButtonList.Remove(button7);
                return button7.Text = "O";
            }
            #endregion

            return null;
        } 

        private void checkWin()
        {
            #region Check player win
            if (button1.Text == "X" && button2.Text == "X" && button3.Text == "X"
                || button4.Text == "X" && button5.Text == "X" && button6.Text == "X"
                || button7.Text == "X" && button8.Text == "X" && button9.Text == "X"
                || button1.Text == "X" && button4.Text == "X" && button7.Text == "X"
                || button2.Text == "X" && button5.Text == "X" && button8.Text == "X"
                || button3.Text == "X" && button6.Text == "X" && button9.Text == "X"
                || button1.Text == "X" && button5.Text == "X" && button9.Text == "X"
                || button3.Text == "X" && button5.Text == "X" && button7.Text == "X")
            {
                playerScore++;
                playerResult.Text = playerScore.ToString();
                aIResult.Text = aIScore.ToString();
                drawResultLabel.Text = draw.ToString();
                MessageBox.Show(NameForm.SetPlayerName + " wins! ");
                playerWin = true;
                playAgain();
            }
            #endregion

            #region Check AI win
            if (button1.Text == "O" && button2.Text == "O" && button3.Text == "O"
                || button4.Text == "O" && button5.Text == "O" && button6.Text == "O"
                || button7.Text == "O" && button8.Text == "O" && button9.Text == "O"
                || button1.Text == "O" && button4.Text == "O" && button7.Text == "O"
                || button2.Text == "O" && button5.Text == "O" && button8.Text == "O"
                || button3.Text == "O" && button6.Text == "O" && button9.Text == "O"
                || button1.Text == "O" && button5.Text == "O" && button9.Text == "O"
                || button3.Text == "O" && button5.Text == "O" && button7.Text == "O")
            {
                aIScore++;
                aIResult.Text = aIScore.ToString();
                playerResult.Text = playerScore.ToString();
                drawResultLabel.Text = draw.ToString();
                MessageBox.Show("AI wins!");
                aIWin = true;
                playAgain();
            }
            #endregion

            #region Result is draw
            playerWin = false;
            aIWin = false;
            if (ButtonList.Count == 0 && !aIWin && !playerWin)
            {
                MessageBox.Show("Draw!");
                draw++;
                playerResult.Text = playerScore.ToString();
                aIResult.Text = aIScore.ToString();
                drawResultLabel.Text = draw.ToString();
                playAgain();
            }
            #endregion
        }

        private void playAgain()
        {
            foreach (Control kontrola in this.Controls)
            {
                if (kontrola is Button)
                {
                    ((Button)kontrola).Enabled = true;
                    ((Button)kontrola).Text = "";
                }
            }

            fillButtonList(ButtonList);
        }

        private void fillButtonList(List<Button> list)
        {
            list.Clear();
            list.Add(button1);
            list.Add(button2);
            list.Add(button3);
            list.Add(button4);
            list.Add(button5);
            list.Add(button6);
            list.Add(button7);
            list.Add(button8);
            list.Add(button9);
        }
        #endregion
    }
}
