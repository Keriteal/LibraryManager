using System;
using System.Windows.Forms;

namespace LibraryManager
{
    public partial class OperationDialog : Form
    {
        public OperationDialog()
        {
            InitializeComponent();
        }

        private void btnRegist_Click(object sender, EventArgs e)
        {
            new RegistDialog().ShowDialog(this);
        }

        private void btnBorrowLead_Click(object sender, EventArgs e)
        {
            new ReturnDialog("", null).ShowDialog(this);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new UserList().ShowDialog(this);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new BookManager().ShowDialog(this);
        }

        private void OperationDialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.library.tryClose();
            Application.Exit();
        }
    }
}
