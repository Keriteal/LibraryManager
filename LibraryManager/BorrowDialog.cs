using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace LibraryManager
{
    public partial class BorrowDialog : Form
    {
        string userid;
        String capability;
        UserList userList = null;
        public BorrowDialog(String userid, UserList userList)
        {
            this.userid = userid;
            this.userList = userList;
            InitializeComponent();
        }

        private void BorrowDialog_Load(object sender, EventArgs e)
        {
            reload();
        }

        #region 刷新
        void reload()
        {
            listView1.Items.Clear();
            MySqlDataReader reader = Program.library.executeQuery(
                "SELECT 5-COUNT(borrowlog.bookid) capability " +
                "FROM borrowlog " +
                $"WHERE borrowlog.userid = {userid} AND !borrowlog.isreturned " +
                "ORDER BY borrowlog.userid; "
                );
            if (reader != null)
            {
                reader.Read();
                capability = reader["capability"].ToString();
                label_remains.Text = capability;
                Program.library.tryClose();
            }

            MySqlDataReader reader_books = Program.library.executeQuery(
                "SELECT " +
                    "booktable.bookid id, " +
                    "booktable.bookname name, " +
                    "booktable.bookcount - COUNT(borrowlog.userid) remains " +
                "FROM booktable " +
                "LEFT JOIN borrowlog ON booktable.bookid = borrowlog.bookid AND ! borrowlog.isreturned " +
                "GROUP BY booktable.bookid " +
                "ORDER BY booktable.bookid;"
                );
            if (reader_books != null)
            {
                while (reader_books.Read())
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = reader_books["id"].ToString();
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, reader_books["name"].ToString()));
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, reader_books["remains"].ToString()));
                    listView1.Items.Add(item);
                }
            }
            Program.library.tryClose();
        }
        #endregion

        private void btnBorrow_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 1)
            {
                if (!label_remains.Text.Equals("0"))
                {
                    if (!listView1.SelectedItems[0].SubItems[2].Text.Equals("0"))
                    {
                        var result = Program.library.executeUpdate(
                        "INSERT INTO borrowlog(userid, bookid, borrowdate) " +
                        $"VALUES ( {userid}, {listView1.SelectedItems[0].SubItems[0].Text.Trim()}, NOW() )"
                        );
                        Program.library.tryClose();
                        if (!result)
                        {
                            Console.WriteLine("ERROR");
                        }
                        userList.fresh();
                        reload();
                    }
                    else
                    {
                        MessageBox.Show("该书已借完");
                    }
                }
                else
                {
                    MessageBox.Show("借书数量已经到了上限");
                }
            }
        }
    }
}
