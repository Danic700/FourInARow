using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GameLogic;

namespace GameConsoleUI
{
    /// <summary>
    /// This is the gamesettingsForm, where we have the options for the game.
    /// </summary>
    public partial class GameSettingsForm : Form
    {
        // Const Members
        private const string k_ComputerPlayerName = "Computer";

        // Data Members
        private bool m_UserWantsToPlay = false;

        // C'tor
        public GameSettingsForm()
        {
            this.InitializeComponent();
            this.InitUI();
        }

        // Public Properties
        public string FirstPlayerName
        {
            get { return this.player1NameTextBox.Text; }
        }

        public string SecondPlayerName
        {
            get
            {
                if (this.player2NameTextBox.Text.Equals("[Computer]"))
                {
                    return k_ComputerPlayerName;
                }
                else
                {
                    return this.player2NameTextBox.Text;
                }
            }
        }

        public int NumberOfRowsSelected
        {
            get { return (int)this.numericUpDownRows.Value; }
        }

        public int NumberOfColumnsSelected
        {
            get { return (int)this.numericUpDownCols.Value; }
        }

        public bool UserWantsToPlay
        {
            get { return this.m_UserWantsToPlay; }
        }
    
        // Public Methods

        // Private Methods
        private void InitUI()
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        // Events
        private void gameSettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
            this.m_UserWantsToPlay = false;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            this.Close();
            this.m_UserWantsToPlay = true;
        }
    }
}