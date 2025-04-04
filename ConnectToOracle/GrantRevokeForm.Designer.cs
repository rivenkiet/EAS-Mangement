namespace ConnectToOracle
{
    partial class GrantRevokeForm
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.oracleDataAdapter1 = new Oracle.ManagedDataAccess.Client.OracleDataAdapter();
            this.listPrivs = new System.Windows.Forms.DataGridView();
            this.submitBtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblName = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.privilegeCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grantedCol = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.adminOptionCol = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.listPrivs)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listPrivs
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.listPrivs.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.listPrivs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.listPrivs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.privilegeCol,
            this.grantedCol,
            this.adminOptionCol});
            this.listPrivs.Location = new System.Drawing.Point(32, 79);
            this.listPrivs.Name = "listPrivs";
            this.listPrivs.RowHeadersWidth = 51;
            this.listPrivs.RowTemplate.Height = 24;
            this.listPrivs.Size = new System.Drawing.Size(718, 401);
            this.listPrivs.TabIndex = 0;
            this.listPrivs.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.listPrivs_CellContentClick);
            // 
            // submitBtn
            // 
            this.submitBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(86)))), ((int)(((byte)(174)))));
            this.submitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.submitBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.submitBtn.ForeColor = System.Drawing.Color.White;
            this.submitBtn.Location = new System.Drawing.Point(622, 496);
            this.submitBtn.Name = "submitBtn";
            this.submitBtn.Size = new System.Drawing.Size(128, 47);
            this.submitBtn.TabIndex = 1;
            this.submitBtn.Text = "Xác nhận";
            this.submitBtn.UseVisualStyleBackColor = false;
            this.submitBtn.Click += new System.EventHandler(this.submitBtn_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.lblName);
            this.panel1.Controls.Add(this.listPrivs);
            this.panel1.Controls.Add(this.submitBtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(782, 568);
            this.panel1.TabIndex = 2;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(355, 23);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(70, 25);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "label1";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 2;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(86)))), ((int)(((byte)(174)))));
            this.button1.Location = new System.Drawing.Point(474, 496);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(128, 47);
            this.button1.TabIndex = 3;
            this.button1.Text = "Quay lại";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // privilegeCol
            // 
            this.privilegeCol.HeaderText = "Privilege";
            this.privilegeCol.MinimumWidth = 6;
            this.privilegeCol.Name = "privilegeCol";
            this.privilegeCol.Width = 200;
            // 
            // grantedCol
            // 
            this.grantedCol.HeaderText = "Granted";
            this.grantedCol.MinimumWidth = 6;
            this.grantedCol.Name = "grantedCol";
            this.grantedCol.Width = 125;
            // 
            // adminOptionCol
            // 
            this.adminOptionCol.HeaderText = "Admin Option";
            this.adminOptionCol.MinimumWidth = 6;
            this.adminOptionCol.Name = "adminOptionCol";
            this.adminOptionCol.Width = 150;
            // 
            // GrantRevokeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 568);
            this.Controls.Add(this.panel1);
            this.Name = "GrantRevokeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)(this.listPrivs)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Oracle.ManagedDataAccess.Client.OracleDataAdapter oracleDataAdapter1;
        private System.Windows.Forms.DataGridView listPrivs;
        private System.Windows.Forms.Button submitBtn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn privilegeCol;
        private System.Windows.Forms.DataGridViewCheckBoxColumn grantedCol;
        private System.Windows.Forms.DataGridViewCheckBoxColumn adminOptionCol;
    }
}