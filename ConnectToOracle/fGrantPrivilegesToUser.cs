using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ConnectToOracle
{
    public partial class fGrantPrivilegesToUser : Form
    {
        Database database;
        Exception ex = null;
        int isGrantOption = 0;
        string selectedTable = null;
        string selectedUser = null;
        string selectColumns = null;
        string updateColumns = null;
        string selectedStatementTypes = null;
        List<string> initialSelectedPrivileges = new List<string>();


        public fGrantPrivilegesToUser(string user)
        {
            InitializeComponent();
            database = Database.getInstance();
            AddTable(tablesList);
            selectedUser  = user;
            userName.Text = userName.Text + selectedUser;
        }

        private void fGrantPrivilegesToUser_Load(object sender, EventArgs e)
        {

        }

        //Method tách chuỗi khi lấy item từ Listview
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

        public void AddTable(ListView l)
        {
            List<List<String>> list = database.getAllTables(ref ex);
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
                item.Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Italic);
                l.Items.Add(item);
            }
        }

        public void AddPrivs(ListView l)
        {
            List<List<String>> list = database.GetUserPrivOnTable(selectedUser, selectedTable, ref ex);
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
                l.Items.Add(item);
            }
        }

        public void AddSelectColumn(ListView l, string table)
        {
            if (table != null)
            {
                // Xóa hết các mục trong ListView
                l.Items.Clear();

                List<List<String>> list = database.getAllColumn(table, ref ex);
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
                    item.Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Italic);
                    l.Items.Add(item);
                }
            }
        }

        public void AddUpdateColumn(ListView l, string table)
        {
            if (table != null)
            {
                // Xóa hết các mục trong ListView
                l.Items.Clear();

                List<List<String>> list = database.getAllColumn(table, ref ex);
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
                    item.Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Italic);
                    l.Items.Add(item);
                }
            }
        }


        public string GetListViewSelectedItems(ListView listView)
        {
            StringBuilder selectedItemsString = new StringBuilder();

            // Lặp qua tất cả các mục trong ListView
            foreach (ListViewItem item in listView.SelectedItems)
            {
                // Thêm giá trị của mỗi mục đã được chọn vào chuỗi
                selectedItemsString.Append(item.Text); // Hoặc sử dụng item.SubItems[n].Text để lấy giá trị của các cột khác
                selectedItemsString.Append(", "); // Phân tách các mục bằng dấu phẩy và khoảng trắng
            }

            // Loại bỏ dấu phẩy và khoảng trắng cuối cùng nếu có
            if (selectedItemsString.Length > 0)
            {
                selectedItemsString.Length -= 2;
            }

            // Trả về chuỗi chứa các mục đã được chọn
            return selectedItemsString.ToString();
        }



        private void statementTypesCheckBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<string> selectedItems = new List<string>();
            foreach (var item in statementTypesCheckBox.CheckedItems)
            {
                string itemValue = item.ToString();
                if (itemValue != "WITH GRANT OPTION")
                {
                    selectedItems.Add(itemValue);
                }
            }

            selectedStatementTypes = string.Join(",", selectedItems);

            if (selectedItems.Contains("SELECT") && selectedTable != null)
            {
                AddSelectColumn(selectColList, selectedTable);
                tablesList.Enabled = false;
            }
            else
            {
                selectColList.Items.Clear();
                if (!selectedItems.Contains("UPDATE"))
                {
                    tablesList.Enabled = true;
                }
            }

            if (selectedItems.Contains("UPDATE") && selectedTable != null)
            {
                AddUpdateColumn(updateColList, selectedTable);
                tablesList.Enabled = false;
            }
            else
            {
                updateColList.Items.Clear();
                if (!selectedItems.Contains("SELECT"))
                {
                    tablesList.Enabled = true;
                }

            }
        }



        private void tablesList_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (tablesList.SelectedItems.Count > 0)
            {
                selectedTable = ExtractItemString(tablesList.SelectedItems[0].ToString());
                if (selectedStatementTypes != null && selectedStatementTypes.Contains("SELECT"))
                {
                    AddSelectColumn(selectColList, selectedTable);
                }
                if (selectedStatementTypes != null && selectedStatementTypes.Contains("UPDATE"))
                {
                    AddUpdateColumn(updateColList, selectedTable);
                }
                initialSelectedPrivileges.Clear();
                
                List<List<string>> userPrivileges = database.GetUserPrivOnTable(selectedUser, selectedTable, ref ex);

                foreach (List<string> privilege in userPrivileges)
                {
                    initialSelectedPrivileges.Add(privilege[0]);
                }
                string temp = string.Join(",", initialSelectedPrivileges);
                

                // Thêm các mục vào CheckedListBox và đặt trạng thái Checked tương ứng
                if(initialSelectedPrivileges.Count == 0)
                {
                    for (int i = 0; i < statementTypesCheckBox.Items.Count; i++)
                    {
                        statementTypesCheckBox.SetItemChecked(i, false);
                    }
                }
                else
                {
                    
                    foreach (string privilege in initialSelectedPrivileges)
                    {
                        int index = statementTypesCheckBox.Items.IndexOf(privilege);
                        if (index != -1)
                        {
                            statementTypesCheckBox.SetItemChecked(index, true);
                        }
                    }
                }              
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            List<string> values = new List<string>();
            foreach (var item in statementTypesCheckBox.CheckedItems)
            {
                string itemValue = item.ToString();
                if (itemValue != "WITH GRANT OPTION")
                {
                    values.Add(itemValue);
                }
                else
                {
                    isGrantOption = 1;
                }
            }


            selectedStatementTypes = string.Join(",", values);
            selectColumns = GetListViewSelectedItems(selectColList);
            updateColumns = GetListViewSelectedItems(updateColList);

            if (selectedUser != null && selectedTable != null && selectedStatementTypes != null)
            {
                database.RevokePrilegesOnTable(selectedUser, selectedTable);
                database.GrantPermissionToUserOrRole(selectedStatementTypes, selectedTable, selectedUser, isGrantOption, selectColumns, updateColumns);
            }
            else
            {
                MessageBox.Show("Missing User, Table Or Statement Types");
            }

            
            //MessageBox.Show(selectedStatementTypes);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}