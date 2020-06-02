using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace LibraryManager
{
    public partial class UserList : Form
    {
        public UserList()
        {
            InitializeComponent();
        }

        private void UserList_Load(object sender, EventArgs e)
        {
            fresh();
        }

        public void fresh()
        {
            usersList.Items.Clear();
            MySqlDataReader reader = Program.library.executeQuery(
                "SELECT usertable.userid id, usertable.username user, usertable.other other, COUNT(borrowlog.bookid) count " +
                "FROM usertable " +
                "LEFT JOIN borrowlog ON usertable.userid = borrowlog.userid " + 
                "AND !borrowlog.isreturned " +
                "GROUP BY usertable.userid; ");
            while (reader.Read())
            {
                ListViewItem item = new ListViewItem();
                item.Text = reader["id"].ToString();
                item.SubItems.Add(new ListViewItem.ListViewSubItem(item, reader["user"].ToString()));
                item.SubItems.Add(new ListViewItem.ListViewSubItem(item, reader["other"].ToString()));
                item.SubItems.Add(new ListViewItem.ListViewSubItem(item, reader["count"].ToString()));
                usersList.Items.Add(item);
            }
            Program.library.tryClose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (usersList.SelectedItems.Count == 1)
            {
                new BorrowDialog(usersList.SelectedItems[0].SubItems[0].Text, this).ShowDialog();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (usersList.SelectedItems.Count == 1)
            {
                new ReturnDialog(usersList.SelectedItems[0].SubItems[0].Text, this).ShowDialog();
            }
        }
    }
}
