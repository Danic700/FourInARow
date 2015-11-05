namespace GameLogic
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// This is the boardCell for all the coins in the logic
    /// </summary>

    public class BoardCell
    {
        private Coin m_CoinInCell = null;
        private int m_CellPositionInBoardColumn;
        private int m_CellPositionInBoardRow;

        // C'tor
        public BoardCell(int i_BoardRow, int i_BoardColumn)
        {
            this.m_CellPositionInBoardRow = i_BoardRow;
            this.m_CellPositionInBoardColumn = i_BoardColumn;
        }

        // Public Properties
        public int CellRow
        {
            get { return m_CellPositionInBoardRow; }
        }

        public int CellColumn
        {
            get { return m_CellPositionInBoardColumn; }
        }

        public Coin CoinInCell
        {
            get { return m_CoinInCell; }
            set { m_CoinInCell = value; }
        }

        // Public Methods
        public bool IsCellFull()
        {
            return this.m_CoinInCell != null;
        }
    }
}
