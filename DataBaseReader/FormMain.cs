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
        public static List<string> QueryList = new List<string>();
        //Путь к базе данных (полный)
        public static string DataBasePath = default;
        //Подключение к базе данных
        public static OleDbConnection DataBaseConnection;
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
            //Запись всех файлов в директории для автоматического считывания xml файлов
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
            //Закрыть базу данных при выходе из программы, если БД открыта
            if (DataBaseConnection != null)
            {
                DataBaseConnection.Close();
            }
        }

        private void TextBoxQueryNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Допустить устанавливать только целочисленные значения в TextBox
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void ButtonDoQuery_Click(object sender, EventArgs e)
        {
            //Попытаться выполнить запрос, в противном случае вызывать окно с ошибкой
            try
            {
                DataGridView.Rows.Clear();
                //Проверить на существующие значения TextBox
                if (CheckerNumberQuery(TextBoxQueryNumber.Text, QueryList.Count))
                {
                    //Отобразить столбцы в DataGridView по текущему запросу
                    SetAllColumns(QueryList[Convert.ToInt32(TextBoxQueryNumber.Text) - 1], DataBaseConnection);
                    //Отобразить заполненные ячейки в DataGridView по текущему запросу
                    SetAllRows(QueryList[Convert.ToInt32(TextBoxQueryNumber.Text) - 1], DataBaseConnection);
                    //Сохранить последний выполненный запрос в свойство
                    LastQuery = QueryList[Convert.ToInt32(TextBoxQueryNumber.Text) - 1];
                }
            }
            catch
            {
                MessageBox.Show("В запросе обнаружена ошибка.\nЛибо не открыта БД.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonInsertUpdateDelete_Click(object sender, EventArgs e)
        {
            //Проверить на существующие значения TextBox
            try
            {
                if (CheckerNumberQuery(TextBoxQueryNumber.Text, QueryList.Count))
                {
                    //Выполнить запрос на изменение элементов в базе данных
                    new OleDbCommand(QueryList[Convert.ToInt32(TextBoxQueryNumber.Text) - 1], DataBaseConnection).ExecuteNonQuery();
                }
            }
            catch
            {
                MessageBox.Show("В запросе обнаружена ошибка.\nЛибо не открыта БД.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonFastQuery_Click(object sender, EventArgs e)
        {
            if (RichTextBoxFastQuery.Text != string.Empty)
            {
                try
                {
                    //Выполнять обычный запрос на получение, если в запросе содержится SELECT
                    if (RichTextBoxFastQuery.Text.Contains("SELECT"))
                    {
                        DataGridView.Rows.Clear();
                        SetAllColumns(RichTextBoxFastQuery.Text, DataBaseConnection);
                        SetAllRows(RichTextBoxFastQuery.Text, DataBaseConnection);
                        LastQuery = RichTextBoxFastQuery.Text;
                    }
                    else
                    {
                        new OleDbCommand(RichTextBoxFastQuery.Text, DataBaseConnection).ExecuteNonQuery();
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
            //Переключать возможность изменения вручную через CheckBox
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
            if (CheckBoxAllowEdit.Checked)
            {
                try
                {
                    //Получение всех запросов для изменения
                    var queryList = GetUpdateQuery(LastQuery, DataBaseConnection);
                    for (int i = 0; i < queryList.Count; i++)
                    {
                        new OleDbCommand(queryList[i], DataBaseConnection).ExecuteNonQuery();
                    }
                    MessageBox.Show("Изменено успешно!", "Выполнено", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                catch
                {
                    MessageBox.Show("Изменение невозможно!\nПожалуйста проверьте введённые данные и используйте в запросе только одну таблицу.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Вы не разрешили редактирование", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ButtonInsertDb_Click(object sender, EventArgs e)
        {
            try
            {
                //Выполнять добавление только в случае использования одной таблицы
                if (GetTableName(LastQuery, GetAllTableName(DataBaseConnection)).Count < 2)
                {
                    var formAdd = new FormAddDel(false, null)
                    {
                        Text = "Выполните ввод"
                    };
                    formAdd.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Пожалуйста, используйте одну таблицу", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                MessageBox.Show("Запрос не введён", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonDeleteDb_Click(object sender, EventArgs e)
        {
            try
            {
                //Выполнять удаление только в случае использования одной таблицы
                if (GetTableName(LastQuery, GetAllTableName(DataBaseConnection)).Count < 2)
                {
                    var rowDel = new List<string>();
                    for (int i = 0; i < DataGridView.ColumnCount; i++)
                    {
                        rowDel.Add(DataGridView[i, DataGridView.CurrentRow.Index].Value.ToString());
                    }
                    var formDel = new FormAddDel(true, rowDel)
                    {
                        Text = "Подтвердите удаление!"
                    };
                    formDel.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Пожалуйста, используйте одну таблицу", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                MessageBox.Show("Запрос не введён", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonRefresh_Click(object sender, EventArgs e)
        {
            DataGridView.Refresh();
        }

        private void ButtonClear_Click(object sender, EventArgs e)
        {
            DataGridView.Rows.Clear();
        }

        private void MenuStripDataBase_Click_1(object sender, EventArgs e)
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

        private void MenuStripAboutProgram_Click(object sender, EventArgs e)
        {
            new FormAboutProgram().Show();
        }

        private void MenuStripDescription_Click(object sender, EventArgs e)
        {
            new FormDescription().Show();
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
                //Получение типа из XML файла
                switch (reader.NodeType)
                {
                    //Если встречается обычный текст
                    case XmlNodeType.Text:
                    {
                        //Пропускать строку после каждой строчки, если запрос многострочный
                        if (queryText != string.Empty)
                        {
                            queryText += "\n";
                        }
                        queryText += reader.Value;
                        break;
                    }
                    //Если встречается закрывающий тег </...>
                    case XmlNodeType.EndElement:
                    {
                        //Добавлять запрос в лист
                        if (queryText != string.Empty)
                        {
                            QueryList.Add(queryText);
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
        private void SetAllColumns(string query, OleDbConnection connection)
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
        /// Установка всех строк по текущему запросу из базы данных в DataGridView.
        /// </summary>
        /// <param name="query">Запрос.</param>
        /// <param name="connection">Подключение к базе данных.</param>
        private void SetAllRows(string query, OleDbConnection connection)
        {
            //Запись команды из базы данных
            var command = new OleDbCommand(query, connection);
            //Построение переменной для чтения
            var reader = command.ExecuteReader();
            //Лист массивов для работы с каждым элементом
            var data = new List<string[]>();
            while (reader.Read())
            {
                //Инициализация строки в зависимости от количества столбцов 
                data.Add(new string[ColumnCount]);
                for (int i = 0; i < ColumnCount; i++)
                {
                    //Заполнение последней иницилазированной строки из базы данных
                    data[data.Count - 1][i] = reader[i].ToString();
                }
            }
            reader.Close();
            //Установка всех строк в DataGridView
            foreach (string[] e in data)
            {
                DataGridView.Rows.Add(e);
            }
        }

        /// <summary>
        /// Проверка строки для ввода номера запроса на несуществующие или пустые значения.
        /// </summary>
        /// <param name="queryNumber">Номер запроса.</param>
        /// <param name="count">Количество запросов.</param>
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
                //Добавить в лист только элементы столбца TABLE_NAME
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
        public List<string> GetTableName(string query, List<string> allTableName)
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
            var queryList = GetTableName(query, GetAllTableName(DataBaseConnection));
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
                        //Создавать запрос только при условии изменения значения в ячейке
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
            return stringBuild.ToString();
        }
    }
}
