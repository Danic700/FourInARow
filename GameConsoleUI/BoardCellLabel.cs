using System.Windows.Forms;
using System.Drawing;

namespace GameConsoleUI
{
    /// <summary>
    /// This is the BoardcellLabel
    /// </summary>

    public class BoardCellLabel : Label
    {
        


        // Const Members
        private const int k_CellWidth = 67;
        private const int k_CellHeight = 67;
        
        // Data Members
        private int m_CellRowPosition;
        private int m_CellColumnPosition;

        // C'tor
        public BoardCellLabel(int i_CellRowPosition, int i_CellColumnPosition)
        {
            this.m_CellRowPosition = i_CellRowPosition;
            this.m_CellColumnPosition = i_CellColumnPosition;
            this.Size = new Size(k_CellWidth, k_CellHeight);
            this.Text = string.Empty;
            this.TextAlign = ContentAlignment.MiddleCenter;
            this.Image = Properties.Resources.EmptyCell;
        }

        // Public Properties
        public int CellRowPosition
        {
            get { return this.m_CellRowPosition; }
        }

        public int CellColumnPosition
        {
            get { return this.m_CellColumnPosition; }
        }
    }
}
