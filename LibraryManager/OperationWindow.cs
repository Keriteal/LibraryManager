using System;
using System.Windows.Forms;

namespace LibraryManager
{
    public partial class OperationWindow : Form
    {
        public OperationWindow()
        {
            InitializeComponent();
        }

        private void btnRegist_Click(object sender, EventArgs e)
        {
            Hide();
            new RegistDialog().ShowDialog(this);
            Show();
        }

        private void btnBorrowLead_Click(object sender, EventArgs e)
        {
            Hide();
            new ReturnDialog("", null).ShowDialog(this);
            Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Hide();
            new UserList().ShowDialog(this);
            Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Hide();
            new BookManager().ShowDialog(this);
            Show();
        }

        private void OperationDialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.library.tryClose();
            Application.Exit();
        }

        private void OperationDialog_Load(object sender, EventArgs e)
        {
            Hide();
            new LoginDialog().ShowDialog(this);
            Show();
        }
    }
}
