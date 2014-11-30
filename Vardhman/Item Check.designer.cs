namespace Vardhman
{
    partial class Item_Check
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgv_item_check = new System.Windows.Forms.DataGridView();
            this.check = new System.Windows.Forms.DataGridViewButtonColumn();
            this.company = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemtype = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemdetail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.meter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.txt_search = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_city = new System.Windows.Forms.Label();
            this.lbl_acc_name = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_item_check)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_item_check
            // 
            this.dgv_item_check.AllowUserToAddRows = false;
            this.dgv_item_check.AllowUserToDeleteRows = false;
            this.dgv_item_check.AllowUserToResizeColumns = false;
            this.dgv_item_check.AllowUserToResizeRows = false;
            this.dgv_item_check.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv_item_check.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgv_item_check.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgv_item_check.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_item_check.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.check,
            this.company,
            this.itemtype,
            this.itemname,
            this.itemdetail,
            this.quantity,
            this.meter,
            this.rate,
            this.id});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(227)))), ((int)(((byte)(103)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_item_check.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_item_check.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_item_check.Location = new System.Drawing.Point(0, 0);
            this.dgv_item_check.Name = "dgv_item_check";
            this.dgv_item_check.Size = new System.Drawing.Size(703, 356);
            this.dgv_item_check.TabIndex = 0;
            this.dgv_item_check.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_item_check_CellValueChanged);
            this.dgv_item_check.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgv_item_check_CellBeginEdit);
            this.dgv_item_check.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_item_check_CellLeave);
            this.dgv_item_check.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_item_check_CellContentDoubleClick);
            this.dgv_item_check.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_item_check_CellEndEdit);
            this.dgv_item_check.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_item_check_CellContentClick);
            // 
            // check
            // 
            this.check.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.check.HeaderText = "check";
            this.check.Name = "check";
            this.check.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.check.Text = "check";
            this.check.Width = 43;
            // 
            // company
            // 
            this.company.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.company.HeaderText = "company";
            this.company.Name = "company";
            this.company.Width = 75;
            // 
            // itemtype
            // 
            this.itemtype.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.itemtype.HeaderText = "Item Type";
            this.itemtype.Name = "itemtype";
            this.itemtype.Width = 79;
            // 
            // itemname
            // 
            this.itemname.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.itemname.HeaderText = "Item Name";
            this.itemname.Name = "itemname";
            this.itemname.Width = 83;
            // 
            // itemdetail
            // 
            this.itemdetail.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.itemdetail.HeaderText = "Item Detail";
            this.itemdetail.Name = "itemdetail";
            this.itemdetail.Width = 82;
            // 
            // quantity
            // 
            this.quantity.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.quantity.HeaderText = "Quantity";
            this.quantity.Name = "quantity";
            this.quantity.Width = 71;
            // 
            // meter
            // 
            this.meter.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.meter.HeaderText = "Meter";
            this.meter.Name = "meter";
            this.meter.Width = 59;
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
            // id
            // 
            this.id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.Visible = false;
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
            this.splitContainer1.Panel1.Controls.Add(this.txt_search);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.lbl_city);
            this.splitContainer1.Panel1.Controls.Add(this.lbl_acc_name);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgv_item_check);
            this.splitContainer1.Size = new System.Drawing.Size(703, 444);
            this.splitContainer1.SplitterDistance = 84;
            this.splitContainer1.TabIndex = 1;
            // 
            // txt_search
            // 
            this.txt_search.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_search.Location = new System.Drawing.Point(86, 40);
            this.txt_search.Name = "txt_search";
            this.txt_search.Size = new System.Drawing.Size(163, 29);
            this.txt_search.TabIndex = 3;
            this.txt_search.TextChanged += new System.EventHandler(this.txt_search_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "Search";
            // 
            // lbl_city
            // 
            this.lbl_city.AutoSize = true;
            this.lbl_city.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_city.Location = new System.Drawing.Point(322, 13);
            this.lbl_city.Name = "lbl_city";
            this.lbl_city.Size = new System.Drawing.Size(40, 24);
            this.lbl_city.TabIndex = 1;
            this.lbl_city.Text = "City";
            // 
            // lbl_acc_name
            // 
            this.lbl_acc_name.AutoSize = true;
            this.lbl_acc_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_acc_name.Location = new System.Drawing.Point(10, 13);
            this.lbl_acc_name.Name = "lbl_acc_name";
            this.lbl_acc_name.Size = new System.Drawing.Size(136, 24);
            this.lbl_acc_name.TabIndex = 0;
            this.lbl_acc_name.Text = "Account Name";
            // 
            // Item_Check
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(703, 444);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Item_Check";
            this.Text = "Item_Check";
            this.Load += new System.EventHandler(this.Item_Check_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Item_Check_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_item_check)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label lbl_city;
        private System.Windows.Forms.Label lbl_acc_name;
        private System.Windows.Forms.DataGridView dgv_item_check;
        private System.Windows.Forms.DataGridViewButtonColumn check;
        private System.Windows.Forms.DataGridViewTextBoxColumn company;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemtype;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemname;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemdetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn meter;
        private System.Windows.Forms.DataGridViewTextBoxColumn rate;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.TextBox txt_search;
        private System.Windows.Forms.Label label1;
    }
}