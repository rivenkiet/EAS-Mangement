namespace ConnectToOracle
{
    partial class fGrantPrivilegesToRole
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
            this.lbRoleName = new System.Windows.Forms.Label();
            this.tableList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.selectColList = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.updateColList = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.statementTypesCheckbox = new System.Windows.Forms.CheckedListBox();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbRoleName
            // 
            this.lbRoleName.AutoSize = true;
            this.lbRoleName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbRoleName.Location = new System.Drawing.Point(350, 28);
            this.lbRoleName.Name = "lbRoleName";
            this.lbRoleName.Size = new System.Drawing.Size(82, 25);
            this.lbRoleName.TabIndex = 0;
            this.lbRoleName.Text = "ROLE: ";
            // 
            // tableList
            // 
            this.tableList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.tableList.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.tableList.GridLines = true;
            this.tableList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.tableList.HideSelection = false;
            this.tableList.Location = new System.Drawing.Point(22, 78);
            this.tableList.Name = "tableList";
            this.tableList.Size = new System.Drawing.Size(253, 360);
            this.tableList.TabIndex = 1;
            this.tableList.UseCompatibleStateImageBehavior = false;
            this.tableList.View = System.Windows.Forms.View.Details;
            this.tableList.SelectedIndexChanged += new System.EventHandler(this.tableList_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Table";
            this.columnHeader1.Width = 300;
            // 
            // selectColList
            // 
            this.selectColList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
            this.selectColList.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.selectColList.GridLines = true;
            this.selectColList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.selectColList.HideSelection = false;
            this.selectColList.Location = new System.Drawing.Point(292, 78);
            this.selectColList.Name = "selectColList";
            this.selectColList.Size = new System.Drawing.Size(253, 360);
            this.selectColList.TabIndex = 2;
            this.selectColList.UseCompatibleStateImageBehavior = false;
            this.selectColList.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Select Column";
            this.columnHeader2.Width = 300;
            // 
            // updateColList
            // 
            this.updateColList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3});
            this.updateColList.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.updateColList.GridLines = true;
            this.updateColList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.updateColList.HideSelection = false;
            this.updateColList.Location = new System.Drawing.Point(564, 78);
            this.updateColList.Name = "updateColList";
            this.updateColList.Size = new System.Drawing.Size(253, 360);
            this.updateColList.TabIndex = 3;
            this.updateColList.UseCompatibleStateImageBehavior = false;
            this.updateColList.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Update Column";
            this.columnHeader3.Width = 300;
            // 
            // statementTypesCheckbox
            // 
            this.statementTypesCheckbox.CheckOnClick = true;
            this.statementTypesCheckbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.statementTypesCheckbox.FormattingEnabled = true;
            this.statementTypesCheckbox.Items.AddRange(new object[] {
            "SELECT",
            "INSERT",
            "UPDATE",
            "DELETE"});
            this.statementTypesCheckbox.Location = new System.Drawing.Point(292, 481);
            this.statementTypesCheckbox.Name = "statementTypesCheckbox";
            this.statementTypesCheckbox.Size = new System.Drawing.Size(253, 114);
            this.statementTypesCheckbox.TabIndex = 4;
            this.statementTypesCheckbox.SelectedIndexChanged += new System.EventHandler(this.statementTypesCheckbox_SelectedIndexChanged);
            // 
            // btnConfirm
            // 
            this.btnConfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(86)))), ((int)(((byte)(174)))));
            this.btnConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnConfirm.ForeColor = System.Drawing.Color.White;
            this.btnConfirm.Location = new System.Drawing.Point(690, 629);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(127, 40);
            this.btnConfirm.TabIndex = 5;
            this.btnConfirm.Text = "Xác nhận";
            this.btnConfirm.UseVisualStyleBackColor = false;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnBack
            // 
            this.btnBack.FlatAppearance.BorderSize = 2;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnBack.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(86)))), ((int)(((byte)(174)))));
            this.btnBack.Location = new System.Drawing.Point(557, 629);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(127, 40);
            this.btnBack.TabIndex = 6;
            this.btnBack.Text = "Quay lại";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // fGrantPrivilegesToRole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(839, 681);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.statementTypesCheckbox);
            this.Controls.Add(this.updateColList);
            this.Controls.Add(this.selectColList);
            this.Controls.Add(this.tableList);
            this.Controls.Add(this.lbRoleName);
            this.Name = "fGrantPrivilegesToRole";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "fGrantPrivilegesToRole";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbRoleName;
        private System.Windows.Forms.ListView tableList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ListView selectColList;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ListView updateColList;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.CheckedListBox statementTypesCheckbox;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnBack;
    }
}