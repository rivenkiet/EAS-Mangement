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
    public partial class Create_User : Form
    {
        Database database;
        Exception ex = null;
        public Create_User()
        {
            InitializeComponent();
            database = Database.getInstance();
        }

        private void create_user(object sender, EventArgs e)
        {
            database.createUser(txtUsername.Text, txtPassword.Text, ref ex);
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
