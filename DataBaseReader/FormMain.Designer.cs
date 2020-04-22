namespace DataBaseReader
{
    partial class FormMain
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.MenuStripFile = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuStripOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuStripDataBase = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuStripQuery = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuStripEditQuery = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuStripExit = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.GroupBoxDataBase = new System.Windows.Forms.GroupBox();
            this.ButtonFastQuery = new System.Windows.Forms.Button();
            this.RichTextBoxFastQuery = new System.Windows.Forms.RichTextBox();
            this.ButtonInsertUpdateDelete = new System.Windows.Forms.Button();
            this.TextBoxQueryNumber = new System.Windows.Forms.TextBox();
            this.LabelQueryNumber = new System.Windows.Forms.Label();
            this.ButtonDoQuery = new System.Windows.Forms.Button();
            this.DataGridView = new System.Windows.Forms.DataGridView();
            this.ButtonRefresh = new System.Windows.Forms.Button();
            this.ButtonClear = new System.Windows.Forms.Button();
            this.CheckBoxAllowEdit = new System.Windows.Forms.CheckBox();
            this.ButtonInsertDb = new System.Windows.Forms.Button();
            this.ButtonUpdateDb = new System.Windows.Forms.Button();
            this.ButtonDeleteDb = new System.Windows.Forms.Button();
            this.ButtonRefreshDb = new System.Windows.Forms.Button();
            this.GroupBoxEdit = new System.Windows.Forms.GroupBox();
            this.GroupBoxCreateDelete = new System.Windows.Forms.GroupBox();
            this.MenuStrip.SuspendLayout();
            this.GroupBoxDataBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView)).BeginInit();
            this.GroupBoxEdit.SuspendLayout();
            this.GroupBoxCreateDelete.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuStripFile
            // 
            this.MenuStripFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuStripOpen,
            this.MenuStripEditQuery,
            this.MenuStripExit});
            this.MenuStripFile.Name = "MenuStripFile";
            this.MenuStripFile.Size = new System.Drawing.Size(45, 20);
            this.MenuStripFile.Text = "Файл";
            // 
            // MenuStripOpen
            // 
            this.MenuStripOpen.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuStripDataBase,
            this.MenuStripQuery});
            this.MenuStripOpen.Name = "MenuStripOpen";
            this.MenuStripOpen.Size = new System.Drawing.Size(172, 22);
            this.MenuStripOpen.Text = "Открыть...";
            // 
            // MenuStripDataBase
            // 
            this.MenuStripDataBase.Name = "MenuStripDataBase";
            this.MenuStripDataBase.Size = new System.Drawing.Size(163, 22);
            this.MenuStripDataBase.Text = "База данных";
            this.MenuStripDataBase.Click += new System.EventHandler(this.MenuStripDataBase_Click);
            // 
            // MenuStripQuery
            // 
            this.MenuStripQuery.Name = "MenuStripQuery";
            this.MenuStripQuery.Size = new System.Drawing.Size(163, 22);
            this.MenuStripQuery.Text = "Файл с запросами";
            // 
            // MenuStripEditQuery
            // 
            this.MenuStripEditQuery.Name = "MenuStripEditQuery";
            this.MenuStripEditQuery.Size = new System.Drawing.Size(172, 22);
            this.MenuStripEditQuery.Text = "Редактор запросов";
            this.MenuStripEditQuery.Click += new System.EventHandler(this.MenuStripEditQuery_Click);
            // 
            // MenuStripExit
            // 
            this.MenuStripExit.Name = "MenuStripExit";
            this.MenuStripExit.Size = new System.Drawing.Size(172, 22);
            this.MenuStripExit.Text = "Выход";
            this.MenuStripExit.Click += new System.EventHandler(this.MenuStripExit_Click);
            // 
            // MenuStrip
            // 
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuStripFile});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(834, 24);
            this.MenuStrip.TabIndex = 0;
            this.MenuStrip.Text = "menuStrip1";
            // 
            // GroupBoxDataBase
            // 
            this.GroupBoxDataBase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.GroupBoxDataBase.Controls.Add(this.ButtonFastQuery);
            this.GroupBoxDataBase.Controls.Add(this.RichTextBoxFastQuery);
            this.GroupBoxDataBase.Controls.Add(this.ButtonInsertUpdateDelete);
            this.GroupBoxDataBase.Controls.Add(this.TextBoxQueryNumber);
            this.GroupBoxDataBase.Controls.Add(this.LabelQueryNumber);
            this.GroupBoxDataBase.Controls.Add(this.ButtonDoQuery);
            this.GroupBoxDataBase.Location = new System.Drawing.Point(8, 32);
            this.GroupBoxDataBase.Name = "GroupBoxDataBase";
            this.GroupBoxDataBase.Size = new System.Drawing.Size(232, 326);
            this.GroupBoxDataBase.TabIndex = 2;
            this.GroupBoxDataBase.TabStop = false;
            this.GroupBoxDataBase.Text = "Управление с помощью запросов";
            // 
            // ButtonFastQuery
            // 
            this.ButtonFastQuery.Location = new System.Drawing.Point(16, 144);
            this.ButtonFastQuery.Name = "ButtonFastQuery";
            this.ButtonFastQuery.Size = new System.Drawing.Size(200, 40);
            this.ButtonFastQuery.TabIndex = 9;
            this.ButtonFastQuery.Text = "Выполнить быстрый запрос";
            this.ButtonFastQuery.UseVisualStyleBackColor = true;
            this.ButtonFastQuery.Click += new System.EventHandler(this.ButtonFastQuery_Click);
            // 
            // RichTextBoxFastQuery
            // 
            this.RichTextBoxFastQuery.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.RichTextBoxFastQuery.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RichTextBoxFastQuery.Location = new System.Drawing.Point(16, 192);
            this.RichTextBoxFastQuery.Name = "RichTextBoxFastQuery";
            this.RichTextBoxFastQuery.Size = new System.Drawing.Size(200, 126);
            this.RichTextBoxFastQuery.TabIndex = 8;
            this.RichTextBoxFastQuery.Text = "";
            this.RichTextBoxFastQuery.WordWrap = false;
            // 
            // ButtonInsertUpdateDelete
            // 
            this.ButtonInsertUpdateDelete.Location = new System.Drawing.Point(16, 96);
            this.ButtonInsertUpdateDelete.Name = "ButtonInsertUpdateDelete";
            this.ButtonInsertUpdateDelete.Size = new System.Drawing.Size(200, 40);
            this.ButtonInsertUpdateDelete.TabIndex = 6;
            this.ButtonInsertUpdateDelete.Text = "Добавить/Изменить/Удалить";
            this.ButtonInsertUpdateDelete.UseVisualStyleBackColor = true;
            this.ButtonInsertUpdateDelete.Click += new System.EventHandler(this.ButtonInsertUpdateDelete_Click);
            // 
            // TextBoxQueryNumber
            // 
            this.TextBoxQueryNumber.Location = new System.Drawing.Point(136, 22);
            this.TextBoxQueryNumber.MaxLength = 9;
            this.TextBoxQueryNumber.Name = "TextBoxQueryNumber";
            this.TextBoxQueryNumber.Size = new System.Drawing.Size(80, 20);
            this.TextBoxQueryNumber.TabIndex = 7;
            this.TextBoxQueryNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxQueryNumber_KeyPress);
            // 
            // LabelQueryNumber
            // 
            this.LabelQueryNumber.AutoSize = true;
            this.LabelQueryNumber.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LabelQueryNumber.Location = new System.Drawing.Point(16, 24);
            this.LabelQueryNumber.Name = "LabelQueryNumber";
            this.LabelQueryNumber.Size = new System.Drawing.Size(116, 16);
            this.LabelQueryNumber.TabIndex = 6;
            this.LabelQueryNumber.Text = "Номер запроса:";
            // 
            // ButtonDoQuery
            // 
            this.ButtonDoQuery.Location = new System.Drawing.Point(16, 48);
            this.ButtonDoQuery.Name = "ButtonDoQuery";
            this.ButtonDoQuery.Size = new System.Drawing.Size(200, 40);
            this.ButtonDoQuery.TabIndex = 0;
            this.ButtonDoQuery.Text = "Выполнить запрос";
            this.ButtonDoQuery.UseVisualStyleBackColor = true;
            this.ButtonDoQuery.Click += new System.EventHandler(this.ButtonDoQuery_Click);
            // 
            // DataGridView
            // 
            this.DataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DataGridView.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView.Location = new System.Drawing.Point(256, 85);
            this.DataGridView.Name = "DataGridView";
            this.DataGridView.ReadOnly = true;
            this.DataGridView.Size = new System.Drawing.Size(568, 220);
            this.DataGridView.TabIndex = 3;
            // 
            // ButtonRefresh
            // 
            this.ButtonRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ButtonRefresh.Location = new System.Drawing.Point(256, 310);
            this.ButtonRefresh.Name = "ButtonRefresh";
            this.ButtonRefresh.Size = new System.Drawing.Size(136, 48);
            this.ButtonRefresh.TabIndex = 4;
            this.ButtonRefresh.Text = "Обновить";
            this.ButtonRefresh.UseVisualStyleBackColor = true;
            this.ButtonRefresh.Click += new System.EventHandler(this.ButtonRefresh_Click);
            // 
            // ButtonClear
            // 
            this.ButtonClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ButtonClear.Location = new System.Drawing.Point(400, 310);
            this.ButtonClear.Name = "ButtonClear";
            this.ButtonClear.Size = new System.Drawing.Size(136, 48);
            this.ButtonClear.TabIndex = 5;
            this.ButtonClear.Text = "Очистить";
            this.ButtonClear.UseVisualStyleBackColor = true;
            this.ButtonClear.Click += new System.EventHandler(this.ButtonClear_Click);
            // 
            // CheckBoxAllowEdit
            // 
            this.CheckBoxAllowEdit.AutoSize = true;
            this.CheckBoxAllowEdit.Location = new System.Drawing.Point(16, 16);
            this.CheckBoxAllowEdit.Name = "CheckBoxAllowEdit";
            this.CheckBoxAllowEdit.Size = new System.Drawing.Size(168, 17);
            this.CheckBoxAllowEdit.TabIndex = 6;
            this.CheckBoxAllowEdit.Text = "Разрешить редактирование";
            this.CheckBoxAllowEdit.UseVisualStyleBackColor = true;
            this.CheckBoxAllowEdit.CheckedChanged += new System.EventHandler(this.CheckBoxAllowEdit_CheckedChanged);
            // 
            // ButtonInsertDb
            // 
            this.ButtonInsertDb.Location = new System.Drawing.Point(8, 16);
            this.ButtonInsertDb.Name = "ButtonInsertDb";
            this.ButtonInsertDb.Size = new System.Drawing.Size(75, 23);
            this.ButtonInsertDb.TabIndex = 7;
            this.ButtonInsertDb.Text = "Добавить";
            this.ButtonInsertDb.UseVisualStyleBackColor = true;
            this.ButtonInsertDb.Click += new System.EventHandler(this.ButtonInsertDb_Click);
            // 
            // ButtonUpdateDb
            // 
            this.ButtonUpdateDb.Location = new System.Drawing.Point(192, 16);
            this.ButtonUpdateDb.Name = "ButtonUpdateDb";
            this.ButtonUpdateDb.Size = new System.Drawing.Size(75, 23);
            this.ButtonUpdateDb.TabIndex = 7;
            this.ButtonUpdateDb.Text = "Изменить";
            this.ButtonUpdateDb.UseVisualStyleBackColor = true;
            this.ButtonUpdateDb.Click += new System.EventHandler(this.ButtonUpdateDb_Click);
            // 
            // ButtonDeleteDb
            // 
            this.ButtonDeleteDb.Location = new System.Drawing.Point(96, 16);
            this.ButtonDeleteDb.Name = "ButtonDeleteDb";
            this.ButtonDeleteDb.Size = new System.Drawing.Size(75, 23);
            this.ButtonDeleteDb.TabIndex = 7;
            this.ButtonDeleteDb.Text = "Удалить";
            this.ButtonDeleteDb.UseVisualStyleBackColor = true;
            // 
            // ButtonRefreshDb
            // 
            this.ButtonRefreshDb.Location = new System.Drawing.Point(184, 16);
            this.ButtonRefreshDb.Name = "ButtonRefreshDb";
            this.ButtonRefreshDb.Size = new System.Drawing.Size(75, 23);
            this.ButtonRefreshDb.TabIndex = 7;
            this.ButtonRefreshDb.Text = "Сохранить";
            this.ButtonRefreshDb.UseVisualStyleBackColor = true;
            this.ButtonRefreshDb.Click += new System.EventHandler(this.ButtonRefreshDb_Click);
            // 
            // GroupBoxEdit
            // 
            this.GroupBoxEdit.Controls.Add(this.CheckBoxAllowEdit);
            this.GroupBoxEdit.Controls.Add(this.ButtonUpdateDb);
            this.GroupBoxEdit.Location = new System.Drawing.Point(256, 32);
            this.GroupBoxEdit.Name = "GroupBoxEdit";
            this.GroupBoxEdit.Size = new System.Drawing.Size(280, 48);
            this.GroupBoxEdit.TabIndex = 8;
            this.GroupBoxEdit.TabStop = false;
            this.GroupBoxEdit.Text = "Прямое изменение данных";
            // 
            // GroupBoxCreateDelete
            // 
            this.GroupBoxCreateDelete.Controls.Add(this.ButtonInsertDb);
            this.GroupBoxCreateDelete.Controls.Add(this.ButtonDeleteDb);
            this.GroupBoxCreateDelete.Controls.Add(this.ButtonRefreshDb);
            this.GroupBoxCreateDelete.Location = new System.Drawing.Point(552, 32);
            this.GroupBoxCreateDelete.Name = "GroupBoxCreateDelete";
            this.GroupBoxCreateDelete.Size = new System.Drawing.Size(272, 48);
            this.GroupBoxCreateDelete.TabIndex = 9;
            this.GroupBoxCreateDelete.TabStop = false;
            this.GroupBoxCreateDelete.Text = "Прямое управление данными";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 365);
            this.Controls.Add(this.GroupBoxCreateDelete);
            this.Controls.Add(this.GroupBoxEdit);
            this.Controls.Add(this.ButtonClear);
            this.Controls.Add(this.ButtonRefresh);
            this.Controls.Add(this.DataGridView);
            this.Controls.Add(this.GroupBoxDataBase);
            this.Controls.Add(this.MenuStrip);
            this.MainMenuStrip = this.MenuStrip;
            this.MinimumSize = new System.Drawing.Size(563, 350);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Работа с БД";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            this.GroupBoxDataBase.ResumeLayout(false);
            this.GroupBoxDataBase.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView)).EndInit();
            this.GroupBoxEdit.ResumeLayout(false);
            this.GroupBoxEdit.PerformLayout();
            this.GroupBoxCreateDelete.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem MenuStripFile;
        private System.Windows.Forms.MenuStrip MenuStrip;
        private System.Windows.Forms.GroupBox GroupBoxDataBase;
        private System.Windows.Forms.DataGridView DataGridView;
        private System.Windows.Forms.Button ButtonRefresh;
        private System.Windows.Forms.ToolStripMenuItem MenuStripEditQuery;
        private System.Windows.Forms.Button ButtonClear;
        private System.Windows.Forms.Label LabelQueryNumber;
        private System.Windows.Forms.Button ButtonDoQuery;
        private System.Windows.Forms.TextBox TextBoxQueryNumber;
        private System.Windows.Forms.Button ButtonInsertUpdateDelete;
        private System.Windows.Forms.ToolStripMenuItem MenuStripExit;
        private System.Windows.Forms.Button ButtonFastQuery;
        private System.Windows.Forms.RichTextBox RichTextBoxFastQuery;
        private System.Windows.Forms.ToolStripMenuItem MenuStripOpen;
        private System.Windows.Forms.ToolStripMenuItem MenuStripQuery;
        private System.Windows.Forms.ToolStripMenuItem MenuStripDataBase;
        private System.Windows.Forms.CheckBox CheckBoxAllowEdit;
        private System.Windows.Forms.Button ButtonInsertDb;
        private System.Windows.Forms.Button ButtonUpdateDb;
        private System.Windows.Forms.Button ButtonDeleteDb;
        private System.Windows.Forms.Button ButtonRefreshDb;
        private System.Windows.Forms.GroupBox GroupBoxEdit;
        private System.Windows.Forms.GroupBox GroupBoxCreateDelete;
    }
}

