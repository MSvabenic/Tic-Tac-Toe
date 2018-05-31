using System;
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
        #endregion

        #region Constructor
        public MainForm()
        {
            InitializeComponent();

            playerLabel.Text = NameForm.SetPlayerName;

            playAgain();
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
                aIMove(sender, e);
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
        private void aIMove(object sender, EventArgs e)
        {
            foreach (Button button in ButtonList)
            {
                if (button.Text == "" && button.Enabled)
                {
                    button.Text = "O";
                    button.Enabled = false;
                    break;
                }
            }
        }

        private void checkWin()
        {
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
                MessageBox.Show(NameForm.SetPlayerName + " wins! ");
                playerResult.Text = playerScore.ToString();
                aIResult.Text = aIScore.ToString();
                playAgain();
            }

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
                MessageBox.Show("AI wins!");
                playAgain();
            }
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
