using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManager
{
    public partial class RegistDialog : Form
    {
        public RegistDialog()
        {
            InitializeComponent();
        }

        private void btnCommit_Click(object sender, EventArgs e)
        {
            bool result = false;
            result = Program.library.executeUpdate("INSERT INTO usertable ( username, other, registtime ) " +
                $"VALUES ( '{textUsername.Text.Trim()}', '{textOther.Text.Trim()}', NOW() ); ");
            if (result)
            {
                Close();
            }
            else
            {
                MessageBox.Show("ERROR");
            }
        }
    }
}
