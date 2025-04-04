using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConnectToOracle
{
    public partial class fGrantRoleToUser : Form
    {
        Database database;
        Exception ex = null;
        string selectedUser = null;
        string selectedRole = null;
        public fGrantRoleToUser()
        {
            InitializeComponent();
            database = Database.getInstance();
            AddUser(userList);
            AddRoles(roleList);
        }

        public string ExtractItemString(string input)
        {
            // Tìm vị trí của dấu '{'
            int startIndex = input.IndexOf('{');
            if (startIndex == -1) // Nếu không tìm thấy dấu '{', trả về chuỗi ban đầu
                return input;

            // Tìm vị trí của dấu '}'
            int endIndex = input.IndexOf('}');
            if (endIndex == -1 || endIndex <= startIndex) // Nếu không tìm thấy dấu '}' hoặc nó xuất hiện trước dấu '{', trả về chuỗi ban đầu
                return input;

            // Trích xuất phần tử giữa dấu '{' và dấu '}'
            string extractedValue = input.Substring(startIndex + 1, endIndex - startIndex - 1).Trim();
            return extractedValue;
        }


        private void userList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (userList.SelectedItems.Count > 0)
            {
                selectedUser = ExtractItemString(userList.SelectedItems[0].ToString());
            }
        }

        public void AddUser(ListView l)
        {
            List<List<String>> list = database.getAllUsers(ref ex);
            if (ex != null)
            {
                MessageBox.Show(ex.Message);
                ex = null;
                return;
            }
            for (int i = 0; i < list.Count; i++)
            {
                ListViewItem item = new ListViewItem();
                item.Text = list[i][0];
                item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = list[i][1] });
                item.Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Italic);
                l.Items.Add(item);
            }

        }

        public void AddRoles(ListView l)
        {
            List<String> list = database.getAllRoles(ref ex);
            if (ex != null)
            {
                MessageBox.Show(ex.Message);
                ex = null;
                return;
            }
            for (int i = 0; i < list.Count; i++)
            {
                ListViewItem item = new ListViewItem();
                item.Text = list[i];
                item.Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Italic);
                l.Items.Add(item);
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (selectedUser != null && selectedRole != null)
            {
                database.GrantRoleToUser(selectedUser, selectedRole);
            }
            else
            {
                MessageBox.Show("Missing User, Table Or Statement Types");
            }
        }

        private void roleList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (roleList.SelectedItems.Count > 0)
            {
                selectedRole = ExtractItemString(roleList.SelectedItems[0].ToString());
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
