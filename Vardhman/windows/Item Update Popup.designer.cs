namespace Vardhman
{
    partial class Item_Update_Popup
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
            this.txt_item_name = new System.Windows.Forms.TextBox();
            this.txt_rate = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbl_id = new System.Windows.Forms.Label();
            this.btn_update = new System.Windows.Forms.Button();
            this.btn_delete = new System.Windows.Forms.Button();
            this.cbo_item_type = new System.Windows.Forms.ComboBox();
            this.cbo_company = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txt_item_name
            // 
            this.txt_item_name.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_item_name.Location = new System.Drawing.Point(76, 64);
            this.txt_item_name.Name = "txt_item_name";
            this.txt_item_name.Size = new System.Drawing.Size(128, 20);
            this.txt_item_name.TabIndex = 2;
            // 
            // txt_rate
            // 
            this.txt_rate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_rate.Location = new System.Drawing.Point(76, 90);
            this.txt_rate.Name = "txt_rate";
            this.txt_rate.Size = new System.Drawing.Size(128, 20);
            this.txt_rate.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Company";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Item Type";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Item Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(40, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Rate";
            // 
            // lbl_id
            // 
            this.lbl_id.AutoSize = true;
            this.lbl_id.Location = new System.Drawing.Point(105, 176);
            this.lbl_id.Name = "lbl_id";
            this.lbl_id.Size = new System.Drawing.Size(15, 13);
            this.lbl_id.TabIndex = 8;
            this.lbl_id.Text = "id";
            this.lbl_id.Visible = false;
            // 
            // btn_update
            // 
            this.btn_update.Location = new System.Drawing.Point(4, 116);
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(68, 23);
            this.btn_update.TabIndex = 4;
            this.btn_update.Text = "Update";
            this.btn_update.UseVisualStyleBackColor = true;
            this.btn_update.Click += new System.EventHandler(this.btn_update_Click);
            // 
            // btn_delete
            // 
            this.btn_delete.Location = new System.Drawing.Point(74, 116);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(68, 23);
            this.btn_delete.TabIndex = 5;
            this.btn_delete.Text = "Delete";
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // cbo_item_type
            // 
            this.cbo_item_type.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbo_item_type.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbo_item_type.FormattingEnabled = true;
            this.cbo_item_type.Location = new System.Drawing.Point(76, 38);
            this.cbo_item_type.Name = "cbo_item_type";
            this.cbo_item_type.Size = new System.Drawing.Size(128, 21);
            this.cbo_item_type.TabIndex = 1;
            this.cbo_item_type.TextChanged += new System.EventHandler(this.cbo_item_type_TextChanged);
            // 
            // cbo_company
            // 
            this.cbo_company.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbo_company.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbo_company.FormattingEnabled = true;
            this.cbo_company.Location = new System.Drawing.Point(76, 12);
            this.cbo_company.Name = "cbo_company";
            this.cbo_company.Size = new System.Drawing.Size(128, 21);
            this.cbo_company.TabIndex = 0;
            this.cbo_company.TextChanged += new System.EventHandler(this.cbo_company_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(148, 116);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(68, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Item_Update_Popup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(218, 147);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cbo_company);
            this.Controls.Add(this.cbo_item_type);
            this.Controls.Add(this.btn_delete);
            this.Controls.Add(this.btn_update);
            this.Controls.Add(this.lbl_id);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_rate);
            this.Controls.Add(this.txt_item_name);
            this.KeyPreview = true;
            this.Name = "Item_Update_Popup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Item_Update_Popup";
            this.Load += new System.EventHandler(this.Item_Update_Popup_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Item_Update_Popup_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_item_name;
        private System.Windows.Forms.TextBox txt_rate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbl_id;
        private System.Windows.Forms.Button btn_update;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.ComboBox cbo_item_type;
        private System.Windows.Forms.ComboBox cbo_company;
        private System.Windows.Forms.Button button1;
    }
}