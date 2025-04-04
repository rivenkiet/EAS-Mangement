namespace ConnectToOracle
{
    partial class fGrantPrivilegesToUser
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
            this.tablesList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.selectColList = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.updateColList = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.statementTypesCheckBox = new System.Windows.Forms.CheckedListBox();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.userName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tablesList
            // 
            this.tablesList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.tablesList.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.tablesList.GridLines = true;
            this.tablesList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.tablesList.HideSelection = false;
            this.tablesList.Location = new System.Drawing.Point(23, 72);
            this.tablesList.MultiSelect = false;
            this.tablesList.Name = "tablesList";
            this.tablesList.Size = new System.Drawing.Size(249, 361);
            this.tablesList.TabIndex = 0;
            this.tablesList.UseCompatibleStateImageBehavior = false;
            this.tablesList.View = System.Windows.Forms.View.Details;
            this.tablesList.SelectedIndexChanged += new System.EventHandler(this.tablesList_SelectedIndexChanged_1);
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
            this.selectColList.Location = new System.Drawing.Point(301, 72);
            this.selectColList.Name = "selectColList";
            this.selectColList.Size = new System.Drawing.Size(249, 361);
            this.selectColList.TabIndex = 1;
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
            this.updateColList.Location = new System.Drawing.Point(576, 72);
            this.updateColList.Name = "updateColList";
            this.updateColList.Size = new System.Drawing.Size(249, 361);
            this.updateColList.TabIndex = 2;
            this.updateColList.UseCompatibleStateImageBehavior = false;
            this.updateColList.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Update Column";
            this.columnHeader3.Width = 300;
            // 
            // statementTypesCheckBox
            // 
            this.statementTypesCheckBox.CheckOnClick = true;
            this.statementTypesCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.statementTypesCheckBox.FormattingEnabled = true;
            this.statementTypesCheckBox.Items.AddRange(new object[] {
            "SELECT",
            "INSERT",
            "UPDATE",
            "DELETE",
            "WITH GRANT OPTION"});
            this.statementTypesCheckBox.Location = new System.Drawing.Point(279, 455);
            this.statementTypesCheckBox.Name = "statementTypesCheckBox";
            this.statementTypesCheckBox.Size = new System.Drawing.Size(282, 136);
            this.statementTypesCheckBox.TabIndex = 3;
            this.statementTypesCheckBox.SelectedIndexChanged += new System.EventHandler(this.statementTypesCheckBox_SelectedIndexChanged);
            // 
            // btnBack
            // 
            this.btnBack.FlatAppearance.BorderSize = 2;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnBack.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(86)))), ((int)(((byte)(174)))));
            this.btnBack.Location = new System.Drawing.Point(556, 608);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(130, 46);
            this.btnBack.TabIndex = 4;
            this.btnBack.Text = "Quay lại";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(86)))), ((int)(((byte)(174)))));
            this.btnConfirm.FlatAppearance.BorderSize = 2;
            this.btnConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnConfirm.ForeColor = System.Drawing.Color.White;
            this.btnConfirm.Location = new System.Drawing.Point(695, 608);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(130, 46);
            this.btnConfirm.TabIndex = 5;
            this.btnConfirm.Text = "Xác nhận";
            this.btnConfirm.UseVisualStyleBackColor = false;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // userName
            // 
            this.userName.AutoSize = true;
            this.userName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.userName.Location = new System.Drawing.Point(379, 26);
            this.userName.Name = "userName";
            this.userName.Size = new System.Drawing.Size(83, 25);
            this.userName.TabIndex = 6;
            this.userName.Text = "USER: ";
            // 
            // fGrantPrivilegesToUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 666);
            this.Controls.Add(this.userName);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.statementTypesCheckBox);
            this.Controls.Add(this.updateColList);
            this.Controls.Add(this.selectColList);
            this.Controls.Add(this.tablesList);
            this.Name = "fGrantPrivilegesToUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "fGrantPrivilegesToUser";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView tablesList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ListView selectColList;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ListView updateColList;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.CheckedListBox statementTypesCheckBox;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Label userName;
    }
}