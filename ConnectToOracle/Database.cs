using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;
using Oracle.ManagedDataAccess.EntityFramework;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ConnectToOracle
{
    class Database
    {
        private OracleConnection con = null; 
        private static Database _instance;
        bool isLogIn = false;

        //Tao ra doi tuong de thuc thi cac ham
        private Database()
        {
        
        }

        //Ngan chan viec tu dong don giai phong tai nguyen cua C#
        internal class OpenedContext : IDisposable
        {
            private OracleConnection _connection;

            public OpenedContext(OracleConnection conn)
            {
                _connection = conn;
                if (_connection.State != System.Data.ConnectionState.Open) _connection.Open();
            }

            public void Dispose()
            {
                if (_connection.State != System.Data.ConnectionState.Closed) _connection.Close();
            }

        }

        //Thuc hien viec login va set isLogin bang true nhung lan sau ham khong con hoat dong
        public void logInToDataBse(string account, string password,ref Exception exOutput)
        {
            // Nhớ hỏi nếu bỏ return thì lần sau vẫn log in bằng user khác được ko?
            /*if(isLogIn)
            {
                return;
            }*/
            String connectionString = $@"Data Source= (DESCRIPTION =
    (ADDRESS = (PROTOCOL = TCP)(HOST = 127.0.0.1)(PORT = 1521))
    (CONNECT_DATA =
      (SERVER = DEDICATED)
      (SERVICE_NAME = XE)
    )
  ); User Id = {account};password={password};DBA Privilege=SYSDBA;"; // Nếu để DBA Privilege là SYSDBA thì ko đăng nhập bằng user thường được
            bool check = true;
            con = new OracleConnection(connectionString);

            try
            {
                con.Open();
                isLogIn = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                exOutput = ex;
                check = false;
                isLogIn = false; // Trường hợp Log in lỗi
            }
            if (!check)
            {
                con = null;
            }
        }

        //Ham lay ra doi tuong de thuc thi
        public static Database getInstance()
        {
            if (_instance == null)
            {
                _instance = new Database();
            }
            return _instance;
        }
 
        //ham lay tat ca cac user neu chua dang nhap thi khong co du lieu
        public List<List<String>> getAllUsers(ref Exception  exOutput)
        {
            if (isLogIn == false) return new List<List<string>>();
            List<List<String>>  result = new List<List<string>>();
            using(new OpenedContext(con))
            {
                try
                {
                    OracleCommand cmd = new OracleCommand("GET_ALL_USERS",con);

                    cmd.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    dt.Load(cmd.ExecuteReader());
                    foreach (DataRow dr in dt.Rows)
                    {
                        List<String> temp = new List<String>();
                        temp.Add(dr.Field<String>(0));
                        temp.Add(dr.Field<String>(1));
                        result.Add(temp);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    exOutput = ex;
                }
            }
            return result;
        }

        public List<String> getAllRoles(ref Exception exOutput)
        {
            if (isLogIn == false) return new List<String>();
            List<String> result = new List<String>();
            using (new OpenedContext(con))
            {
                try
                {
                    OracleCommand cmd = new OracleCommand("GET_ALL_ROLES", con);

                    cmd.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    dt.Load(cmd.ExecuteReader());
                    foreach (DataRow dr in dt.Rows)
                    {
                        result.Add(dr.Field<String>(0));
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    exOutput = ex;
                }
            }
            return result;
        }

        public List<String> getAllSystemPrivis(Exception exOutput)
        {
            if(isLogIn == false) return new List<String>();
            List<String> result = new List<String>();
            using (new OpenedContext(con))
            {
                try
                {
                    OracleCommand cmd = new OracleCommand("GET_ALL_PRIVS", con);

                    cmd.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    dt.Load(cmd.ExecuteReader());
                    foreach (DataRow dr in dt.Rows)
                    {
                        result.Add(dr.Field<String>(0));
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    exOutput = ex;
                }
            }
            return result;
        }

        public List<List<String>> getSysPrivsOfAAgent(String agent,Exception exOutput)
        {
            if (isLogIn == false) return new List<List<String>>();
            List<List<String>> result = new List<List<String>>();
            using (new OpenedContext(con))
            {
                try
                {
                    OracleCommand cmd = new OracleCommand("CHECK_PRIVIS_A_ACTOR", con);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("USER_NAME",OracleDbType.Varchar2).Value = agent;
                    DataTable dt = new DataTable();
                    dt.Load(cmd.ExecuteReader());
                    foreach (DataRow dr in dt.Rows)
                    {
                        List<String> temp = new List<String>();
                        temp.Add(dr.Field<String>(0));
                        temp.Add(dr.Field<String>(1));
                        result.Add(temp);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    exOutput = ex;
                }
            }
            return result;
        }
        public List<List<String>> getALLPrivilegesOfRole(string name, ref Exception exOutput)
        {
            if (isLogIn == false) return new List<List<string>>();
            List<List<String>> result = new List<List<string>>();
            using (new OpenedContext(con))
            {
                try
                {
                    OracleCommand cmd = new OracleCommand($"select DISTINCT PRIVILEGE,TABLE_NAME from ROLE_TAB_PRIVS WHERE ROLE = '{name}'");

                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;
                    OracleDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        List<String> temp = new List<String>();
                        temp.Add(reader.GetString(0));
                        temp.Add(reader.GetString(1));
                        result.Add(temp);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    exOutput = ex;
                }
            }
            return result;
        }

        
        //Lấy quyền trên bảng của một user 
        public List<List<String>> getALLPrivilegesOfUser(string name, ref Exception exOutput)
        {
            if (isLogIn == false) return new List<List<string>>();
            List<List<String>> result = new List<List<string>>();
            using (new OpenedContext(con))
            {
                try
                {   // Bảng DBA_TAB_PRIVS cho ra quyền trên bảng của bao gồm cả role và user
                    OracleCommand cmd = new OracleCommand($"select PRIVILEGE,TABLE_NAME from DBA_TAB_PRIVS  WHERE GRANTEE = '{name}'");// limit cho máy chạy

                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;
                    OracleDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        List<String> temp = new List<String>();
                        temp.Add(reader.GetString(0));
                        temp.Add(reader.GetString(1));
                        result.Add(temp);
                    }

                    OracleCommand cmd2 = new OracleCommand($"select DISTINCT PRIVILEGE,TABLE_NAME from All_COL_PRIVS  WHERE GRANTEE = '{name}'");// limit cho máy chạy

                    cmd2.Connection = con;
                    cmd2.CommandType = CommandType.Text;
                    OracleDataReader reader2 = cmd2.ExecuteReader();
                    while (reader2.Read())
                    {
                        List<String> temp = new List<String>();
                        temp.Add(reader2.GetString(0));
                        temp.Add(reader2.GetString(1));
                        result.Add(temp);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    exOutput = ex;
                }
            }
            return result;
        }


        public void createUser(string name, string pass, ref Exception exOutput)
        {
            if (isLogIn == false) return;

            using (new OpenedContext(con))
            {
                try
                {
                    OracleCommand cmd = new OracleCommand();
                    cmd.CommandText = "CREATE_USER";
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("pi_username", OracleDbType.Varchar2).Value = name;
                    cmd.Parameters.Add("pi_password", OracleDbType.Varchar2).Value = pass;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Create Success!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    exOutput = ex;
                }
            }
        }

        //Create role function
        public void createRole(string name, string pass, ref Exception exOutput)
        {
            if (isLogIn == false) return;

            using (new OpenedContext(con))
            {
                try
                {
                    OracleCommand cmd = new OracleCommand();
                    cmd.CommandText = "CREATE_ROLE";
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("pi_username", OracleDbType.Varchar2).Value = name;
                    cmd.Parameters.Add("pi_password", OracleDbType.Varchar2).Value = pass;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Create Success!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    exOutput = ex;
                }
            }
        }

        public List<List<String>> getAllColumn(string tableName, ref Exception exOutput)
        {
            if (isLogIn == false) return new List<List<string>>();
            List<List<String>> result = new List<List<string>>();
            using (new OpenedContext(con))
            {
                try
                {
                    string query = "SELECT column_name FROM USER_TAB_COLUMNS WHERE table_name = :table_name";
                    OracleCommand cmd = new OracleCommand(query);
                    cmd.Parameters.Add(new OracleParameter(":table_name", tableName));

                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;
                    OracleDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        List<String> temp = new List<String>();
                        temp.Add(reader.GetString(0));
                        result.Add(temp);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    exOutput = ex;
                }
            }

            return result;
        }

        //Câp quyền trên table cho user hoặc role 
        public void GrantPermissionToUserOrRole(string permissionType, string tableName, string targetName, int isGrantOption, string columnNamesSelect, string columnNamesUpdate)
        {
            bool success = false;

            try
            {
                // Tạo kết nối
                using (new OpenedContext(con))
                {
                    // Tạo đối tượng command
                    using (OracleCommand cmd = new OracleCommand("Sp_Grant_Permission_To_User_Or_Role", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Thêm các tham số vào command
                        cmd.Parameters.Add(new OracleParameter("permission_type", OracleDbType.Varchar2)).Value = permissionType;
                        cmd.Parameters.Add(new OracleParameter("tablename", OracleDbType.Varchar2)).Value = tableName;
                        cmd.Parameters.Add(new OracleParameter("target_name", OracleDbType.Varchar2)).Value = targetName;
                        cmd.Parameters.Add(new OracleParameter("is_grant_option", OracleDbType.Int32)).Value = isGrantOption;
                        cmd.Parameters.Add(new OracleParameter("column_name_select", OracleDbType.Varchar2)).Value = columnNamesSelect;
                        cmd.Parameters.Add(new OracleParameter("column_name_update", OracleDbType.Varchar2)).Value = columnNamesUpdate;

                        // Thực thi command
                        cmd.ExecuteNonQuery();

                        // Nếu đến được đến đây mà không có lỗi, đánh dấu thành công
                        success = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show(ex.Message);
            }

            // Hiển thị thông báo tương ứng
            if (success)
            {
                MessageBox.Show("Procedure executed successfully");
            }
            else
            {
                MessageBox.Show("Procedure executed failed");
            }
        }

        //Thực thi procedure cấp role cho user 
        public void GrantRoleToUser(string userName, string roleName)
        {
            bool success = false;

            try
            {
                // Tạo kết nối
                using (new OpenedContext(con))
                {
                    // Tạo đối tượng command
                    using (OracleCommand cmd = new OracleCommand("Sp_Grant_Role_To_User", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Thêm các tham số vào command
                        cmd.Parameters.Add(new OracleParameter("username", OracleDbType.Varchar2)).Value = userName;
                        cmd.Parameters.Add(new OracleParameter("rolename", OracleDbType.Varchar2)).Value = roleName;

                        // Thực thi command
                        cmd.ExecuteNonQuery();

                        // Nếu đến được đến đây mà không có lỗi, đánh dấu thành công
                        success = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show(ex.Message);
            }

            // Hiển thị thông báo tương ứng
            if (success)
            {
                MessageBox.Show("Procedure executed successfully");
            }
            else
            {
                MessageBox.Show("Procedure executed failed");
            }
        }

        //Thay đổi mật khẩu của một user  
        public void EditUser(string userName, string password)
        {
            bool success = false;
            try
            {
                // Tạo kết nối
                using (new OpenedContext(con))
                {
                    // Tạo đối tượng command
                    using (OracleCommand cmd = new OracleCommand("ChangeUserPassword", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Thêm các tham số vào command
                        cmd.Parameters.Add(new OracleParameter("username", OracleDbType.Varchar2)).Value = userName;
                        cmd.Parameters.Add(new OracleParameter("new_password", OracleDbType.Varchar2)).Value = password;

                        // Thực thi command
                        cmd.ExecuteNonQuery();

                        // Nếu đến được đến đây mà không có lỗi, đánh dấu thành công
                        success = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show(ex.Message);
            }

            // Hiển thị thông báo tương ứng
            if (success)
            {
                MessageBox.Show("Procedure executed successfully");
            }
            else
            {
                MessageBox.Show("Procedure executed failed");
            }
        }

        //Thay đổi mật khẩu của một role  
        public void EditRole(string userName, string password)
        {
            bool success = false;
            try
            {
                // Tạo kết nối
                using (new OpenedContext(con))
                {
                    // Tạo đối tượng command
                    using (OracleCommand cmd = new OracleCommand("ChangeRolePassword", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Thêm các tham số vào command
                        cmd.Parameters.Add(new OracleParameter("username", OracleDbType.Varchar2)).Value = userName;
                        cmd.Parameters.Add(new OracleParameter("new_password", OracleDbType.Varchar2)).Value = password;

                        // Thực thi command
                        cmd.ExecuteNonQuery();

                        // Nếu đến được đến đây mà không có lỗi, đánh dấu thành công
                        success = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show(ex.Message);
            }

            // Hiển thị thông báo tương ứng
            if (success)
            {
                MessageBox.Show("Procedure executed successfully");
            }
            else
            {
                MessageBox.Show("Procedure executed failed");
            }
        }

        //Lấy các quyền của một user trên một table 
        public List<List<String>> GetUserPrivOnTable(string userName, string tableName, ref Exception exOutput)
        {
            if (isLogIn == false) return new List<List<string>>();
            List<List<String>> result = new List<List<string>>();
            using (new OpenedContext(con))
            {
                try
                {
                    string query = "SELECT PRIVILEGE FROM all_tab_privs WHERE table_name = :table_name AND grantee = :user_name";
                    OracleCommand cmd = new OracleCommand(query);

                    cmd.Parameters.Add(new OracleParameter(":table_name", tableName));
                    cmd.Parameters.Add(new OracleParameter(":user_name", userName));

                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;
                    OracleDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        List<String> temp = new List<String>();
                        temp.Add(reader.GetString(0));
                        result.Add(temp);
                    }

                    //Lay quyen update
                    string query2 = "SELECT DISTINCT PRIVILEGE FROM All_COL_PRIVS WHERE table_name = :table_name AND grantee = :user_name";
                    OracleCommand cmd2 = new OracleCommand(query2);

                    cmd2.Parameters.Add(new OracleParameter(":table_name", tableName));
                    cmd2.Parameters.Add(new OracleParameter(":user_name", userName));

                    cmd2.Connection = con;
                    cmd2.CommandType = CommandType.Text;
                    OracleDataReader reader2 = cmd2.ExecuteReader();
                    while (reader2.Read())
                    {
                        List<String> temp = new List<String>();
                        temp.Add(reader2.GetString(0));
                        result.Add(temp);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    exOutput = ex;
                }
            }
          return result;
        }



        //XÓA USER 
        public void dropUser(string name, ref Exception exOutput)
        {
            if (isLogIn == false) return;
            using (new OpenedContext(con))
            {
                try
                {

                    OracleCommand cmd = new OracleCommand();
                    cmd.CommandText = "DROP_USER";
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("pi_username", OracleDbType.Varchar2).Value = name;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Drop Success!");
                  }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    exOutput = ex;
                }
            }
        }

        public void dropRole(string name, ref Exception exOutput)
        {
            if (isLogIn == false) return;
            using (new OpenedContext(con))
            {
                try
                {

                    OracleCommand cmd = new OracleCommand();
                    cmd.CommandText = "DROP_ROLE";
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("pi_username", OracleDbType.Varchar2).Value = name;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Drop Success!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    exOutput = ex;
                }
            }
        }








        public List<List<String>> getAllTables(ref Exception exOutput)
    {
        if (isLogIn == false) return new List<List<string>>();
        List<List<String>> result = new List<List<string>>();
        using (new OpenedContext(con))
        {
            try
            {
                OracleCommand cmd = new OracleCommand("SELECT table_name FROM tabs");

                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                OracleDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    List<String> temp = new List<String>();
                    temp.Add(reader.GetString(0));
                    result.Add(temp);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                exOutput = ex;
            }
        }
        return result;

    }
        //Cấp quyền cho user hoặc role không có admin option 
        public void GrantPrileges(string userName, string privileges)
        {
            bool success = false;

            try
            {
                // Tạo kết nối
                using (new OpenedContext(con))
                {
                    // Tạo đối tượng command
                    using (OracleCommand cmd = new OracleCommand("GRANT_PRIVILEGES", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Thêm các tham số vào command
                        cmd.Parameters.Add(new OracleParameter("USER_NAME", OracleDbType.Varchar2)).Value = userName;
                        cmd.Parameters.Add(new OracleParameter("QUYEN", OracleDbType.Varchar2)).Value = privileges;

                        // Thực thi command
                        cmd.ExecuteNonQuery();

                        // Nếu đến được đến đây mà không có lỗi, đánh dấu thành công
                        success = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show(ex.Message);
            }
            // Hiển thị thông báo tương ứng
            if (success)
            {
                MessageBox.Show("Procedure executed successfully");
            }
            else
            {
                MessageBox.Show("Procedure executed failed");
            }
        }

        //Cấp quyền cho user hoặc role có admin option 
        public void GrantPrilegesWithAdminOption(string userName, string privileges)
        {
            bool success = false;

            try
            {
                // Tạo kết nối
                using (new OpenedContext(con))
                {
                    // Tạo đối tượng command
                    using (OracleCommand cmd = new OracleCommand("GRANT_ADMIN_OPTION", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Thêm các tham số vào command
                        cmd.Parameters.Add(new OracleParameter("USER_NAME", OracleDbType.Varchar2)).Value = userName;
                        cmd.Parameters.Add(new OracleParameter("QUYEN", OracleDbType.Varchar2)).Value = privileges;

                        // Thực thi command
                        cmd.ExecuteNonQuery();

                        // Nếu đến được đến đây mà không có lỗi, đánh dấu thành công
                        success = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show(ex.Message);
            }
            // Hiển thị thông báo tương ứng
            if (success)
            {
                MessageBox.Show("Procedure executed successfully");
            }
            else
            {
                MessageBox.Show("Procedure executed failed");
            }
        }


        //Thu hồi quyền không có admin option 
        public void RevokePrileges(string userName, string privileges)
        {
            bool success = false;

            try
            {
                // Tạo kết nối
                using (new OpenedContext(con))
                {
                    // Tạo đối tượng command
                    using (OracleCommand cmd = new OracleCommand("REVOKE_PRIVILEGES", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Thêm các tham số vào command
                        cmd.Parameters.Add(new OracleParameter("USER_NAME", OracleDbType.Varchar2)).Value = userName;
                        cmd.Parameters.Add(new OracleParameter("QUYEN", OracleDbType.Varchar2)).Value = privileges;

                        // Thực thi command
                        cmd.ExecuteNonQuery();

                        // Nếu đến được đến đây mà không có lỗi, đánh dấu thành công
                        success = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show(ex.Message);
            }
            // Hiển thị thông báo tương ứng
            if (success)
            {
                MessageBox.Show("Procedure executed successfully");
            }
            else
            {
                MessageBox.Show("Procedure executed failed");
            }
        }

        //Thu hồi quyền trên table
        public void RevokePrilegesOnTable(string userName, string tableName)
        {
            bool success = false;

            try
            {
                // Tạo kết nối
                using (new OpenedContext(con))
                {
                    // Tạo đối tượng command
                    using (OracleCommand cmd = new OracleCommand("Sp_RevokePrivilegeOnTable", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Thêm các tham số vào command
                        cmd.Parameters.Add(new OracleParameter("username", OracleDbType.Varchar2)).Value = userName;
                        cmd.Parameters.Add(new OracleParameter("tablename", OracleDbType.Varchar2)).Value = tableName;

                        // Thực thi command
                        cmd.ExecuteNonQuery();

                        // Nếu đến được đến đây mà không có lỗi, đánh dấu thành công
                        success = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show(ex.Message);
            }
            // Hiển thị thông báo tương ứng
            if (success)
            {
              //  MessageBox.Show("Revoke Procedure executed successfully");
            }
            else
            {
                MessageBox.Show("Revoke Procedure executed failed");
            }
        }

        //Thu hồi quyền có admin option 
        public void RevokePrilegesWithAdminOption(string userName, string privileges)
        {
            bool success = false;

            try
            {
                // Tạo kết nối
                using (new OpenedContext(con))
                {
                    // Tạo đối tượng command
                    using (OracleCommand cmd = new OracleCommand("REVOKE_ADMIN_OPTION", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Thêm các tham số vào command
                        cmd.Parameters.Add(new OracleParameter("USER_NAME", OracleDbType.Varchar2)).Value = userName;
                        cmd.Parameters.Add(new OracleParameter("QUYEN", OracleDbType.Varchar2)).Value = privileges;

                        // Thực thi command
                        cmd.ExecuteNonQuery();

                        // Nếu đến được đến đây mà không có lỗi, đánh dấu thành công
                        success = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show(ex.Message);
            }
            // Hiển thị thông báo tương ứng
            if (success)
            {
                MessageBox.Show("Procedure executed successfully");
            }
            else
            {
                MessageBox.Show("Procedure executed failed");
            }
        }


        public void logOut()
        {
            if (isLogIn) {
                con = null;
                isLogIn = false;
            }
        }
        ~Database()
        {
            con = null;
            if(_instance != null)
            {
                _instance = null;
            }
        }

    }
}
