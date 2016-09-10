namespace Vardhman
{
    partial class Price_List
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.cbo_type = new System.Windows.Forms.ComboBox();
            this.cbo_company = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.dgv_item_entry = new System.Windows.Forms.DataGridView();
            this.itemname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_clear = new System.Windows.Forms.Button();
            this.btn_remove_code = new System.Windows.Forms.Button();
            this.btn_append_rate = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_item_entry)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.cbo_type);
            this.splitContainer1.Panel1.Controls.Add(this.cbo_company);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(341, 463);
            this.splitContainer1.SplitterDistance = 66;
            this.splitContainer1.TabIndex = 0;
            // 
            // cbo_type
            // 
            this.cbo_type.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbo_type.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbo_type.FormattingEnabled = true;
            this.cbo_type.Location = new System.Drawing.Point(164, 30);
            this.cbo_type.Name = "cbo_type";
            this.cbo_type.Size = new System.Drawing.Size(132, 21);
            this.cbo_type.TabIndex = 5;
            this.cbo_type.Leave += new System.EventHandler(this.cbo_type_Leave);
            // 
            // cbo_company
            // 
            this.cbo_company.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbo_company.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbo_company.FormattingEnabled = true;
            this.cbo_company.Location = new System.Drawing.Point(21, 30);
            this.cbo_company.Name = "cbo_company";
            this.cbo_company.Size = new System.Drawing.Size(137, 21);
            this.cbo_company.TabIndex = 4;
            this.cbo_company.Leave += new System.EventHandler(this.cbo_type_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(161, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Item Type";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Company";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.dgv_item_entry);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.btn_clear);
            this.splitContainer2.Panel2.Controls.Add(this.btn_remove_code);
            this.splitContainer2.Panel2.Controls.Add(this.btn_append_rate);
            this.splitContainer2.Panel2.Controls.Add(this.btn_save);
            this.splitContainer2.Size = new System.Drawing.Size(341, 393);
            this.splitContainer2.SplitterDistance = 347;
            this.splitContainer2.TabIndex = 1;
            // 
            // dgv_item_entry
            // 
            this.dgv_item_entry.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_item_entry.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.itemname,
            this.rate});
            this.dgv_item_entry.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_item_entry.Location = new System.Drawing.Point(0, 0);
            this.dgv_item_entry.Name = "dgv_item_entry";
            this.dgv_item_entry.Size = new System.Drawing.Size(341, 347);
            this.dgv_item_entry.TabIndex = 0;
            this.dgv_item_entry.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_item_entry_CellValueChanged);
            this.dgv_item_entry.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_item_entry_CellEndEdit);
            this.dgv_item_entry.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgv_item_entry_EditingControlShowing);
            // 
            // itemname
            // 
            this.itemname.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.itemname.HeaderText = "Item Name";
            this.itemname.Name = "itemname";
            this.itemname.Width = 83;
            // 
            // rate
            // 
            this.rate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.rate.DefaultCellStyle = dataGridViewCellStyle1;
            this.rate.HeaderText = "Rate";
            this.rate.Name = "rate";
            this.rate.Width = 55;
            // 
            // btn_clear
            // 
            this.btn_clear.Location = new System.Drawing.Point(259, 3);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(69, 34);
            this.btn_clear.TabIndex = 3;
            this.btn_clear.Text = "Clear";
            this.btn_clear.UseVisualStyleBackColor = true;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // btn_remove_code
            // 
            this.btn_remove_code.Location = new System.Drawing.Point(175, 3);
            this.btn_remove_code.Name = "btn_remove_code";
            this.btn_remove_code.Size = new System.Drawing.Size(69, 34);
            this.btn_remove_code.TabIndex = 2;
            this.btn_remove_code.Text = "Remove Code";
            this.btn_remove_code.UseVisualStyleBackColor = true;
            this.btn_remove_code.Click += new System.EventHandler(this.btn_remove_code_Click);
            // 
            // btn_append_rate
            // 
            this.btn_append_rate.Location = new System.Drawing.Point(91, 3);
            this.btn_append_rate.Name = "btn_append_rate";
            this.btn_append_rate.Size = new System.Drawing.Size(69, 34);
            this.btn_append_rate.TabIndex = 1;
            this.btn_append_rate.Text = "Append Code";
            this.btn_append_rate.UseVisualStyleBackColor = true;
            this.btn_append_rate.Click += new System.EventHandler(this.btn_append_rate_Click);
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(7, 3);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(69, 34);
            this.btn_save.TabIndex = 0;
            this.btn_save.Text = "Save";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // Price_List
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 463);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Price_List";
            this.Text = "Price_List";
            this.Load += new System.EventHandler(this.Price_List_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Price_List_FormClosing);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_item_entry)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dgv_item_entry;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemname;
        private System.Windows.Forms.DataGridViewTextBoxColumn rate;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_append_rate;
        private System.Windows.Forms.ComboBox cbo_type;
        private System.Windows.Forms.ComboBox cbo_company;
        private System.Windows.Forms.Button btn_remove_code;
        private System.Windows.Forms.Button btn_clear;

    }
}