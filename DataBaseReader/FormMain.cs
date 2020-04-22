using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;

namespace DataBaseReader
{
    public partial class FormMain : Form
    {
        //Лист, содержащий запросы
        public static List<string> Query = new List<string>();
        //Путь к базе данных (полный)
        public static string DataBasePath = default;
        //Подключение к базе данных
        public static OleDbConnection dataBase;
        //Количество столбцов в полученном запросе
        public static int ColumnCount { get; set; }
        //Последний выполненный запрос
        public static string LastQuery { get; set; }
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

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Закрытие базы данных, если она открыта
            if (dataBase != null)
            {
                dataBase.Close();
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

        private void ButtonDoQuery_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridView.Rows.Clear();
                if (CheckerNumberQuery(TextBoxQueryNumber.Text, Query.Count))
                {
                    CreateDataBaseInfo(Query[Convert.ToInt32(TextBoxQueryNumber.Text) - 1], dataBase);
                    InputDataBase(Query[Convert.ToInt32(TextBoxQueryNumber.Text) - 1], dataBase);
                    LastQuery = Query[Convert.ToInt32(TextBoxQueryNumber.Text) - 1];
                }
            }
            catch
            {
                MessageBox.Show("В запросе обнаружена ошибка.\nЛибо не открыта БД.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonInsertUpdateDelete_Click(object sender, EventArgs e)
        {
            if (CheckerNumberQuery(TextBoxQueryNumber.Text, Query.Count))
            {
                new OleDbCommand(Query[Convert.ToInt32(TextBoxQueryNumber.Text) - 1], dataBase).ExecuteNonQuery();
            }
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
                        LastQuery = RichTextBoxFastQuery.Text;
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

        private void CheckBoxAllowEdit_CheckedChanged(object sender, EventArgs e)
        {

            if (CheckBoxAllowEdit.Checked == false)
            {
                DataGridView.ReadOnly = true;
            }
            else
            {
                MessageBox.Show("При изменении данных используйте в запросе ТОЛЬКО ОДНУ таблицу!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DataGridView.ReadOnly = false;
            }
        }

        private void ButtonUpdateDb_Click(object sender, EventArgs e)
        {

            try
            {
                var queryList = GetUpdateQuery(LastQuery, dataBase);
                for (int i = 0; i < queryList.Count; i++)
                {
                    new OleDbCommand(queryList[i], dataBase).ExecuteNonQuery();
                }
            }
            catch
            {
                MessageBox.Show("Изменение невозможно!\nПожалуйста проверьте введённые данные и используйте в запросе только одну таблицу.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ButtonInsertDb_Click(object sender, EventArgs e)
        {
            //DataGridView.Rows.Add(new[] { "", "object", "object" });
            //new OleDbCommand("INSERT INTO City (Code, Name, CompanyCount) VALUES (10, NULL, NULL);", dataBase).ExecuteNonQuery();
        }

        private void ButtonDeleteDb_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in DataGridView.SelectedRows)
            {
                DataGridView.Rows.Remove(row);
            }
        }

        private void ButtonSaveDb_Click(object sender, EventArgs e)
        {

        }

        private void ButtonRefresh_Click(object sender, EventArgs e)
        {
            DataGridView.Refresh();
        }

        private void ButtonClear_Click(object sender, EventArgs e)
        {
            DataGridView.Rows.Clear();
        }

        private void MenuStripDataBase_Click(object sender, EventArgs e)
        {
            new FormOpen().ShowDialog();
        }

        private void MenuStripEditQuery_Click(object sender, EventArgs e)
        {
            new FormEditQuery().Show();
        }

        private void MenuStripExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
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
                                Query.Add(queryText);
                            }
                            queryText = string.Empty;
                            break;
                        }
                }
            }
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
        /// <returns>Существование запроса.</returns>
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

        /// <summary>
        /// Позволяет получить список всех таблиц из базы данных.
        /// </summary>
        /// <param name="connection">Подключение к базе данных.</param>
        /// <returns>Список всех таблиц.</returns>
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
        /// Позволяет получить список таблиц, которые используются в запросе.
        /// </summary>
        /// <param name="query">Запрос.</param>
        /// <param name="allTableName">Список всех таблиц.</param>
        /// <returns>Список таблиц запроса.</returns>
        List<string> GetTableName(string query, List<string> allTableName)
        {
            var tableName = new List<string>();
            for (int i = 0; i < allTableName.Count; i++)
            {
                if (query.Contains(allTableName[i]))
                {
                    tableName.Add(allTableName[i]);
                }
            }
            return tableName;
        }

        /// <summary>
        /// Создание листа с запросами для изменения значений в базе данных.
        /// </summary>
        /// <param name="query">Запрос, из которого будет взята таблица.</param>
        /// <param name="connection">Подключение к базе данных.</param>
        /// <returns>Список запросов.</returns>
        List<string> GetUpdateQuery(string query, OleDbConnection connection)
        {
            var queryList = GetTableName(query, GetAllTableName(dataBase));
            if (queryList.Count < 2)
            {
                //Хранимые данные запроса
                var command = new OleDbCommand(query, connection);
                //Переменная для чтения значений из текущего запроса
                var reader = command.ExecuteReader();
                //Заполнение DataGridView 
                var adapter = new OleDbDataAdapter(query, connection);
                var dataTable = new DataTable();
                adapter.Fill(dataTable);
                //Список с запросами для изменения
                var updateQuery = new List<string>();
                for (int i = 0; i < DataGridView.RowCount; i++)
                {
                    reader.Read();
                    for (int j = 0; j < dataTable.Columns.Count; j++)
                    {
                        //Создавать запрос только при условии изменения значения
                        if (DataGridView[j, i].Value.ToString() != reader[j].ToString())
                        {
                            updateQuery.Add(CreateUpdateQuery(queryList[0], DataGridView.Columns[j].Name, DataGridView[j, i].Value.ToString(), DataGridView.Columns[0].Name, reader[0].ToString()));
                        }
                    }
                }
                return updateQuery;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Создаёт запрос на добавление данных с указанными параметрами.
        /// </summary>
        /// <param name="table">Таблица, в которой необходимо выполнить изменение</param>
        /// <param name="columnName">Название столбца.</param>
        /// <param name="value">Значение.</param>
        /// <param name="where1">Первое условие.</param>
        /// <param name="where2">Второе условие.</param>
        /// <returns>Готовый запрос на изменение.</returns>
        string CreateUpdateQuery(string table, string columnName, string value, string where1, string where2)
        {
            StringBuilder stringBuild = new StringBuilder();
            stringBuild.Append("UPDATE ");
            stringBuild.Append(table);
            stringBuild.Append(" SET ");
            stringBuild.Append(columnName);
            stringBuild.Append(" = \"");
            stringBuild.Append(value);
            stringBuild.Append("\" WHERE ");
            stringBuild.Append(where1);
            stringBuild.Append(" = ");
            stringBuild.Append(where2);
            stringBuild.Append(";");
            MessageBox.Show(stringBuild.ToString());
            return stringBuild.ToString();
        }
    }
}
