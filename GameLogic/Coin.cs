namespace GameLogic
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// These are the coins we made for the logic X and O
    /// </summary>

    public class Coin
    {
        public enum eCoinType
        {
            X,
            O,
        }

        private eCoinType m_CoinType;

        public Coin(eCoinType i_CoinType)
        {
            this.m_CoinType = i_CoinType;
        }

        public eCoinType CoinType
        {
            get { return m_CoinType; }
        }
    }
}
