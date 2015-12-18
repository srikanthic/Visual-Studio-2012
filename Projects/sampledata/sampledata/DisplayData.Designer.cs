namespace sampledata
{
    partial class DisplayData
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
            this.lblTo = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.SearchOnDates = new System.Windows.Forms.Button();
            this.dateTimeTo = new System.Windows.Forms.DateTimePicker();
            this.dateTimeFrom = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.checkListbox = new System.Windows.Forms.CheckedListBox();
            this.To = new System.Windows.Forms.Label();
            this.lblNoRows = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtTo = new System.Windows.Forms.TextBox();
            this.txtFrom = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtRows = new System.Windows.Forms.TextBox();
            this.cmbColumns = new System.Windows.Forms.ComboBox();
            this.lblFrom = new System.Windows.Forms.Label();
            this.dataGridSearchResults = new System.Windows.Forms.DataGridView();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.dataGrid = new System.Windows.Forms.DataGridView();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnBlobData = new System.Windows.Forms.Button();
            this.btnSubmit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridSearchResults)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Location = new System.Drawing.Point(623, 38);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(20, 13);
            this.lblTo.TabIndex = 11;
            this.lblTo.Text = "To";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer1.Size = new System.Drawing.Size(1143, 467);
            this.splitContainer1.SplitterDistance = 233;
            this.splitContainer1.TabIndex = 12;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.label1);
            this.splitContainer2.Panel1.Controls.Add(this.SearchOnDates);
            this.splitContainer2.Panel1.Controls.Add(this.dateTimeTo);
            this.splitContainer2.Panel1.Controls.Add(this.dateTimeFrom);
            this.splitContainer2.Panel1.Controls.Add(this.label2);
            this.splitContainer2.Panel1.Controls.Add(this.checkListbox);
            this.splitContainer2.Panel1.Controls.Add(this.To);
            this.splitContainer2.Panel1.Controls.Add(this.lblNoRows);
            this.splitContainer2.Panel1.Controls.Add(this.btnSearch);
            this.splitContainer2.Panel1.Controls.Add(this.txtTo);
            this.splitContainer2.Panel1.Controls.Add(this.txtFrom);
            this.splitContainer2.Panel1.Controls.Add(this.label4);
            this.splitContainer2.Panel1.Controls.Add(this.txtRows);
            this.splitContainer2.Panel1.Controls.Add(this.cmbColumns);
            this.splitContainer2.Panel1.Controls.Add(this.lblFrom);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.dataGridSearchResults);
            this.splitContainer2.Size = new System.Drawing.Size(1143, 233);
            this.splitContainer2.SplitterDistance = 57;
            this.splitContainer2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(623, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 63;
            this.label1.Text = "FromDate";
            // 
            // SearchOnDates
            // 
            this.SearchOnDates.Location = new System.Drawing.Point(470, 30);
            this.SearchOnDates.Name = "SearchOnDates";
            this.SearchOnDates.Size = new System.Drawing.Size(134, 23);
            this.SearchOnDates.TabIndex = 62;
            this.SearchOnDates.Text = "Search On Dates";
            this.SearchOnDates.UseVisualStyleBackColor = true;
            this.SearchOnDates.Click += new System.EventHandler(this.SearchOnDates_Click);
            // 
            // dateTimeTo
            // 
            this.dateTimeTo.Location = new System.Drawing.Point(911, 33);
            this.dateTimeTo.Name = "dateTimeTo";
            this.dateTimeTo.Size = new System.Drawing.Size(129, 20);
            this.dateTimeTo.TabIndex = 61;
            // 
            // dateTimeFrom
            // 
            this.dateTimeFrom.Location = new System.Drawing.Point(682, 33);
            this.dateTimeFrom.Name = "dateTimeFrom";
            this.dateTimeFrom.Size = new System.Drawing.Size(167, 20);
            this.dateTimeFrom.TabIndex = 60;
            this.dateTimeFrom.Value = new System.DateTime(2011, 5, 25, 15, 6, 23, 0);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(855, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 59;
            this.label2.Text = "ToDate";
            // 
            // checkListbox
            // 
            this.checkListbox.FormattingEnabled = true;
            this.checkListbox.Location = new System.Drawing.Point(199, 6);
            this.checkListbox.Name = "checkListbox";
            this.checkListbox.Size = new System.Drawing.Size(120, 49);
            this.checkListbox.TabIndex = 55;
            // 
            // To
            // 
            this.To.AutoSize = true;
            this.To.Location = new System.Drawing.Point(641, 7);
            this.To.Name = "To";
            this.To.Size = new System.Drawing.Size(20, 13);
            this.To.TabIndex = 54;
            this.To.Text = "To";
            // 
            // lblNoRows
            // 
            this.lblNoRows.AutoSize = true;
            this.lblNoRows.Location = new System.Drawing.Point(3, 9);
            this.lblNoRows.Name = "lblNoRows";
            this.lblNoRows.Size = new System.Drawing.Size(84, 13);
            this.lblNoRows.TabIndex = 45;
            this.lblNoRows.Text = "Enter no of rows";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(355, 28);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(90, 23);
            this.btnSearch.TabIndex = 53;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtTo
            // 
            this.txtTo.Location = new System.Drawing.Point(677, 4);
            this.txtTo.Name = "txtTo";
            this.txtTo.Size = new System.Drawing.Size(80, 20);
            this.txtTo.TabIndex = 50;
            // 
            // txtFrom
            // 
            this.txtFrom.Location = new System.Drawing.Point(543, 4);
            this.txtFrom.Name = "txtFrom";
            this.txtFrom.Size = new System.Drawing.Size(92, 20);
            this.txtFrom.TabIndex = 49;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(334, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 51;
            this.label4.Text = "Select Column";
            // 
            // txtRows
            // 
            this.txtRows.Location = new System.Drawing.Point(93, 6);
            this.txtRows.Name = "txtRows";
            this.txtRows.Size = new System.Drawing.Size(100, 20);
            this.txtRows.TabIndex = 46;
            // 
            // cmbColumns
            // 
            this.cmbColumns.FormattingEnabled = true;
            this.cmbColumns.Location = new System.Drawing.Point(415, 3);
            this.cmbColumns.Name = "cmbColumns";
            this.cmbColumns.Size = new System.Drawing.Size(74, 21);
            this.cmbColumns.TabIndex = 48;
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Location = new System.Drawing.Point(495, 13);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(30, 13);
            this.lblFrom.TabIndex = 52;
            this.lblFrom.Text = "From";
            // 
            // dataGridSearchResults
            // 
            this.dataGridSearchResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridSearchResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridSearchResults.Location = new System.Drawing.Point(0, 0);
            this.dataGridSearchResults.Name = "dataGridSearchResults";
            this.dataGridSearchResults.Size = new System.Drawing.Size(1143, 172);
            this.dataGridSearchResults.TabIndex = 54;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.dataGrid);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.btnUpdate);
            this.splitContainer3.Panel2.Controls.Add(this.btnSelect);
            this.splitContainer3.Panel2.Controls.Add(this.btnDel);
            this.splitContainer3.Panel2.Controls.Add(this.btnBlobData);
            this.splitContainer3.Panel2.Controls.Add(this.btnSubmit);
            this.splitContainer3.Size = new System.Drawing.Size(1143, 230);
            this.splitContainer3.SplitterDistance = 1034;
            this.splitContainer3.TabIndex = 55;
            // 
            // dataGrid
            // 
            this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGrid.Location = new System.Drawing.Point(0, 0);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.Size = new System.Drawing.Size(1034, 230);
            this.dataGrid.TabIndex = 14;
            this.dataGrid.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGrid_CellValueChanged);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(-1, 149);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(106, 37);
            this.btnUpdate.TabIndex = 49;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(-1, 12);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(106, 37);
            this.btnSelect.TabIndex = 48;
            this.btnSelect.Text = "Select All Records";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(-1, 192);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(106, 35);
            this.btnDel.TabIndex = 1;
            this.btnDel.Text = "Delete";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnBlobData
            // 
            this.btnBlobData.Location = new System.Drawing.Point(-1, 55);
            this.btnBlobData.Name = "btnBlobData";
            this.btnBlobData.Size = new System.Drawing.Size(106, 50);
            this.btnBlobData.TabIndex = 0;
            this.btnBlobData.Text = "DisplayBlobData";
            this.btnBlobData.UseVisualStyleBackColor = true;
            this.btnBlobData.Click += new System.EventHandler(this.btnBlobData_Click);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(-1, 111);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(106, 37);
            this.btnSubmit.TabIndex = 47;
            this.btnSubmit.Text = "Insert";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // DisplayData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1143, 467);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.lblTo);
            this.Name = "DisplayData";
            this.Text = "DisplayData";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.DisplayData_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridSearchResults)).EndInit();
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dataGrid;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Label lblNoRows;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtTo;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.TextBox txtFrom;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox txtRows;
        private System.Windows.Forms.ComboBox cmbColumns;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.DataGridView dataGridSearchResults;
        private System.Windows.Forms.Label To;
        private System.Windows.Forms.CheckedListBox checkListbox;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnBlobData;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimeFrom;
        private System.Windows.Forms.DateTimePicker dateTimeTo;
        private System.Windows.Forms.Button SearchOnDates;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnUpdate;
    }
}