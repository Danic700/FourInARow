namespace GameLogic
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// This is the game logic, where we make the moves and check for winners.
    /// </summary>

    public class FourInARowGame
    {
        // Data Members
        private List<Player> m_Players = new List<Player>(Constants.k_NumberfPlayers);
        private Board m_GameBoard = null;
        private int m_CurrentPlayerIndex = Constants.k_FirstPlayerIndex;
        private int m_RoundWinnerIndex = Constants.k_DefaultValue;

        // C'tor
        public FourInARowGame(int i_NumberOfRows, int i_NumberOfColumns, string i_FirstPlayerName, string i_SecondPlayerName)
        {
            CreateGameBoard(i_NumberOfRows, i_NumberOfColumns);
            InitPlayers(i_FirstPlayerName, i_SecondPlayerName);
        }

        // Public Properties
        public List<Player> Players
        {
            get { return m_Players; }
        }

        public Board GameBoard
        {
            get { return m_GameBoard; }
        }

        public int PlayerIndex
        {
            get { return m_CurrentPlayerIndex; }
        }

        public int WinnerIndex
        {
            get { return m_RoundWinnerIndex; }
        }

        // Public Methods
        public bool IsPossibleMove(int i_Column)
        {
            return !m_GameBoard.GameBoard[i_Column, 0].IsCellFull();
        }

        public void ProcessPlayerMove(int i_Column)
        {
            int Row = this.m_GameBoard.GetCellRowToFill(i_Column);
            if (Row > Constants.k_DefaultValue)
            {
                this.m_GameBoard.UpdateBoardCell(this.m_Players[this.m_CurrentPlayerIndex].PlayerCoinType, Row, i_Column);
                this.CheckBoardForWinner(i_Column, Row);
                this.UpdateCurrentPlayer();
            }
        }

        public bool IsColumnFull(int i_Column)
        {
            return this.m_GameBoard.GetCellRowToFill(i_Column) == Constants.k_DefaultValue;
        }

        public void InitPlayersScore()
        {
            foreach (Player player in m_Players)
            {
                player.InitScore();
            }
        }

        public bool IsNextCellInColumnEmpty(int i_Row, int i_Column)
        {
            return !((i_Row == m_GameBoard.NumberOfRows) || (m_GameBoard.GetBoardCell(i_Row, i_Column).CoinInCell != null));
        }

        public void ProcessComputerMove()
        {
            int Column = this.GetRandomPossibleMove();
            int Row;

            Row = this.m_GameBoard.GetCellRowToFill(Column);
            this.m_GameBoard.UpdateBoardCell(this.m_Players[Constants.k_SecondPlayerIndex].PlayerCoinType, Row, Column);
            this.CheckBoardForWinner(Column, Row);
            this.UpdateCurrentPlayer();
        }

        public bool IsBoardFull()
        {
            return this.m_GameBoard.IsBoardFull();
        }

        public string GetPlayerName(int i_PlayerIndex)
        {
            return this.m_Players[i_PlayerIndex].Name;
        }

        public List<BoardCell> GetWinnerCells()
        {
            return this.m_GameBoard.WinnerCells;
        }

        public void UpdateCurrentPlayer()
        {
            this.m_CurrentPlayerIndex = (this.m_CurrentPlayerIndex + 1) % 2;
        }

        public bool IsThereAWinner()
        {
            return this.m_RoundWinnerIndex != Constants.k_DefaultValue;
        }

        public void SetNewRoundWithNewProperties(int i_Rows, int i_Columns, string i_FirstPlayerName, string i_SecondPlayerName)
        {
            this.m_CurrentPlayerIndex = Constants.k_FirstPlayerIndex;
            this.CreateGameBoard(i_Rows, i_Columns);
            this.SetPlayersNames(i_FirstPlayerName, i_SecondPlayerName);
            this.m_RoundWinnerIndex = Constants.k_DefaultValue;
        }

        public void PrepareNewRound()
        {
            this.m_CurrentPlayerIndex = Constants.k_FirstPlayerIndex;
            this.CreateGameBoard(this.m_GameBoard.NumberOfRows, this.m_GameBoard.NumberOfColumns);
            this.m_RoundWinnerIndex = Constants.k_DefaultValue;
        }

        public int GetNumberOfRowsInBoard()
        {
            return this.GameBoard.NumberOfRows;
        }

        public int GetNumberOfColumnsInBoard()
        {
            return this.GameBoard.NumberOfColumns;
        }

        // Private Methods
        private void CreateGameBoard(int i_NumberOfRows, int i_NumberOfColumns)
        {
            this.m_GameBoard = new Board(i_NumberOfRows, i_NumberOfColumns);
        }

        private void CheckBoardForWinner(int i_LastColumnFilled, int i_LastRowFilled)
        {
            if (this.m_GameBoard.CheckWinner(i_LastColumnFilled, i_LastRowFilled))
            {
                this.m_RoundWinnerIndex = this.m_CurrentPlayerIndex;
                this.m_Players[this.m_CurrentPlayerIndex].UpdateScore();
            }
        }

        private int GetRandomPossibleMove()
        {
            Random Rand = new Random();
            int Column = Rand.Next(this.m_GameBoard.NumberOfColumns);

            while (!this.IsPossibleMove(Column))
            {
                Column = Rand.Next(this.m_GameBoard.NumberOfColumns);
            }

            return Column;
        }

        private void AddPlayer(string i_Name, Player.ePlayerType i_PlayerType, Coin.eCoinType i_CoinType)
        {
            this.m_Players.Add(new Player(i_Name, i_PlayerType, i_CoinType));
        }

        private void InitPlayers(string i_FirstPlayerName, string i_SecondPlayerName)
        {
            AddPlayer(i_FirstPlayerName, Player.ePlayerType.human, Coin.eCoinType.X);
            AddPlayer(i_SecondPlayerName, Player.ePlayerType.human, Coin.eCoinType.O);
            AddPlayer(i_SecondPlayerName, Player.ePlayerType.computer, Coin.eCoinType.O);  
        }

        private void SetPlayersNames(string i_FirstPlayerName, string i_SecondPlayerName)
        {
            m_Players[Constants.k_FirstPlayerIndex].Name = i_FirstPlayerName;
            m_Players[Constants.k_SecondPlayerIndex].Name = i_SecondPlayerName;
        }
    }
}
