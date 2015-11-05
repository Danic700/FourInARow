namespace GameLogic
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// This is the board of the logic part of the game
    /// </summary>

    public class Board
    {
        private BoardCell[,] m_Board;
        private int m_NumberOfColumns = Constants.k_DefaultValue;
        private int m_NumberOfRows = Constants.k_DefaultValue;
        private List<BoardCell> m_WinnerCells = new List<BoardCell>();

        // C'tor
        public Board(int i_NumberOfRows, int i_NumberOfColumns)
        {
            this.m_NumberOfRows = i_NumberOfRows;
            this.m_NumberOfColumns = i_NumberOfColumns;
            InitializeBoard();
        }

        // Public Properties
        public int NumberOfColumns
        {
            get { return m_NumberOfColumns; }
        }

        public int NumberOfRows
        {
            get { return m_NumberOfRows; }
        }

        public BoardCell[,] GameBoard
        {
            get { return m_Board; }
        }

        public List<BoardCell> WinnerCells
        {
            get { return m_WinnerCells; }
        }

        // Public Methods
        public BoardCell GetBoardCell(int i_CellRow, int i_CellColumn)
        {
            return this.m_Board[i_CellColumn, i_CellRow];
        }

        public void UpdateBoardCell(Coin.eCoinType i_CoinType, int i_CellRow, int i_CellColumn)
        {
            this.GetBoardCell(i_CellRow, i_CellColumn).CoinInCell = new Coin(i_CoinType);
        }

        public int GetCellRowToFill(int i_Column)
        {
            int CellRow = this.m_NumberOfRows - 1;

            while (CellRow > Constants.k_DefaultValue && this.GetBoardCell(CellRow, i_Column).IsCellFull())
            {
                CellRow--;
            }

            return CellRow;
        }

        public bool IsBoardFull()
        {
            int FullColumnsCounter = 0;

            for (int index = 0; index < this.m_NumberOfColumns; index++)
            {
                if (this.GetBoardCell(0, index).IsCellFull())
                {
                    FullColumnsCounter++;
                }
            }

            return FullColumnsCounter == this.m_NumberOfColumns;
        }

        public bool CheckWinner(int i_LastColumnFilled, int i_LastRowFilled)
        {
            return this.CheckColumnWinner(i_LastColumnFilled, i_LastRowFilled) ||
                this.CheckRowWinner(i_LastColumnFilled, i_LastRowFilled) ||
                this.CheckMainDiagnolWinner(i_LastColumnFilled, i_LastRowFilled) ||
                this.CheckSecDiagnolWinner(i_LastColumnFilled, i_LastRowFilled);
        }

        // Private Methods
        private void InitializeBoard()
        {
            this.m_Board = new BoardCell[this.m_NumberOfColumns, this.m_NumberOfRows];
            InitializeCells();
        }

        private void InitializeCells()
        {
            for (int Column = 0; Column < this.m_NumberOfColumns; Column++)
            {
                for (int Row = 0; Row < this.m_NumberOfRows; Row++)
                {
                    this.m_Board[Column, Row] = new BoardCell(Row, Column);
                }
            }
        }

        private bool CheckColumnWinner(int i_LastColumnFilled, int i_LastRowFilled)
        {
            this.m_WinnerCells.Clear();
            int CoinTypeStreak = 0;
            Coin.eCoinType WinnerCoinType = this.GetBoardCell(i_LastRowFilled, i_LastColumnFilled).CoinInCell.CoinType;
            int RowToCheck = i_LastRowFilled;

            if (Constants.k_CoinStreakToWin - i_LastRowFilled >= 0)
            {
                while (RowToCheck < this.m_NumberOfRows &&
                this.GetBoardCell(RowToCheck, i_LastColumnFilled).CoinInCell.CoinType == WinnerCoinType)
                {
                    this.m_WinnerCells.Add(this.GetBoardCell(RowToCheck, i_LastColumnFilled));
                    CoinTypeStreak++;
                    RowToCheck++;
                }
            }

            return CoinTypeStreak == Constants.k_CoinStreakToWin;
        }

        private bool CheckRowWinner(int i_LastColumnFilled, int i_LastRowFilled)
        {
            this.m_WinnerCells.Clear();
            int CoinTypeStreak = 0;
            Coin.eCoinType WinnerCoinType = this.GetBoardCell(i_LastRowFilled, i_LastColumnFilled).CoinInCell.CoinType;
            int ColumnToCheck = i_LastColumnFilled;

            while (ColumnToCheck < this.m_NumberOfColumns &&
                this.GetBoardCell(i_LastRowFilled, ColumnToCheck).IsCellFull() &&
                this.GetBoardCell(i_LastRowFilled, ColumnToCheck).CoinInCell.CoinType == WinnerCoinType)
            {
                this.m_WinnerCells.Add(this.GetBoardCell(i_LastRowFilled, ColumnToCheck));
                CoinTypeStreak++;
                ColumnToCheck++;
            }

            ColumnToCheck = i_LastColumnFilled - 1;
            while (ColumnToCheck > Constants.k_DefaultValue &&
                this.GetBoardCell(i_LastRowFilled, ColumnToCheck).IsCellFull() &&
                this.GetBoardCell(i_LastRowFilled, ColumnToCheck).CoinInCell.CoinType == WinnerCoinType)
            {
                this.m_WinnerCells.Add(this.GetBoardCell(i_LastRowFilled, ColumnToCheck));
                CoinTypeStreak++;
                ColumnToCheck--;
            }

            return CoinTypeStreak >= Constants.k_CoinStreakToWin;
        }

        private bool CheckMainDiagnolWinner(int i_LastColumnFilled, int i_LastRowFilled)
        {
            this.m_WinnerCells.Clear();
            int CoinTypeStreak = 0;
            Coin.eCoinType WinnerCoinType = this.GetBoardCell(i_LastRowFilled, i_LastColumnFilled).CoinInCell.CoinType;
            int ColumnToCheck = i_LastColumnFilled;
            int RowToCheck = i_LastRowFilled;

            while (ColumnToCheck < this.m_NumberOfColumns && RowToCheck < this.m_NumberOfRows &&
                this.GetBoardCell(RowToCheck, ColumnToCheck).IsCellFull() &&
                this.GetBoardCell(RowToCheck, ColumnToCheck).CoinInCell.CoinType == WinnerCoinType)
            {
                this.m_WinnerCells.Add(this.GetBoardCell(RowToCheck, ColumnToCheck));
                CoinTypeStreak++;
                ColumnToCheck++;
                RowToCheck++;
            }

            ColumnToCheck = i_LastColumnFilled - 1;
            RowToCheck = i_LastRowFilled - 1;
            while (ColumnToCheck > Constants.k_DefaultValue && RowToCheck > Constants.k_DefaultValue &&
                this.GetBoardCell(RowToCheck, ColumnToCheck).IsCellFull() &&
                this.GetBoardCell(RowToCheck, ColumnToCheck).CoinInCell.CoinType == WinnerCoinType)
            {
                this.m_WinnerCells.Add(this.GetBoardCell(RowToCheck, ColumnToCheck));
                CoinTypeStreak++;
                ColumnToCheck--;
                RowToCheck--;
            }

            return CoinTypeStreak >= Constants.k_CoinStreakToWin;
        }

        private bool CheckSecDiagnolWinner(int i_LastColumnFilled, int i_LastRowFilled)
        {
            this.m_WinnerCells.Clear();
            int CoinTypeStreak = 0;
            Coin.eCoinType WinnerCoinType = this.GetBoardCell(i_LastRowFilled, i_LastColumnFilled).CoinInCell.CoinType;
            int ColumnToCheck = i_LastColumnFilled;
            int RowToCheck = i_LastRowFilled;

            while (ColumnToCheck < this.m_NumberOfColumns && RowToCheck > Constants.k_DefaultValue &&
                this.GetBoardCell(RowToCheck, ColumnToCheck).IsCellFull() &&
                this.GetBoardCell(RowToCheck, ColumnToCheck).CoinInCell.CoinType == WinnerCoinType)
            {
                this.m_WinnerCells.Add(this.GetBoardCell(RowToCheck, ColumnToCheck));
                CoinTypeStreak++;
                ColumnToCheck++;
                RowToCheck--;
            }

            ColumnToCheck = i_LastColumnFilled - 1;
            RowToCheck = i_LastRowFilled + 1;
            while (ColumnToCheck > Constants.k_DefaultValue && RowToCheck < this.m_NumberOfRows &&
                this.GetBoardCell(RowToCheck, ColumnToCheck).IsCellFull() &&
                this.GetBoardCell(RowToCheck, ColumnToCheck).CoinInCell.CoinType == WinnerCoinType)
            {
                this.m_WinnerCells.Add(this.GetBoardCell(RowToCheck, ColumnToCheck));
                CoinTypeStreak++;
                ColumnToCheck--;
                RowToCheck++;
            }

            return CoinTypeStreak >= Constants.k_CoinStreakToWin;
        }
    }
}
