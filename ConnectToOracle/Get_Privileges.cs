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

namespace ConnectToOracle
{
    public partial class Get_Privileges : Form
    {
        Database database;
        string name;
        string type;
        Exception ex = null;
        List<List<String>> list;
        public Get_Privileges(string name, string type)
        {
            InitializeComponent();
            database = Database.getInstance();
            this.name = name;
            if (type == "USER" )
            {
                list = database.getALLPrivilegesOfUser(name, ref ex);
            }
            else
            {
                list = database.getALLPrivilegesOfRole(name, ref ex);
            }
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
                listPrivileges.Items.Add(item);
            }
        }

        
        
    }
}
