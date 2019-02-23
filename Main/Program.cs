using System;
using System.Windows.Forms;
using System.Management;
using System.IO;


namespace Main
{
    static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Main.Login login = null;


            if (global::Library.Classes.Cryptograph.CheckAndCountMAC() > 0)
            {
                login = new Main.Login();

                if (login.ShowDialog() == DialogResult.OK)
                {
                    Application.Run(new Forms.Start());
                }

                login.Disposed += delegate { login.Dispose(); };
            }
            else
            {
                MessageBox.Show("Este programa foi desenvolvido para ser acessado somente por um computador específico.");
            }
        }
    }
}
