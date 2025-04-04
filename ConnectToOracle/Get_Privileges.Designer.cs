namespace ConnectToOracle
{
    partial class Get_Privileges
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
            this.listPrivileges = new System.Windows.Forms.ListView();
            this.Privileges = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.table_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // listPrivileges
            // 
            this.listPrivileges.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Privileges,
            this.table_name});
            this.listPrivileges.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.listPrivileges.FullRowSelect = true;
            this.listPrivileges.GridLines = true;
            this.listPrivileges.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listPrivileges.HideSelection = false;
            this.listPrivileges.Location = new System.Drawing.Point(16, 15);
            this.listPrivileges.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listPrivileges.Name = "listPrivileges";
            this.listPrivileges.Size = new System.Drawing.Size(581, 467);
            this.listPrivileges.TabIndex = 5;
            this.listPrivileges.UseCompatibleStateImageBehavior = false;
            this.listPrivileges.View = System.Windows.Forms.View.Details;
            // 
            // Privileges
            // 
            this.Privileges.Text = "Privileges";
            this.Privileges.Width = 89;
            // 
            // table_name
            // 
            this.table_name.Text = "Table Name";
            this.table_name.Width = 409;
            // 
            // Get_Privileges
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 502);
            this.Controls.Add(this.listPrivileges);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Get_Privileges";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Get_Privileges";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListView listPrivileges;
        private System.Windows.Forms.ColumnHeader Privileges;
        private System.Windows.Forms.ColumnHeader table_name;
    }
}