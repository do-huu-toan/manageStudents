namespace ManageStudent
{
    partial class fAddTeacher
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_Update = new System.Windows.Forms.Button();
            this.btn_Load = new System.Windows.Forms.Button();
            this.cb_boMon = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dtgrv_ShowTeacher = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgrv_ShowTeacher)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_Update);
            this.panel1.Controls.Add(this.btn_Load);
            this.panel1.Controls.Add(this.cb_boMon);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(525, 109);
            this.panel1.TabIndex = 3;
            // 
            // btn_Update
            // 
            this.btn_Update.Location = new System.Drawing.Point(233, 69);
            this.btn_Update.Name = "btn_Update";
            this.btn_Update.Size = new System.Drawing.Size(64, 37);
            this.btn_Update.TabIndex = 5;
            this.btn_Update.Text = "Update";
            this.btn_Update.UseVisualStyleBackColor = true;
            this.btn_Update.Click += new System.EventHandler(this.Btn_Update_Click);
            // 
            // btn_Load
            // 
            this.btn_Load.Location = new System.Drawing.Point(314, 69);
            this.btn_Load.Name = "btn_Load";
            this.btn_Load.Size = new System.Drawing.Size(64, 37);
            this.btn_Load.TabIndex = 4;
            this.btn_Load.Text = "Load";
            this.btn_Load.UseVisualStyleBackColor = true;
            this.btn_Load.Click += new System.EventHandler(this.Btn_Load_Click);
            // 
            // cb_boMon
            // 
            this.cb_boMon.FormattingEnabled = true;
            this.cb_boMon.Location = new System.Drawing.Point(257, 18);
            this.cb_boMon.Name = "cb_boMon";
            this.cb_boMon.Size = new System.Drawing.Size(121, 21);
            this.cb_boMon.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(133, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Danh sách môn học: ";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dtgrv_ShowTeacher);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(13, 128);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(524, 458);
            this.panel2.TabIndex = 4;
            // 
            // dtgrv_ShowTeacher
            // 
            this.dtgrv_ShowTeacher.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            this.dtgrv_ShowTeacher.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgrv_ShowTeacher.Location = new System.Drawing.Point(3, 34);
            this.dtgrv_ShowTeacher.Name = "dtgrv_ShowTeacher";
            this.dtgrv_ShowTeacher.Size = new System.Drawing.Size(518, 421);
            this.dtgrv_ShowTeacher.TabIndex = 1;
            this.dtgrv_ShowTeacher.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.Dtgrv_ShowTeacher_RowsRemoved);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Danh sách giáo viên:";
            // 
            // fAddTeacher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 598);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "fAddTeacher";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Giáo viên";
            this.Load += new System.EventHandler(this.FAddTeacher_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgrv_ShowTeacher)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cb_boMon;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_Load;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dtgrv_ShowTeacher;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_Update;
    }
}