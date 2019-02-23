using System.Drawing;
using System.Windows.Forms;

namespace Library.Controls
{
    public partial class LineVerticalSeparator : UserControl
    {
        public LineVerticalSeparator()
        {
            InitializeComponent();

            this.Paint += new PaintEventHandler(VerticalSeparator_Paint);

            this.MaximumSize = new Size(2, 2000);
            this.MinimumSize = new Size(2, 0);

            this.Height = 350;
        }

        private void VerticalSeparator_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            g.DrawLine(Pens.DarkGray, new Point(0, 0), new Point(0, this.Height));
            g.DrawLine(Pens.White, new Point(1, 0), new Point(1,this.Height));
            
        }
    }
}
