using Library.Converter;

namespace Library.Windows.Forms
{
    public partial class MoneyTextBox : System.Windows.Forms.TextBox
    {
        public MoneyTextBox()
        {
            InitializeComponent();
        }

        protected override void OnLeave(System.EventArgs e)
        {
            base.Text = base.Text.ConvertToMoneyString();

            base.OnLeave(e);
        }

        public decimal? Value
        {
            get { return base.Text.ConvertToDecimal(); }
            set 
            { 
                if (value != null) 
                    base.Text = value.Value.ConvertToMoneyString(); 
                else 
                    base.Text = ""; 
            }
        }
    }
}
