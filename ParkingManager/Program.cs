using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CarManager
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Application.Run(new Fportstate());
            Login fl = new Login();
            fl.ShowDialog();
            if (fl.DialogResult == DialogResult.OK)
            {
                Application.Run(new Fportstate());
            }
            else if (fl.DialogResult == DialogResult.Yes)
            {
                Application.Run(new VIP());
            }
        }
    }
}