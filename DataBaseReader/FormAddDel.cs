using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Text;
using System.Windows.Forms;

namespace DataBaseReader
{
    public partial class FormAddDel : Form
    {
        readonly bool readOnly;
        readonly List<string> Rows;
        public FormAddDel(bool readOnly, List<string> rows)
        {
            InitializeComponent();
            this.readOnly = readOnly;
            Rows = rows;
        }

        private void FormAddDel_Load(object sender, EventArgs e)
        {
            var adapter = new OleDbDataAdapter(FormMain.LastQuery, FormMain.dataBase);
            var dataTable = new DataTable();
            adapter.Fill(dataTable);
            DataGridViewEdit.ColumnCount = dataTable.Columns.Count;
            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                DataGridViewEdit.Columns[i].Name = dataTable.Columns[i].ToString();
            }
            DataGridViewEdit.Rows.Add();
            DataGridViewEdit.ReadOnly = readOnly;
            if (readOnly)
            {
                AddValueInDataGridView();
            }
        }

        private void ButtonPerform_Click(object sender, EventArgs e)
        {
            try
            {
                if (!readOnly)
                {
                    new OleDbCommand(CreateInsertQuery(FormMain.LastQuery, FormMain.dataBase), FormMain.dataBase).ExecuteNonQuery();
                    MessageBox.Show("Добавлено успешно!", "Выполнено", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    Close();
                }
                else
                {
                    new OleDbCommand(CreateDeleteQuery(FormMain.LastQuery, FormMain.dataBase), FormMain.dataBase).ExecuteNonQuery();
                    MessageBox.Show("Удалено успешно!", "Выполнено", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    Close();
                }
            }
            catch
            {
                MessageBox.Show("Что-то пошло не так! Возможно, ошибка ввода!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Создание запроса для ввода новых значений.
        /// </summary>
        /// <param name="query">Запрос из которого будет взята таблица.</param>
        /// <param name="connection">Подключение к базе данных.</param>
        /// <returns>Строка с запросом.</returns>
        string CreateInsertQuery(string query, OleDbConnection connection)
        {
            StringBuilder queryInsert = new StringBuilder();
            queryInsert.Append("INSERT INTO ");
            var table = new FormMain().GetTableName(query, new FormMain().GetAllTableName(connection));
            queryInsert.Append(table[0]);
            queryInsert.Append(" (");
            for (int i = 0; i < DataGridViewEdit.Columns.Count; i++)
            {
                queryInsert.Append(DataGridViewEdit.Columns[i].Name);
                queryInsert.Append(", ");
            }
            queryInsert.Remove(queryInsert.Length - 2, 2);
            queryInsert.Append(") VALUES (");
            for (int i = 0; i < DataGridViewEdit.Columns.Count; i++)
            {
                queryInsert.Append("'");
                queryInsert.Append(DataGridViewEdit[i, 0].Value);
                queryInsert.Append("', ");
            }
            queryInsert.Remove(queryInsert.Length - 2, 2);
            queryInsert.Append(");");
            return queryInsert.ToString();
        }

        /// <summary>
        /// Создание запроса для удаления значений.
        /// </summary>
        /// <param name="query">Запрос из которого будет взята таблица.</param>
        /// <param name="connection">Подключение к базе данных.</param>
        /// <returns>Строка к запросом.</returns>
        string CreateDeleteQuery(string query, OleDbConnection connection)
        {
            //DELETE FROM <таблица> WHERE<условие>;
            StringBuilder queryDelete = new StringBuilder();
            var table = new FormMain().GetTableName(query, new FormMain().GetAllTableName(connection));
            queryDelete.Append("DELETE FROM ");
            queryDelete.Append(table[0]);
            queryDelete.Append(" WHERE ");
            queryDelete.Append(DataGridViewEdit.Columns[0].Name);
            queryDelete.Append(" = ");
            queryDelete.Append(DataGridViewEdit[0, 0].Value);
            return queryDelete.ToString();
        }

        /// <summary>
        /// Устанавливает значения в DataGridView.
        /// </summary>
        void AddValueInDataGridView()
        {
            for (int j = 0; j < DataGridViewEdit.Columns.Count; j++)
            {
                DataGridViewEdit[j, 0].Value = Rows[j];
            }
        }
    }
}
