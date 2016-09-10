namespace Vardhman
{
    partial class item_update_popup_no_insert
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
            this.button1 = new System.Windows.Forms.Button();
            this.cbo_company = new System.Windows.Forms.ComboBox();
            this.cbo_item_type = new System.Windows.Forms.ComboBox();
            this.btn_update = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_rate = new System.Windows.Forms.TextBox();
            this.txt_item_name = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Location = new System.Drawing.Point(114, 116);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(68, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cbo_company
            // 
            this.cbo_company.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbo_company.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbo_company.FormattingEnabled = true;
            this.cbo_company.Location = new System.Drawing.Point(79, 12);
            this.cbo_company.Name = "cbo_company";
            this.cbo_company.Size = new System.Drawing.Size(128, 21);
            this.cbo_company.TabIndex = 0;
            this.cbo_company.TextChanged += new System.EventHandler(this.cbo_company_TextChanged);
            // 
            // cbo_item_type
            // 
            this.cbo_item_type.FormattingEnabled = true;
            this.cbo_item_type.Location = new System.Drawing.Point(79, 38);
            this.cbo_item_type.Name = "cbo_item_type";
            this.cbo_item_type.Size = new System.Drawing.Size(128, 21);
            this.cbo_item_type.TabIndex = 1;
            this.cbo_item_type.TextChanged += new System.EventHandler(this.cbo_item_type_TextChanged);
            // 
            // btn_update
            // 
            this.btn_update.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_update.Location = new System.Drawing.Point(40, 116);
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(68, 23);
            this.btn_update.TabIndex = 4;
            this.btn_update.Text = "OK";
            this.btn_update.UseVisualStyleBackColor = true;
            this.btn_update.Click += new System.EventHandler(this.btn_update_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(43, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Rate";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Item Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Item Type";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Company";
            // 
            // txt_rate
            // 
            this.txt_rate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_rate.Location = new System.Drawing.Point(79, 90);
            this.txt_rate.Name = "txt_rate";
            this.txt_rate.Size = new System.Drawing.Size(128, 20);
            this.txt_rate.TabIndex = 3;
            // 
            // txt_item_name
            // 
            this.txt_item_name.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_item_name.Location = new System.Drawing.Point(79, 64);
            this.txt_item_name.Name = "txt_item_name";
            this.txt_item_name.Size = new System.Drawing.Size(128, 20);
            this.txt_item_name.TabIndex = 2;
            // 
            // item_update_popup_no_insert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(223, 151);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cbo_company);
            this.Controls.Add(this.cbo_item_type);
            this.Controls.Add(this.btn_update);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_rate);
            this.Controls.Add(this.txt_item_name);
            this.Name = "item_update_popup_no_insert";
            this.Text = "item_update_popup_no_insert";
            this.Load += new System.EventHandler(this.item_update_popup_no_insert_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cbo_company;
        private System.Windows.Forms.ComboBox cbo_item_type;
        private System.Windows.Forms.Button btn_update;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_rate;
        private System.Windows.Forms.TextBox txt_item_name;
    }
}