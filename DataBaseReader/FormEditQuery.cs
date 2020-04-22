﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataBaseReader
{
    public partial class FormEditQuery : Form
    {
        public FormEditQuery()
        {
            InitializeComponent();
        }

        private void ButtomQueryAdd_Click(object sender, EventArgs e)
        {
            if(RichTextBoxQuery.Text != string.Empty)
            {
                FormMain.query.Add(RichTextBoxQuery.Text);
            }
            else
            {
                MessageBox.Show("Нельзя добавить пустой запрос!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtomQueryEdit_Click(object sender, EventArgs e)
        {
            if (RichTextBoxQuery.Text != string.Empty)
            {
                if (FormMain.CheckerNumberQuery(TextBoxQueryNumber.Text, FormMain.query.Count))
                {
                    FormMain.query[Convert.ToInt32(TextBoxQueryNumber.Text) - 1] = RichTextBoxQuery.Text;
                }
            }
            else
            {
                MessageBox.Show("Нельзя добавить пустой запрос!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtomQueryList_Click(object sender, EventArgs e)
        {
            RichTextBoxQuery.Clear();
            for (int i = 1; i <= FormMain.query.Count; i++)
            {
                RichTextBoxQuery.Text += "Запрос " + i + ".\n\n";
                RichTextBoxQuery.Text += FormMain.query[i - 1];
                RichTextBoxQuery.Text += "\n\n";
            }
        }

        private void ButtomQueryClear_Click(object sender, EventArgs e)
        {
            RichTextBoxQuery.Clear();
        }

        private void ButtomQueryListNow_Click(object sender, EventArgs e)
        {
            if (FormMain.CheckerNumberQuery(TextBoxQueryNumber.Text, FormMain.query.Count))
            {
                RichTextBoxQuery.Text = "Запрос " + TextBoxQueryNumber.Text + ".\n\n";
                RichTextBoxQuery.Text += FormMain.query[Convert.ToInt32(TextBoxQueryNumber.Text) - 1];
            }
        }

        private void TextBoxQueryNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void ComboBoxTemplate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboBoxTemplate.SelectedItem.ToString() == ComboBoxTemplate.Items[0].ToString())
            {
                RichTextBoxQuery.Text = "SELECT * FROM City;";
            }
            else if (ComboBoxTemplate.SelectedItem.ToString() == ComboBoxTemplate.Items[1].ToString())
            {
                RichTextBoxQuery.Text = "INSERT INTO <таблица> (<столбец1>, <столбец2>, <...>) VALUES ('<поле1>', '<поле2>', '<...>');";
            }
            else if (ComboBoxTemplate.SelectedItem.ToString() == ComboBoxTemplate.Items[2].ToString())
            {
                RichTextBoxQuery.Text = "UPDATE <таблица> SET <столбец> = <значение> WHERE <условие>;";
            }
            else
            {
                RichTextBoxQuery.Text = "DELETE FROM <таблица> WHERE <условие>;";
            }
        }
    }
}