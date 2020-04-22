namespace DataBaseReader
{
    partial class FormAddDel
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
            this.DataGridViewEdit = new System.Windows.Forms.DataGridView();
            this.ButtonPerform = new System.Windows.Forms.Button();
            this.ButtonCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewEdit)).BeginInit();
            this.SuspendLayout();
            // 
            // DataGridViewEdit
            // 
            this.DataGridViewEdit.AllowUserToAddRows = false;
            this.DataGridViewEdit.AllowUserToDeleteRows = false;
            this.DataGridViewEdit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DataGridViewEdit.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DataGridViewEdit.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.DataGridViewEdit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridViewEdit.Location = new System.Drawing.Point(20, 20);
            this.DataGridViewEdit.MinimumSize = new System.Drawing.Size(400, 44);
            this.DataGridViewEdit.Name = "DataGridViewEdit";
            this.DataGridViewEdit.ReadOnly = true;
            this.DataGridViewEdit.RowHeadersVisible = false;
            this.DataGridViewEdit.Size = new System.Drawing.Size(400, 44);
            this.DataGridViewEdit.TabIndex = 0;
            // 
            // ButtonPerform
            // 
            this.ButtonPerform.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ButtonPerform.Location = new System.Drawing.Point(60, 80);
            this.ButtonPerform.Name = "ButtonPerform";
            this.ButtonPerform.Size = new System.Drawing.Size(120, 40);
            this.ButtonPerform.TabIndex = 1;
            this.ButtonPerform.Text = "Выполнить";
            this.ButtonPerform.UseVisualStyleBackColor = true;
            this.ButtonPerform.Click += new System.EventHandler(this.ButtonPerform_Click);
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ButtonCancel.Location = new System.Drawing.Point(260, 80);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(120, 40);
            this.ButtonCancel.TabIndex = 2;
            this.ButtonCancel.Text = "Отмена";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            this.ButtonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // FormAddDel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 135);
            this.Controls.Add(this.ButtonCancel);
            this.Controls.Add(this.ButtonPerform);
            this.Controls.Add(this.DataGridViewEdit);
            this.MaximumSize = new System.Drawing.Size(20000, 170);
            this.MinimumSize = new System.Drawing.Size(456, 170);
            this.Name = "FormAddDel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormAddDel";
            this.Load += new System.EventHandler(this.FormAddDel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewEdit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DataGridViewEdit;
        private System.Windows.Forms.Button ButtonPerform;
        private System.Windows.Forms.Button ButtonCancel;
    }
}