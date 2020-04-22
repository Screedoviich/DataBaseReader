using System;
using System.Data.OleDb;
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
            TextBoxPath.Text = FormMain.DataBasePath;
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
                MessageBox.Show("База данных успешно открыта!", "Выполнено", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch
            {
                MessageBox.Show("Неверная база данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonPath_Click(object sender, EventArgs e)
        {
            OpenFileDialog.ShowDialog();
            FormMain.DataBasePath = TextBoxPath.Text = OpenFileDialog.FileName;
        }
    }
}
