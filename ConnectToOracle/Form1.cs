using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;

namespace ConnectToOracle
{
    public partial class fLogin : Form
    {
        Database database;
        Exception ex = null;
        public fLogin()
        {
            InitializeComponent();

            database = Database.getInstance();
        }

        private void btnLogInEnter(object sender, EventArgs e)
        {
            if(database != null)
            {
                database.logInToDataBse(txtUsername.Text,txtPassword.Text,ref ex);
;            }
            if(ex != null)
            {
                MessageBox.Show(ex.Message);
                ex = null;
                return;
            }
          // fMain f = new fMain();
            AllUserForm f = new AllUserForm(txtUsername.Text);

            this.Hide();
            f.ShowDialog();
            database.logOut();
            txtUsername.Text = "";
            txtPassword.Text = "";
            this.Show();

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void fLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(MessageBox.Show("Exit the program?", "Notify", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
                
            }
        }
    }


}
