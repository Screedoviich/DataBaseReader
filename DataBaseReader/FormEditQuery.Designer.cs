namespace DataBaseReader
{
    partial class FormEditQuery
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.RichTextBoxQuery = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.LabelQueryNumber = new System.Windows.Forms.Label();
            this.TextBoxQueryNumber = new System.Windows.Forms.TextBox();
            this.ButtomQueryEdit = new System.Windows.Forms.Button();
            this.ButtomQueryListNow = new System.Windows.Forms.Button();
            this.ButtomQueryList = new System.Windows.Forms.Button();
            this.ButtomQueryAdd = new System.Windows.Forms.Button();
            this.LabelEditQuery = new System.Windows.Forms.Label();
            this.ButtomQueryClear = new System.Windows.Forms.Button();
            this.ComboBoxTemplate = new System.Windows.Forms.ComboBox();
            this.LabelTemplate = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // RichTextBoxQuery
            // 
            this.RichTextBoxQuery.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RichTextBoxQuery.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RichTextBoxQuery.Location = new System.Drawing.Point(264, 40);
            this.RichTextBoxQuery.Name = "RichTextBoxQuery";
            this.RichTextBoxQuery.Size = new System.Drawing.Size(300, 160);
            this.RichTextBoxQuery.TabIndex = 6;
            this.RichTextBoxQuery.Text = "";
            this.RichTextBoxQuery.WordWrap = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LabelQueryNumber);
            this.groupBox1.Controls.Add(this.TextBoxQueryNumber);
            this.groupBox1.Controls.Add(this.ButtomQueryEdit);
            this.groupBox1.Controls.Add(this.ButtomQueryListNow);
            this.groupBox1.Controls.Add(this.ButtomQueryList);
            this.groupBox1.Controls.Add(this.ButtomQueryAdd);
            this.groupBox1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(16, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(232, 240);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Управление запросами";
            // 
            // LabelQueryNumber
            // 
            this.LabelQueryNumber.AutoSize = true;
            this.LabelQueryNumber.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LabelQueryNumber.Location = new System.Drawing.Point(16, 120);
            this.LabelQueryNumber.Name = "LabelQueryNumber";
            this.LabelQueryNumber.Size = new System.Drawing.Size(116, 16);
            this.LabelQueryNumber.TabIndex = 10;
            this.LabelQueryNumber.Text = "Номер запроса:";
            // 
            // TextBoxQueryNumber
            // 
            this.TextBoxQueryNumber.Location = new System.Drawing.Point(136, 117);
            this.TextBoxQueryNumber.MaxLength = 9;
            this.TextBoxQueryNumber.Name = "TextBoxQueryNumber";
            this.TextBoxQueryNumber.Size = new System.Drawing.Size(80, 21);
            this.TextBoxQueryNumber.TabIndex = 3;
            this.TextBoxQueryNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxQueryNumber_KeyPress);
            // 
            // ButtomQueryEdit
            // 
            this.ButtomQueryEdit.Location = new System.Drawing.Point(16, 144);
            this.ButtomQueryEdit.Name = "ButtomQueryEdit";
            this.ButtomQueryEdit.Size = new System.Drawing.Size(200, 40);
            this.ButtomQueryEdit.TabIndex = 4;
            this.ButtomQueryEdit.Text = "Редактировать";
            this.ButtomQueryEdit.UseVisualStyleBackColor = true;
            this.ButtomQueryEdit.Click += new System.EventHandler(this.ButtomQueryEdit_Click);
            // 
            // ButtomQueryListNow
            // 
            this.ButtomQueryListNow.Location = new System.Drawing.Point(16, 192);
            this.ButtomQueryListNow.Name = "ButtomQueryListNow";
            this.ButtomQueryListNow.Size = new System.Drawing.Size(200, 40);
            this.ButtomQueryListNow.TabIndex = 5;
            this.ButtomQueryListNow.Text = "Показать текущий";
            this.ButtomQueryListNow.UseVisualStyleBackColor = true;
            this.ButtomQueryListNow.Click += new System.EventHandler(this.ButtomQueryListNow_Click);
            // 
            // ButtomQueryList
            // 
            this.ButtomQueryList.Location = new System.Drawing.Point(16, 72);
            this.ButtomQueryList.Name = "ButtomQueryList";
            this.ButtomQueryList.Size = new System.Drawing.Size(200, 40);
            this.ButtomQueryList.TabIndex = 2;
            this.ButtomQueryList.Text = "Полный список";
            this.ButtomQueryList.UseVisualStyleBackColor = true;
            this.ButtomQueryList.Click += new System.EventHandler(this.ButtomQueryList_Click);
            // 
            // ButtomQueryAdd
            // 
            this.ButtomQueryAdd.Location = new System.Drawing.Point(16, 24);
            this.ButtomQueryAdd.Name = "ButtomQueryAdd";
            this.ButtomQueryAdd.Size = new System.Drawing.Size(200, 40);
            this.ButtomQueryAdd.TabIndex = 0;
            this.ButtomQueryAdd.Text = "Добавить";
            this.ButtomQueryAdd.UseVisualStyleBackColor = true;
            this.ButtomQueryAdd.Click += new System.EventHandler(this.ButtomQueryAdd_Click);
            // 
            // LabelEditQuery
            // 
            this.LabelEditQuery.AutoSize = true;
            this.LabelEditQuery.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LabelEditQuery.Location = new System.Drawing.Point(264, 16);
            this.LabelEditQuery.Name = "LabelEditQuery";
            this.LabelEditQuery.Size = new System.Drawing.Size(163, 18);
            this.LabelEditQuery.TabIndex = 11;
            this.LabelEditQuery.Text = "Поле для запросов:";
            // 
            // ButtomQueryClear
            // 
            this.ButtomQueryClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ButtomQueryClear.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButtomQueryClear.Location = new System.Drawing.Point(264, 208);
            this.ButtomQueryClear.Name = "ButtomQueryClear";
            this.ButtomQueryClear.Size = new System.Drawing.Size(144, 40);
            this.ButtomQueryClear.TabIndex = 7;
            this.ButtomQueryClear.Text = "Очистить";
            this.ButtomQueryClear.UseVisualStyleBackColor = true;
            this.ButtomQueryClear.Click += new System.EventHandler(this.ButtomQueryClear_Click);
            // 
            // ComboBoxTemplate
            // 
            this.ComboBoxTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ComboBoxTemplate.BackColor = System.Drawing.SystemColors.Control;
            this.ComboBoxTemplate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ComboBoxTemplate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxTemplate.Items.AddRange(new object[] {
            "Стандарт",
            "Добавить",
            "Изменить",
            "Удалить"});
            this.ComboBoxTemplate.Location = new System.Drawing.Point(416, 224);
            this.ComboBoxTemplate.Name = "ComboBoxTemplate";
            this.ComboBoxTemplate.Size = new System.Drawing.Size(144, 21);
            this.ComboBoxTemplate.TabIndex = 8;
            this.ComboBoxTemplate.SelectedIndexChanged += new System.EventHandler(this.ComboBoxTemplate_SelectedIndexChanged);
            // 
            // LabelTemplate
            // 
            this.LabelTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LabelTemplate.AutoSize = true;
            this.LabelTemplate.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LabelTemplate.Location = new System.Drawing.Point(416, 208);
            this.LabelTemplate.Name = "LabelTemplate";
            this.LabelTemplate.Size = new System.Drawing.Size(117, 13);
            this.LabelTemplate.TabIndex = 13;
            this.LabelTemplate.Text = "Выберите шаблон:";
            // 
            // FormEditQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 265);
            this.Controls.Add(this.LabelTemplate);
            this.Controls.Add(this.ComboBoxTemplate);
            this.Controls.Add(this.ButtomQueryClear);
            this.Controls.Add(this.LabelEditQuery);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.RichTextBoxQuery);
            this.MinimumSize = new System.Drawing.Size(600, 300);
            this.Name = "FormEditQuery";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Редактор запросов";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox RichTextBoxQuery;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label LabelQueryNumber;
        private System.Windows.Forms.TextBox TextBoxQueryNumber;
        private System.Windows.Forms.Button ButtomQueryEdit;
        private System.Windows.Forms.Button ButtomQueryList;
        private System.Windows.Forms.Button ButtomQueryAdd;
        private System.Windows.Forms.Label LabelEditQuery;
        private System.Windows.Forms.Button ButtomQueryClear;
        private System.Windows.Forms.Button ButtomQueryListNow;
        private System.Windows.Forms.ComboBox ComboBoxTemplate;
        private System.Windows.Forms.Label LabelTemplate;
    }
}