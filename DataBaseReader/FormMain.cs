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
using System.IO;
using System.Xml;

namespace DataBaseReader
{
    public partial class FormMain : Form
    {
        //Лист, содержащий запросы.
        public static List<string> query = new List<string>();
        //Путь к базе данных (полный)
        public static string dataBasePath = default;
        //Подключение к базе данных
        public static OleDbConnection dataBase;
        //Количество столбцов в полученном запросе
        private static int ColumnCount { get; set; }
        //Последний выполненный запрос
        private static int lastQuery { get; set; }
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            //Запись всех файлов в директории
            string[] files = Directory.GetFiles(Application.StartupPath);
            foreach(string file in files)
            {
                //Запись только имени файла и расширения
                string fileName = file.Substring(Application.StartupPath.Length + 1);
                //Запись расширения
                string fileExtension = fileName.Substring(fileName.Length - 4);
                if (fileExtension == ".xml")
                {
                    XmlReader(fileName);
                }
            }
        }
        
        private void ButtonRefresh_Click(object sender, EventArgs e)
        {
            DataGridView.Refresh();
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Закрытие базы данных, если она открыта
            if (dataBase != null)
            {
                dataBase.Close();
            }
        }

        private void ButtonDoQuery_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridView.Rows.Clear();
                if (CheckerNumberQuery(TextBoxQueryNumber.Text, query.Count))
                {
                    CreateDataBaseInfo(query[Convert.ToInt32(TextBoxQueryNumber.Text) - 1], dataBase);
                    InputDataBase(query[Convert.ToInt32(TextBoxQueryNumber.Text) - 1], dataBase);
                    lastQuery = Convert.ToInt32(TextBoxQueryNumber.Text);
                    lastQuery--;
                }
            }
            catch
            {
                MessageBox.Show("В запросе обнаружена ошибка.\nЛибо не открыта БД.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MenuStripEditQuery_Click(object sender, EventArgs e)
        {
            new FormEditQuery().Show();
        }

        /// <summary>
        /// Установка всех столбцов по текущему запросу из базы данных в DataGridView.
        /// </summary>
        /// <param name="query">Запрос.</param>
        /// <param name="connection">Подключение к базе данных.</param>
        private void CreateDataBaseInfo(string query, OleDbConnection connection)
        {
            //Выполнение запроса и установка в переменную
            var adapter = new OleDbDataAdapter(query, connection);
            var dataTable = new DataTable();
            adapter.Fill(dataTable);
            ColumnCount = DataGridView.ColumnCount = dataTable.Columns.Count;
            for (int i = 0; i < ColumnCount; i++)
            {
                DataGridView.Columns[i].Name = dataTable.Columns[i].ToString();
            }
            DataGridView.AllowUserToAddRows = false;
            DataGridView.Name = "Данные по текущему запросу";
            DataGridView.RowHeadersVisible = false;
            DataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        }

        /// <summary>
        /// Установка всех данных по текущему запросу из базы данных в DataGridView.
        /// </summary>
        /// <param name="query">Запрос.</param>
        /// <param name="connection">Подключение к базе данных.</param>
        private void InputDataBase(string query, OleDbConnection connection)
        {
            var command = new OleDbCommand(query, connection);
            var reader = command.ExecuteReader();
            var data = new List<string[]>();
            while (reader.Read())
            {
                data.Add(new string[ColumnCount]);
                for (int i = 0; i < ColumnCount; i++)
                {
                    data[data.Count - 1][i] = reader[i].ToString();
                }
            }
            reader.Close();
            foreach (string[] e in data)
            {
                DataGridView.Rows.Add(e);
            }
        }

        /// <summary>
        /// Проверка строки для ввода запроса на несуществующие или пустые значения.
        /// </summary>
        /// <param name="queryNumber">Номер запроса.</param>
        /// <param name="count">Количество запросов</param>
        /// <returns></returns>
        public static bool CheckerNumberQuery(string queryNumber, int count)
        {
            if (queryNumber == string.Empty)
            {
                MessageBox.Show("Введите запрос!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (Convert.ToInt32(queryNumber) <= 0 || Convert.ToInt32(queryNumber) > count)
            {
                MessageBox.Show("Запроса под таким номером не найдено!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                return true;
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

        private void ButtonInsertUpdateDelete_Click(object sender, EventArgs e)
        {
            if (CheckerNumberQuery(TextBoxQueryNumber.Text, query.Count))
            {
                new OleDbCommand(query[Convert.ToInt32(TextBoxQueryNumber.Text) - 1], dataBase).ExecuteNonQuery();
            }
        }

        private void ButtonClear_Click(object sender, EventArgs e)
        {
            DataGridView.Rows.Clear();
        }

        private void MenuStripExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ButtonFastQuery_Click(object sender, EventArgs e)
        {
            if (RichTextBoxFastQuery.Text != string.Empty)
            {
                try
                {
                    if (RichTextBoxFastQuery.Text.Contains("SELECT"))
                    {
                        DataGridView.Rows.Clear();
                        CreateDataBaseInfo(RichTextBoxFastQuery.Text, dataBase);
                        InputDataBase(RichTextBoxFastQuery.Text, dataBase);
                    }
                    else
                    {
                        new OleDbCommand(RichTextBoxFastQuery.Text, dataBase).ExecuteNonQuery();
                    }
                }
                catch
                {
                    MessageBox.Show("Неверный запрос.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Введите запрос!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MenuStripDataBase_Click(object sender, EventArgs e)
        {
            new FormOpen().ShowDialog();
        }

        /// <summary>
        /// Установка запросов из XML файла в лист.
        /// </summary>
        /// <param name="filePath">Путь к файлу.</param>
        static void XmlReader(string filePath)
        {
            var reader = new XmlTextReader(filePath);
            string queryText = string.Empty;
            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Text:
                    {
                        if (queryText != string.Empty)
                        {
                            queryText += "\n";
                        }
                        queryText += reader.Value;
                        break;
                    }
                    case XmlNodeType.EndElement:
                    {
                        if (queryText != string.Empty) 
                        {
                            query.Add(queryText);
                        }
                        queryText = string.Empty;
                        break;
                    }
                }
            }
        }

        private void CheckBoxAllowEdit_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBoxAllowEdit.Checked == false)
            {
                DataGridView.ReadOnly = true;
            }
            else
            {
                DataGridView.ReadOnly = false;
            }
        }

        private void ButtonInsertDb_Click(object sender, EventArgs e)
        {
            DataGridView.Rows.Add();
        }

        private void ButtonRefreshDb_Click(object sender, EventArgs e)
        {
            DataGridView.Refresh();
        }

        /// <summary>
        /// Позволяет получить список всех таблиц из базы данных.
        /// </summary>
        /// <param name="connection">Подключение к базе данных.</param>
        /// <returns></returns>
        public List<string> GetAllTableName(OleDbConnection connection)
        {
            var names = new List<string>();
            var table = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
            for (int i = 0; i < table.Rows.Count; i++)
            {
                names.Add(table.Rows[i].Field<string>("TABLE_NAME"));
            }
            return names;
        }
        /// <summary>
        /// Позволяет получить строку таблиц, которые используются в запросе.
        /// </summary>
        /// <param name="query">Запрос.</param>
        /// <param name="tableNames">Список всех таблиц.</param>
        /// <returns></returns>
        public string GetTableName(string query, List<string> tableNames)
        {
            StringBuilder strBuild = new StringBuilder();
            for (int i = 0; i < tableNames.Count; i++)
            {
                if (query.Contains(tableNames[i]))
                {
                    strBuild.Append(tableNames[i]);
                    strBuild.Append(", ");
                }
            }
            strBuild.Remove(strBuild.Length - 2, 1);
            return strBuild.ToString();
        }
        List<string> CreateInsertQuery(string query, OleDbConnection connection)
        {
            var command = new OleDbCommand(query, connection);
            var reader = command.ExecuteReader();
            OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection);
            var dataTable = new DataTable();
            adapter.Fill(dataTable);
            var insertQuery = new List<string>();
            for (int i = 0; i < DataGridView.RowCount; i++)
            {
                reader.Read();
                for (int j = 0; j < dataTable.Columns.Count; j++)
                {
                    if (DataGridView[j, i].Value.ToString() != reader[j].ToString())
                    {
                        StringBuilder stringBuild = new StringBuilder();
                        stringBuild.Append("UPDATE ");
                        stringBuild.Append(GetTableName(query, GetAllTableName(dataBase)));
                        stringBuild.Append("SET ");
                        stringBuild.Append(DataGridView.Columns[j].Name);
                        stringBuild.Append(" = \"");
                        stringBuild.Append(DataGridView[j, i].Value.ToString());
                        stringBuild.Append("\" WHERE ");
                        stringBuild.Append(DataGridView.Columns[0].Name);
                        stringBuild.Append(" = ");
                        stringBuild.Append(reader[0].ToString());
                        stringBuild.Append(";");
                        insertQuery.Add(stringBuild.ToString());
                    }
                }
            }
            return insertQuery;
        }

        private void ButtonUpdateDb_Click(object sender, EventArgs e)
        {
            var queryList = CreateInsertQuery(query[lastQuery], dataBase);
            for (int i = 0; i < queryList.Count; i++)
            {
                new OleDbCommand(queryList[i], dataBase).ExecuteNonQuery();
            }
        }
    }
}
