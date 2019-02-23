using System.Windows.Forms;
using System.Security.Permissions;

namespace Library.Controls
{
    public partial class MyPictureBox : PictureBox
    {
        public MyPictureBox()
        {
            InitializeComponent();
        }

        protected override CreateParams CreateParams
        {
            [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x00000020; //WS_EX_TRANSPARENT 
                return cp;
            }
        }

    }
}
