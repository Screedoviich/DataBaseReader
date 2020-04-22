using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataBaseReader
{
    public partial class FormOpen : Form
    {
        public FormOpen()
        {
            InitializeComponent();
        }

        private void FormOpen_Load(object sender, EventArgs e)
        {
            TextBoxPath.Text = FormMain.dataBasePath;
        }

        private void ButtonInput_Click(object sender, EventArgs e)
        {
            if (FormMain.dataBase != null)
            {
                FormMain.dataBase.Close();
            }
            FormMain.dataBase = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + TextBoxPath.Text);
            try
            {
                FormMain.dataBase.Open();
            }
            catch
            {
                MessageBox.Show("Неверная база данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonPath_Click(object sender, EventArgs e)
        {
            OpenFileDialog.ShowDialog();
            FormMain.dataBasePath = TextBoxPath.Text = OpenFileDialog.FileName;
        }
    }
}
