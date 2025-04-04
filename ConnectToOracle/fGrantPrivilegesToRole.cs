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
    public partial class fGrantPrivilegesToRole : Form
    {
        Database database;
        Exception ex = null;
        int isGrantOption = 0;
        string selectedTable = null;
        string selectedRole = null;
        string selectColumns = null;
        string updateColumns = null;
        string selectedStatementTypes = null;
        List<string> initialSelectedPrivileges = new List<string>();
        fGrantPrivilegesToUser f;



        public fGrantPrivilegesToRole(string roleName)
        {
            InitializeComponent();
            selectedRole = roleName;
            database = Database.getInstance();
            lbRoleName.Text = lbRoleName.Text + roleName;
            f = new fGrantPrivilegesToUser(roleName);
            f.AddTable(tableList);
        }

        private void tableList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tableList.SelectedItems.Count > 0)
            {
                selectedTable = f.ExtractItemString(tableList.SelectedItems[0].ToString());
                if (selectedStatementTypes != null && selectedStatementTypes.Contains("SELECT"))
                {
                    f.AddSelectColumn(selectColList, selectedTable);
                }
                if (selectedStatementTypes != null && selectedStatementTypes.Contains("UPDATE"))
                {
                    f.AddUpdateColumn(updateColList, selectedTable);
                }
                initialSelectedPrivileges.Clear();
                List<List<string>> userPrivileges = database.GetUserPrivOnTable(selectedRole, selectedTable, ref ex);

                foreach (List<string> privilege in userPrivileges)
                {
                    initialSelectedPrivileges.Add(privilege[0]);
                }
                string temp = string.Join(",", initialSelectedPrivileges);


                // Thêm các mục vào CheckedListBox và đặt trạng thái Checked tương ứng
                if (initialSelectedPrivileges.Count == 0)
                {
                    for (int i = 0; i < statementTypesCheckbox.Items.Count; i++)
                    {
                        statementTypesCheckbox.SetItemChecked(i, false);
                    }
                }
                else
                {

                    foreach (string privilege in initialSelectedPrivileges)
                    {
                        int index = statementTypesCheckbox.Items.IndexOf(privilege);
                        if (index != -1)
                        {
                            statementTypesCheckbox.SetItemChecked(index, true);
                        }
                    }
                }

            }
        }

        private void statementTypesCheckbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<string> selectedItems = new List<string>();
            foreach (var item in statementTypesCheckbox.CheckedItems)
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
                f.AddSelectColumn(selectColList, selectedTable);
                tableList.Enabled = false;
            }
            else
            {
                selectColList.Items.Clear();
                if (!selectedItems.Contains("UPDATE"))
                {
                    tableList.Enabled = true;
                }
            }

            if (selectedItems.Contains("UPDATE") && selectedTable != null)
            {
                f.AddUpdateColumn(updateColList, selectedTable);
                tableList.Enabled = false;
            }
            else
            {
                updateColList.Items.Clear();
                if (!selectedItems.Contains("SELECT"))
                {
                    tableList.Enabled = true;
                }

            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            List<string> values = new List<string>();
            foreach (var item in statementTypesCheckbox.CheckedItems)
            {
                string itemValue = item.ToString();
                if (itemValue != "WITH GRANT OPTION")
                {
                    values.Add(itemValue);
                }
            }


            selectedStatementTypes = string.Join(",", values);
            selectColumns = f.GetListViewSelectedItems(selectColList);
            updateColumns = f.GetListViewSelectedItems(updateColList);

            if (selectedRole!= null && selectedTable != null && selectedStatementTypes != null)
            {
                database.RevokePrilegesOnTable(selectedRole, selectedTable);
                database.GrantPermissionToUserOrRole(selectedStatementTypes, selectedTable, selectedRole, isGrantOption, selectColumns, updateColumns);
            }
            else
            {
                MessageBox.Show("Missing User, Table Or Statement Types");
            }
            //  MessageBox.Show(selectedStatementTypes);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
