using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace LibraryManager
{
    public partial class BookManager : Form
    {
        public BookManager()
        {
            InitializeComponent();
        }

        private void BookManager_Load(object sender, EventArgs e)
        {
            refresh();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            refresh();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            new BookDialog(true, "auto", "", "1", "", this).ShowDialog(this);
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            if (bookslist.SelectedItems.Count == 1)
            {
                string bookid = bookslist.SelectedItems[0].SubItems[0].Text;
                string bookname = bookslist.SelectedItems[0].SubItems[1].Text;
                string bookcount = bookslist.SelectedItems[0].SubItems[2].Text;
                string bookremains = bookslist.SelectedItems[0].SubItems[3].Text;
                new BookDialog(false, bookid, bookname, bookcount, bookremains, this).ShowDialog(this);
            }
        }

        public void refresh()
        {
            bookslist.Items.Clear();
            MySqlDataReader reader = Program.library.executeQuery(
                "SELECT " +
                    "booktable.bookid id, " +
                    "booktable.bookname name, " +
                    "booktable.bookcount count, " +
                    "booktable.bookcount - COUNT(borrowlog.userid) remains " +
                "FROM booktable " +
                "LEFT JOIN borrowlog ON booktable.bookid = borrowlog.bookid AND ! borrowlog.isreturned " +
                "GROUP BY booktable.bookid " +
                "ORDER BY booktable.bookid;"
                );
            if (reader != null)
            {
                while (reader.Read())
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = reader["id"].ToString();
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, reader["name"].ToString()));
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, reader["count"].ToString()));
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, reader["remains"].ToString()));
                    bookslist.Items.Add(item);
                }
            }
            Program.library.tryClose();
        }
    }
}
