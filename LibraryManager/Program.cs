using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManager
{
    static class Program
    {
        public static MYSQL.MYSQL library = null;

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new OperationWindow());
        }
    }

    public class library_container
    {
        public MYSQL.MYSQL library = null;
    }
}
