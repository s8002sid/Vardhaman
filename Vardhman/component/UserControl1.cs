using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
namespace Vardhman
{
    public partial class UserControl1 : UserControl
    {
        ArrayList Items = new ArrayList();
        public UserControl1()
        {
            InitializeComponent();
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
            populate();
        }
        public void populate()
        {
            for (int i = 0; i < 2; i++)
            {
                createCombo();
            }
            for (int i = 2; i < 7; i++)
            {
                createText();
            }
        }
        private void createText()
        {
            //checkSize();
            TextBox t = new TextBox();
            t.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            t.Location = calculateLocation();
            t.Name = "textBox" + Convert.ToString(Items.Count + 1);
            t.KeyPress += new System.Windows.Forms.KeyPressEventHandler(TextBox_KeyPress);
            t.TextChanged += new EventHandler(TextBox_TextChange);
            t.Size = new System.Drawing.Size(190, 30);
            t.TabIndex = Items.Count;
            Items.Add(t);
            this.Controls.Add(t);
        }
        private void createLabel(string Text)
        {
            //checkSize();
            Label l = new Label();
            l.AutoSize = true;
            l.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            l.Location = calculateLocation();
            l.Name = "label" + Items.Count;
            l.Size = new System.Drawing.Size(56, 30);
            l.Text = Text;
            Items.Add(l);
            this.Controls.Add(l);
        }
        private void createCombo()
        {
            //checkSize();
            ComboBox c = new ComboBox();
            c.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            c.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            c.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            c.FormattingEnabled = true;
            c.Location = calculateLocation();
            c.Name = "comboBox" + Convert.ToString(1 + Items.Count);
            c.KeyPress += new System.Windows.Forms.KeyPressEventHandler(comboBox_KeyPress);
            c.TextChanged += new EventHandler(ComboBox_TextChange);
            c.Size = new System.Drawing.Size(190, 30);
            c.TabIndex = Items.Count + 1;
            this.Controls.Add(c);
            Items.Add(c);
        }
        private Point calculateLocation()
        {
            int y = Items.Count / 7;
            int x = Items.Count % 7;
            x = x * 190;
            y = y * 30;
            return new Point(x, y);

        }
        private void comboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }
        private void TextBox_TextChange(object sender, EventArgs e)
        {
            TextBox t = (TextBox)sender;
            if ( t.Text!= "" && !hasNewRowCreated(t.Name.Substring(7)))
                populate();
        }
        private void ComboBox_TextChange(object sender, EventArgs e)
        {
            ComboBox c = (ComboBox)sender;
            if ( c.Text!= "" && !hasNewRowCreated(c.Name.Substring(8)))
                populate();
        }
        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }
        private Boolean hasNewRowCreated(string value)
        {
            int x = Convert.ToInt32(value);
            int rowx, rowactual;
            rowx = x / 7;
            rowactual = Items.Count / 7 - 1;
            if (rowx == rowactual)
                return false;
            else return true;
        }
        //private void checkSize()
        //{
        //    int x = Items.Count/7;
        //    if (x * 30 <= this.Width)
        //        this.Width = this.Width + 30;
        //}
    }
}
