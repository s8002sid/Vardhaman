namespace Vardhman
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_item_type_merge = new System.Windows.Forms.Button();
            this.btn_new_ledger = new System.Windows.Forms.Button();
            this.btn_manual_recepit_entry = new System.Windows.Forms.Button();
            this.btn_manual_bill_entry = new System.Windows.Forms.Button();
            this.btn_deletion = new System.Windows.Forms.Button();
            this.btn_new_account = new System.Windows.Forms.Button();
            this.btn_summary = new System.Windows.Forms.Button();
            this.btn_price_list = new System.Windows.Forms.Button();
            this.btn_empty_bill = new System.Windows.Forms.Button();
            this.btn_ledger = new System.Windows.Forms.Button();
            this.btn_recepit = new System.Windows.Forms.Button();
            this.btn_billing = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.homeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recoveryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Vardhman Backup|*.bak";
            // 
            // panel1
            // 
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.btn_item_type_merge);
            this.panel1.Controls.Add(this.btn_new_ledger);
            this.panel1.Controls.Add(this.btn_manual_recepit_entry);
            this.panel1.Controls.Add(this.btn_manual_bill_entry);
            this.panel1.Controls.Add(this.btn_deletion);
            this.panel1.Controls.Add(this.btn_new_account);
            this.panel1.Controls.Add(this.btn_summary);
            this.panel1.Controls.Add(this.btn_price_list);
            this.panel1.Controls.Add(this.btn_empty_bill);
            this.panel1.Controls.Add(this.btn_ledger);
            this.panel1.Controls.Add(this.btn_recepit);
            this.panel1.Controls.Add(this.btn_billing);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(933, 695);
            this.panel1.TabIndex = 14;
            // 
            // btn_item_type_merge
            // 
            this.btn_item_type_merge.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_item_type_merge.AutoEllipsis = true;
            this.btn_item_type_merge.BackColor = System.Drawing.Color.White;
            this.btn_item_type_merge.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_item_type_merge.BackgroundImage")));
            this.btn_item_type_merge.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_item_type_merge.FlatAppearance.BorderSize = 0;
            this.btn_item_type_merge.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_item_type_merge.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_item_type_merge.ForeColor = System.Drawing.Color.Black;
            this.btn_item_type_merge.Location = new System.Drawing.Point(703, 420);
            this.btn_item_type_merge.Name = "btn_item_type_merge";
            this.btn_item_type_merge.Size = new System.Drawing.Size(218, 78);
            this.btn_item_type_merge.TabIndex = 23;
            this.btn_item_type_merge.Text = "Item Type Merge";
            this.btn_item_type_merge.UseVisualStyleBackColor = false;
            this.btn_item_type_merge.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            this.btn_item_type_merge.Click += new System.EventHandler(this.btn_item_type_merge_Click);
            this.btn_item_type_merge.MouseEnter += new System.EventHandler(this.btn_MouseHover);
            // 
            // btn_new_ledger
            // 
            this.btn_new_ledger.AutoEllipsis = true;
            this.btn_new_ledger.BackColor = System.Drawing.Color.White;
            this.btn_new_ledger.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_new_ledger.BackgroundImage")));
            this.btn_new_ledger.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_new_ledger.FlatAppearance.BorderSize = 0;
            this.btn_new_ledger.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_new_ledger.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_new_ledger.ForeColor = System.Drawing.Color.Black;
            this.btn_new_ledger.Location = new System.Drawing.Point(7, 228);
            this.btn_new_ledger.Name = "btn_new_ledger";
            this.btn_new_ledger.Size = new System.Drawing.Size(218, 78);
            this.btn_new_ledger.TabIndex = 21;
            this.btn_new_ledger.Text = "New Ledger";
            this.btn_new_ledger.UseVisualStyleBackColor = false;
            this.btn_new_ledger.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            this.btn_new_ledger.Click += new System.EventHandler(this.btn_new_ledger_Click);
            this.btn_new_ledger.MouseEnter += new System.EventHandler(this.btn_MouseHover);
            // 
            // btn_manual_recepit_entry
            // 
            this.btn_manual_recepit_entry.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_manual_recepit_entry.AutoEllipsis = true;
            this.btn_manual_recepit_entry.BackColor = System.Drawing.Color.White;
            this.btn_manual_recepit_entry.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_manual_recepit_entry.BackgroundImage")));
            this.btn_manual_recepit_entry.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_manual_recepit_entry.FlatAppearance.BorderSize = 0;
            this.btn_manual_recepit_entry.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_manual_recepit_entry.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_manual_recepit_entry.ForeColor = System.Drawing.Color.Black;
            this.btn_manual_recepit_entry.Location = new System.Drawing.Point(703, 221);
            this.btn_manual_recepit_entry.Name = "btn_manual_recepit_entry";
            this.btn_manual_recepit_entry.Size = new System.Drawing.Size(218, 78);
            this.btn_manual_recepit_entry.TabIndex = 20;
            this.btn_manual_recepit_entry.Text = "Manual Recepit Entry";
            this.btn_manual_recepit_entry.UseVisualStyleBackColor = false;
            this.btn_manual_recepit_entry.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            this.btn_manual_recepit_entry.Click += new System.EventHandler(this.btn_manual_recepit_entry_Click);
            this.btn_manual_recepit_entry.MouseEnter += new System.EventHandler(this.btn_MouseHover);
            // 
            // btn_manual_bill_entry
            // 
            this.btn_manual_bill_entry.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_manual_bill_entry.AutoEllipsis = true;
            this.btn_manual_bill_entry.BackColor = System.Drawing.Color.White;
            this.btn_manual_bill_entry.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_manual_bill_entry.BackgroundImage")));
            this.btn_manual_bill_entry.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_manual_bill_entry.FlatAppearance.BorderSize = 0;
            this.btn_manual_bill_entry.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_manual_bill_entry.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_manual_bill_entry.ForeColor = System.Drawing.Color.Black;
            this.btn_manual_bill_entry.Location = new System.Drawing.Point(703, 124);
            this.btn_manual_bill_entry.Name = "btn_manual_bill_entry";
            this.btn_manual_bill_entry.Size = new System.Drawing.Size(218, 78);
            this.btn_manual_bill_entry.TabIndex = 19;
            this.btn_manual_bill_entry.Text = "Manual Bill Entry";
            this.btn_manual_bill_entry.UseVisualStyleBackColor = false;
            this.btn_manual_bill_entry.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            this.btn_manual_bill_entry.Click += new System.EventHandler(this.btn_manual_bill_entry_Click);
            this.btn_manual_bill_entry.MouseEnter += new System.EventHandler(this.btn_MouseHover);
            // 
            // btn_deletion
            // 
            this.btn_deletion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_deletion.AutoEllipsis = true;
            this.btn_deletion.BackColor = System.Drawing.Color.White;
            this.btn_deletion.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_deletion.BackgroundImage")));
            this.btn_deletion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_deletion.FlatAppearance.BorderSize = 0;
            this.btn_deletion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_deletion.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_deletion.ForeColor = System.Drawing.Color.Black;
            this.btn_deletion.Location = new System.Drawing.Point(703, 28);
            this.btn_deletion.Name = "btn_deletion";
            this.btn_deletion.Size = new System.Drawing.Size(218, 78);
            this.btn_deletion.TabIndex = 16;
            this.btn_deletion.Text = "Deletion";
            this.btn_deletion.UseVisualStyleBackColor = false;
            this.btn_deletion.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            this.btn_deletion.Click += new System.EventHandler(this.btn_deletion_Click);
            this.btn_deletion.MouseEnter += new System.EventHandler(this.btn_MouseHover);
            // 
            // btn_new_account
            // 
            this.btn_new_account.AutoEllipsis = true;
            this.btn_new_account.BackColor = System.Drawing.Color.White;
            this.btn_new_account.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_new_account.BackgroundImage")));
            this.btn_new_account.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_new_account.FlatAppearance.BorderSize = 0;
            this.btn_new_account.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_new_account.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_new_account.ForeColor = System.Drawing.Color.Black;
            this.btn_new_account.Location = new System.Drawing.Point(7, 510);
            this.btn_new_account.Name = "btn_new_account";
            this.btn_new_account.Size = new System.Drawing.Size(218, 78);
            this.btn_new_account.TabIndex = 13;
            this.btn_new_account.Text = "New Account";
            this.btn_new_account.UseVisualStyleBackColor = false;
            this.btn_new_account.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            this.btn_new_account.Click += new System.EventHandler(this.btn_new_account_Click);
            this.btn_new_account.MouseEnter += new System.EventHandler(this.btn_MouseHover);
            // 
            // btn_summary
            // 
            this.btn_summary.AutoEllipsis = true;
            this.btn_summary.BackColor = System.Drawing.Color.White;
            this.btn_summary.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_summary.BackgroundImage")));
            this.btn_summary.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_summary.FlatAppearance.BorderSize = 0;
            this.btn_summary.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_summary.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_summary.ForeColor = System.Drawing.Color.Black;
            this.btn_summary.Location = new System.Drawing.Point(7, 416);
            this.btn_summary.Name = "btn_summary";
            this.btn_summary.Size = new System.Drawing.Size(218, 78);
            this.btn_summary.TabIndex = 12;
            this.btn_summary.Text = "Summary";
            this.btn_summary.UseVisualStyleBackColor = false;
            this.btn_summary.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            this.btn_summary.Click += new System.EventHandler(this.btn_summary_Click);
            this.btn_summary.MouseEnter += new System.EventHandler(this.btn_MouseHover);
            // 
            // btn_price_list
            // 
            this.btn_price_list.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_price_list.AutoEllipsis = true;
            this.btn_price_list.BackColor = System.Drawing.Color.White;
            this.btn_price_list.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_price_list.BackgroundImage")));
            this.btn_price_list.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_price_list.FlatAppearance.BorderSize = 0;
            this.btn_price_list.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_price_list.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_price_list.ForeColor = System.Drawing.Color.Black;
            this.btn_price_list.Location = new System.Drawing.Point(703, 322);
            this.btn_price_list.Name = "btn_price_list";
            this.btn_price_list.Size = new System.Drawing.Size(218, 78);
            this.btn_price_list.TabIndex = 11;
            this.btn_price_list.Text = "Price List";
            this.btn_price_list.UseVisualStyleBackColor = false;
            this.btn_price_list.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            this.btn_price_list.Click += new System.EventHandler(this.btn_price_list_Click);
            this.btn_price_list.MouseEnter += new System.EventHandler(this.btn_MouseHover);
            // 
            // btn_empty_bill
            // 
            this.btn_empty_bill.AutoEllipsis = true;
            this.btn_empty_bill.BackColor = System.Drawing.Color.Transparent;
            this.btn_empty_bill.BackgroundImage = global::Vardhman.Properties.Resources.normal;
            this.btn_empty_bill.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_empty_bill.FlatAppearance.BorderSize = 0;
            this.btn_empty_bill.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_empty_bill.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_empty_bill.ForeColor = System.Drawing.Color.Black;
            this.btn_empty_bill.Location = new System.Drawing.Point(834, 534);
            this.btn_empty_bill.Name = "btn_empty_bill";
            this.btn_empty_bill.Size = new System.Drawing.Size(39, 31);
            this.btn_empty_bill.TabIndex = 8;
            this.btn_empty_bill.UseVisualStyleBackColor = false;
            this.btn_empty_bill.MouseLeave += new System.EventHandler(this.btn_empty_bill_MouseLeave);
            this.btn_empty_bill.Click += new System.EventHandler(this.btn_empty_bill_Click);
            this.btn_empty_bill.MouseEnter += new System.EventHandler(this.btn_empty_bill_MouseEnter);
            // 
            // btn_ledger
            // 
            this.btn_ledger.AutoEllipsis = true;
            this.btn_ledger.BackColor = System.Drawing.Color.White;
            this.btn_ledger.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_ledger.BackgroundImage")));
            this.btn_ledger.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_ledger.FlatAppearance.BorderSize = 0;
            this.btn_ledger.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ledger.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ledger.ForeColor = System.Drawing.Color.Black;
            this.btn_ledger.Location = new System.Drawing.Point(7, 322);
            this.btn_ledger.Name = "btn_ledger";
            this.btn_ledger.Size = new System.Drawing.Size(218, 78);
            this.btn_ledger.TabIndex = 7;
            this.btn_ledger.Text = "Ledger";
            this.btn_ledger.UseVisualStyleBackColor = false;
            this.btn_ledger.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            this.btn_ledger.Click += new System.EventHandler(this.btn_ledger_Click);
            this.btn_ledger.MouseEnter += new System.EventHandler(this.btn_MouseHover);
            // 
            // btn_recepit
            // 
            this.btn_recepit.AutoEllipsis = true;
            this.btn_recepit.BackColor = System.Drawing.Color.White;
            this.btn_recepit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_recepit.BackgroundImage")));
            this.btn_recepit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_recepit.FlatAppearance.BorderSize = 0;
            this.btn_recepit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_recepit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_recepit.ForeColor = System.Drawing.Color.Black;
            this.btn_recepit.Location = new System.Drawing.Point(7, 134);
            this.btn_recepit.Name = "btn_recepit";
            this.btn_recepit.Size = new System.Drawing.Size(218, 78);
            this.btn_recepit.TabIndex = 6;
            this.btn_recepit.Text = "Recepit";
            this.btn_recepit.UseVisualStyleBackColor = false;
            this.btn_recepit.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            this.btn_recepit.Click += new System.EventHandler(this.btn_recepit_Click);
            this.btn_recepit.MouseEnter += new System.EventHandler(this.btn_MouseHover);
            // 
            // btn_billing
            // 
            this.btn_billing.AutoEllipsis = true;
            this.btn_billing.BackColor = System.Drawing.Color.White;
            this.btn_billing.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_billing.BackgroundImage")));
            this.btn_billing.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_billing.FlatAppearance.BorderSize = 0;
            this.btn_billing.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_billing.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_billing.ForeColor = System.Drawing.Color.Black;
            this.btn_billing.Location = new System.Drawing.Point(7, 40);
            this.btn_billing.Name = "btn_billing";
            this.btn_billing.Size = new System.Drawing.Size(218, 78);
            this.btn_billing.TabIndex = 4;
            this.btn_billing.Text = "Billing";
            this.btn_billing.UseVisualStyleBackColor = false;
            this.btn_billing.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            this.btn_billing.Click += new System.EventHandler(this.btn_billing_Click);
            this.btn_billing.MouseEnter += new System.EventHandler(this.btn_MouseHover);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(231, 211);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(520, 95);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.homeToolStripMenuItem,
            this.backupToolStripMenuItem,
            this.recoveryToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(933, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // homeToolStripMenuItem
            // 
            this.homeToolStripMenuItem.AutoSize = false;
            this.homeToolStripMenuItem.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("homeToolStripMenuItem.BackgroundImage")));
            this.homeToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.homeToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.homeToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("homeToolStripMenuItem.Image")));
            this.homeToolStripMenuItem.Name = "homeToolStripMenuItem";
            this.homeToolStripMenuItem.Size = new System.Drawing.Size(40, 21);
            this.homeToolStripMenuItem.Text = "              ";
            this.homeToolStripMenuItem.Click += new System.EventHandler(this.homeToolStripMenuItem_Click);
            // 
            // backupToolStripMenuItem
            // 
            this.backupToolStripMenuItem.Name = "backupToolStripMenuItem";
            this.backupToolStripMenuItem.Size = new System.Drawing.Size(61, 21);
            this.backupToolStripMenuItem.Text = "Backup";
            this.backupToolStripMenuItem.Click += new System.EventHandler(this.backupToolStripMenuItem_Click);
            // 
            // recoveryToolStripMenuItem
            // 
            this.recoveryToolStripMenuItem.Name = "recoveryToolStripMenuItem";
            this.recoveryToolStripMenuItem.Size = new System.Drawing.Size(73, 21);
            this.recoveryToolStripMenuItem.Text = "Recovery";
            this.recoveryToolStripMenuItem.Click += new System.EventHandler(this.recoveryToolStripMenuItem_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(933, 695);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.panel1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.Text = "Vardhaman";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Main_Load);
            this.SizeChanged += new System.EventHandler(this.Main_SizeChanged);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_billing;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btn_recepit;
        private System.Windows.Forms.Button btn_ledger;
        private System.Windows.Forms.Button btn_empty_bill;
        private System.Windows.Forms.Button btn_summary;
        private System.Windows.Forms.Button btn_price_list;
        private System.Windows.Forms.Button btn_new_account;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ToolStripMenuItem homeToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem backupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recoveryToolStripMenuItem;
        private System.Windows.Forms.Button btn_deletion;
        private System.Windows.Forms.Button btn_manual_recepit_entry;
        private System.Windows.Forms.Button btn_manual_bill_entry;
        private System.Windows.Forms.Button btn_new_ledger;
        private System.Windows.Forms.Button btn_item_type_merge;
    }
}