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
    public partial class NameForm : Form
    {
        #region Variables
        public static string SetPlayerName;
        #endregion

        #region Constructor
        public NameForm()
        {
            InitializeComponent();
        }
        #endregion

        #region Form events
        private void acceptButton_Click(object sender, EventArgs e)
        {
            SetPlayerName = nameTextBox.Text == "" ? "Player" : nameTextBox.Text;

            var mainForm = new MainForm();

            mainForm.Show();

            this.Visible = false;
        }

        private void NameForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        #endregion
    }
}
