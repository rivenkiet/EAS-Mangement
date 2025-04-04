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
    public partial class fCreateRole : Form
    {
        Database database;
        Exception ex = null;
        public fCreateRole()
        {
            InitializeComponent();
            database = Database.getInstance();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            database.createRole(txtUsername.Text, txtPassword.Text, ref ex);
            if (ex != null)
            {
                MessageBox.Show(ex.Message);
                ex = null;
                return;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
