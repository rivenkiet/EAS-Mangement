namespace ConnectToOracle
{
    partial class AllUserForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listUsers = new System.Windows.Forms.ListView();
            this.nameCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.statusCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listRoles = new System.Windows.Forms.ListView();
            this.roleCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lbCurrentUser = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnGrantRole = new System.Windows.Forms.Button();
            this.btnCreateRole = new System.Windows.Forms.Button();
            this.btnCreateUser = new System.Windows.Forms.Button();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // listUsers
            // 
            this.listUsers.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.listUsers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nameCol,
            this.statusCol});
            this.listUsers.Dock = System.Windows.Forms.DockStyle.Left;
            this.listUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.listUsers.ForeColor = System.Drawing.SystemColors.InfoText;
            this.listUsers.FullRowSelect = true;
            this.listUsers.GridLines = true;
            this.listUsers.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listUsers.HideSelection = false;
            this.listUsers.Location = new System.Drawing.Point(0, 0);
            this.listUsers.MultiSelect = false;
            this.listUsers.Name = "listUsers";
            this.listUsers.Size = new System.Drawing.Size(396, 438);
            this.listUsers.TabIndex = 0;
            this.listUsers.UseCompatibleStateImageBehavior = false;
            this.listUsers.View = System.Windows.Forms.View.Details;
            this.listUsers.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listUsers_MouseDoubleClick);
            // 
            // nameCol
            // 
            this.nameCol.Text = "AccountName";
            this.nameCol.Width = 182;
            // 
            // statusCol
            // 
            this.statusCol.Text = "Status";
            this.statusCol.Width = 145;
            // 
            // listRoles
            // 
            this.listRoles.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.listRoles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.roleCol});
            this.listRoles.Dock = System.Windows.Forms.DockStyle.Right;
            this.listRoles.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.listRoles.FullRowSelect = true;
            this.listRoles.GridLines = true;
            this.listRoles.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listRoles.HideSelection = false;
            this.listRoles.Location = new System.Drawing.Point(421, 0);
            this.listRoles.MultiSelect = false;
            this.listRoles.Name = "listRoles";
            this.listRoles.Size = new System.Drawing.Size(268, 438);
            this.listRoles.TabIndex = 1;
            this.listRoles.UseCompatibleStateImageBehavior = false;
            this.listRoles.View = System.Windows.Forms.View.Details;
            this.listRoles.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listRoles_MouseDoubleClick);
            // 
            // roleCol
            // 
            this.roleCol.Text = "Role";
            this.roleCol.Width = 132;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.listUsers);
            this.panel1.Controls.Add(this.listRoles);
            this.panel1.Location = new System.Drawing.Point(235, 99);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(689, 438);
            this.panel1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.ForeColor = System.Drawing.Color.LightGray;
            this.label2.Location = new System.Drawing.Point(408, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(347, 29);
            this.label2.TabIndex = 3;
            this.label2.Text = "Danh sách tất cả user và role";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.panel2.Controls.Add(this.btnGrantRole);
            this.panel2.Controls.Add(this.btnCreateRole);
            this.panel2.Controls.Add(this.btnCreateUser);
            this.panel2.Controls.Add(this.btnDashboard);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(186, 603);
            this.panel2.TabIndex = 4;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lbCurrentUser);
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(186, 144);
            this.panel3.TabIndex = 0;
            // 
            // lbCurrentUser
            // 
            this.lbCurrentUser.AutoSize = true;
            this.lbCurrentUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbCurrentUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(156)))), ((int)(((byte)(149)))));
            this.lbCurrentUser.Location = new System.Drawing.Point(20, 99);
            this.lbCurrentUser.Name = "lbCurrentUser";
            this.lbCurrentUser.Size = new System.Drawing.Size(103, 20);
            this.lbCurrentUser.TabIndex = 1;
            this.lbCurrentUser.Text = "User Name";
            this.lbCurrentUser.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label3.Location = new System.Drawing.Point(285, 555);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(578, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "*Nhấp đúp chuột vào một user hoặc role để thực hiện các thao tác liên quan ";
            // 
            // btnGrantRole
            // 
            this.btnGrantRole.FlatAppearance.BorderSize = 0;
            this.btnGrantRole.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGrantRole.Font = new System.Drawing.Font("Nirmala UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGrantRole.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.btnGrantRole.Image = global::ConnectToOracle.Properties.Resources.tap;
            this.btnGrantRole.Location = new System.Drawing.Point(3, 306);
            this.btnGrantRole.Name = "btnGrantRole";
            this.btnGrantRole.Size = new System.Drawing.Size(186, 41);
            this.btnGrantRole.TabIndex = 4;
            this.btnGrantRole.Text = "Cấp role ";
            this.btnGrantRole.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnGrantRole.UseVisualStyleBackColor = true;
            this.btnGrantRole.Click += new System.EventHandler(this.btnGrantRole_Click);
            // 
            // btnCreateRole
            // 
            this.btnCreateRole.FlatAppearance.BorderSize = 0;
            this.btnCreateRole.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateRole.Font = new System.Drawing.Font("Nirmala UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateRole.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.btnCreateRole.Image = global::ConnectToOracle.Properties.Resources.icons8_community_30;
            this.btnCreateRole.Location = new System.Drawing.Point(3, 249);
            this.btnCreateRole.Name = "btnCreateRole";
            this.btnCreateRole.Size = new System.Drawing.Size(186, 41);
            this.btnCreateRole.TabIndex = 3;
            this.btnCreateRole.Text = "Tạo Role";
            this.btnCreateRole.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnCreateRole.UseVisualStyleBackColor = true;
            this.btnCreateRole.Click += new System.EventHandler(this.btnCreateRole_Click);
            // 
            // btnCreateUser
            // 
            this.btnCreateUser.FlatAppearance.BorderSize = 0;
            this.btnCreateUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateUser.Font = new System.Drawing.Font("Nirmala UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.btnCreateUser.Image = global::ConnectToOracle.Properties.Resources.icons8_add_user_24;
            this.btnCreateUser.Location = new System.Drawing.Point(0, 196);
            this.btnCreateUser.Name = "btnCreateUser";
            this.btnCreateUser.Size = new System.Drawing.Size(186, 41);
            this.btnCreateUser.TabIndex = 2;
            this.btnCreateUser.Text = "Tạo User";
            this.btnCreateUser.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnCreateUser.UseVisualStyleBackColor = true;
            this.btnCreateUser.Click += new System.EventHandler(this.btnCreateUser_Click);
            // 
            // btnDashboard
            // 
            this.btnDashboard.FlatAppearance.BorderSize = 0;
            this.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashboard.Font = new System.Drawing.Font("Nirmala UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDashboard.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.btnDashboard.Image = global::ConnectToOracle.Properties.Resources.home;
            this.btnDashboard.Location = new System.Drawing.Point(3, 150);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Size = new System.Drawing.Size(186, 41);
            this.btnDashboard.TabIndex = 1;
            this.btnDashboard.Text = "Trang chủ";
            this.btnDashboard.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnDashboard.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ConnectToOracle.Properties.Resources._9131529;
            this.pictureBox1.Location = new System.Drawing.Point(60, 22);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(63, 63);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // AllUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(982, 603);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.MinimizeBox = false;
            this.Name = "AllUserForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "All Users";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listUsers;
        private System.Windows.Forms.ColumnHeader nameCol;
        private System.Windows.Forms.ColumnHeader statusCol;
        private System.Windows.Forms.ListView listRoles;
        private System.Windows.Forms.ColumnHeader roleCol;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnGrantRole;
        private System.Windows.Forms.Button btnCreateRole;
        private System.Windows.Forms.Button btnCreateUser;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lbCurrentUser;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
    }
}