namespace Registry
{
    partial class DoctorForm
    {
        ///<summary>
        ///Required designer variable.
        ///</summary>
        private System.ComponentModel.IContainer components = null;
        ///<summary>
        /// Clean up any resources being used.
        ///</summary>
        ///<param name="disposing">true if managed resources should be disposed;otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        #region Windows Form Designer generated code
        ///<summary>
        ///Required method for Designer support – do not modify
        /// the contents of this method with the code editor.
        ///</summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DoctorForm));
            this.info = new System.Windows.Forms.DataGridView();
            this.info_Key = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.info_Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.info_tabPage = new System.Windows.Forms.TabPage();
            this.timetable_tabPage = new System.Windows.Forms.TabPage();
            this.timetable = new System.Windows.Forms.DataGridView();
            this.timetable_Key = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.startTime1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.endTime1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.info)).BeginInit();
            this.tabControl.SuspendLayout();
            this.info_tabPage.SuspendLayout();
            this.timetable_tabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timetable)).BeginInit();
            this.SuspendLayout();
            // 
            // info
            // 
            this.info.AllowUserToAddRows = false;
            this.info.AllowUserToDeleteRows = false;
            this.info.AllowUserToResizeColumns = false;
            this.info.AllowUserToResizeRows = false;
            this.info.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.info.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.info.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.info.ColumnHeadersVisible = false;
            this.info.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.info_Key,
            this.info_Value});
            this.info.Dock = System.Windows.Forms.DockStyle.Fill;
            this.info.Location = new System.Drawing.Point(4, 4);
            this.info.Margin = new System.Windows.Forms.Padding(4);
            this.info.MultiSelect = false;
            this.info.Name = "info";
            this.info.RowHeadersWidth = 51;
            this.info.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.info.RowTemplate.Height = 23;
            this.info.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.info.Size = new System.Drawing.Size(551, 399);
            this.info.TabIndex = 0;
            this.info.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.info_CellContentClick);
            this.info.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.info_CellValidating);
            // 
            // info_Key
            // 
            this.info_Key.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.info_Key.HeaderText = "Key";
            this.info_Key.MinimumWidth = 6;
            this.info_Key.Name = "info_Key";
            this.info_Key.ReadOnly = true;
            this.info_Key.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.info_Key.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.info_Key.Width = 160;
            // 
            // info_Value
            // 
            this.info_Value.HeaderText = "Value";
            this.info_Value.MinimumWidth = 6;
            this.info_Value.Name = "info_Value";
            this.info_Value.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.info_Value.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.info_tabPage);
            this.tabControl.Controls.Add(this.timetable_tabPage);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(567, 436);
            this.tabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl.TabIndex = 1;
            // 
            // info_tabPage
            // 
            this.info_tabPage.Controls.Add(this.info);
            this.info_tabPage.Location = new System.Drawing.Point(4, 25);
            this.info_tabPage.Margin = new System.Windows.Forms.Padding(4);
            this.info_tabPage.Name = "info_tabPage";
            this.info_tabPage.Padding = new System.Windows.Forms.Padding(4);
            this.info_tabPage.Size = new System.Drawing.Size(559, 407);
            this.info_tabPage.TabIndex = 0;
            this.info_tabPage.Text = "Інформація";
            this.info_tabPage.UseVisualStyleBackColor = true;
            // 
            // timetable_tabPage
            // 
            this.timetable_tabPage.Controls.Add(this.timetable);
            this.timetable_tabPage.Location = new System.Drawing.Point(4, 25);
            this.timetable_tabPage.Margin = new System.Windows.Forms.Padding(4);
            this.timetable_tabPage.Name = "timetable_tabPage";
            this.timetable_tabPage.Padding = new System.Windows.Forms.Padding(4);
            this.timetable_tabPage.Size = new System.Drawing.Size(559, 407);
            this.timetable_tabPage.TabIndex = 1;
            this.timetable_tabPage.Text = "Графік работи";
            this.timetable_tabPage.UseVisualStyleBackColor = true;
            // 
            // timetable
            // 
            this.timetable.AllowUserToAddRows = false;
            this.timetable.AllowUserToDeleteRows = false;
            this.timetable.AllowUserToResizeColumns = false;
            this.timetable.AllowUserToResizeRows = false;
            this.timetable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.timetable.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.timetable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.timetable.ColumnHeadersVisible = false;
            this.timetable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.timetable_Key,
            this.startTime1,
            this.endTime1});
            this.timetable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.timetable.Location = new System.Drawing.Point(4, 4);
            this.timetable.Margin = new System.Windows.Forms.Padding(4);
            this.timetable.MultiSelect = false;
            this.timetable.Name = "timetable";
            this.timetable.RowHeadersWidth = 51;
            this.timetable.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.timetable.RowTemplate.Height = 23;
            this.timetable.Size = new System.Drawing.Size(551, 399);
            this.timetable.TabIndex = 0;
            this.timetable.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.timetable_CellValidating);
            // 
            // timetable_Key
            // 
            this.timetable_Key.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.timetable_Key.HeaderText = "Key";
            this.timetable_Key.MinimumWidth = 6;
            this.timetable_Key.Name = "timetable_Key";
            this.timetable_Key.ReadOnly = true;
            this.timetable_Key.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.timetable_Key.Width = 110;
            // 
            // startTime1
            // 
            this.startTime1.HeaderText = "startTime";
            this.startTime1.MinimumWidth = 6;
            this.startTime1.Name = "startTime1";
            // 
            // endTime1
            // 
            this.endTime1.HeaderText = "endTime";
            this.endTime1.MinimumWidth = 6;
            this.endTime1.Name = "endTime1";
            // 
            // DoctorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 436);
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "DoctorForm";
            this.Text = "Інформація";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DoctorForm_FormClosing);
            this.Load += new System.EventHandler(this.DoctorForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.info)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.info_tabPage.ResumeLayout(false);
            this.timetable_tabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.timetable)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion
        private System.Windows.Forms.DataGridView info;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage info_tabPage;
        private System.Windows.Forms.TabPage timetable_tabPage;
        private System.Windows.Forms.DataGridView timetable;
        private System.Windows.Forms.DataGridViewTextBoxColumn timetable_Key;
        private System.Windows.Forms.DataGridViewTextBoxColumn startTime1;
        private System.Windows.Forms.DataGridViewTextBoxColumn endTime1;
        private System.Windows.Forms.DataGridViewTextBoxColumn info_Key;
        private System.Windows.Forms.DataGridViewTextBoxColumn info_Value;
    }
}
