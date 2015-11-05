namespace GameLogic
{
    public class Player
    {
        public enum ePlayerType
        {
            human,
            computer,
        }

        private string m_Name;
        private int m_PlayerScore = 0;
        private ePlayerType m_PlayerType;
        private Coin.eCoinType m_PlayerCoinType;

        // C'tor
        public Player(string i_Name, ePlayerType i_PlayerType, Coin.eCoinType i_CoinType)
        {
            this.m_Name = i_Name;
            this.m_PlayerType = i_PlayerType;
            this.m_PlayerCoinType = i_CoinType;
        }

        // Public Properties
        public string Name
        {
            get { return m_Name; }
            set { m_Name = value; }
        }

        public Coin.eCoinType PlayerCoinType
        {
            get { return m_PlayerCoinType; }
        }

        public ePlayerType PlayerType
        {
            get { return m_PlayerType; }
        }

        public int PlayerScore
        {
            get { return m_PlayerScore; }
            set { m_PlayerScore = value; }
        }

        // Public Methods
        public void UpdateScore()
        {
            this.m_PlayerScore++;
        }

        public void InitScore()
        {
            m_PlayerScore = 0;
        }
    }
}
