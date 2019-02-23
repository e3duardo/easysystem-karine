using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Globalization;

namespace Library.Windows.Forms
{
    public partial class Print : Form
    {

        private StringReader myReader;

        private int contador = 10;

        private Font printFont = null;

        private SolidBrush myBrush = null;

        private StringFormat stringformat = new StringFormat();

        private PrintPreviewDialog printPreviewDialog1;

        public string InputString { get; set; }
        public string InputTitle { get; set; }

        public Print()
        {
            InitializeComponent();
        }

        public Print(string inputString)
        {
            InitializeComponent();
            this.InputString = inputString;
        }

        public Print(string inputString, string inputTitle)
        {
            InitializeComponent();
            this.InputString = inputString;
            this.InputTitle = inputTitle;
        }


        // /////FUNÇÕES DE EVENTOS
        private void print_Load(object sender, EventArgs e)
        {
            if (this.InputTitle != "")
            {
                this.printDocument.DocumentName = this.InputTitle;
                this.Name = string.Format("Imprimir - {0}", this.InputTitle);
            }

            this.myReader = new StringReader(this.InputString);

            this.printPreviewControl.Document = this.printDocument;
            this.timer.Start();
        }

        private void imprimirButton_Click(object sender, EventArgs e)
        {
            this.timer.Stop();

            this.printDialog.Document = this.printDocument;

            if (this.printDialog.ShowDialog() == DialogResult.OK)
            {
                this.printDocument.Print();
            }
        }

        private void printPreviewControl_Click(object sender, EventArgs e)
        {
            printPreviewDialog1 = new PrintPreviewDialog();
            printPreviewDialog1.Document = this.printDocument;
            printPreviewDialog1.ShowDialog();
        }

        private void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            float linesPerPage = 0;
            float yPosition = 0;
            int count = 0;
            //float leftMargin = e.MarginBounds.Left;
            //float topMargin = e.MarginBounds.Top;
            float leftMargin = e.MarginBounds.Left;
            float topMargin = e.MarginBounds.Top;
            string line = null;
            printFont = new Font("Times New Roman", 14);
            myBrush = new SolidBrush(Color.Black);
            // Work out the number of lines per page, using the MarginBounds.
            linesPerPage = e.MarginBounds.Height / printFont.GetHeight(e.Graphics);
            // Iterate over the string using the StringReader, printing each line.
            while (count < linesPerPage && ((line = this.myReader.ReadLine()) != null))
            {
                // calculate the next line position based on the height of the font according to the printing device
                yPosition = topMargin + (count * printFont.GetHeight(e.Graphics));
                // draw the next line in the rich edit control
                e.Graphics.DrawString(line, printFont, myBrush, leftMargin, yPosition, stringformat);
                count++;
            }
            // If there are more lines, print another page.
            if (line != null)
                e.HasMorePages = true;
            else
                e.HasMorePages = false;
            myBrush.Dispose();
        }





        private void printDocument_EndPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            this.imprimirButton.Text = "Impressão concluída";
            //this.DialogResult = DialogResult.OK;
        }

        private void printDocument_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            this.imprimirButton.Text = "Impressão iniciada";
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            this.contador--;

            this.imprimirButton.Text = string.Format("Imprimir em {0} segundos", contador);

            if (this.contador == 0)
            {
                this.timer.Stop();
                this.imprimirButton.PerformClick();
            }
        }

        // /////FUNÇÕES DO FORMULÁRIO
    }
}
