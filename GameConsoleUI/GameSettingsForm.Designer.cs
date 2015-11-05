using System.Windows.Forms;

namespace GameConsoleUI
{
    public partial class GameSettingsForm
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

        private void InitializeComponent()
        {
            this.Player1Label = new System.Windows.Forms.Label();
            this.player1NameTextBox = new System.Windows.Forms.TextBox();
            this.player2NameTextBox = new System.Windows.Forms.TextBox();
            this.BoardHeightLabel = new System.Windows.Forms.Label();
            this.OkButton = new System.Windows.Forms.Button();
            this.numericUpDownRows = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownCols = new System.Windows.Forms.NumericUpDown();
            this.Player2Label = new System.Windows.Forms.Label();
            this.BoardWidthLabel = new System.Windows.Forms.Label();
            this.CancelButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCols)).BeginInit();
            this.SuspendLayout();
            // 
            // Player1Label
            // 
            this.Player1Label.AutoSize = true;
            this.Player1Label.Location = new System.Drawing.Point(38, 34);
            this.Player1Label.Name = "Player1Label";
            this.Player1Label.Size = new System.Drawing.Size(64, 17);
            this.Player1Label.TabIndex = 3;
            this.Player1Label.Text = "Player 1:";
            // 
            // player1NameTextBox
            // 
            this.player1NameTextBox.Location = new System.Drawing.Point(120, 31);
            this.player1NameTextBox.Name = "player1NameTextBox";
            this.player1NameTextBox.Size = new System.Drawing.Size(136, 22);
            this.player1NameTextBox.TabIndex = 1;
            this.player1NameTextBox.Text = "Player1";
            // 
            // player2NameTextBox
            // 
            this.player2NameTextBox.Location = new System.Drawing.Point(120, 78);
            this.player2NameTextBox.Name = "player2NameTextBox";
            this.player2NameTextBox.Size = new System.Drawing.Size(136, 22);
            this.player2NameTextBox.TabIndex = 2;
            this.player2NameTextBox.Text = "Player2";
            // 
            // BoardHeightLabel
            // 
            this.BoardHeightLabel.AutoSize = true;
            this.BoardHeightLabel.Location = new System.Drawing.Point(38, 155);
            this.BoardHeightLabel.Name = "BoardHeightLabel";
            this.BoardHeightLabel.Size = new System.Drawing.Size(152, 17);
            this.BoardHeightLabel.TabIndex = 7;
            this.BoardHeightLabel.Text = "Board Height (in cells):";
            // 
            // OkButton
            // 
            this.OkButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OkButton.Location = new System.Drawing.Point(41, 243);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(83, 23);
            this.OkButton.TabIndex = 9;
            this.OkButton.Text = "OK";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // numericUpDownRows
            // 
            this.numericUpDownRows.Location = new System.Drawing.Point(208, 155);
            this.numericUpDownRows.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.numericUpDownRows.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numericUpDownRows.Name = "numericUpDownRows";
            this.numericUpDownRows.Size = new System.Drawing.Size(48, 22);
            this.numericUpDownRows.TabIndex = 10;
            this.numericUpDownRows.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // numericUpDownCols
            // 
            this.numericUpDownCols.Location = new System.Drawing.Point(208, 185);
            this.numericUpDownCols.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.numericUpDownCols.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numericUpDownCols.Name = "numericUpDownCols";
            this.numericUpDownCols.Size = new System.Drawing.Size(48, 22);
            this.numericUpDownCols.TabIndex = 11;
            this.numericUpDownCols.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // Player2Label
            // 
            this.Player2Label.AutoSize = true;
            this.Player2Label.Location = new System.Drawing.Point(38, 81);
            this.Player2Label.Name = "Player2Label";
            this.Player2Label.Size = new System.Drawing.Size(64, 17);
            this.Player2Label.TabIndex = 12;
            this.Player2Label.Text = "Player 2:";
            // 
            // BoardWidthLabel
            // 
            this.BoardWidthLabel.AutoSize = true;
            this.BoardWidthLabel.Location = new System.Drawing.Point(38, 185);
            this.BoardWidthLabel.Name = "BoardWidthLabel";
            this.BoardWidthLabel.Size = new System.Drawing.Size(147, 17);
            this.BoardWidthLabel.TabIndex = 13;
            this.BoardWidthLabel.Text = "Board Width (in cells):";
            // 
            // CancelButton
            // 
            this.CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelButton.Location = new System.Drawing.Point(161, 243);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(83, 23);
            this.CancelButton.TabIndex = 14;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // GameSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 278);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.BoardWidthLabel);
            this.Controls.Add(this.Player2Label);
            this.Controls.Add(this.numericUpDownCols);
            this.Controls.Add(this.numericUpDownRows);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.BoardHeightLabel);
            this.Controls.Add(this.player2NameTextBox);
            this.Controls.Add(this.player1NameTextBox);
            this.Controls.Add(this.Player1Label);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GameSettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Game Properties";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.gameSettingsForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCols)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Player1Label;
        private System.Windows.Forms.TextBox player1NameTextBox;
        private System.Windows.Forms.TextBox player2NameTextBox;
        private System.Windows.Forms.Label BoardHeightLabel;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.NumericUpDown numericUpDownRows;
        private System.Windows.Forms.NumericUpDown numericUpDownCols;
        private Label Player2Label;
        private Label BoardWidthLabel;
        private Button CancelButton;
    }
}