using System.Windows.Forms;
using System.Drawing;

namespace GameConsoleUI
{
    /// <summary>
    /// This is the ColumnLabel
    /// </summary>
    public class ColumnLabel : Label
    {
        // Const Members
        private const int k_ButtonWidth = 67;
        private const int k_ButtonHeight = 67;

        // Read-Only Members
        private int r_ColumnNumber;

        // C'tor
        public ColumnLabel(int i_ColumnNumber)
        {
            this.r_ColumnNumber = i_ColumnNumber;
            this.Size = new Size(k_ButtonWidth, k_ButtonHeight);
        }

        // Public Properties
        public int ButtonColumnNumber
        {
            get { return this.r_ColumnNumber; }
        }
    }
}
