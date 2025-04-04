using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ConnectToOracle
{
    public partial class AllUserForm : Form
    {
        Database database;
        string currentUser;
        Exception ex = null;
        public AllUserForm(string current_user)
        {
            InitializeComponent();
            database = Database.getInstance();
            AddUser();
            AddRoles();
            currentUser = current_user;
            lbCurrentUser.Text = "User: " + current_user;
        }


        private void AddUser()
        {
            List<List<String>> list = database.getAllUsers(ref ex);
            if(ex != null)
            {
                MessageBox.Show(ex.Message);
                ex = null;
                return;
            }
            for(int i = 0; i < list.Count; i++)
            {
                ListViewItem item = new ListViewItem();
                item.Text = list[i][0];
                item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = list[i][1] });
                item.Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Italic);
                listUsers.Items.Add(item);
                
            }
            
        }

        private void AddRoles()
        {
            List<String> list = database.getAllRoles(ref ex);
            if(ex != null)
            {
                MessageBox.Show(ex.Message);
                ex = null;
                return ;
            }
            for(int i = 0;i< list.Count; i++)
            {
                ListViewItem item = new ListViewItem();
                item.Text = list[i];
                item.Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Italic);
                listRoles.Items.Add(item);
            }
        }

        private void listUsers_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewHitTestInfo info = listUsers.HitTest(e.X, e.Y);
            ListViewItem item = info.Item;
            if (item != null)
            {
                //GrantRevokeForm form = new GrantRevokeForm(item.Text,"USER");
                fGrantMenu form  = new fGrantMenu(item.Text, "USER");
                form.ShowDialog();
                AllUserForm f = new AllUserForm(currentUser);
                this.Dispose();
                f.ShowDialog();

            }
            else
            {
                this.listUsers.SelectedItems.Clear();
                
                MessageBox.Show("No Item is selected");
            }
        }

        private void listRoles_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewHitTestInfo info = listRoles.HitTest(e.X, e.Y);
            ListViewItem item = info.Item;
            if (item != null)
            {
                // GrantRevokeForm form = new GrantRevokeForm(item.Text, "ROLE");
                fGrantMenu form = new fGrantMenu(item.Text, "ROLE");
                form.ShowDialog();
                AllUserForm f = new AllUserForm(currentUser);
                this.Dispose();
                f.ShowDialog();

            }
            else
            {
                this.listUsers.SelectedItems.Clear();

                MessageBox.Show("No Item is selected");
            }
        }

        private void btnCreateUser_Click(object sender, EventArgs e)
        {
            Create_User f = new Create_User();
            this.Hide();
            f.ShowDialog();

            AllUserForm form = new AllUserForm(currentUser);
            this.Dispose();
            form.ShowDialog();
        }

        private void btnCreateRole_Click(object sender, EventArgs e)
        {
            fCreateRole form = new fCreateRole();
            this.Hide();
            form.ShowDialog();

            AllUserForm f = new AllUserForm(currentUser);
            this.Dispose();
            f.ShowDialog();
        }

        private void btnGrantRole_Click(object sender, EventArgs e)
        {
            fGrantRoleToUser form = new fGrantRoleToUser();
            this.Hide();
            form.ShowDialog();
            this.Show();
        }
    }
}
