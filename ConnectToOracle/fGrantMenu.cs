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
    public partial class fGrantMenu : Form
    {
        Exception ex;
        Database database;
        string name;
        string type;
        public fGrantMenu(string _name, string _type)
        {
            InitializeComponent();
            name = _name;
            type = _type;
            database = Database.getInstance();
            if (type == "ROLE")
            {
                lbName.Text = "Role: ";
            }
            else
            {
                lbName.Text = "User: ";
            }
            lbName.Text = lbName.Text + name;
        }

        private void btnGrantSystem_Click(object sender, EventArgs e)
        {
            GrantRevokeForm form = new GrantRevokeForm(name, type);

            this.Hide();
            form.ShowDialog();
            this.Show();
            
        }

        private void btnGrantTable_Click(object sender, EventArgs e)
        {
            if(type == "USER")
            {
                fGrantPrivilegesToUser form = new fGrantPrivilegesToUser(name);
                this.Hide();
                form.ShowDialog();
                this.Show();
            }
            else if(type == "ROLE")
            {
                fGrantPrivilegesToRole form = new fGrantPrivilegesToRole(name);
                this.Hide();
                form.ShowDialog();
                this.Show();
            }
            
        }

        private void btnGrantRole_Click(object sender, EventArgs e)
        {
            fGrantRoleToUser form = new fGrantRoleToUser();
            this.Hide();
            form.ShowDialog();
            this.Show();
        }

        private void dropUser(object sender, EventArgs e)
        {
            if (type == "USER")
            {
                database.dropUser(name, ref ex);
            }
            else if(type == "ROLE")
            {
                database.dropRole(name, ref ex);
            }
            
            if (ex != null)
            {
                MessageBox.Show(ex.Message);
                ex = null;
                return;
            }
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            Get_Privileges form = new Get_Privileges(name,type);
            this.Hide();
            form.ShowDialog();
            this.Show();
            
            
            
        }

        private void btnEditUser_Click(object sender, EventArgs e)
        {
            fEditUser form = new fEditUser(name, type);
            this.Hide();
            form.ShowDialog();
            this.Show();
        }
    }
}
