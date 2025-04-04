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
    public partial class fEditUser : Form
    {
        Database database;
        Exception ex = null;
        string user_name;
        string _type;
        public fEditUser(string userName, string type)
        {
            InitializeComponent();
            database = Database.getInstance();
            txtUsername.Text = userName;
            txtUsername.Enabled = false;
            user_name = userName;
            _type = type;

        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if(_type == "ROLE")
            {
                database.EditRole(txtUsername.Text, txtPassword.Text);
            }
            else
            {
                database.EditUser(txtUsername.Text, txtPassword.Text);
            }
           
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
