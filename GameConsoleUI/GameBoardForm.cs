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
    /// This is the GameBoardForm, this is wheere we make the cool coin animations and the flashing disco lights.
    /// </summary>
    public partial class GameBoardForm : Form
    {
        // Const Members
        private const int k_InlargeBoardWidthBy = 67;
        private const int k_InlargeBoardHeightBy = 75;
        private const int k_BoardSizeWidthAddition = 5;
        private const int k_BoardSizeHeightAddition = 40;
        private const int k_FirstPlayerScoreLabelWidthAddition = -60;
        private const int k_SecondPlayerScoreLabelWidthAddition = 10;
        private const int k_BoardCellLabelLoactionAdditionY = 70;
        private const int k_BoardCellLabelLoactionMultiplier = 67;
        private const int k_ColumnButtonLoactionAdditionX = 0;
        private const int k_ColumnButtonLocationMultiplierX = 67;
        private const int k_ColumnButtonLocationY = 0;
        private const int k_PlayerScoreLabelHeightAddition = -50;
        private const string k_ComputerPlayerName = "Computer";
        private const int k_DefaultValue = -1;
        private const string k_EmptyCell = " ";
        private const int k_FirstPlayerIndex = 0;
        private const int k_SecondPlayerIndex = 1;
        private const int k_AnimationInterval = 45;
        private const int k_WinningCellsFlash = 280;


        // Read-Only Members
        private readonly GameSettingsForm r_GameSettings = new GameSettingsForm();

        // Data Members
        private List<ColumnLabel> m_ColumnsButtons = new List<ColumnLabel>();
        private List<List<BoardCellLabel>> m_BoardCells = new List<List<BoardCellLabel>>();
        private bool m_UserDoesntWantAnotherRound = false;
        private Cursor m_RedCoinCursor = new Cursor(Properties.Resources.CoinRed.GetHicon());
        private Cursor m_YellowCoinCursor = new Cursor(Properties.Resources.CoinYellow.GetHicon());
        private int m_BoardCellRowToAnimate = k_DefaultValue;
        private int m_BoardCellColumnToAnimate = k_DefaultValue;
        private bool m_ContinueAnimation = false;
        private FourInARowGame m_GameLogic = null;
        private bool m_BoardHasNewSize = false;
        private bool m_MarkWinningCells = true;

        // C'tor
        public GameBoardForm()
        {
            this.InitializeComponent();
            this.Show();
        }

        // Public Properties
        public GameSettingsForm GameProperties
        {
            get { return this.r_GameSettings; }
        }

        // Public Methods
        public void RunGame()
        {
            this.r_GameSettings.ShowDialog();
            if (this.r_GameSettings.UserWantsToPlay == true)
            {
                this.m_GameLogic = new FourInARowGame(this.r_GameSettings.NumberOfRowsSelected, this.r_GameSettings.NumberOfColumnsSelected, this.r_GameSettings.FirstPlayerName, this.r_GameSettings.SecondPlayerName);
                this.InitUI();
            }
            else
            {
                this.Close();
            }
        }

        // Private Methods
        private void InitUI()
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.pictureBoxAbout.Visible = false;
            this.InitBoard();
            this.Cursor = this.m_RedCoinCursor;
        }

        private void SetScoreBoardStatusBar()
        {
            StringBuilder firstPlayerNameAndScore = new StringBuilder();
            firstPlayerNameAndScore.Append(this.m_GameLogic.Players[k_FirstPlayerIndex].Name);
            firstPlayerNameAndScore.Append(": ");
            firstPlayerNameAndScore.Append(this.m_GameLogic.Players[k_FirstPlayerIndex].PlayerScore);
            firstPlayerNameAndScore.Append(",");
            this.toolStripStatusFirstPlayer.Text = firstPlayerNameAndScore.ToString();
            StringBuilder secondPlayerNameAndScore = new StringBuilder();
            secondPlayerNameAndScore.Append(this.m_GameLogic.Players[k_SecondPlayerIndex].Name);
            secondPlayerNameAndScore.Append(": ");
            secondPlayerNameAndScore.Append(this.m_GameLogic.Players[k_SecondPlayerIndex].PlayerScore);
            this.toolStripStatusSecondPlayer.Text = secondPlayerNameAndScore.ToString();
        }

        private void InitBoard()
        {
            int windowWidth = (k_InlargeBoardWidthBy * this.m_GameLogic.GetNumberOfColumnsInBoard()) + k_BoardSizeWidthAddition;
            int windowHeight = (k_InlargeBoardHeightBy * (this.m_GameLogic.GetNumberOfRowsInBoard() + 1)) + k_BoardSizeHeightAddition;
            this.Size = new Size(windowWidth, windowHeight);
            this.InitCloumnsButtons();
            this.InitBoardMatrixLabels();
            this.SetScoreBoardStatusBar();
            this.UpdateCurrentPlayerStatusBar();
        }

        private void InitCloumnsButtons()
        {
            for (int Column = 0; Column < this.m_GameLogic.GetNumberOfColumnsInBoard(); Column++)
            {
                ColumnLabel columnButton = new ColumnLabel(Column);
                columnButton.Location = new Point((Column * k_ColumnButtonLocationMultiplierX) + k_ColumnButtonLoactionAdditionX, k_ColumnButtonLocationY);
                columnButton.Click += new System.EventHandler(this.columnButtonClicked_Clicked);
                this.m_ColumnsButtons.Add(columnButton);
                this.Controls.Add(columnButton);
            }
        }

        private void UpdateCurrentPlayerStatusBar()
        {
            this.toolStripStatusCurrentPlayer.Text = this.m_GameLogic.Players[this.m_GameLogic.PlayerIndex].Name;
        }
        
        private void InitBoardMatrixLabels()
        {
            for (int Row = 0; Row < this.m_GameLogic.GetNumberOfRowsInBoard(); Row++)
            {
                List<BoardCellLabel> RowCellLabels = new List<BoardCellLabel>();
                for (int Column = 0; Column < this.m_GameLogic.GetNumberOfColumnsInBoard(); Column++)
                {
                    BoardCellLabel boardcell = new BoardCellLabel(Row, Column);
                    boardcell.Location = new Point(Column * k_BoardCellLabelLoactionMultiplier, (Row * k_BoardCellLabelLoactionMultiplier) + k_BoardCellLabelLoactionAdditionY);
                    RowCellLabels.Add(boardcell);
                    this.Controls.Add(boardcell);
                }

                this.m_BoardCells.Add(RowCellLabels);
            }
        }

        private void RefreshBoard()
        {
            for (int Row = 0; Row < this.m_GameLogic.GameBoard.NumberOfRows; Row++)
            {
                for (int Column = 0; Column < this.m_GameLogic.GameBoard.NumberOfColumns; Column++)
                {
                    if (this.m_GameLogic.GameBoard.GetBoardCell(Row, Column).CoinInCell != null)
                    {
                        this.UpdateFormBoardCell(Row, Column, this.m_GameLogic.GameBoard.GetBoardCell(Row, Column).CoinInCell.CoinType);
                    }
                    else
                    {
                        this.UpdateFormBoardCell(Row, Column, null);
                    }
                }
            }

            this.UpdateCurrentPlayerStatusBar();
        }

        private void UpdateFormBoardCell(int i_CellRow, int i_CellColumn, Coin.eCoinType? i_CellCoin)
        {
            if (i_CellCoin == Coin.eCoinType.X)
            {
                this.m_BoardCells[i_CellRow][i_CellColumn].Image = Properties.Resources.FullCellRed;
            }
            else
            {
                if (i_CellCoin == Coin.eCoinType.O)
                {
                    this.m_BoardCells[i_CellRow][i_CellColumn].Image = Properties.Resources.FullCellYellow;
                }
                else
                {
                    this.m_BoardCells[i_CellRow][i_CellColumn].Image = Properties.Resources.EmptyCell;
                }
            }          
        }

        private void HandleBoardIsFull()
        {
            string TieMessage = string.Format("It's A Tie!!{0}Another Round?", Environment.NewLine);
            switch (MessageBox.Show(this, TieMessage, "End Of Game", MessageBoxButtons.YesNo))
            {
                case DialogResult.Yes:
                    this.PrepareNewRound();
                    break;

                default:
                    this.m_UserDoesntWantAnotherRound = true;
                    this.Close();
                    break;
            }
        }

        private void PrepareNewRound()
        {
            if (this.m_BoardHasNewSize == true)
            {
                this.PrepareNewRoundWithNewProperties();
                this.m_BoardHasNewSize = false;
            }
            else
            {
                this.m_GameLogic.PrepareNewRound();
                this.EnableAllColumnButtons();
                this.RefreshBoard();
            }
            m_MarkWinningCells = true;
            this.pictureBoxAbout.Visible = false;
        }

        private void EnableAllColumnButtons()
        {
            foreach (ColumnLabel button in this.m_ColumnsButtons)
            {
                button.Enabled = true;
            }
        }

        private void HandleGameWinner()
        {
            System.Timers.Timer timer = new System.Timers.Timer(k_WinningCellsFlash);
            timer.Elapsed += new System.Timers.ElapsedEventHandler(this.FlashingCoinstimer_Elapsed);
            timer.AutoReset = true;
            timer.Start();
            string WinMessage = string.Format("{0} Won!!{1}Another Round?", this.m_GameLogic.Players[this.m_GameLogic.WinnerIndex].Name, Environment.NewLine);
            switch (MessageBox.Show(this, WinMessage, "End Of Game", MessageBoxButtons.YesNo))
            {
                case DialogResult.Yes:
                    timer.Stop();
                    this.PrepareNewRound();
                    break;

                default:
                    timer.Stop();
                    this.m_UserDoesntWantAnotherRound = true;
                    this.Close();
                    break;
            }
        }

        private void PrepareNewTournir()
        {
            this.m_GameLogic.InitPlayersScore();
            this.SetScoreBoardStatusBar();
            this.PrepareNewRound();
        }

        private void AnimateCoinFall(int i_Column)
        {
            System.Timers.Timer timer = new System.Timers.Timer(k_AnimationInterval);
            timer.Elapsed += new System.Timers.ElapsedEventHandler(this.CoinAnimationtimer_Elapsed);
            Coin.eCoinType playerCoin = (this.m_GameLogic.PlayerIndex == k_FirstPlayerIndex) ? Coin.eCoinType.O : Coin.eCoinType.X;
            
            for (int Row = 0; Row < this.m_GameLogic.GetNumberOfRowsInBoard(); Row++)
            {
                if (this.m_GameLogic.IsNextCellInColumnEmpty(Row, i_Column) == true)
                {
                    this.m_ContinueAnimation = false;
                    this.m_BoardCellRowToAnimate = Row;
                    this.m_BoardCellColumnToAnimate = i_Column;
                    this.UpdateFormBoardCell(Row, i_Column, playerCoin);
                    this.Refresh();
                    timer.Start();
                    while (this.m_ContinueAnimation == false)
                    {
                    }

                    timer.Stop();
                }
                else
                {
                    break;
                }
            }
        }

        private void MarkWinningCells()
        {
            List<BoardCell> WinningCells = this.m_GameLogic.GetWinnerCells();
            foreach (BoardCell cell in WinningCells)
            {
                this.m_BoardCells[cell.CellRow][cell.CellColumn].Image = this.m_GameLogic.WinnerIndex == k_FirstPlayerIndex ? Properties.Resources.WinnerCellRed : Properties.Resources.WinnerCellYellow;            
            }
        }

        private void UnMarkWinningCells()
        {
            List<BoardCell> WinningCells = this.m_GameLogic.GetWinnerCells();
            foreach (BoardCell cell in WinningCells)
            {
                this.m_BoardCells[cell.CellRow][cell.CellColumn].Image = this.m_GameLogic.WinnerIndex == k_FirstPlayerIndex ? Properties.Resources.FullCellRed : Properties.Resources.FullCellYellow;
            }
        }

        private void ClearColumnLabels()
        {
            for (int Column = 0; Column < this.m_GameLogic.GetNumberOfColumnsInBoard(); Column++)
            {
                this.Controls.Remove(this.m_ColumnsButtons[Column]);
            }
        }

        private void ClearBoardCellLabels()
        {
            for (int Row = 0; Row < this.m_GameLogic.GetNumberOfRowsInBoard(); Row++)
            {
                for (int Column = 0; Column < this.m_GameLogic.GetNumberOfColumnsInBoard(); Column++)
                {
                    this.Controls.Remove(this.m_BoardCells[Row][Column]);
                }
            }
        }

        private void ClearForm()
        {
            this.ClearColumnLabels();
            this.ClearBoardCellLabels();
        }

        private void PrepareNewRoundWithNewProperties()
        {
            this.ClearForm();
            this.m_BoardCells.Clear();
            this.m_ColumnsButtons.Clear();
            this.m_GameLogic.SetNewRoundWithNewProperties(this.r_GameSettings.NumberOfRowsSelected, this.r_GameSettings.NumberOfColumnsSelected, this.r_GameSettings.FirstPlayerName, this.r_GameSettings.SecondPlayerName);
            this.InitBoard();
            this.Cursor = this.m_RedCoinCursor;
            this.pictureBoxAbout.Visible = false;
        }

        private bool PropertiesChanged()
        {
            return this.m_GameLogic.GetNumberOfColumnsInBoard() != this.r_GameSettings.NumberOfColumnsSelected || this.m_GameLogic.GetNumberOfRowsInBoard() != this.r_GameSettings.NumberOfRowsSelected
                || this.m_GameLogic.Players[k_FirstPlayerIndex].Name != this.r_GameSettings.FirstPlayerName || this.m_GameLogic.Players[k_SecondPlayerIndex].Name != this.r_GameSettings.SecondPlayerName;
        }

        // Events
        private void columnButtonClicked_Clicked(object sender, EventArgs e)
        {
            ColumnLabel ColumnClicked = sender as ColumnLabel;
            this.m_GameLogic.ProcessPlayerMove(ColumnClicked.ButtonColumnNumber);
            this.AnimateCoinFall(ColumnClicked.ButtonColumnNumber);
            if (this.m_GameLogic.IsColumnFull(ColumnClicked.ButtonColumnNumber))
            {
                ColumnClicked.Enabled = false;
            }

            this.RefreshBoard();
            if (this.m_GameLogic.IsThereAWinner() == true)
            {
                this.SetScoreBoardStatusBar();
                this.MarkWinningCells();
                this.HandleGameWinner();          
            }
            else
            {
                if (this.m_GameLogic.IsBoardFull() == true)
                {
                    this.HandleBoardIsFull();
                }
                else
                {
                    this.Cursor = (this.m_GameLogic.PlayerIndex == k_FirstPlayerIndex) ? this.m_RedCoinCursor : this.m_YellowCoinCursor;
                }
            }
        }

        private void gameForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (this.m_UserDoesntWantAnotherRound == true)
                {
                    Application.Exit();
                }
                else
                {
                    switch (MessageBox.Show(this, "Are you sure you want to exit?", "Exit", MessageBoxButtons.YesNo))
                    {
                        case DialogResult.No:
                            e.Cancel = true;
                            break;

                        default:
                            break;
                    }
                }
            }
        }

        private void startANewGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.PrepareNewRound();
        }

        private void startANewTournirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.PrepareNewTournir();
        }

        private void menuStrip1_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Arrow;
        }

        private void menuStrip1_MouseLeave(object sender, EventArgs e)
        {
            if (this.m_GameLogic != null)
            {
                this.Cursor = (this.m_GameLogic.PlayerIndex == k_FirstPlayerIndex) ? this.m_RedCoinCursor : this.m_YellowCoinCursor;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void propertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch (this.r_GameSettings.ShowDialog())
            {
                case DialogResult.Cancel:
                    this.r_GameSettings.Hide();
                    break;

                default:
                    if (this.PropertiesChanged() == true)
                    {
                        switch (MessageBox.Show("Start New Game?", "4 In A row", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                        {
                            case DialogResult.No:
                                this.m_BoardHasNewSize = true;
                                MessageBox.Show("New Board size will take effect\non the next game.", "4 In A row");
                                break;

                            default:
                                this.PrepareNewRoundWithNewProperties();
                                break;
                        }
                    }

                    break;
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.pictureBoxAbout.Location = new Point((this.ClientSize.Width / 2) - (this.pictureBoxAbout.Width / 2), (this.ClientSize.Height / 2) - (this.pictureBoxAbout.Height / 2));
            this.pictureBoxAbout.Visible = true;
        }

        private void pictureBoxAbout_Click(object sender, EventArgs e)
        {
            this.pictureBoxAbout.Visible = false;
        }

        private void howToPlayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(@"C:\FourInARowHelp.txt"))
            {
                MessageBox.Show(System.IO.File.ReadAllText(@"C:\FourInARowHelp.txt"), "How To Play");
            }
        }

        private void pictureBoxAbout_MouseEnter(object sender, EventArgs e)
        {
            this.menuStrip1_MouseEnter(sender, e);
        }

        private void pictureBoxAbout_MouseLeave(object sender, EventArgs e)
        {
            this.menuStrip1_MouseLeave(sender, e);
        }

        //Timer Elapsed Events
        private void CoinAnimationtimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            this.UpdateFormBoardCell(this.m_BoardCellRowToAnimate, this.m_BoardCellColumnToAnimate, null);
            this.m_ContinueAnimation = true;
        }

        private void FlashingCoinstimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (m_MarkWinningCells == true)
            {
                this.MarkWinningCells();
                m_MarkWinningCells = false;
            }
            else
            {
                this.UnMarkWinningCells();
                m_MarkWinningCells = true;
            }
        }
    }
 }
