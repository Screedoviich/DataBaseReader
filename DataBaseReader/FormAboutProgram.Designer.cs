namespace DataBaseReader
{
    partial class FormAboutProgram
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAboutProgram));
            this.GroupBoxProgramInfo = new System.Windows.Forms.GroupBox();
            this.LabelProgramCreator2 = new System.Windows.Forms.Label();
            this.LabelProgramVersion2 = new System.Windows.Forms.Label();
            this.LabelProgramName2 = new System.Windows.Forms.Label();
            this.LabelProgramCreator1 = new System.Windows.Forms.Label();
            this.LabelProgramVersion1 = new System.Windows.Forms.Label();
            this.LabelProgramName1 = new System.Windows.Forms.Label();
            this.PictureBoxIcon = new System.Windows.Forms.PictureBox();
            this.GroupBoxProgramInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // GroupBoxProgramInfo
            // 
            this.GroupBoxProgramInfo.Controls.Add(this.LabelProgramCreator2);
            this.GroupBoxProgramInfo.Controls.Add(this.LabelProgramVersion2);
            this.GroupBoxProgramInfo.Controls.Add(this.LabelProgramName2);
            this.GroupBoxProgramInfo.Controls.Add(this.LabelProgramCreator1);
            this.GroupBoxProgramInfo.Controls.Add(this.LabelProgramVersion1);
            this.GroupBoxProgramInfo.Controls.Add(this.LabelProgramName1);
            this.GroupBoxProgramInfo.Location = new System.Drawing.Point(120, 8);
            this.GroupBoxProgramInfo.Name = "GroupBoxProgramInfo";
            this.GroupBoxProgramInfo.Size = new System.Drawing.Size(256, 96);
            this.GroupBoxProgramInfo.TabIndex = 1;
            this.GroupBoxProgramInfo.TabStop = false;
            this.GroupBoxProgramInfo.Text = "Информация";
            // 
            // LabelProgramCreator2
            // 
            this.LabelProgramCreator2.AutoSize = true;
            this.LabelProgramCreator2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LabelProgramCreator2.Location = new System.Drawing.Point(136, 72);
            this.LabelProgramCreator2.Name = "LabelProgramCreator2";
            this.LabelProgramCreator2.Size = new System.Drawing.Size(85, 14);
            this.LabelProgramCreator2.TabIndex = 1;
            this.LabelProgramCreator2.Text = "Screedoviich";
            this.LabelProgramCreator2.Click += new System.EventHandler(this.LabelProgramCreator2_Click);
            // 
            // LabelProgramVersion2
            // 
            this.LabelProgramVersion2.AutoSize = true;
            this.LabelProgramVersion2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LabelProgramVersion2.Location = new System.Drawing.Point(136, 48);
            this.LabelProgramVersion2.Name = "LabelProgramVersion2";
            this.LabelProgramVersion2.Size = new System.Drawing.Size(27, 14);
            this.LabelProgramVersion2.TabIndex = 1;
            this.LabelProgramVersion2.Text = "1.0";
            this.LabelProgramVersion2.Click += new System.EventHandler(this.LabelProgramVersion2_Click);
            // 
            // LabelProgramName2
            // 
            this.LabelProgramName2.AutoSize = true;
            this.LabelProgramName2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LabelProgramName2.Location = new System.Drawing.Point(136, 24);
            this.LabelProgramName2.Name = "LabelProgramName2";
            this.LabelProgramName2.Size = new System.Drawing.Size(113, 14);
            this.LabelProgramName2.TabIndex = 1;
            this.LabelProgramName2.Text = "DataBaseReader";
            // 
            // LabelProgramCreator1
            // 
            this.LabelProgramCreator1.AutoSize = true;
            this.LabelProgramCreator1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LabelProgramCreator1.Location = new System.Drawing.Point(8, 72);
            this.LabelProgramCreator1.Name = "LabelProgramCreator1";
            this.LabelProgramCreator1.Size = new System.Drawing.Size(51, 14);
            this.LabelProgramCreator1.TabIndex = 0;
            this.LabelProgramCreator1.Text = "Автор:";
            // 
            // LabelProgramVersion1
            // 
            this.LabelProgramVersion1.AutoSize = true;
            this.LabelProgramVersion1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LabelProgramVersion1.Location = new System.Drawing.Point(8, 48);
            this.LabelProgramVersion1.Name = "LabelProgramVersion1";
            this.LabelProgramVersion1.Size = new System.Drawing.Size(61, 14);
            this.LabelProgramVersion1.TabIndex = 0;
            this.LabelProgramVersion1.Text = "Версия:";
            // 
            // LabelProgramName1
            // 
            this.LabelProgramName1.AutoSize = true;
            this.LabelProgramName1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LabelProgramName1.Location = new System.Drawing.Point(8, 24);
            this.LabelProgramName1.Name = "LabelProgramName1";
            this.LabelProgramName1.Size = new System.Drawing.Size(77, 14);
            this.LabelProgramName1.TabIndex = 0;
            this.LabelProgramName1.Text = "Название:";
            // 
            // PictureBoxIcon
            // 
            this.PictureBoxIcon.Image = global::DataBaseReader.Properties.Resources.DataBaseReaderIcon;
            this.PictureBoxIcon.Location = new System.Drawing.Point(8, 8);
            this.PictureBoxIcon.Name = "PictureBoxIcon";
            this.PictureBoxIcon.Size = new System.Drawing.Size(96, 96);
            this.PictureBoxIcon.TabIndex = 0;
            this.PictureBoxIcon.TabStop = false;
            // 
            // FormAboutProgram
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 110);
            this.Controls.Add(this.GroupBoxProgramInfo);
            this.Controls.Add(this.PictureBoxIcon);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(400, 145);
            this.MinimumSize = new System.Drawing.Size(400, 145);
            this.Name = "FormAboutProgram";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "О программе";
            this.GroupBoxProgramInfo.ResumeLayout(false);
            this.GroupBoxProgramInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox PictureBoxIcon;
        private System.Windows.Forms.GroupBox GroupBoxProgramInfo;
        private System.Windows.Forms.Label LabelProgramCreator2;
        private System.Windows.Forms.Label LabelProgramVersion2;
        private System.Windows.Forms.Label LabelProgramName2;
        private System.Windows.Forms.Label LabelProgramCreator1;
        private System.Windows.Forms.Label LabelProgramVersion1;
        private System.Windows.Forms.Label LabelProgramName1;
    }
}