using System.Windows.Forms;
using System.Collections.Generic;

namespace GameConsoleUI
{
    public partial class GameBoardForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusCurrentPlayer = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusFirstPlayer = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusSecondPlayer = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.gameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startANewGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startANewTournirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.propertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.howToPlayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBoxAbout = new System.Windows.Forms.PictureBox();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAbout)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusCurrentPlayer,
            this.toolStripStatusFirstPlayer,
            this.toolStripStatusSecondPlayer});
            this.statusStrip1.Location = new System.Drawing.Point(0, 424);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 13, 0);
            this.statusStrip1.Size = new System.Drawing.Size(405, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripStatusLabel1.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(85, 17);
            this.toolStripStatusLabel1.Text = "Current Player:";
            // 
            // toolStripStatusCurrentPlayer
            // 
            this.toolStripStatusCurrentPlayer.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripStatusCurrentPlayer.Name = "toolStripStatusCurrentPlayer";
            this.toolStripStatusCurrentPlayer.Size = new System.Drawing.Size(45, 17);
            this.toolStripStatusCurrentPlayer.Text = "Player1";
            // 
            // toolStripStatusFirstPlayer
            // 
            this.toolStripStatusFirstPlayer.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripStatusFirstPlayer.Name = "toolStripStatusFirstPlayer";
            this.toolStripStatusFirstPlayer.Size = new System.Drawing.Size(90, 17);
            this.toolStripStatusFirstPlayer.Text = "          Player1: 0,";
            // 
            // toolStripStatusSecondPlayer
            // 
            this.toolStripStatusSecondPlayer.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripStatusSecondPlayer.Name = "toolStripStatusSecondPlayer";
            this.toolStripStatusSecondPlayer.Size = new System.Drawing.Size(57, 17);
            this.toolStripStatusSecondPlayer.Text = "Player2: 0";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gameToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(405, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.MouseEnter += new System.EventHandler(this.menuStrip1_MouseEnter);
            this.menuStrip1.MouseLeave += new System.EventHandler(this.menuStrip1_MouseLeave);
            // 
            // gameToolStripMenuItem
            // 
            this.gameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startANewGameToolStripMenuItem,
            this.startANewTournirToolStripMenuItem,
            this.propertiesToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.gameToolStripMenuItem.Name = "gameToolStripMenuItem";
            this.gameToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.gameToolStripMenuItem.Text = "Game";
            // 
            // startANewGameToolStripMenuItem
            // 
            this.startANewGameToolStripMenuItem.Name = "startANewGameToolStripMenuItem";
            this.startANewGameToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.startANewGameToolStripMenuItem.Text = "Start a New Game";
            this.startANewGameToolStripMenuItem.Click += new System.EventHandler(this.startANewGameToolStripMenuItem_Click);
            // 
            // startANewTournirToolStripMenuItem
            // 
            this.startANewTournirToolStripMenuItem.Name = "startANewTournirToolStripMenuItem";
            this.startANewTournirToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.startANewTournirToolStripMenuItem.Text = "Start a New Tournir";
            this.startANewTournirToolStripMenuItem.Click += new System.EventHandler(this.startANewTournirToolStripMenuItem_Click);
            // 
            // propertiesToolStripMenuItem
            // 
            this.propertiesToolStripMenuItem.Name = "propertiesToolStripMenuItem";
            this.propertiesToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.propertiesToolStripMenuItem.Text = "Properties...";
            this.propertiesToolStripMenuItem.Click += new System.EventHandler(this.propertiesToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.howToPlayToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // howToPlayToolStripMenuItem
            // 
            this.howToPlayToolStripMenuItem.Name = "howToPlayToolStripMenuItem";
            this.howToPlayToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.howToPlayToolStripMenuItem.Text = "How To Play?";
            this.howToPlayToolStripMenuItem.Click += new System.EventHandler(this.howToPlayToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // pictureBoxAbout
            // 
            this.pictureBoxAbout.BackColor = System.Drawing.Color.White;
            this.pictureBoxAbout.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBoxAbout.Image = global::GameConsoleUI.Properties.Resources.AboutPicture;
            this.pictureBoxAbout.Location = new System.Drawing.Point(70, 113);
            this.pictureBoxAbout.Name = "pictureBoxAbout";
            this.pictureBoxAbout.Size = new System.Drawing.Size(268, 197);
            this.pictureBoxAbout.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxAbout.TabIndex = 2;
            this.pictureBoxAbout.TabStop = false;
            this.pictureBoxAbout.Visible = false;
            this.pictureBoxAbout.Click += new System.EventHandler(this.pictureBoxAbout_Click);
            this.pictureBoxAbout.MouseEnter += new System.EventHandler(this.pictureBoxAbout_MouseEnter);
            this.pictureBoxAbout.MouseLeave += new System.EventHandler(this.pictureBoxAbout_MouseLeave);
            // 
            // GameBoardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(405, 446);
            this.Controls.Add(this.pictureBoxAbout);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GameBoardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "4 in a Row!!";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.gameForm_FormClosing);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAbout)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripStatusLabel toolStripStatusCurrentPlayer;
        private ToolStripStatusLabel toolStripStatusSecondPlayer;
        private ToolStripStatusLabel toolStripStatusFirstPlayer;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem gameToolStripMenuItem;
        private ToolStripMenuItem startANewGameToolStripMenuItem;
        private ToolStripMenuItem startANewTournirToolStripMenuItem;
        private ToolStripMenuItem propertiesToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem howToPlayToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private PictureBox pictureBoxAbout;
    }
}