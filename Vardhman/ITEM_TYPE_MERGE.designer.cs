namespace Vardhman
{
    partial class ITEM_TYPE_MERGE
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
            this.cmb_fromType = new System.Windows.Forms.ComboBox();
            this.cmb_toType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_submit = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmb_fromType
            // 
            this.cmb_fromType.AllowDrop = true;
            this.cmb_fromType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmb_fromType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmb_fromType.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_fromType.FormattingEnabled = true;
            this.cmb_fromType.Location = new System.Drawing.Point(113, 16);
            this.cmb_fromType.Name = "cmb_fromType";
            this.cmb_fromType.Size = new System.Drawing.Size(245, 32);
            this.cmb_fromType.TabIndex = 0;
            this.cmb_fromType.Enter += new System.EventHandler(this.comboBox1_Enter);
            // 
            // cmb_toType
            // 
            this.cmb_toType.AllowDrop = true;
            this.cmb_toType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmb_toType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmb_toType.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_toType.FormattingEnabled = true;
            this.cmb_toType.Location = new System.Drawing.Point(447, 16);
            this.cmb_toType.Name = "cmb_toType";
            this.cmb_toType.Size = new System.Drawing.Size(223, 32);
            this.cmb_toType.TabIndex = 1;
            this.cmb_toType.Enter += new System.EventHandler(this.comboBox2_Enter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "From Type";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(363, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "To Type";
            // 
            // btn_submit
            // 
            this.btn_submit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_submit.Location = new System.Drawing.Point(115, 56);
            this.btn_submit.Name = "btn_submit";
            this.btn_submit.Size = new System.Drawing.Size(82, 30);
            this.btn_submit.TabIndex = 4;
            this.btn_submit.Text = "Submit";
            this.btn_submit.UseVisualStyleBackColor = true;
            this.btn_submit.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_submit);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmb_toType);
            this.groupBox1.Controls.Add(this.cmb_fromType);
            this.groupBox1.Location = new System.Drawing.Point(15, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(681, 102);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // ITEM_TYPE_MERGE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(749, 126);
            this.Controls.Add(this.groupBox1);
            this.Name = "ITEM_TYPE_MERGE";
            this.Text = "ITEM_TYPE_MERGE";
            this.Load += new System.EventHandler(this.ITEM_TYPE_MERGE_Load);
            this.SizeChanged += new System.EventHandler(this.ITEM_TYPE_MERGE_SizeChanged);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ITEM_TYPE_MERGE_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmb_fromType;
        private System.Windows.Forms.ComboBox cmb_toType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_submit;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}