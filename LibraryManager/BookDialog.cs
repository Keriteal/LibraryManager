using System;
using System.Windows.Forms;

namespace LibraryManager
{
    public partial class BookDialog : Form
    {
        bool isadd;
        String bookid;
        string bookname;
        String bookcount;
        string bookremains;
        BookManager bookManager = null;
        public BookDialog(bool isadd, String bookid, String bookname, String bookcount, string bookremains, BookManager bookManager)
        {
            this.isadd = isadd;
            this.bookid = bookid;
            this.bookname = bookname;
            this.bookcount = bookcount;
            this.bookremains = bookremains;
            this.bookManager = bookManager;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool result = false;
            if (isadd)
            {
                result = Program.library.executeUpdate($"INSERT INTO booktable ( bookname, bookcount ) " +
                    $"VALUES ( '{textBox2.Text.Trim()}', {textBox3.Text.Trim()} );");

            }
            else
            {
                string newcount = textBox3.Text.Trim();
                if (int.Parse(newcount) >= int.Parse(bookcount) - int.Parse(bookremains))
                {
                    result = Program.library.executeUpdate($"UPDATE booktable SET" +
                    $" bookname = '{textBox2.Text.Trim()}'," +
                    $" bookcount = '{newcount}'" +
                    $" WHERE bookid = {bookid.Trim()}; ");
                }
                else
                {
                    MessageBox.Show("新的数过小");
                }

            }
            Program.library.tryClose();
            if (result)
            {
                if (bookManager != null)
                {
                    bookManager.refresh();
                }
                Close();
            }
            else
            {
                MessageBox.Show("ERROR");
            }
        }

        private void BookDialog_Load(object sender, EventArgs e)
        {
            textBox1.Text = bookid;
            textBox2.Text = bookname;
            textBox3.Text = bookcount;
        }
    }
}
