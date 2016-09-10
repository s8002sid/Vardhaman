namespace Vardhman
{
    partial class Match
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
            this.dgv_link = new System.Windows.Forms.DataGridView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.link = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_link)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_link
            // 
            this.dgv_link.AllowUserToAddRows = false;
            this.dgv_link.AllowUserToDeleteRows = false;
            this.dgv_link.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_link.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.link,
            this.Column1});
            this.dgv_link.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_link.Location = new System.Drawing.Point(0, 0);
            this.dgv_link.MultiSelect = false;
            this.dgv_link.Name = "dgv_link";
            this.dgv_link.ReadOnly = true;
            this.dgv_link.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_link.Size = new System.Drawing.Size(176, 163);
            this.dgv_link.TabIndex = 0;
            this.dgv_link.TabStop = false;
            this.dgv_link.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_link_CellContentClick);
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
            this.splitContainer1.Panel1.Controls.Add(this.button2);
            this.splitContainer1.Panel1.Controls.Add(this.button1);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgv_link);
            this.splitContainer1.Size = new System.Drawing.Size(176, 231);
            this.splitContainer1.SplitterDistance = 64;
            this.splitContainer1.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(98, 36);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(66, 23);
            this.button2.TabIndex = 2;
            this.button2.TabStop = false;
            this.button2.Text = "Use Other";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 36);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.TabStop = false;
            this.button1.Text = "No Problem";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Account with similar\r\nname already exists";
            // 
            // link
            // 
            this.link.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            this.link.DefaultCellStyle = dataGridViewCellStyle2;
            this.link.HeaderText = "Link";
            this.link.Name = "link";
            this.link.ReadOnly = true;
            this.link.Width = 33;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Column1";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Visible = false;
            // 
            // Match
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(176, 231);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Name = "Match";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Match";
            this.Load += new System.EventHandler(this.Match_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Match_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Match_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_link)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_link;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewLinkColumn link;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
    }
}