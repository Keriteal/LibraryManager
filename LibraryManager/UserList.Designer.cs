namespace LibraryManager
{
    partial class UserList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.usersList = new System.Windows.Forms.ListView();
            this.user_id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.user_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.user_other = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.user_borrowed = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // usersList
            // 
            this.usersList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.user_id,
            this.user_name,
            this.user_other,
            this.user_borrowed});
            this.usersList.FullRowSelect = true;
            this.usersList.GridLines = true;
            this.usersList.HideSelection = false;
            this.usersList.Location = new System.Drawing.Point(12, 12);
            this.usersList.Name = "usersList";
            this.usersList.Size = new System.Drawing.Size(393, 396);
            this.usersList.TabIndex = 0;
            this.usersList.UseCompatibleStateImageBehavior = false;
            this.usersList.View = System.Windows.Forms.View.Details;
            // 
            // user_id
            // 
            this.user_id.Text = "用户 ID";
            this.user_id.Width = 90;
            // 
            // user_name
            // 
            this.user_name.Text = "姓名";
            // 
            // user_other
            // 
            this.user_other.Text = "备注";
            this.user_other.Width = 160;
            // 
            // user_borrowed
            // 
            this.user_borrowed.Text = "借阅本数";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(330, 414);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "借书";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(249, 414);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "还书";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // UserList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 446);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.usersList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UserList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "用户列表";
            this.Load += new System.EventHandler(this.UserList_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView usersList;
        private System.Windows.Forms.ColumnHeader user_id;
        private System.Windows.Forms.ColumnHeader user_name;
        private System.Windows.Forms.ColumnHeader user_other;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ColumnHeader user_borrowed;
        private System.Windows.Forms.Button button2;
    }
}