using System;
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
                FormMain.QueryList.Add(RichTextBoxQuery.Text);
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
                if (FormMain.CheckerNumberQuery(TextBoxQueryNumber.Text, FormMain.QueryList.Count))
                {
                    FormMain.QueryList[Convert.ToInt32(TextBoxQueryNumber.Text) - 1] = RichTextBoxQuery.Text;
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
            for (int i = 1; i <= FormMain.QueryList.Count; i++)
            {
                RichTextBoxQuery.Text += "Запрос " + i + ".\n\n";
                RichTextBoxQuery.Text += FormMain.QueryList[i - 1];
                RichTextBoxQuery.Text += "\n\n";
            }
        }

        private void ButtomQueryClear_Click(object sender, EventArgs e)
        {
            RichTextBoxQuery.Clear();
        }

        private void ButtomQueryListNow_Click(object sender, EventArgs e)
        {
            if (FormMain.CheckerNumberQuery(TextBoxQueryNumber.Text, FormMain.QueryList.Count))
            {
                RichTextBoxQuery.Text = "Запрос " + TextBoxQueryNumber.Text + ".\n\n";
                RichTextBoxQuery.Text += FormMain.QueryList[Convert.ToInt32(TextBoxQueryNumber.Text) - 1];
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
