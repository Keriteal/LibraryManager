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
    public partial class LoginDialog : Form
    {
        public LoginDialog()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program.library = new MYSQL.MYSQL(textHost.Text, int.Parse(textPort.Text), textUser.Text, textPass.Text, "library_database");
            if (!Program.library.connect())
            {
                MessageBox.Show("Failed");
            }
            else
            {
                Program.library.executeUpdate(@"CREATE TABLE IF NOT EXISTS
booktable (
bookid int NOT NULL PRIMARY KEY AUTO_INCREMENT,
bookname VARCHAR(25) NOT NULL,
bookcount int NOT NULL
);");
                Program.library.executeUpdate(@"CREATE TABLE IF NOT EXISTS
usertable (
userid INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
username varchar(25) NOT NULL,
registtime datetime(0) NOT NULL,
other VARCHAR(25)
);");
                Program.library.executeUpdate(@"CREATE TABLE IF NOT EXISTS
borrowlog (
`logid` INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
`userid` INT NOT NULL,
`bookid` INT NOT NULL,
`isreturned` tinyint(1) NOT NULL DEFAULT 0,
`returntime` datetime(0) NULL DEFAULT NULL,
`borrowdate` DATETIME NOT NULL,
FOREIGN KEY(userid) REFERENCES usertable(userid),
FOREIGN KEY(bookid) REFERENCES booktable(bookid)
);");
                Close();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Height = 375 - Height;
        }
    }
}
