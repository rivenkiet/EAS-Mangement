namespace ConnectToOracle
{
    partial class fGrantMenu
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
            this.btnGrantSystem = new System.Windows.Forms.Button();
            this.btnGrantTable = new System.Windows.Forms.Button();
            this.drop_user = new System.Windows.Forms.Button();
            this.ShowPrivileges = new System.Windows.Forms.Button();
            this.lbName = new System.Windows.Forms.Label();
            this.btnEditUser = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGrantSystem
            // 
            this.btnGrantSystem.FlatAppearance.BorderSize = 2;
            this.btnGrantSystem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGrantSystem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnGrantSystem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(86)))), ((int)(((byte)(174)))));
            this.btnGrantSystem.Location = new System.Drawing.Point(52, 284);
            this.btnGrantSystem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGrantSystem.Name = "btnGrantSystem";
            this.btnGrantSystem.Size = new System.Drawing.Size(324, 53);
            this.btnGrantSystem.TabIndex = 0;
            this.btnGrantSystem.Text = "Cấp quyền hệ thống";
            this.btnGrantSystem.UseVisualStyleBackColor = true;
            this.btnGrantSystem.Click += new System.EventHandler(this.btnGrantSystem_Click);
            // 
            // btnGrantTable
            // 
            this.btnGrantTable.FlatAppearance.BorderSize = 2;
            this.btnGrantTable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGrantTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnGrantTable.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(86)))), ((int)(((byte)(174)))));
            this.btnGrantTable.Location = new System.Drawing.Point(52, 360);
            this.btnGrantTable.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGrantTable.Name = "btnGrantTable";
            this.btnGrantTable.Size = new System.Drawing.Size(324, 54);
            this.btnGrantTable.TabIndex = 1;
            this.btnGrantTable.Text = "Cấp quyền trên bảng";
            this.btnGrantTable.UseVisualStyleBackColor = true;
            this.btnGrantTable.Click += new System.EventHandler(this.btnGrantTable_Click);
            // 
            // drop_user
            // 
            this.drop_user.FlatAppearance.BorderSize = 2;
            this.drop_user.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.drop_user.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.drop_user.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(86)))), ((int)(((byte)(174)))));
            this.drop_user.Location = new System.Drawing.Point(52, 438);
            this.drop_user.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.drop_user.Name = "drop_user";
            this.drop_user.Size = new System.Drawing.Size(324, 54);
            this.drop_user.TabIndex = 3;
            this.drop_user.Text = "Xóa";
            this.drop_user.UseVisualStyleBackColor = true;
            this.drop_user.Click += new System.EventHandler(this.dropUser);
            // 
            // ShowPrivileges
            // 
            this.ShowPrivileges.FlatAppearance.BorderSize = 2;
            this.ShowPrivileges.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ShowPrivileges.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.ShowPrivileges.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(86)))), ((int)(((byte)(174)))));
            this.ShowPrivileges.Location = new System.Drawing.Point(52, 205);
            this.ShowPrivileges.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ShowPrivileges.Name = "ShowPrivileges";
            this.ShowPrivileges.Size = new System.Drawing.Size(324, 53);
            this.ShowPrivileges.TabIndex = 4;
            this.ShowPrivileges.Text = "Hiển thị quyền ";
            this.ShowPrivileges.UseVisualStyleBackColor = true;
            this.ShowPrivileges.Click += new System.EventHandler(this.button1_Click);
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(85)))), ((int)(((byte)(174)))));
            this.lbName.Location = new System.Drawing.Point(141, 158);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(145, 25);
            this.lbName.TabIndex = 6;
            this.lbName.Text = "USER: NAME";
            this.lbName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnEditUser
            // 
            this.btnEditUser.FlatAppearance.BorderSize = 2;
            this.btnEditUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnEditUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(86)))), ((int)(((byte)(174)))));
            this.btnEditUser.Location = new System.Drawing.Point(52, 506);
            this.btnEditUser.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEditUser.Name = "btnEditUser";
            this.btnEditUser.Size = new System.Drawing.Size(324, 54);
            this.btnEditUser.TabIndex = 7;
            this.btnEditUser.Text = "Hiệu Chỉnh";
            this.btnEditUser.UseVisualStyleBackColor = true;
            this.btnEditUser.Click += new System.EventHandler(this.btnEditUser_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ConnectToOracle.Properties.Resources.user;
            this.pictureBox1.Location = new System.Drawing.Point(146, 35);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(140, 104);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // fGrantMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(431, 585);
            this.Controls.Add(this.btnEditUser);
            this.Controls.Add(this.lbName);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.ShowPrivileges);
            this.Controls.Add(this.drop_user);
            this.Controls.Add(this.btnGrantTable);
            this.Controls.Add(this.btnGrantSystem);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "fGrantMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "fGrantMenu";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGrantSystem;
        private System.Windows.Forms.Button btnGrantTable;
        private System.Windows.Forms.Button drop_user;
        private System.Windows.Forms.Button ShowPrivileges;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.Button btnEditUser;
    }
}