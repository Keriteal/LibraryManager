using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace LibraryManager
{
    public partial class ReturnDialog : Form
    {
        bool ShowAll = false;
        string userid = "";
        UserList userList = null;
        public ReturnDialog(String userid, UserList userList)
        {
            this.userid = userid;
            this.userList = userList;
            InitializeComponent();
        }

        private void ReturnDialog_Load(object sender, EventArgs e)
        {
            fresh();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            bool result = false;
            string logid = listView1.SelectedItems[0].SubItems[0].Text;
            //Console.WriteLine(logid);
            if (listView1.SelectedItems[0].SubItems[4].Text.Equals("否"))
            {
                result = Program.library.executeUpdate($"UPDATE borrowlog SET returntime = NOW(), isreturned = 1 " +
                    $"WHERE borrowlog.logid = {logid}; ");
                if (!result)
                {
                    MessageBox.Show("ERROR");
                }
                fresh();
                if (userList != null)
                {
                    userList.fresh();
                }
            }
        }

        private void fresh()
        {
            listView1.Items.Clear();
            MySqlDataReader reader = Program.library.executeQuery(
                "SELECT borrowlog.logid id, usertable.username user, booktable.bookname book, borrowlog.borrowdate time, IF(borrowlog.isreturned,'是', '否') returned " +
                "FROM usertable, borrowlog, booktable " +
                "WHERE usertable.userid = borrowlog.userid AND borrowlog.bookid = booktable.bookid " +
                $"{(ShowAll ? "" : "AND !borrowlog.isreturned")} " +
                $"{(userList == null ? "" : $"AND borrowlog.userid = {userid} ")}" +
                "ORDER BY id;");
            if (reader != null)
            {
                while (reader.Read())
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = reader["id"].ToString();
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, reader["user"].ToString()));
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, reader["book"].ToString()));
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, reader["time"].ToString()));
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, reader["returned"].ToString()));
                    listView1.Items.Add(item);
                }
            }
            Program.library.tryClose();
        }

        private void btnSwitch_Click(object sender, EventArgs e)
        {
            ShowAll = !ShowAll;
            if (btnSwitch.Text.Equals("显示全部"))
            {
                btnSwitch.Text = "仅显示未归还";
            }
            else
            {
                btnSwitch.Text = "显示全部";
            }
            fresh();
        }
    }
}
