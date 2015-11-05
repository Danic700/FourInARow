

namespace GameConsoleUI
{
    /// <summary>
    /// This is the Game and GUI initializer
    /// </summary>
    public class FourInARowGUI
    {
        
        // Data Members
        private GameBoardForm m_FourInARowBoardForm = new GameBoardForm();

        // C'tor
        public FourInARowGUI()
        {
            this.m_FourInARowBoardForm.RunGame();
            this.m_FourInARowBoardForm.Hide();
            if (!this.m_FourInARowBoardForm.IsDisposed)
            {
                this.m_FourInARowBoardForm.ShowDialog();
            }
        }
    }
}
