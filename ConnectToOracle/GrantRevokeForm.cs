using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConnectToOracle
{
    public partial class GrantRevokeForm : Form
    {
        Database database;
        Exception ex = null;
        string name;
        string type;
        List<List<string>> privsAAgent;
        List<string> grantList = new List<string>(); //list chua cac privs muon grant 
        List<string> grantAdminOptionList = new List<string>();
        List<string> revokeList = new List<string>();
        List<string> revokeAdminOptionList = new List<string>();
        public GrantRevokeForm(string _name,string _type)
        {
            InitializeComponent();
            database = Database.getInstance();
            name = _name;
            type = _type;
            if(type=="ROLE")
            {
                lblName.Text = "Role: ";
            }
            else
            {
                lblName.Text = "User: ";
            }
            lblName.Text = lblName.Text + name;
            AddPrivs();
        }

        private void AddPrivs()
        {
            List<string> privs = database.getAllSystemPrivis(ex);
            privsAAgent = database.getSysPrivsOfAAgent(name,ex);
            if(ex != null)
            {
                MessageBox.Show(ex.Message);
                ex = null;
                return;
            }
            foreach (string priv in privs)
            {
                int index = 0;
                bool isGranted = checkGranted(priv, privsAAgent, ref index);
                bool isAdminOption = false;
                DataGridViewRow row = new DataGridViewRow();
                row.Cells.Add(new DataGridViewTextBoxCell() { Value = priv});
                
                row.Cells.Add(new DataGridViewCheckBoxCell() { Value = isGranted });
                if (isGranted)
                {
                    if (privsAAgent[index][1] == "NO")
                    {
                        isAdminOption = false ;
                    }
                    else
                    {
                        isAdminOption = true;
                    }
                }

                row.Cells.Add(new DataGridViewCheckBoxCell() { Value = isAdminOption });
                row.DefaultCellStyle.Font = new Font("Arial", 10, System.Drawing.FontStyle.Italic);
                listPrivs.Rows.Add(row);
            }
            
        }

        private bool checkGranted(string priv, List<List<string>> privsAAgent,ref int index)
        {
            bool check = false;
            for(int i = 0; i < privsAAgent.Count; i++)
            {
                if(priv == privsAAgent[i][0])
                {
                    check = true;
                    index = i;
                    break;
                }
            }
            return check;
        }

        private void listPrivs_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 1) //nhan vao button granted
            {
                //Reference the GridView Row.
                DataGridViewRow row = listPrivs.Rows[e.RowIndex];

                //Set the CheckBox selection.
                row.Cells["grantedCol"].Value = !Convert.ToBoolean(row.Cells["grantedCol"].EditedFormattedValue);
                if (Convert.ToBoolean(row.Cells["grantedCol"].Value))//if revoke
                {
                    if (Convert.ToBoolean(row.Cells["adminOptionCol"].Value)) //to revoke admin option
                    {
                        row.Cells["adminOptionCol"].Value = !Convert.ToBoolean(row.Cells["adminOptionCol"].EditedFormattedValue);
                    }
                    
                    if (grantList.Contains(row.Cells[0].Value.ToString()) == true)// remove to grantlist if have
                    {
                        grantList.Remove(row.Cells[0].Value.ToString());
                    }
                    else if (grantAdminOptionList.Contains(row.Cells[0].Value.ToString())) //remove to grantlistforadmin
                    {
                        grantAdminOptionList.Remove(row.Cells[0].Value.ToString());
                    }
                    else//add to revoke list
                    {
                        
                        revokeList.Add(row.Cells[0].Value.ToString());
                        if (revokeAdminOptionList.Contains(row.Cells[0].Value.ToString())) //if revoke normaly don't need to revoke with admin option
                        {
                            revokeAdminOptionList.Remove(row.Cells[0].Value.ToString());
                        }
                    }
                }
                else//if grant
                {
                    if (revokeList.Contains(row.Cells[0].Value.ToString()) == true)//remove to revoke list if have
                    {
                        revokeList.Remove(row.Cells[0].Value.ToString());
                        List<string> temp = new List<string>();
                        temp.Add(row.Cells[0].Value.ToString());
                        temp.Add("YES");
                        if (!revokeAdminOptionList.Contains(row.Cells[0].Value.ToString()) && !privsAAgent.Contains(temp))
                        {
                            revokeAdminOptionList.Add(row.Cells[0].Value.ToString());
                        }

                    }
                    else//add to grantlist
                    {
                        grantList.Add(row.Cells[0].Value.ToString());
                    }
                }
            }

            if (e.RowIndex >= 0 && e.ColumnIndex == 2) //khi nhan vao admin option
            {
                //Reference the GridView Row.
                DataGridViewRow row = listPrivs.Rows[e.RowIndex];

                //Set the CheckBox selection.
                row.Cells["adminOptionCol"].Value = !Convert.ToBoolean(row.Cells["adminOptionCol"].EditedFormattedValue);

                if (Convert.ToBoolean(row.Cells["adminOptionCol"].Value))//if revoke
                {
                    
                    if (grantAdminOptionList.Contains(row.Cells[0].Value.ToString()) == true)//remove grantadminoption list if gave
                    {
                        grantAdminOptionList.Remove(row.Cells[0].Value.ToString());
                        List<string> temp = new List<string>();
                        //use case: revoke admin option but have grant normal
                        if(!grantList.Contains(row.Cells[0].Value.ToString()) && !checkPrivs(row.Cells[0].Value.ToString()))
                        {
                            grantList.Add(row.Cells[0].Value.ToString());
                        }
                    }
                    else//add to revoke admin option
                    {
                        revokeAdminOptionList.Add(row.Cells[0].Value.ToString());
                    }
                }
                else//if grant
                {
                    if (!Convert.ToBoolean(row.Cells["grantedCol"].Value))//set true for grantcol when set true for adminoption
                    {
                        row.Cells["grantedCol"].Value = !Convert.ToBoolean(row.Cells["grantedCol"].EditedFormattedValue);
                        
                    }
                    
                    if (revokeAdminOptionList.Contains(row.Cells[0].Value.ToString()) == true)//remove if list have
                    {
                        revokeAdminOptionList.Remove(row.Cells[0].Value.ToString());
                    }
                    
                    else//add list
                    {
                        if (revokeList.Contains(row.Cells[0].Value.ToString()))
                        {
                            revokeList.Remove(row.Cells[0].Value.ToString());
                        }
                        grantAdminOptionList.Add(row.Cells[0].Value.ToString());
                        if (grantList.Contains(row.Cells[0].Value.ToString()))//if grant by adminoption, don't need to grant normaly
                        {
                            grantList.Remove(row.Cells[0].Value.ToString());
                        }
                    }
                }

            }
        }

        //kiem tra doi tuong hien tai co quyen nay hay khong
        private bool checkPrivs(string name)
        {
            bool check = false;
            for(int i=0;i<privsAAgent.Count;i++)
            {
                if (privsAAgent[i][0] == name)
                {
                    check = true;
                    break;
                }
            }
            return check;
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            //Grant quyền cho user hoặc role không có admin option 
            foreach (string i in grantList)
            {
                database.GrantPrileges(name, i);
            }
            //Grant quyền cho user hoặc role có admin option 
            foreach (string i in grantAdminOptionList)
            {
                database.GrantPrilegesWithAdminOption(name, i);
            }
            //Revoke quyền cho user hoặc role không có admin option 
            foreach (string i in revokeList)
            {
                database.RevokePrileges(name, i);
            }
            //Revoke quyền cho user hoặc role có admin option 
            foreach (string i in revokeAdminOptionList)
            {
                database.RevokePrilegesWithAdminOption(name, i);
            }
            GrantRevokeForm form = new GrantRevokeForm(name, type);
            this.Dispose();
            form.ShowDialog();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
